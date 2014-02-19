using System.Collections.Generic;

namespace CalorieTracker.Models.ViewModels
{
    public class DashboardModel
    {
        public DashboardModel(bool isNewUser, User dashboardUser, List<UserNutrientRDAModel> userNutrientRDAList)
        {
            IsNewUser = isNewUser;
            DashboardUser = dashboardUser;
            UserNutrientRDAList = userNutrientRDAList;
        }

        public User DashboardUser { get; set; }

        public List<UserNutrientRDAModel> UserNutrientRDAList { get; set; }

        public bool IsNewUser { get; set; }
    }
}