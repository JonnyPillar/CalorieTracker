using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Calorie_Tracker.DAL;

namespace Calorie_Tracker.Models
{
    public class Dashboard
    {
        private calorie_tracker_v1Entities db = new calorie_tracker_v1Entities();

        public Dashboard()
        {

        }

        public Dashboard(string userID)
        {
            this.user = db.tbl_user.Find(userID);
        }

        public tbl_user user { get; set; }
    }
}