using System;

namespace CalorieTracker.Utils.History
{
    public interface IHistoryItem
    {
        string GetItemType();
        DateTime GetCreationDate();
        string GetItemInfomation();
        string GetItemImage();
    }
}