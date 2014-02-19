using System;
using System.Collections.Generic;
using System.Linq;
using CalorieTracker.Models;

namespace CalorieTracker.Utils.RDA
{
    // ReSharper disable once InconsistentNaming
    public class RDAUtil
    {
        /// <summary>
        /// Calculate A Users RDA Value for a Nutrient Over A Period Of Time
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="nutrient">Nutrient</param>
        /// <param name="currentTimeSpan">Log Timespan</param>
        /// <returns>The amount the user has consumed in the time period</returns>
        public static decimal CalculateUserNutrientValue(User user, Nutrient nutrient, TimeSpan currentTimeSpan)
        {
            return GetUserNutrientValueCount(user, nutrient, currentTimeSpan);
        }

        /// <summary>
        /// Calcaulate A Users RDA Percentage for a Nutrient over a period of time
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="nutrient">Nutrient</param>
        /// <param name="currentTimeSpan">Log Timespan</param>
        /// <returns>Percentage RDA A User Has Consumed</returns>
        public static decimal CalculateUserNutrientPercentage(User user, Nutrient nutrient, TimeSpan currentTimeSpan)
        {
            return GetUserNutrientValueCount(user, nutrient, currentTimeSpan) / GetRDAValueForTimespan(user, nutrient, currentTimeSpan) * 100;
        }

        /// <summary>
        /// Get The Recommended RDA Value For A Nutrient Over A TimeSpan
        /// </summary>
        /// <param name="user"></param>
        /// <param name="nutrient"></param>
        /// <param name="currentTimeSpan"></param>
        /// <returns></returns>
        public static decimal GetRDAValueForTimespan(User user, Nutrient nutrient, TimeSpan currentTimeSpan)
        {
            NutrientRDA nutrientRDA = GetNutrientRDAForUser(user, nutrient);
            return nutrientRDA.Value*currentTimeSpan.Days;
        }


        private static decimal GetUserNutrientValueCount(User user, Nutrient nutrient, TimeSpan currentTimeSpan)
        {
            decimal nutrientValueCount = 0;
            var nutrientRDA = GetNutrientRDAForUser(user, nutrient);
            if (nutrientRDA != null)
            {
                DateTime earliestLogDateTime = DateTime.Now.AddDays(-currentTimeSpan.Days);
                nutrientValueCount = CalcUserNutrientCount(user, earliestLogDateTime, nutrientRDA,
                    nutrientValueCount);
            }
            return nutrientValueCount;
        }

        /// <summary>
        /// Get Nutrient RDA for A User
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="nutrient">Nutrient</param>
        /// <returns>Nutrient RDA</returns>
        public static NutrientRDA GetNutrientRDAForUser(User user, Nutrient nutrient)
        {
            bool userGender = user.Gender; //False Male, True Female
            int userAge = (DateTime.Now - user.DOB).Days / 365;
            List<NutrientRDA> nutrientRdaList =
                nutrient.tbl_nutrient_rda.Where(
                    n => n.Gender == userGender && n.AgeMax >= userAge && n.AgeMin <= userAge).ToList();
            return nutrientRdaList.FirstOrDefault();
        }

        /// <summary>
        /// Calculate A Users Nutrient Count
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="earliestLogDateTime">Earliest Log Time</param>
        /// <param name="nutrientRDA">Nutrient RDA</param>
        /// <param name="nutrientValueCount">Nutrient Value Count</param>
        /// <returns></returns>
        private static decimal CalcUserNutrientCount(User user, DateTime earliestLogDateTime, NutrientRDA nutrientRDA,
            decimal nutrientValueCount)
        {
            List<FoodLog> userFoodLogs =
                user.UserFoodLogs.Where(fL => fL.CreationTimestamp.CompareTo(earliestLogDateTime) > 0).ToList();
            //Get all food logs for the user that since before this timespan

            for (int i = 0; i < userFoodLogs.Count(); i++)
            {
                FoodLog foodLog = userFoodLogs.ElementAt(i);
                FoodNutritionLogs foodNutritionLog =
                    foodLog.Food.FoodNutritionLogs.FirstOrDefault(
                        fNL => fNL.NurtientID == nutrientRDA.NutrientID);
                if (foodNutritionLog != null) nutrientValueCount += foodNutritionLog.Value;
            }
            return nutrientValueCount;
        }
    }
}