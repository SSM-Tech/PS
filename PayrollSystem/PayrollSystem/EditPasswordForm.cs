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
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel Change Password?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
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
    }
}
