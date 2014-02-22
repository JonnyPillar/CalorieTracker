using System.Text;

namespace CalorieTracker.Utils.Chart
{
    public class ChartDataSet
    {
        public ChartDataSet()
        {
            FillColor = "rgba(220,220,220,0.5)";
            StrokeColor = "rgba(220,220,220,1)";
            PointColor = "rgba(220,220,220,1)";
            PointStrokeColor = "#fff";
        }

        public ChartDataSet(string data)
        {
            Data = data;
            FillColor = "rgba(220,220,220,0.5)";
            StrokeColor = "rgba(220,220,220,1)";
            PointColor = "rgba(220,220,220,1)";
            PointStrokeColor = "#fff";
        }

        public ChartDataSet(string data, string fillColor, string strokeColor, string pointColor,
            string pointStrokeColor)
        {
            Data = data;
            FillColor = fillColor;
            StrokeColor = strokeColor;
            PointColor = pointColor;
            PointStrokeColor = pointStrokeColor;
        }

        public string GetOutputString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("fillColor: '{0}',\r\n", FillColor);
            stringBuilder.AppendFormat("strokeColor: '{0}',\r\n", StrokeColor);
            stringBuilder.AppendFormat("pointColor: '{0}',\r\n", PointColor);
            stringBuilder.AppendFormat("pointStrokeColor: '{0}',\r\n", PointStrokeColor);
            stringBuilder.AppendFormat("data: [{0}]", Data);
            return stringBuilder.ToString();
        }

        public string Data { get; set; }

        public string StrokeColor { get; set; }

        public string FillColor { get; set; }

        public string PointColor { get; set; }

        public string PointStrokeColor { get; set; }
    }
}