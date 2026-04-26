using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace DBapplication
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }

      
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

        public DataTable GetActiveEmployees()
        {
            // Query to fetch active employees only based on the soft-delete mechanism
            string query = "SELECT EmployeeID, FirstName, LastName, EmployeeRole, Phone, Email, HireDate, Salary FROM Employee WHERE IsActive = 1;";

            return dbMan.ExecuteReader(query);
        }

        public DataTable GetUserLoginInfo(string email)
        {
            // The UNION combines both queries. 
            // If found in Client, we hardcode the Role as 'Client'.
            // If found in Employee, we grab their actual EmployeeRole (Admin, Vet, Staff).
            string query = $"SELECT PasswordHash, 'Client' AS Role FROM Client WHERE Email = '{email}' " +
                $"UNION " +
                $"SELECT PasswordHash, EmployeeRole AS Role FROM Employee WHERE Email = '{email}';";

            return dbMan.ExecuteReader(query);
        }


    }
}
