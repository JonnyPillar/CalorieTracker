using System.Collections.Generic;

namespace CalorieTracker.Models.ViewModels
{
    public class DashboardModel
    {
        public DashboardModel(bool isNewUser, User dashboardUser)
        {
            IsNewUser = isNewUser;
            DashboardUser = dashboardUser;
            //UserNutrientRDAList = userNutrientRDAList;
        }

        public User DashboardUser { get; set; }

<<<<<<< HEAD
        //public List<NutrientRDA> UserNutrientRDAList { get; set; }
=======
        //public List<UserNutrientRDAModel> UserNutrientRDAList { get; set; }
>>>>>>> b5d70df00a32dfe3b1e1300e323d364f084db9c8

        public bool IsNewUser { get; set; }

        public decimal NutritionTimespan { get; set; }
    }
}