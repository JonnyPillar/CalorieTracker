using System;
using System.Collections.Generic;
using System.Linq;
using CalorieTracker.Models;

namespace CalorieTracker.Utils.RDA
{
    public class NutrientRDAUtil
    {
        public static NutrientRDA GetNutrientRDAForUser(User _user, Nutrient _nutrient)
        {
            bool userGender = _user.Gender; //False Male, True Female
            int userAge = (DateTime.Now - _user.DOB).Days/365;

            List<NutrientRDA> nutrientRdaList =
                _nutrient.tbl_nutrient_rda.Where(
                    n => n.Gender == userGender && n.AgeMax >= userAge && n.AgeMin <= userAge).ToList();
            return nutrientRdaList.FirstOrDefault();
        }
    }
}