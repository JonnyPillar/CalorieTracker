
namespace CalorieTracker.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_activity_log
    {
        public tbl_activity_log()
        {

        }

        /// <summary>
        /// New Food Log From Log Food View Model
        /// </summary>
        /// <param name="newLog">Food Log View Model</param>
        public tbl_activity_log(ViewModels.LogActivityModel newLog)
        {
            this.activity_log_id = Guid.NewGuid().ToString();
            this.activity_log_activity_id = newLog.SelectedActivity;
            this.activity_log_user_id = newLog.UserID;
            this.activity_log_duration = TimeSpan.ParseExact(newLog.Duration.ToString(), "HH:MM:SS", null);
            this.activity_log_distance = Convert.ToDouble(newLog.Distance);
            this.activity_log_notes = newLog.Notes;
            this.activity_log_file_url = newLog.File;
            this.actvitity_log_timestamp = DateTime.Now;
        }

        /// <summary>
        /// Log ID
        /// </summary>
        public string activity_log_id { get; set; }
        /// <summary>
        /// Activity ID
        /// </summary>
        public string activity_log_activity_id { get; set; }
        /// <summary>
        /// User ID
        /// </summary>
        public string activity_log_user_id { get; set; }
        /// <summary>
        /// Activity Time Seconds
        /// </summary>
        public System.TimeSpan activity_log_duration { get; set; }
        /// <summary>
        /// Activity Distance Meters
        /// </summary>
        public double activity_log_distance { get; set; }
        /// <summary>
        /// Activity Hear Rate BPM
        /// </summary>
        public Nullable<int> activity_log_heart_rate { get; set; }
        /// <summary>
        /// Activity Total Climb
        /// </summary>
        public Nullable<double> activity_log_accent { get; set; }
        /// <summary>
        /// Activity Notes
        /// </summary>
        public string activity_log_notes { get; set; }
        /// <summary>
        /// Activity GPX/TCX file URL
        /// </summary>
        public string activity_log_file_url { get; set; }
        /// <summary>
        /// Activity Date ddMMyyyyHHmmss
        /// </summary>
        public System.DateTime actvitity_log_timestamp { get; set; }
    
        public virtual tbl_activity tbl_activity { get; set; }
        public virtual tbl_user tbl_user { get; set; }
    }
}
