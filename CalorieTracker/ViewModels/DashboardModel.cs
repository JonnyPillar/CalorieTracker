using System.Collections.Generic;
using System.Linq;
using CalorieTracker.Models;

namespace CalorieTracker.ViewModels
{
    public class DashboardModel
    {
        public DashboardUserInformationModel UserInfomation { get; set; }
        public List<tbl_food_log> FoodLogList { get; set; }
        public List<tbl_activity_log> ActivityLogList { get; set; }

        public DashboardModel(tbl_user User, List<tbl_user_information> userInformationList)
        {
            UserInfomation = new DashboardUserInformationModel(User, userInformationList);
            FoodLogList = User.tbl_food_log.ToList();
            ActivityLogList = User.tbl_activity_log.ToList();
        }
    }
}