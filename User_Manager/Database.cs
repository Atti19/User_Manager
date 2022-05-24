using MySql;
using MySql.Data.MySqlClient;
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

            //Constructor
            public DBconnect()
            {
                Initialize();
            }

            //Initialize values
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
            public void Insert(string name, string pw, long cnp, long tel)
            {
                string query = $"INSERT INTO users (nume, passw, cnp, tel, nivel) VALUES('{name}','{pw}','{cnp}','{tel}','1')";

                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }

            //Update statement
            public void Update()
            {
                string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = connection;

                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
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
        public string[] Select(string user)
        {
            string query = $"SELECT * FROM users where nume = '{user}'";

            //Create a list to store the result
            string[] list = new string[6];
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0]=(dataReader["id"] + "");
                    list[1]=(dataReader["nume"] + "");
                    list[2]=(dataReader["passw"] + "");
                    list[3]=(dataReader["cnp"] + "");
                    list[4]=(dataReader["tel"] + "");
                    list[5]=(dataReader["nivel"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }
    }
}
