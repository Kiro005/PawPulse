using DBapplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawPulse
{
    public partial class AppointmentsClientUC : UserControl
    {
        int ClientID;
        string ClientName;
        Controller ControllerObj;
        public AppointmentsClientUC(int clientID, string clientName)
        {
            InitializeComponent();
            ControllerObj = new Controller();
            this.ClientID = clientID;
            this.ClientName = clientName;

            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
        }
    }
}
