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

        public int TestConnection()
        {
            
            string query = "SELECT 1";

            object result = dbMan.ExecuteScalar(query);

            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            return 0;
        }



    }
}
