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
    public class WekaUserNutrition : IInstance
    {
        private readonly List<User> _userList;
        private List<Nutrient> _nutrientList;
        public List<string> stringList;

        //private readonly string _saveLocation = @"C:\Code\Calorie Tracker\CalorieTracker\CalorieTracker\App_Data\";
        private readonly string _saveLocation = @"D:\inetpub\wwwroot\Temp\";

        public WekaUserNutrition(List<User> user)
        {
            _userList = user;
            stringList = new List<string>();
        }

        public int CalculateAgeBracket(User user)
        {
            int age = DateTime.Now.Year - user.DOB.Year;
            return (int) decimal.Ceiling(age / 10);
        }


        public string GetAttributes()
        {
            var attributeStringBuilder = new StringBuilder("@RELATION user\r\n\r\n");
            attributeStringBuilder.AppendLine("@ATTRIBUTE AgeBracket {1,2,3,4,5,6,7,8,9,10,11}");
            var db = new CalorieTrackerEntities();
            _nutrientList = db.Nutrients.Take(10).ToList();
            foreach (Nutrient nutrient in _nutrientList)
            {
                attributeStringBuilder.AppendFormat("@ATTRIBUTE {0} numeric\r\n", nutrient.Name.Replace(",", "").Replace(" ", ""));
            }
            return attributeStringBuilder.ToString();
        }

        public string GetInstanceData()
        {
            try
            {
                using (var writer = new StreamWriter(_saveLocation + "Temp_" + ".arff", true))
                {
                    writer.Write(GetAttributes());

                    writer.Write("\r\n@DATA\r\n");
                }

                for (int i = 0; i < _userList.Count; i++)
                    {
                        if (i > 900)
                        {

                            using (var writer = new StreamWriter(_saveLocation + "Temp_" + ".arff", true))
                            {
                                StringBuilder userStringBuilder = new StringBuilder();

                                userStringBuilder.AppendFormat("{0}", CalculateAgeBracket(_userList[i]));
                                foreach (Nutrient nutrient in _nutrientList)
                                {
                                    var rdaUtil = new RDAUtil(_userList[i], nutrient, new TimeSpan(40, 0, 0, 0));
                                    //Calc Nut Value for last 30 days
                                    userStringBuilder.AppendFormat(",{0}", rdaUtil.UserNutrientRDAValue);
                                }
                                userStringBuilder.Append("\r\n");
                                writer.Write(userStringBuilder.ToString());
                                writer.Close();
                                writer.Dispose();
                            }
                        }

                    }
                    
                }
            
            catch (Exception e)
            {
                string temp = "";

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