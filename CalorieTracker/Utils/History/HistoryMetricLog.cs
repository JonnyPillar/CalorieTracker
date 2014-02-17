using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalorieTracker.Models;

namespace CalorieTracker.Utils.History
{
    public class HistoryMetricLog : IHistoryItem
    {
        private MetricLog _metricLog;

        public HistoryMetricLog(MetricLog metricLog)
        {
            _metricLog = metricLog;
        }
    }
}