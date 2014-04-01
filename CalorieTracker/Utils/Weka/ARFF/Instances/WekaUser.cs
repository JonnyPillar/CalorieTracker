using System.Collections.Generic;
using System.Text;
using CalorieTracker.Models;

namespace CalorieTracker.Utils.Weka.ARFF.Instances
{
    public class WekaUser : IWekaInstance
    {
        private readonly List<User> _userList;

        public WekaUser(List<User> user)
        {
            _userList = user;
        }

        public string GetAttributes()
        {
            var attributeStringBuilder = new StringBuilder("@RELATION user\r\n\r\n");
            attributeStringBuilder.AppendLine("@ATTRIBUTE ID numeric");
            attributeStringBuilder.AppendLine("@ATTRIBUTE DOB date \"yyyy-MM-dd\"");
            attributeStringBuilder.AppendLine("@ATTRIBUTE Gender {True, False}");
            attributeStringBuilder.AppendLine("@ATTRIBUTE CreationDate date \"yyyy-MM-dd\"");
            return attributeStringBuilder.ToString();
        }

        public string GetInstanceData()
        {
            var dataStringBuilder = new StringBuilder("\r\n@DATA\r\n");
            for (int i = 0; i < _userList.Count; i++)
            {
                dataStringBuilder.AppendFormat("{0},{1},{2},{3}\r\n", _userList[i].UserID, _userList[i].DOB.ToString("yyyy-MM-dd"),
                    _userList[i].Gender, _userList[i].CreationTimestamp.ToString("yyyy-MM-dd"));
            }
            return dataStringBuilder.ToString();
        }
    }
}