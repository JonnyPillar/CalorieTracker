using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalorieTracker.Models;

namespace CalorieTracker.Utils.History
{
    public class HistoryFoodLog : IHistoryItem
    {
        private FoodLog _foodLog;

        public HistoryFoodLog(FoodLog foodLog)
        {
            _foodLog = foodLog;
        }
    }
}