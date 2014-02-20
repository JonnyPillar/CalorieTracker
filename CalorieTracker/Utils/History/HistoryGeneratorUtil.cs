using System;
using System.Collections.Generic;
using System.Linq;
using CalorieTracker.Models;

namespace CalorieTracker.Utils.History
{
    public class HistoryGeneratorUtil
    {
        private readonly User _user;
        private Dictionary<DateTime, List<IHistoryItem>> _userHistoryDictionary;
        private IOrderedEnumerable<KeyValuePair<DateTime, List<IHistoryItem>>> test; 

        public HistoryGeneratorUtil(User user)
        {
            _user = user;
            _userHistoryDictionary = new Dictionary<DateTime, List<IHistoryItem>>();
            GenerateHistory();
        }

        private void GenerateHistory()
        {
            List<FoodLog> userFoodLogs = _user.UserFoodLogs.ToList();
            List<ActivityLog> userActivityLogs = _user.UserActivityLogs.ToList();
            List<MetricLog> userMetricLogs = _user.UserMetricLogs.ToList();

            for (int i = 0; i < userFoodLogs.Count; i++)
            {
                if (_userHistoryDictionary.ContainsKey(userFoodLogs[i].CreationTimestamp.Date))
                {
                    _userHistoryDictionary[userFoodLogs[i].CreationTimestamp.Date].Add(
                        new HistoryFoodLog(userFoodLogs[i]));
                }
                else
                {
                    _userHistoryDictionary.Add(userFoodLogs[i].CreationTimestamp.Date,
                        new List<IHistoryItem> {new HistoryFoodLog(userFoodLogs[i])});
                }
            }
            for (int i = 0; i < userActivityLogs.Count; i++)
            {
                if (_userHistoryDictionary.ContainsKey(userActivityLogs[i].StartDate.Date))
                {
                    _userHistoryDictionary[userActivityLogs[i].StartDate.Date].Add(
                        new HistoryActivityLog(userActivityLogs[i]));
                }
                else
                {
                    _userHistoryDictionary.Add(userActivityLogs[i].StartDate.Date,
                        new List<IHistoryItem> {new HistoryActivityLog(userActivityLogs[i])});
                }
            }
            for (int i = 0; i < userMetricLogs.Count; i++)
            {
                if (_userHistoryDictionary.ContainsKey(userMetricLogs[i].CreationTimestamp.Date))
                {
                    _userHistoryDictionary[userMetricLogs[i].CreationTimestamp.Date].Add(
                        new HistoryMetricLog(userMetricLogs[i]));
                }
                else
                {
                    _userHistoryDictionary.Add(userMetricLogs[i].CreationTimestamp.Date,
                        new List<IHistoryItem> {new HistoryMetricLog(userMetricLogs[i])});
                }
            }

            var newDict = from pair in _userHistoryDictionary
                        orderby pair.Key ascending
                        select pair;

            test = _userHistoryDictionary.OrderByDescending(d => d.Key);
        }

        public IOrderedEnumerable<KeyValuePair<DateTime, List<IHistoryItem>>> Test
        {
            get { return test; }
            set { test = value; }
        }

        public Dictionary<DateTime, List<IHistoryItem>> UserHistoryDictionary
        {
            get { return _userHistoryDictionary; }
        }
    }
}