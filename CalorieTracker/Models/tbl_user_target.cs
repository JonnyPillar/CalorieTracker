//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CalorieTracker.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_user_target
    {
        public tbl_user_target()
        {
            this.tbl_user_target1 = new HashSet<tbl_user_target>();
        }
    
        public string user_target_id { get; set; }
        public string user_target_user_id { get; set; }
        public string user_target_metric_id { get; set; }
        public string user_target_name { get; set; }
        public string user_target_parent_id { get; set; }
        public Nullable<System.DateTime> user_target_creation_timestamp { get; set; }
        public Nullable<sbyte> user_target_completed { get; set; }
        public Nullable<System.DateTime> user_target_completed_timestamp { get; set; }
    
        public virtual tbl_user tbl_user { get; set; }
        public virtual tbl_user_metric tbl_user_metric { get; set; }
        public virtual ICollection<tbl_user_target> tbl_user_target1 { get; set; }
        public virtual tbl_user_target tbl_user_target2 { get; set; }
    }
}
