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
        public string SelectedActivity { get; set; }
        public string UserID { get; set; }
        public double Time { get; set; }
        public double Distance { get; set; }
        public string Notes { get; set; }
        public string File { get; set; } //TODO

        public LogActivityModel()
        {

        }

        public LogActivityModel(List<tbl_activity> activityList)
        {
            ActitivtyList = activityList;
        }
    }
}