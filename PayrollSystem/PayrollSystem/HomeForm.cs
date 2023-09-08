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
        public HomeForm()
        {
            InitializeComponent();
        }
        public HomeForm(DataTable? accDetail)
        {
            InitializeComponent();

            this.accDetail = accDetail;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the application?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }
        }

        private void AccountDetailsButton_Click(object sender, EventArgs e)
        {
            if (accDetail != null)
            {
                StringBuilder message = new StringBuilder();
                message.AppendLine("Account Details:");

                foreach (DataRow row in accDetail.Rows)
                {
                    foreach (DataColumn col in accDetail.Columns)
                    {
                        message.AppendLine($"{col.ColumnName}: {row[col]}");
                    }
                    message.AppendLine(); // Add a blank line between rows
                }

                MessageBox.Show(message.ToString(), "Account Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Account details are not available.", "Account Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
