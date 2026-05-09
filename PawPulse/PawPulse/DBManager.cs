using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBapplication
{
    public class DBManager
    {
        //gharbawy : Data Source=.;Initial Catalog=PawPulse;Integrated Security=True;TrustServerCertificate=True
        //Kiro: Data Source=localhost\SQLEXPRESS02;Initial Catalog=PawPulse;Integrated Security=True;TrustServerCertificate=True
        // Orashy : Data Source=.\SQLEXPRESS;Initial Catalog=PawPulse;Integrated Security=True;Encrypt=True;TrustServerCertificate=True
        static string DB_Connection_String = @"Data Source=localhost\SQLEXPRESS02;Initial Catalog=PawPulse;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection myConnection;

        public DBManager()
        {
            myConnection = new SqlConnection(DB_Connection_String);
            try
            {
                myConnection.Open();
                Console.WriteLine("The DB connection is opened successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("The DB connection is failed");
                Console.WriteLine(e.ToString());
            }
        }

        public int ExecuteNonQuery(string query)
        {
            try
            {
                if (myConnection.State == System.Data.ConnectionState.Closed)
                    myConnection.Open();
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                return myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "DB Error");
                return 0;
            }
        }

        public DataTable ExecuteReader(string query)
        {
            try
            {
                // 1. THE FIX: Make sure the connection is open before we do anything!
                if (myConnection.State == System.Data.ConnectionState.Closed)
                {
                    myConnection.Open();
                }

                SqlCommand myCommand = new SqlCommand(query, myConnection);
                SqlDataReader reader = myCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    return dt;
                }
                else
                {
                    if (!reader.IsClosed)
                        reader.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "DBMANAGER ERROR!"); // Great job keeping this in!
                return null;
            }
        }

        public object ExecuteScalar(string query)
        {
            try
            {
                if (myConnection.State == System.Data.ConnectionState.Closed)
                    myConnection.Open();
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                return myCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public void CloseConnection()
        {
            try
            {
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        
    }
}
;