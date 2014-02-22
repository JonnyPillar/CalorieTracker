namespace CalorieTracker.Utils.RDA.Breakdown
{
    public class RDABreakdownItem
    {
        public RDABreakdownItem(int itemID, decimal itemValue)
        {
            ItemID = itemID;
            ItemValue = itemValue;
        }

        public int ItemID { get; set; }

        public decimal ItemValue { get; set; }
    }
}