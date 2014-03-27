using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CalorieTracker.Models;
using CalorieTracker.Utils.Weka.ARFF.Instances;

namespace CalorieTracker.Utils.Weka.ARFF
{
    public class ARFFGenerator
    {
        private readonly WekaUserNutrition _data;
        //private readonly string _saveLocation = @"C:\Code\Calorie Tracker\CalorieTracker\CalorieTracker\App_Data\";
        private readonly string _saveLocation = @"D:\inetpub\wwwroot\Temp\";
        
        public ARFFGenerator(string fileName, List<User> dataList)
        {
            var fileURL = new StringBuilder(_saveLocation);
            fileURL.AppendFormat("{0}_{1}.arff", fileName, DateTime.Now.ToString("_ddMMyyhhmmss"));

            _saveLocation = fileURL.ToString();
            _data = new WekaUserNutrition(dataList);
        }

        public void GenerateFile()
        {
            _data.GetInstanceData();

            //using (var writer = new StreamWriter(_saveLocation))
            //{
            //    writer.Write(_data.GetAttributes());
            //    writer.WriteLine(_data.GetInstanceData());

            //    foreach (string item in _data.stringList)
            //    {
            //        writer.WriteLine(item);
            //    }
            //}
        }
    }
}