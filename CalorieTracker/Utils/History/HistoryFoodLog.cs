using System;
using System.Text;
using CalorieTracker.Models;

namespace CalorieTracker.Utils.History
{
    public class HistoryFoodLog : IHistoryItem
    {
        private readonly FoodLog _foodLog;

        public HistoryFoodLog(FoodLog foodLog)
        {
            _foodLog = foodLog;
        }

        public string GetItemType()
        {
            return "Food";
        }

        public DateTime GetCreationDate()
        {
            return _foodLog.CreationTimestamp;
        }

        public string GetItemInfomation()
        {
            var itemInfoString = new StringBuilder();
            itemInfoString.AppendFormat("Consumed {0} of {1}", _foodLog.Quantity, _foodLog.Food.Name);
            return itemInfoString.ToString();
        }

        public string GetItemImage()
        {
            return ""; //TODO getImage
        }
    }
}