using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Payroll_System
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Logout?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                LoginForm loginForm = new();
                loginForm.Show();
                this.Close();
            }
        }

        private void AccountDetailsButton_Click(object sender, EventArgs e)
        {
            DataTable? retrievedTable = UserDetails.UserDetail;
            if (retrievedTable != null && retrievedTable.Rows.Count > 0)
            {
                StringBuilder userDetailStringBuilder = new();

                foreach (DataRow row in retrievedTable.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        userDetailStringBuilder.Append(item.ToString()).Append("\t");
                    }
                    userDetailStringBuilder.AppendLine();
                }

                string userDetailString = userDetailStringBuilder.ToString();

                MessageBox.Show(userDetailString, "User Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (retrievedTable == null)
                {
                    MessageBox.Show("The retrievedTable is null.", "User Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The retrievedTable is empty.", "User Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
