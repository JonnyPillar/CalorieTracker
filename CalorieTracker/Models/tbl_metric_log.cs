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
    
    public partial class tbl_metric_log
    {
        public string metric_log_id { get; set; }
        public Nullable<int> metric_log_user_id { get; set; }
        public string metric_log_metric_id { get; set; }
        public decimal metric_log_value { get; set; }
        public System.DateTime metric_log_creation_timestamp { get; set; }
    
        public virtual tbl_user_metric tbl_user_metric { get; set; }
        public virtual tbl_user tbl_user { get; set; }
    }
}