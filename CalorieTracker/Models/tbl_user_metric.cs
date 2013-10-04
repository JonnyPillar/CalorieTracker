
namespace CalorieTracker.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_user_metric
    {
        public tbl_user_metric()
        {
            this.tbl_user_metric_log = new HashSet<tbl_user_metric_log>();
            this.tbl_user_target = new HashSet<tbl_user_target>();
        }

        /// <summary>
        /// Enum of Metric Types
        /// </summary>
        public enum user_metric_types
        {
            Kg, Lb, Mtrs, Feet
        }

        /// <summary>
        /// Metric ID
        /// </summary>
        public string user_metric_id { get; set; }

        /// <summary>
        /// Metric Name
        /// </summary>
        public string user_metric_name { get; set; }

        /// <summary>
        /// Metric Type
        /// </summary>
        public string user_metric_type { get; set; }
    
        public virtual ICollection<tbl_user_metric_log> tbl_user_metric_log { get; set; }
        public virtual ICollection<tbl_user_target> tbl_user_target { get; set; }
    }
}
