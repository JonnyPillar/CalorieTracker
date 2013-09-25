using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalorieTracker.ViewModels
{
    public class LogStatModel
    {
        public double remainingCal;
        public double burnedCal;
        public double eatenCal;

        public LogStatModel(double burned, double eaten)
        {
            burnedCal = burned;
            eatenCal = eaten;
            remainingCal = (2200 - eaten) + burned; //TODO need to add gender calorie amount
        }
    }
}