using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using CalorieTracker.Models;
using CalorieTracker.Utils.RDA;

namespace CalorieTracker.Utils.Weka.ARFF.Instances
{
    public class WekaUserNutrition : IWekaInstance
    {
        private readonly List<User> _userList;
        private List<Nutrient> _nutrientList;
        public List<string> stringList;
        private Dictionary<int, decimal> _dictionary;
        private int historyDays = 40;

        private readonly string _saveLocation = @"C:\Code\Calorie Tracker\CalorieTracker\CalorieTracker\App_Data\";
        //private readonly string _saveLocation = @"D:\inetpub\wwwroot\Temp\";

        public WekaUserNutrition(List<User> user)
        {
            _userList = user;
            stringList = new List<string>();
        }

        public int CalculateAgeBracket(User user)
        {
            int age = DateTime.Now.Year - user.DOB.Year;
            return (int)decimal.Ceiling(age / 30);
        }


        public string GetAttributes()
        {
            var attributeStringBuilder = new StringBuilder("@RELATION user\r\n\r\n");
            attributeStringBuilder.AppendLine("@ATTRIBUTE AgeBracket {1,2,3,4}");
            var db = new CalorieTrackerEntities();
            _nutrientList = db.Nutrients.Take(10).ToList();
            foreach (Nutrient nutrient in _nutrientList)
            {
                attributeStringBuilder.AppendFormat("@ATTRIBUTE {0}", nutrient.Name.Replace(",", "").Replace(" ", ""));
                attributeStringBuilder.Append(" {0,1,2,3}\r\n");
            }
            attributeStringBuilder.AppendLine("@ATTRIBUTE healthValue {1,2,3,4}");
            return attributeStringBuilder.ToString();
        }

        public string GetInstanceData()
        {
            try
            {
                using (var writer = new StreamWriter(_saveLocation + "Temp_" + ".arff"))
                {
                    writer.Write(GetAttributes());
                    writer.Write("\r\n@DATA\r\n");
                    writer.Close();
                }

                for (int i = 0; i < _userList.Count; i++)
                {
                        using (var writer = new StreamWriter(_saveLocation + "Temp_" + ".arff", true))
                        {
                            _dictionary = new Dictionary<int, decimal>();

                            DateTime startDateTime = DateTime.Now.AddDays(-historyDays);
                            List<FoodLog> userFoodLogs =
                                _userList[i].UserFoodLogs.Where(
                                    fL => fL.CreationTimestamp.CompareTo(startDateTime) > 0).ToList();

                            decimal nutrientValueCount = 0;
                            for (int j = 0; j < userFoodLogs.Count(); j++)
                            {
                                FoodLog foodLog = userFoodLogs.ElementAt(j);
                                for (int k = 0; k < foodLog.Food.FoodNutritionLogs.Count; k++)
                                { 
                                    FoodNutritionLogs nutritionLogs =
                                        foodLog.Food.FoodNutritionLogs.ElementAt(k);

                                    if (_dictionary.ContainsKey(nutritionLogs.NurtientID))
                                    {
                                        _dictionary[nutritionLogs.NurtientID] += nutritionLogs.Value*
                                                                                 foodLog.Quantity;
                                    }
                                    else
                                        _dictionary.Add(nutritionLogs.NurtientID, nutritionLogs.Value*
                                                                                  foodLog.Quantity);
                                }
                            }

                            StringBuilder userStringBuilder = new StringBuilder();
                            userStringBuilder.AppendFormat("{0}", CalculateAgeBracket(_userList[i]));
                            double averageRating = 0;
                            foreach (Nutrient nutrient in _nutrientList)
                            {
                                int resultingValue = 0;
                                if (_dictionary.ContainsKey(nutrient.NutrientID))
                                {
                                    NutrientRDA _userNutrientRDA = NutrientRDAUtil.GetNutrientRDAForUser(_userList[i], nutrient);
                                    if (_userNutrientRDA != null)
                                    {
                                        decimal recommendedValueForTimePeriod = _userNutrientRDA.Value*historyDays;

                                        double range = (double) recommendedValueForTimePeriod*0.2;

                                        double upperRange = (double) recommendedValueForTimePeriod + (range/2);
                                        double lowerRange = (double) recommendedValueForTimePeriod - (range/2);

                                        

                                        double value = (double) _dictionary[nutrient.NutrientID];
                                        if (value > upperRange) resultingValue = 3;
                                        else if (value < lowerRange) resultingValue = 1;
                                        else resultingValue = 2;
                                    }
                                }
                                userStringBuilder.AppendFormat(",{0}", resultingValue);
                                averageRating += resultingValue;
                            }
                            userStringBuilder.AppendFormat(",{0}", Math.Floor(averageRating / _nutrientList.Count));
                            userStringBuilder.Append("\r\n");
                            writer.Write(userStringBuilder.ToString());
                            writer.Close();
                        }
                    }

            }
            catch (Exception e)
            {
                string temp = "";
                Debug.WriteLine("Panic");
            }
            return "";



            //var dataStringBuilder = new StringBuilder("\r\n@DATA\r\n");
            //for (int i = 0; i < _userList.Count; i++)
            //{
            //    StringBuilder userStringBuilder = new StringBuilder();

            //    userStringBuilder.AppendFormat("{0}", CalculateAgeBracket(_userList[i]));
            //    foreach (Nutrient nutrient in _nutrientList)
            //    {
            //        var rdaUtil = new RDAUtil(_userList[i], nutrient, new TimeSpan(30, 0, 0, 0));
            //            //Calc Nut Value for last 30 days
            //        userStringBuilder.AppendFormat(",{0}", rdaUtil.UserNutrientRDAValue);
            //    }
            //    userStringBuilder.Append("\r\n");
            //    stringList.Add(userStringBuilder.ToString());
            //}
            //return dataStringBuilder.ToString();
        }
    }
}