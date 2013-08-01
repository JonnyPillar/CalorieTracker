using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;
using Calorie_Tracker.Connection;

namespace Calorie_Tracker.Models
{
    public class User
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember on this computer")]
        public bool RememberMe { get; set; }

        public bool IsValid(string _email, string _password)
        {
            if (validEmail(_email))
            {
                return true;
            }
            else return false;
        }

        public bool IsValid(string _email, string _password, string _firstName, string _secondName, string _dob)
        {

            return false;
        }

        public bool validEmail(string _email)
        {
            DataConnection connection = new DataConnection("SELECT user_email FROM tbl_user WHERE user_email = ?", typeof(User));
            connection.AddParameter(_email);
            if (connection.Exists) return true;
            else return false;
        }
    }
}