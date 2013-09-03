using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CalorieTracker.Models;

namespace CalorieTracker.ViewModels
{
    public class LogUserInformationModel
    {
        [HiddenInput(DisplayValue = false)]
        public string UserID { get; set; }

        [Display(Name = "Metric")]
        public IEnumerable<tbl_user_metric> MetricList { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string SelectedMetric {get; set;}

        [Display(Name = "Value")]
        [Required(ErrorMessage = "Please Provide A Valid Value")]
        public string Value { get; set; }

        /// <summary>
        /// Log User Information Constructor
        /// </summary>
        public LogUserInformationModel()
        {

        }

        /// <summary>
        /// Log User Information Constructor
        /// </summary>
        /// <param name="metricList">Metric List</param>
        public LogUserInformationModel(List<tbl_user_metric> metricList)
        {
            MetricList = metricList;
        }
    }
}