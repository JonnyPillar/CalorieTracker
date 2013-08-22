using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalorieTracker.Models;

namespace CalorieTracker.ViewModels
{
    public class LogActivityModel
    {
        public IEnumerable<tbl_activity> ActitivtyList { get; set; }
        public string selectedActivity { get; set; }

        public LogActivityModel(List<tbl_activity> activityList)
        {
            ActitivtyList = activityList;
        }
    }
}