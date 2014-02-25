using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Utils.Chart
{
    public class ChartUtil
    {
        private readonly string _chartLabels;
        private decimal _maxChartValue;
        private decimal _minChartValue;

        public ChartUtil(string chartLabels)
        {
            _chartLabels = chartLabels;
            ChartDataSets = new List<ChartDataSet>();
        }

        public decimal MinChartValue
        {
            get { return _minChartValue; }
            set { _minChartValue = value; }
        }

        public decimal MaxChartValue
        {
            get { return _maxChartValue; }
            set { _maxChartValue = value; }
        }

        public List<ChartDataSet> ChartDataSets { get; set; }

        public void AddDataSet(ChartDataSet chartDataSet)
        {
            ChartDataSets.Add(chartDataSet);
        }

        public void SetChartMinMaxValues(decimal max, decimal min)
        {
            _maxChartValue = max;
            _minChartValue = min;
        }

        public string GetDataString()
        {
            //return HttpUtility.JavaScriptStringEncode(@"Alert(''Hello'');");

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("labels : [{0}],\r\ndatasets : [\r\n", _chartLabels);

            for (int i = 0; i < ChartDataSets.Count; i++)
            {
                stringBuilder.AppendFormat("{{\r\n{0}\r\n}}", ChartDataSets[i].GetOutputString());
                if (i != ChartDataSets.Count - 1) stringBuilder.Append(",");
                else stringBuilder.Append("\r\n");
            }
            stringBuilder.Append("]");
            string outputString = stringBuilder.ToString();
            return stringBuilder.ToString();
        }
    }
}