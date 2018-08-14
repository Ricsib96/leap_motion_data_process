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

        private const string SERVER = "localhost";
        private const string DATABASE = "data_process";
        private const string UID = "root";
        private const string PASSWORD = "admin";

        private const string TABLE_PATIENTS = "patients";

        private const string COL_ID = "id";
        private const string COL_FIRST_NAME = "first_name";
        private const string COL_LAST_NAME = "last_name";
        private const string COL_ADDRESS = "address";
        private const string COL_BIRTH = "birth";
        private const string COL_SEX = "sex";
        private const string COL_TEL_NUMBER = "tel_number";

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {

            string connectionString;
            connectionString = "SERVER=" + SERVER + ";" + "DATABASE=" +
            DATABASE + ";" + "UID=" + UID + ";" + "PASSWORD=" + PASSWORD + ";";

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
        public void addPatient(NameValueCollection newData)
        {
            string query =  "INSERT INTO "+ TABLE_PATIENTS + "(" + 
                            COL_FIRST_NAME + "," + COL_LAST_NAME + "," +
                            COL_ADDRESS + "," + COL_BIRTH + "," +
                            COL_SEX + "," + COL_TEL_NUMBER + ")" + 
                            
                            "VALUES (" + "'" + newData[COL_FIRST_NAME] + "'" + "," + 
                                        "'" + newData[COL_LAST_NAME] + "'" + "," +
                                        "'" + newData[COL_ADDRESS] + "'" + "," +
                                        "'" + newData[COL_BIRTH] + "'" + "," +
                                        "'" + newData[COL_SEX] + "'" + "," +
                                        "'" + newData[COL_TEL_NUMBER] + "'" + ")";

            OpenConnection();
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                Trace.Write(query);
                CloseConnection();
            }

        }
        public void updatePatient(NameValueCollection newData)
        {
            string query = "UPDATE "+ TABLE_PATIENTS +
                            " SET    " + COL_FIRST_NAME + " = '" + newData[COL_FIRST_NAME] + "', " +
                                    COL_LAST_NAME +" = '" + newData[COL_LAST_NAME] + "', " +
                                    COL_ADDRESS +" = '" + newData[COL_ADDRESS] + "', " +
                                    COL_BIRTH +" = '" + newData[COL_BIRTH] + "', " +
                                    COL_TEL_NUMBER +" = '" + newData[COL_TEL_NUMBER] + "' " +
                            "WHERE  " + COL_ID +" = '" + newData[COL_ID] + "'";

            OpenConnection();
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                Trace.Write(query);
                CloseConnection();
            }

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

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    NameValueCollection temp = new NameValueCollection();

                    temp.Add("firstname", reader.GetString(COL_FIRST_NAME));
                    temp.Add("lastname", reader.GetString(COL_LAST_NAME));
                    temp.Add("id", reader.GetString(COL_ID));
                    
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
        public NameValueCollection getPatientByName(String firstname, String lastname)
        {
            string query = "SELECT * FROM " + TABLE_PATIENTS + " " +
                            "WHERE " + COL_FIRST_NAME +" = '" + firstname + 
                            "' AND " + COL_LAST_NAME +" = '" + lastname + "'";
            NameValueCollection temp = new NameValueCollection();

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    temp.Add("id", reader.GetString(COL_ID));
                    temp.Add("firstname", reader.GetString(COL_FIRST_NAME));
                    temp.Add("lastname", reader.GetString(COL_LAST_NAME));
                    temp.Add("address", reader.GetString(COL_ADDRESS));
                    temp.Add("birth", reader.GetString(COL_BIRTH));
                    temp.Add("tel", reader.GetString(COL_TEL_NUMBER));
                   
                }
                CloseConnection();
            }
            return temp;
        }

        public NameValueCollection getPatientById(int id)
        {
            string query = "SELECT * FROM " + TABLE_PATIENTS + " " +
                            "WHERE " + COL_ID + " = '" + id.ToString() + "'";
            NameValueCollection temp = new NameValueCollection();

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    temp.Add("id", reader.GetString(COL_ID));
                    temp.Add("firstname", reader.GetString(COL_FIRST_NAME));
                    temp.Add("lastname", reader.GetString(COL_LAST_NAME));
                    temp.Add("address", reader.GetString(COL_ADDRESS));
                    temp.Add("birth", reader.GetString(COL_BIRTH));
                    temp.Add("tel", reader.GetString(COL_TEL_NUMBER));

                }
                CloseConnection();
            }
            return temp;
        }
        public void deletePatientById(int id)
        {
            string query = "DELETE FROM " + TABLE_PATIENTS +
                            " WHERE " + COL_ID + " = '" + id + "'";

            OpenConnection();
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                Trace.Write(query);
                CloseConnection();
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
