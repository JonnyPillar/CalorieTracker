using System.Collections.Generic;
using CalorieTracker.Collections;
using CalorieTracker.Models;

namespace CalorieTracker.ViewModels
{
    public class DashboardModel
    {
        public DashboardUserMetricModel UserMetric { get; set; }
        public DashboardHistoryList UserHistory { get; set; }

        /// <summary>
        /// Dashboard Model Constructor
        /// </summary>
        /// <param name="User">Current User</param>
        /// <param name="userInformationList">List of Relivant User Info</param>
        public DashboardModel(tbl_user User, List<tbl_user_metric_log> userInformationList, DashboardHistoryList userHistory)
        {
            UserMetric = new DashboardUserMetricModel(User, userInformationList);
            UserHistory = userHistory;
        }
    }
}