using MySql.Data.MySqlClient;
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
    public partial class EditPasswordForm : Form
    {
        private DataTable? allAccDetail;
        private DataTable? accDetail;
        public EditPasswordForm(DataTable? allAccDetail)
        {
            InitializeComponent();
            this.allAccDetail = allAccDetail;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel Change Password?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                accDetail = allAccDetail;
                AccountDetailsForm adForm = new AccountDetailsForm(accDetail);
                adForm.Show();
                this.Close();
            }
        }


        private void ChangePass(DataTable? allAccDetail)
        {
            if (allAccDetail != null)
            {
                StringBuilder message = new StringBuilder();

                // Iterate through rows and columns to build the message
                foreach (DataRow row in allAccDetail.Rows)
                {
                    foreach (DataColumn col in allAccDetail.Columns)
                    {
                        message.Append($"{col.ColumnName}: {row[col].ToString()}, ");
                    }
                    message.AppendLine(); // Add a new line for each row
                }

                // Display the message in a MessageBox
                MessageBox.Show(message.ToString(), "DataTable Contents", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("DataTable is null.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (allAccDetail != null)
            {
            ChangePass(allAccDetail);
            }
                else
            {
                MessageBox.Show("Old Password should not be Empty?", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OldPassTextBoxt_Enter(object sender, EventArgs e)
        {
            OldPasswordPlaceHolder.Hide();
            OldPassTextBox.SelectAll();
        }

        private void OldPassTextBoxt_Leave(object sender, EventArgs e)
        {
            if (OldPassTextBox.Text == "")
            {
                OldPasswordPlaceHolder.Show();
            }
        }

        private void NewPassTextBox_Enter(object sender, EventArgs e)
        {
            NewPasswordPlaceHolder.Hide();
            NewPassTextBox.SelectAll();
        }

        private void NewPassTextBox_Leave(object sender, EventArgs e)
        {
            if (NewPassTextBox.Text == "")
            {
                NewPasswordPlaceHolder.Show();
            }
        }
        private void ConfNewPassTextBox_Enter(object sender, EventArgs e)
        {
            ConfirmNewPasswordPlaceHolder.Hide();
            ConfNewPassTextBox.SelectAll();
        }
        private void ConfNewPassTextBox_Leave(object sender, EventArgs e)
        {
            if (ConfNewPassTextBox.Text == "")
            {
                ConfirmNewPasswordPlaceHolder.Show();
            }
        }

        private void ConfirmButton_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmButton_Click(sender, e);
            }
        }

        private void OldPasswordPlaceHolder_Click(object sender, EventArgs e)
        {
            OldPassTextBox.Focus();
        }

        private void NewPasswordPlaceHolder_Click(object sender, EventArgs e)
        {
            NewPassTextBox.Focus();
        }

        private void ConfirmNewPasswordPlaceHolder_Click(object sender, EventArgs e)
        {
            ConfNewPassTextBox.Focus();
        }

        private void HideOldPasswordIcon_Click(object sender, EventArgs e)
        {
            OldPassTextBox.UseSystemPasswordChar = false;
            HideOldPasswordIcon.Hide();
            ShowOldPasswordIcon.Show();
        }
        private void ShowOldPasswordIcon_Click(object sender, EventArgs e)
        {
            OldPassTextBox.UseSystemPasswordChar = true;
            HideOldPasswordIcon.Show();
            ShowOldPasswordIcon.Hide();
        }
        private void HideNewPasswordIcon_Click(object sender, EventArgs e)
        {
            NewPassTextBox.UseSystemPasswordChar = false;
            HideNewPasswordIcon.Hide();
            ShowNewPasswordIcon.Show();
        }
        private void ShowNewPasswordIcon_Click(object sender, EventArgs e)
        {
            NewPassTextBox.UseSystemPasswordChar = true;
            HideNewPasswordIcon.Show();
            ShowNewPasswordIcon.Hide();
        }
        private void HideConNewPasswordIcon_Click(object sender, EventArgs e)
        {
            ConfNewPassTextBox.UseSystemPasswordChar = false;
            HideConNewPasswordIcon.Hide();
            ShowConNewPasswordIcon.Show();
        }
        private void ShowConNewPasswordIcon_Click(object sender, EventArgs e)
        {
            ConfNewPassTextBox.UseSystemPasswordChar = true;
            HideConNewPasswordIcon.Show();
            ShowConNewPasswordIcon.Hide();
        }
    }
}
