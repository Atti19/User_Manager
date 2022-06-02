using MySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace User_Manager
{
    public class DBconnect
    {
            private MySqlConnection connection;
            private string server;
            private string database;
            private string uid;
            private string password;

            public DBconnect()
            {
                Initialize();
            }

            
            private void Initialize()
            {
                server = "localhost";
                database = "Gym";
                uid = "root";
                password = "";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

                connection = new MySqlConnection(connectionString);
            }

            //open connection to database
            private bool OpenConnection()
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (MySqlException ex)
                {

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
            private bool CloseConnection()
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
            public void Insert_activity(string nume)
            {
                DateTime data = DateTime.Now;
                string query = $"INSERT INTO activities (Name, Activity) VALUES('{nume}','{data.ToString()}')";
                if(this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
            public void Insert(string name, string pw, string cnp, long tel)
            {
                string query = $"INSERT INTO users (nume, passw, cnp, tel, nivel) VALUES('{name}','{pw}','{cnp}','{tel}','1')";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }

            //Update statement
            public void Update(string name)
            {
                string query = $"UPDATE users SET nivel = '2' WHERE nume='{name}'";

                if (this.OpenConnection() == true)
                {    
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }

            //Delete statement
            public void Delete(string name)
            {
                string query = $"DELETE FROM users WHERE nume = '{name}'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }

        //Select statement
        public Stack Select_activity(string nume)
        {
            string query = $"SELECT * FROM activities where name = '{nume}'";
            Stack stack = new Stack();
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {      
                    stack.Push((dataReader["Name"] + ""));
                    stack.Push((dataReader["Activity"] + ""));
                }
                dataReader.Close();
                this.CloseConnection();
                return stack;
            }
            else return stack;
        }
        public Stack Select_all_Activities()
        {
            string query = "Select * FROM activities";
            Stack stack = new Stack();
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    stack.Push((dataReader["Name"] + ""));
                    stack.Push((dataReader["Activity"] + ""));
                }
                dataReader.Close();
                this.CloseConnection();
                return stack;
            }
            else return stack;
        }
        public Stack Select_all()
        {
            string query = "Select * FROM users";
            Stack stack = new Stack();
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    stack.Push((dataReader["id"] + ""));
                    stack.Push((dataReader["nume"] + ""));
                    stack.Push((dataReader["cnp"] + ""));
                    stack.Push((dataReader["tel"] + ""));
                    stack.Push((dataReader["nivel"] + ""));
                }
                dataReader.Close();
                this.CloseConnection();
                return stack;
            }
            else return stack;
        }
        public string[] Select(string user)
        {
            string query = $"SELECT * FROM users where nume = '{user}'";

            string[] list = new string[6];
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    list[0]=(dataReader["id"] + "");
                    list[1]=(dataReader["nume"] + "");
                    list[2]=(dataReader["passw"] + "");
                    list[3]=(dataReader["cnp"] + "");
                    list[4]=(dataReader["tel"] + "");
                    list[5]=(dataReader["nivel"] + "");
                }
                dataReader.Close();
                this.CloseConnection();  
                return list;
            }
            else
            {
                return list;
            }
        }
    }
}
