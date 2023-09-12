using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem
{
    public partial class HomeForm : Form
    {
        private DataTable? accDetail;
        public HomeForm(DataTable? accDetail)
        {
            InitializeComponent();
            this.accDetail = accDetail;
            if (accDetail != null && accDetail.Rows.Count > 0)
            {
                string username = accDetail.Rows[0]["username"].ToString();
                UsernameLabel.Text = "Welcome, " + username.ToUpper() +"!";
            }
            else
            {
                UsernameLabel.Text = "Welcome, Guest!";
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Logout?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }
        }

        private void AccountDetailsButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you you want to open Account Details?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                AccountDetailsForm ADForm = new AccountDetailsForm(accDetail);
                ADForm.Show();
                this.Close();
            }
        }
    }
}
