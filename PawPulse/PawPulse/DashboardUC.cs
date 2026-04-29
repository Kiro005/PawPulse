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
    public partial class DashboardUC : UserControl
    {
        string ClientName;
        int ClientID;
        Controller controllerObj;
        public DashboardUC(int clientID, string clientName)
        {
            InitializeComponent();
            controllerObj = new Controller();
            this.ClientID = clientID;
            this.ClientName = clientName;

            lblWelcome.Text = $"Welcome, {ClientName}!";
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");

            int petsNumber = controllerObj.getPetsNumber(ClientID);
            if (petsNumber > 0)
            {
                lblPetsNum.Text = petsNumber.ToString();
            }
            else
            {
                lblPetsNum.Text = "0";
            }

            object nextAppointment = controllerObj.GetNextAppointment(ClientID);
            if (nextAppointment != null && nextAppointment != DBNull.Value)
            {
                DateTime appDate = Convert.ToDateTime(nextAppointment);
                lblAppDate.Text = appDate.ToString("MMMM dd");
            }
            else
            {
                lblAppDate.Text = "____";
            }

            decimal totalPayments = controllerObj.GetTotalDept(ClientID);
            lblDept.Text = totalPayments > 0 ? totalPayments.ToString("C") : "$0.00";
        }

        private void DashboardUC_Load(object sender, EventArgs e)
        {

        }
    }
}
