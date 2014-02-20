using System;
using System.Text;
using CalorieTracker.Models;

namespace CalorieTracker.Utils.History
{
    public class HistoryMetricLog : IHistoryItem
    {
        private readonly MetricLog _metricLog;

        public HistoryMetricLog(MetricLog metricLog)
        {
            _metricLog = metricLog;
        }

        public string GetItemType()
        {
            return "Metric";
        }

        public DateTime GetCreationDate()
        {
            return _metricLog.CreationTimestamp;
        }

        public string GetItemInfomation()
        {
            var itemInfoString = new StringBuilder();
            itemInfoString.AppendFormat("Recorded A Value Of {0} For {1}", _metricLog.Value, _metricLog.Metric.Name);
            return itemInfoString.ToString();
        }

        public string GetItemImage()
        {
            return ""; //TODO
        }
    }
}