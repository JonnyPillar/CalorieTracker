using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CalorieTracker.Utils.History;

namespace CalorieTracker.Models.ViewModels
{
    public class HistoryModel
    {
        private IEnumerable<IHistoryItem> _historyList;

        public HistoryModel(User user)
        {
            
        }
    }
}