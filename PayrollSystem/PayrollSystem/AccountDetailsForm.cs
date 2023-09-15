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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PayrollSystem
{
    public partial class AccountDetailsForm : Form
    {
        private DataTable? accDetail;
        private DataTable? allAccDetail;
        public AccountDetailsForm(DataTable? accDetail)
        {
            InitializeComponent();
            this.accDetail = accDetail;
            string employeeID = accDetail.Rows[0]["employeeID"].ToString();

            DB db = new();

            DataTable allAccDetail = new();

            MySqlDataAdapter adapter = new();

            MySqlCommand command = new MySqlCommand("SELECT a.*, e.managerID, e.firstName, e.lastName FROM account a JOIN employee e ON a.employeeID = e.employeeID WHERE a.employeeID = @employeeID;", db.getConnection());

            command.Parameters.Add("@employeeID", MySqlDbType.VarChar).Value = employeeID;

            adapter.SelectCommand = command;

            adapter.Fill(allAccDetail);

            if (allAccDetail != null)
            {
                string firstname = allAccDetail.Rows[0]["firstName"].ToString();
                string lastname = allAccDetail.Rows[0]["lastName"].ToString();
                string userID = allAccDetail.Rows[0]["userID"].ToString();
                string description = allAccDetail.Rows[0]["accountDescription"].ToString();
                string accountlevel = allAccDetail.Rows[0]["accountLevel"].ToString();
                string username = allAccDetail.Rows[0]["username"].ToString();

                UserIDLabel.Text = userID;
                EmployeeIDLabel.Text = employeeID;
                FullnameLabel.Text = firstname + " " + lastname;
                UsernameLabel.Text = username;
                AccountDescriptionLabel.Text = description;
                AccountLevelLabel.Text = accountlevel;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close Account Detail?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                HomeForm homeform = new HomeForm(accDetail);
                homeform.Show();
                this.Close();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Edit Password?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                EditPasswordForm eaform = new EditPasswordForm(allAccDetail);
                eaform.Show();
                this.Close();
            }
        }
    }
}
