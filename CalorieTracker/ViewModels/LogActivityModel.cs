using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CalorieTracker.Models;

namespace CalorieTracker.ViewModels
{
    public class LogActivityModel
    {
        [HiddenInput(DisplayValue = false)]
        public string UserID { get; set; }

        [Display(Name = "Activity List")]
        public IEnumerable<tbl_activity> ActitivtyList { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string SelectedActivity { get; set; }

        [Display(Name = "Duration")]
        [Required(ErrorMessage = "Please Provide A Valid Duration")]
        public TimeSpan Duration { get; set; }

        [Display(Name = "Distance")]
        [Required(ErrorMessage = "Please Provide A Valid Distance")]
        [Range(0, 10000, ErrorMessage = "Value must be between 0 and 10000")]
        public double Distance { get; set; }

        public string Notes { get; set; }
        public string File { get; set; } //TODO

        /// <summary>
        /// Log Activity Model Constructor
        /// </summary>
        public LogActivityModel()
        {

        }

        /// <summary>
        /// Log Activity Model Constructor
        /// </summary>
        /// <param name="activityList">List of Activities</param>
        public LogActivityModel(List<tbl_activity> activityList)
        {
            ActitivtyList = activityList;
        }
    }
}