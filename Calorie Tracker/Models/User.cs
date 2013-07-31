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

        public bool IsValid(string _username, string _password)
        {
            string query = "SELECT user_email FROM tbl_user WHERE user_email = ?";
            MySqlCommand command = new MySqlCommand(query);


            MySqlConnection myConnection = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["mysqlConnection"].ConnectionString);


            MySqlCommand myCommand = new MySqlCommand(query, myConnection);
            myCommand.Parameters.Add(new MySqlParameter("?", _username));
            myConnection.Open();
            MySqlDataReader db_reader = myCommand.ExecuteReader();
            Boolean value = db_reader.HasRows;
            myCommand.Connection.Close();
            return value;
        }
    }
}