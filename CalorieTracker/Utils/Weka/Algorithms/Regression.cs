using System.IO;
using java.io;
using weka.classifiers.functions;
using weka.core;

namespace CalorieTracker.Utils.Weka.Algorithms
{
    public class Regression : IAlgorithm
    {
        private string _arffFileUrl;
        private string _result;

        public bool SetArffFile(string fileUrl)
        {
            var newFile = new FileInfo(fileUrl);
            if (newFile.Exists)
            {
                _arffFileUrl = fileUrl;
                return true;
            }
            return false;
        }

        public void ExecuteProcess()
        {
            var linearRegression = new LinearRegression();
            var dataInstance = new Instances(new FileReader(_arffFileUrl));
            dataInstance.setClassIndex(dataInstance.numAttributes() - 1);

            linearRegression.buildClassifier(dataInstance);
            Instance userInstance = dataInstance.lastInstance();
            double result = linearRegression.classifyInstance(userInstance);
            _result = "The Result is, " + result;
        }

        public string GetResults()
        {
            return _result;
        }
    }
}