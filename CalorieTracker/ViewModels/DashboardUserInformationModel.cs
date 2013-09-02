using System.Collections.Generic;
using CalorieTracker.Models;

namespace CalorieTracker.ViewModels
{
    public class DashboardUserInformationModel
    {
        public tbl_user User { get; set; }
        public List<tbl_user_information> UserInformationList { get; set; }

        public DashboardUserInformationModel(tbl_user user, List<tbl_user_information> informationList)
        {
            User = user;
            UserInformationList = informationList;
        }
    }
}