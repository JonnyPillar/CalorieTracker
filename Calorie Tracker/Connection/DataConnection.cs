using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Data.Odbc;
using MySql.Data.MySqlClient;
using System.Web.Configuration;

namespace Calorie_Tracker.Connection
{
    public class DataConnection
    {
        private MySqlCommand command;
        private MySqlConnection connection;
        private MySqlDataReader reader;
        private Type objectType;

        public DataConnection(string query, Type dbObject)
        {
            connection = new MySqlConnection(WebConfigurationManager.ConnectionStrings["mysqlConnection"].ConnectionString);
            command = new MySqlCommand(query, connection);
            objectType = dbObject;
        }

        public void AddParameter(object value)
        {
            command.Parameters.AddWithValue("?", value);
        }

        public Array ExecuteQuery()
        {
            ArrayList items = new ArrayList();
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                items.Add(Activator.CreateInstance(objectType, reader));
            }
            connection.Close();
            return items.ToArray(objectType);
        }

        public void ExecuteNonQuery()
        {
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public object ExecuteScalar()
        {
            connection.Open();
            object value = command.ExecuteScalar();
            connection.Close();
            return value;
        }

        public Boolean Exists
        {
            get
            {
                connection.Open();
                reader = command.ExecuteReader();
                Boolean value = reader.HasRows;
                reader.Close();
                connection.Close();
                return value;
            }
        }
    }
}