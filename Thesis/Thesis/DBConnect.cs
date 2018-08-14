using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Data;
using System.Collections.Specialized;

namespace Thesis
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "data_process";
            uid = "root";
            password = "admin";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                if(connection.State==ConnectionState.Closed)
                {
                    connection.Open();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert()
        {
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }

        //Select statement
        public List<NameValueCollection> getPatients()
        {
            string query = "SELECT * FROM patients";
            List<NameValueCollection> list = new List<NameValueCollection>();

            OpenConnection();

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                

                while (reader.Read())
                {
                    NameValueCollection temp = new NameValueCollection();

                    temp.Add("firstname", reader.GetString("first_name"));
                    temp.Add("lastname", reader.GetString("last_name"));
                    temp.Add("address", reader.GetString("address"));
                    temp.Add("birth", reader.GetString("birth"));
                    temp.Add("tel", reader.GetString("tel_number"));
                    temp.Add("sex", reader.GetString("sex"));

                    list.Add(temp);
                }

                CloseConnection();

                return list;
            }
            else
            {
                return list;
            }
        }
        

        //Count statement
    /*    public int Count()
        {
        }
    
        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
    */
    }
}
