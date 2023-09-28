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
    public partial class EditPasswordForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;
        public EditPasswordForm()
        {
            InitializeComponent();
        }
        private void ChangePassword()
        {
            MessageBox.Show("Hello Bitch");
        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            String oldPass = retrievedTable.Rows[0][columnName: "password"].ToString();

            if (string.IsNullOrWhiteSpace(TxtOldPass.Text) || string.IsNullOrWhiteSpace(TxtConfOldPass.Text))
            {
                MessageBox.Show("No Empty Fields Allowed", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrWhiteSpace(TxtNewPass.Text) || string.IsNullOrWhiteSpace(TxtConfNewPass.Text))
            {
                MessageBox.Show("No Empty Fields Allowed", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (oldPass != TxtOldPass.Text)
            {
                MessageBox.Show("Wrong Old Password", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (TxtOldPass.Text != TxtConfOldPass.Text)
            {
                MessageBox.Show("Old Password Didn't Match", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (TxtNewPass.Text != TxtConfNewPass.Text)
            {
                MessageBox.Show("New Password Didn't Match", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MessageBox.Show("Are you sure you want to Change Password?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ChangePassword();
            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Cancel Change Password?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

       
    }
}
