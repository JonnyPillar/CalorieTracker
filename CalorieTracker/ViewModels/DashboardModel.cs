using System.Collections.Generic;
using System.Linq;
using CalorieTracker.Models;

namespace CalorieTracker.ViewModels
{
    public class DashboardModel
    {
        public DashboardUserInformationModel UserInfomation { get; set; }
        public List<tbl_food_log> FoodLogList { get; set; }
        public PagedFoodList pagedList { get; set; }

        //public List<tbl_activity_log> ActivityLogList { get; set; }

        /// <summary>
        /// Dashboard Model Constructor
        /// </summary>
        /// <param name="User">Current User</param>
        /// <param name="userInformationList">List of Relivant User Info</param>
        public DashboardModel(tbl_user User, List<tbl_user_information> userInformationList, PagedFoodList pagedlist)
        {
            UserInfomation = new DashboardUserInformationModel(User, userInformationList);
            FoodLogList = User.tbl_food_log.ToList();
            pagedList = pagedlist;
            //ActivityLogList = User.tbl_activity_log.ToList();
        }
    }
}