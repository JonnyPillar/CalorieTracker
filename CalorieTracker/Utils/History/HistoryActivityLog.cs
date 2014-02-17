using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalorieTracker.Models;

namespace CalorieTracker.Utils.History
{
    public class HistoryActivityLog : IHistoryItem
    {
        private ActivityLog _activityLog;

        public HistoryActivityLog(ActivityLog activityLog)
        {
            _activityLog = activityLog;
        }
    }
}