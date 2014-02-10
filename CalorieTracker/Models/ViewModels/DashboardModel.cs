namespace CalorieTracker.Models.ViewModels
{
    public class DashboardModel
    {
        private bool _isNewUser;
        private User _user;

        public DashboardModel(bool isNewUser, User dashboardUser)
        {
            _isNewUser = isNewUser;
            _user = dashboardUser;
        }

        public User DashboardUser
        {
            get { return _user; }
            set { _user = value; }
        }

        public bool IsNewUser
        {
            get { return _isNewUser; }
            set { _isNewUser = value; }
        }
    }
}