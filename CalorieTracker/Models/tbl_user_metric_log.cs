
namespace CalorieTracker.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_user_metric_log
    {
        public tbl_user_metric_log()
        {

        }

        /// <summary>
        /// New User Information Log From User Information View Model
        /// </summary>
        /// <param name="newLog">Food Log View Model</param>
        public tbl_user_metric_log(ViewModels.LogUserInformationModel newLog)
        {
            this.user_metric_log_id = Guid.NewGuid().ToString();
            this.user_metric_log_user_id = newLog.UserID;
            this.user_metric_log_metric_id = newLog.SelectedMetric;
            this.user_metric_log_value = newLog.Value;
            this.user_metric_log_timestamp = DateTime.Now;
        }

        /// <summary>
        /// User Information ID
        /// </summary>
        public string user_metric_log_id { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        public string user_metric_log_user_id { get; set; }

        /// <summary>
        /// Metric ID
        /// </summary>
        public string user_metric_log_metric_id { get; set; }

        /// <summary>
        /// Metric Value
        /// </summary>
        public string user_metric_log_value { get; set; }

        /// <summary>
        /// Metric Timestamp
        /// </summary>
        public System.DateTime user_metric_log_timestamp { get; set; }

        public virtual tbl_user tbl_user { get; set; }
        public virtual tbl_user_metric tbl_user_metric { get; set; }
    }
}
