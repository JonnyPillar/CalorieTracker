using System;
using System.Text;
using CalorieTracker.Models;

namespace CalorieTracker.Utils.History
{
    public class HistoryActivityLog : IHistoryItem
    {
        private readonly ActivityLog _activityLog;

        public HistoryActivityLog(ActivityLog activityLog)
        {
            _activityLog = activityLog;
        }

        public string GetItemType()
        {
            return "History";
        }

        public DateTime GetCreationDate()
        {
            return _activityLog.StartDate;
        }

        public string GetItemInfomation()
        {
            var itemInfoString = new StringBuilder();
            itemInfoString.AppendFormat("Completed {0} of {1}", _activityLog.Distance, _activityLog.Activity.Name);
            return itemInfoString.ToString();
        }

        public string GetItemImage()
        {
            return _activityLog.Activity.ImageUrl;
        }
    }
}