using System.Collections.Generic;
using System.Linq;
using CalorieTracker.Models;
using System;
namespace CalorieTracker.ViewModels
{
    public class DashboardModel
    {
        public DashboardUserInformationModel UserInfomation { get; set; }
        public Dictionary<DateTime, List<object>> UserHistory { get; set; }

        /// <summary>
        /// Dashboard Model Constructor
        /// </summary>
        /// <param name="User">Current User</param>
        /// <param name="userInformationList">List of Relivant User Info</param>
        public DashboardModel(tbl_user User, List<tbl_user_information> userInformationList, Dictionary<DateTime, List<object>> userHistory)
        {
            UserInfomation = new DashboardUserInformationModel(User, userInformationList);
            UserHistory = userHistory;
        }
    }
}