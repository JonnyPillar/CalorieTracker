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
        public static decimal CalculateUserNutrientPercentage(User user, Nutrient nutrient, TimeSpan currentTimeSpan)
        {
            decimal nutrientValueCount = 0;
            var nutrientRdaList = GetNutrientRDAForUser(user, nutrient);
            if (nutrientRdaList.Count() > 0)
            {
                NutrientRDA nutrientRDA = nutrientRdaList.FirstOrDefault();
                if (nutrientRDA != null)
                {
                    DateTime earliestLogDateTime = DateTime.Now.AddDays(-currentTimeSpan.Days);
                    nutrientValueCount = CalcUserNutrientCount(user, earliestLogDateTime, nutrientRDA,
                        nutrientValueCount);
                }
            }
            return nutrientValueCount;
        }

        /// <summary>
        /// Get Nutrient RDA for A User
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="nutrient">Nutrient</param>
        /// <returns>Nutrient RDA</returns>
        public static List<NutrientRDA> GetNutrientRDAForUser(User user, Nutrient nutrient)
        {
            bool userGender = user.Gender; //False Male, True Female
            int userAge = (DateTime.Now - user.DOB).Days/365;
            List<NutrientRDA> nutrientRdaList =
                nutrient.tbl_nutrient_rda.Where(
                    n => n.Gender == userGender && n.AgeMax >= userAge && n.AgeMin <= userAge).ToList();
            return nutrientRdaList;
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