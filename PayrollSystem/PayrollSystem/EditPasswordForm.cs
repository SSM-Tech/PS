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

        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (allAccDetail != null)
            {
                ChangePass(allAccDetail);
            }
            else
            {

            }
        }

        private void OldPassTextBoxt_Enter(object sender, EventArgs e)
        {
            OldPasswordPlaceHolder.Hide();
            OldPassTextBox.SelectAll();
        }

        private void OldPassTextBoxt_Leave(object sender, EventArgs e)
        {
            if(OldPassTextBox.Text == "")
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
    }
}
