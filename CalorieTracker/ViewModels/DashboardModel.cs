using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalorieTracker.Models;

namespace CalorieTracker.ViewModels
{
    public class DashboardModel
    {
        public tbl_user CurrentUser { get; set; }

        public DashboardModel(tbl_user User)
        {
            CurrentUser = User;
            FoodLogList = User.tbl_food_log.ToList();
        }

        public List<tbl_food_log> FoodLogList { get; set; }

    }
}