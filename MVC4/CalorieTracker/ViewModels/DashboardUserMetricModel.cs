using System.Collections.Generic;
using CalorieTracker.Models;

namespace CalorieTracker.ViewModels
{
    public class DashboardUserMetricModel
    {
        public tbl_user User { get; set; }
        public List<tbl_user_metric_log> UserInformationList { get; set; }

        /// <summary>
        /// Dashboard User Information Model Constructor
        /// </summary>
        /// <param name="user">Current User</param>
        /// <param name="informationList">User Indformation</param>
        public DashboardUserMetricModel(tbl_user user, List<tbl_user_metric_log> informationList)
        {
            User = user;
            UserInformationList = informationList;
        }
    }
}