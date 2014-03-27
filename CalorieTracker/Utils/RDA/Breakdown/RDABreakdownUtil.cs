using System;
using System.Collections.Generic;
using System.Linq;
using CalorieTracker.Models;

namespace CalorieTracker.Utils.RDA.Breakdown
{
    public class RDABreakdownUtil
    {
        private readonly Nutrient _nutrient;
        private NutrientRDA _nutrientRDA;
        private readonly Dictionary<int, RDABreakdownItem> _rdaBreakdownItems;
        private readonly User _user;
        private TimeSpan _groupingTimeSpan;
        private TimeSpan _lengthOfTimeTimeSpan;
        private decimal _minValue;
        private decimal _maxValue;

        

        private NutrientRDA _userNutrientRDA;


        public RDABreakdownUtil(Nutrient nutrient, User user, TimeSpan lengthOfTimeTimeSpan, TimeSpan groupingTimeSpan)
        {
            _nutrient = nutrient;
            _user = user;
            _lengthOfTimeTimeSpan = lengthOfTimeTimeSpan;
            _groupingTimeSpan = groupingTimeSpan;
            _rdaBreakdownItems = new Dictionary<int, RDABreakdownItem>();
            _minValue = 0;
            _maxValue = 0;
            StartCalculation();
        }

        public Dictionary<int, RDABreakdownItem> RDABreakdownItems
        {
            get { return _rdaBreakdownItems; }
        }

        public NutrientRDA NutrientRDAObject
        {
            get { return _nutrientRDA; }
        }

        public decimal MinValue
        {
            get { return _minValue; }
        }

        public decimal MaxValue
        {
            get { return _maxValue; }
        }

        private void GenerateRDABreakdown()
        {
        }

        private void StartCalculation()
        {
            _userNutrientRDA = GetNutrientRDAForUser();
            if (_userNutrientRDA != null)
            {
                ProcessNutrientValues();
            }
        }

        /// <summary>
        ///     Returns the appropriate RDA object for the user
        /// </summary>
        /// <returns>NutrientRDA object</returns>
        private NutrientRDA GetNutrientRDAForUser()
        {
            bool userGender = _user.Gender; //False Male, True Female
            int userAge = (DateTime.Now - _user.DOB).Days/365;

            List<NutrientRDA> nutrientRdaList =
                _nutrient.tbl_nutrient_rda.Where(
                    n => n.Gender == userGender && n.AgeMax >= userAge && n.AgeMin <= userAge).ToList();
            _nutrientRDA = nutrientRdaList.FirstOrDefault();
            return _nutrientRDA;
        }

        private void ProcessNutrientValues()
        {
            if (_userNutrientRDA != null)
            {
                DateTime earliestLogDateTime = DateTime.Now.AddDays(-_lengthOfTimeTimeSpan.Days);
                int numberOfPeriods = _lengthOfTimeTimeSpan.Days/_groupingTimeSpan.Days;

                DateTime floorDate = earliestLogDateTime;
                DateTime ceilingDate = earliestLogDateTime.AddDays(numberOfPeriods);
                for (int i = 0; i < numberOfPeriods; i++)
                {
                    List<FoodLog> foodList =
                        _user.UserFoodLogs.Where(
                            fl =>
                                fl.CreationTimestamp.CompareTo(floorDate) >= 0 &&
                                fl.CreationTimestamp.CompareTo(ceilingDate) <= 0).ToList();
                    decimal periodNutrientValue = 0;
                    if (foodList.Count > 0)
                    {
                        for (int j = 0; j < foodList.Count; j++)
                        {
                            FoodLog foodLog = foodList.ElementAt(j);
                            FoodNutritionLogs foodNutritionLog = foodLog.Food.FoodNutritionLogs.FirstOrDefault(
                                fNL => fNL.NurtientID == _userNutrientRDA.NutrientID);

                            if (foodNutritionLog != null)
                            {
                                periodNutrientValue += foodNutritionLog.Value;
                            }
                        }
                    }
                    if (_rdaBreakdownItems.ContainsKey(i))
                    {
                        _rdaBreakdownItems[i].ItemValue += periodNutrientValue;
                    }
                    else
                    {
                        _rdaBreakdownItems.Add(i, new RDABreakdownItem(i, periodNutrientValue));
                    }
                    if (i == 0)
                    {
                        _minValue = _rdaBreakdownItems[i].ItemValue;
                        _maxValue = _rdaBreakdownItems[i].ItemValue;
                    }
                    else
                    {
                        if (_rdaBreakdownItems[i].ItemValue > _maxValue) _maxValue = Math.Ceiling(_rdaBreakdownItems[i].ItemValue);
                        if (_rdaBreakdownItems[i].ItemValue < _minValue) _minValue = _rdaBreakdownItems[i].ItemValue;
                    }
                }
            }
        }

        private decimal GetUserNutrientValueCount()
        {
            decimal nutrientValueCount = 0;
            if (_userNutrientRDA != null)
            {
                DateTime earliestLogDateTime = DateTime.Now.AddDays(-_lengthOfTimeTimeSpan.Days);

                List<FoodLog> userFoodLogs =
                    _user.UserFoodLogs.Where(fL => fL.CreationTimestamp.CompareTo(earliestLogDateTime) > 0).ToList();
                //Get all food logs for the user that since before this timespan

                for (int i = 0; i < userFoodLogs.Count(); i++)
                {
                    FoodLog foodLog = userFoodLogs.ElementAt(i);
                    FoodNutritionLogs foodNutritionLog = foodLog.Food.FoodNutritionLogs.FirstOrDefault(
                        fNL => fNL.NurtientID == _userNutrientRDA.NutrientID);
                    if (foodNutritionLog != null) nutrientValueCount += foodNutritionLog.Value;
                }
            }
            return nutrientValueCount;
        }
    }
}