using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTracker.Utils.Weka.Algorithms
{
    interface IAlgorithm
    {
        bool SetArffFile(string fileUrl);
        void ExecuteProcess();
        string GetResults();
    }
}
