using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll_System
{
    public partial class HomeForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;
        DateTime currentTime = DateTime.Now;
        public HomeForm()
        {
            InitializeComponent();
            SetHomeForm();
        }

        private void SetHomeForm()
        {
            string clockedIn = retrievedTable.Rows[0][columnName: "clockedIn"].ToString();
            string clockedOut = retrievedTable.Rows[0][columnName: "clockedOut"].ToString();

            DateTime clockIn = DateTime.Today.AddHours(1);
            DateTime clockOut = DateTime.Today.AddHours(24);

            if(clockOut > currentTime && clockOut < currentTime && clockedIn == "0")
            {
                ClockedOut();
            }
            else
            {
                if (clockedIn == "0" && clockedOut == "0")
                {
                    ClockDefault();
                }
                else if (clockedIn == "1" && clockedOut == "0")
                {
                    ClockedIn();
                }
                else
                {
                    ClockedOut();
                }
            }
        }
        private void ClockDefault()
        {
            btnClockIn.BackColor = System.Drawing.Color.Lime;
            btnClockOut.BackColor = System.Drawing.Color.Gray;
            btnClockIn.Enabled = true;
            btnClockOut.Enabled = false;
        }
        private void ClockedIn()
        {
            btnClockIn.BackColor = System.Drawing.Color.Gray;
            btnClockOut.BackColor = System.Drawing.Color.Red;
            btnClockIn.Enabled = false;
            btnClockOut.Enabled = true;
        }
        private void ClockedOut()
        {
            btnClockIn.BackColor = System.Drawing.Color.Gray;
            btnClockOut.BackColor = System.Drawing.Color.Gray;
            btnClockIn.Enabled = false;
            btnClockOut.Enabled = false;
        }

        private void btnClockIn_Click(object sender, EventArgs e)
        {
            UserDetails.UserDetail.Rows[0]["clockedIn"] = 1;
            ClockedIn();
        }

        private void btnClockOut_Click(object sender, EventArgs e)
        {
            DateTime clockOutTime = DateTime.Today.AddHours(17);

            if (currentTime < clockOutTime)
            {
                string currentTimeString = currentTime.ToString("h:mm tt");
                string message = $"Are you sure you want to Clock Out? It's still {currentTimeString}";
                DialogResult result = MessageBox.Show(message, "Clock Out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    UserDetails.UserDetail.Rows[0]["clockedOut"] = 1;
                    ClockedOut();
                }
            }
            else
            {
                UserDetails.UserDetail.Rows[0]["clockedOut"] = 1;
                ClockedOut();
            }
            
        }
    }
}
