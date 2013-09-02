using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalorieTracker.Models;

namespace CalorieTracker.ViewModels
{
    public class LogUserInformationModel
    {
        public string UserID { get; set; }
        public IEnumerable<tbl_user_metric> MetricList { get; set; }
        public string SelectedMetric {get; set;}
        public string Value { get; set; }

        public LogUserInformationModel()
        {

        }

        public LogUserInformationModel(List<tbl_user_metric> metricList)
        {
            MetricList = metricList;
        }
    }
}