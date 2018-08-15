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
        public List<Patient> searchPatient(string data)
        {
            List<Patient> list = new List<Patient>();
            string query =  "SELECT * FROM " + TABLE_PATIENTS + " " +
                            "WHERE CONCAT(" + COL_FIRST_NAME + ",' '," + COL_LAST_NAME + ") " +
                            "LIKE '%" + data + "%'";

            OpenConnection();
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Patient temp = new Patient();

                    temp.Id = reader.GetInt32(COL_ID);
                    temp.First_name = reader.GetString(COL_FIRST_NAME);
                    temp.Last_name = reader.GetString(COL_LAST_NAME);

                    list.Add(temp);
                }
                CloseConnection();
            }

            return list;
        }
        public void addPatient(Patient patient)
        {
            string query =  "INSERT INTO "+ TABLE_PATIENTS + "(" + 
                            COL_FIRST_NAME + "," + COL_LAST_NAME + "," +
                            COL_ADDRESS + "," + COL_BIRTH + "," +
                            COL_SEX + "," + COL_TEL_NUMBER + ")" + 
                            
                            "VALUES (" + "'" + patient.First_name + "'" + "," + 
                                        "'" + patient.Last_name + "'" + "," +
                                        "'" + patient.Address + "'" + "," +
                                        "'" + patient.Birth + "'" + "," +
                                        "'" + patient.Sex + "'" + "," +
                                        "'" + patient.Tel_number + "'" + ")";

            OpenConnection();
            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                Trace.Write(query);
                CloseConnection();
            }

        }
        public void updatePatient(Patient patient)
        {
            string query = "UPDATE "+ TABLE_PATIENTS +
                            " SET    " + COL_FIRST_NAME + " = '" + patient.First_name + "', " +
                                    COL_LAST_NAME +" = '" + patient.Last_name + "', " +
                                    COL_ADDRESS +" = '" + patient.Address + "', " +
                                    COL_BIRTH +" = '" + patient.Birth + "', " +
                                    COL_TEL_NUMBER +" = '" + patient.Tel_number + "' " +
                            "WHERE  " + COL_ID +" = '" + patient.Id + "'";

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
        public List<Patient> getPatients()
        {
            string query = "SELECT * FROM patients";
            List<Patient> list = new List<Patient>();

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Patient temp = new Patient();

                    temp.First_name = reader.GetString(COL_FIRST_NAME);
                    temp.Last_name = reader.GetString(COL_LAST_NAME);
                    temp.Id = reader.GetInt32(COL_ID);

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
        public Patient getPatientByName(String firstname, String lastname)
        {
            string query = "SELECT * FROM " + TABLE_PATIENTS + " " +
                            "WHERE " + COL_FIRST_NAME +" = '" + firstname + 
                            "' AND " + COL_LAST_NAME +" = '" + lastname + "'";
            Patient temp = new Patient();

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    temp.Id = reader.GetInt32(COL_ID);
                    temp.First_name = reader.GetString(COL_FIRST_NAME);
                    temp.Last_name = reader.GetString(COL_LAST_NAME);
                    temp.Address = reader.GetString(COL_ADDRESS);
                    temp.Birth = reader.GetString(COL_BIRTH);
                    temp.Tel_number = reader.GetString(COL_TEL_NUMBER);
                   
                }
                CloseConnection();
            }
            return temp;
        }

        public Patient getPatientById(int id)
        {
            string query = "SELECT * FROM " + TABLE_PATIENTS + " " +
                            "WHERE " + COL_ID + " = '" + id.ToString() + "'";
            Patient temp = new Patient();

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    temp.Id = reader.GetInt32(COL_ID);
                    temp.First_name = reader.GetString(COL_FIRST_NAME);
                    temp.Last_name = reader.GetString(COL_LAST_NAME);
                    temp.Address = reader.GetString(COL_ADDRESS);
                    temp.Birth = reader.GetString(COL_BIRTH);
                    temp.Tel_number = reader.GetString(COL_TEL_NUMBER);

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
