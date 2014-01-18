using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalorieTracker.Models
{
    public class LogModels
    {
        public class FoodLogModel : tbl_food_log
        {
            public tbl_user CurrentUser { get; set; }
            public IEnumerable<tbl_food> FoodList { get; set; }
            public string Selected { get; set; }

            public FoodLogModel()
            {
                FoodList = new List<tbl_food>();
            }
        }
    }
}