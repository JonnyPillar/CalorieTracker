namespace CalorieTracker.Models.ViewModels
{
    public class DashboardModel
    {
        public DashboardModel(bool isNewUser, User dashboardUser)
        {
            IsNewUser = isNewUser;
            DashboardUser = dashboardUser;
        }

        public User DashboardUser { get; set; }

        public bool IsNewUser { get; set; }

        public decimal NutritionTimespan { get; set; }
    }
}