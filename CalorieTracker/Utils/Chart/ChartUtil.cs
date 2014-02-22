using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Web;

namespace CalorieTracker.Utils.Chart
{
    public class ChartUtil
    {
        private readonly string _chartLabels;

        public ChartUtil(string chartLabels)
        {
            _chartLabels = chartLabels;
            ChartDataSets = new List<ChartDataSet>();
        }

        public List<ChartDataSet> ChartDataSets { get; set; }

        public void AddDataSet(ChartDataSet chartDataSet)
        {
            ChartDataSets.Add(chartDataSet);
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