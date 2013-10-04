
namespace CalorieTracker.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_activity
    {
        public tbl_activity()
        {
            this.tbl_activity_log = new HashSet<tbl_activity_log>();
        }

        public string activity_id { get; set; }
        /// <summary>
        /// Activity Name
        /// </summary>
        public string activity_name { get; set; }
        /// <summary>
        /// Burn Rate Per Second
        /// </summary>
        public Nullable<double> activity_calorie_burn_rate { get; set; }
        /// <summary>
        /// Image Url
        /// </summary>
        public string activity_image_url { get; set; }
        /// <summary>
        /// Activity Log
        /// </summary>
        public virtual ICollection<tbl_activity_log> tbl_activity_log { get; set; }
    }
}
