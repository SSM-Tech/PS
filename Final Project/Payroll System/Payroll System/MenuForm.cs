using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
    public partial class MenuForm : Form
    {
        DBConn dbConn = new();
        DBQuery dbQuery = new DBQuery();
        DataTable? retrievedTable = UserDetails.UserDetail;
        private System.Timers.Timer serverTimer;
        private bool isProgrammaticClose = false;
        private string userID;

        public MenuForm()
        {
            InitializeComponent();

            userID = retrievedTable.Rows[0][columnName: "userID"].ToString();

            serverTimer = new System.Timers.Timer(60000);
            serverTimer.Elapsed += ServerTimerElapsed;
            serverTimer.AutoReset = true;
            serverTimer.Enabled = true;

            serverTimer.Start();

            FormClosing += new FormClosingEventHandler(OnFormClosing);
            string username = retrievedTable.Rows[0][columnName: "username"].ToString().ToUpper();
            string acclevel = retrievedTable.Rows[0][columnName: "accountLevel"].ToString();
            if (acclevel != "1")
            {
                ManageAccoountFormButton.Visible = true;
                TicketsFormButton.Visible = true;
                Application.DoEvents();
            }
            UsernameLabel.Text = "Welcome " + username;
            LoadForm(new HomeForm());
            BtnDefaultColors();
            HomeFormButton.BackColor = SystemColors.ActiveBorder;
        }
        private void ServerTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CheckServerStatus();
            CheckAccountStatus();
        }
        private void CheckServerStatus()
        {
            DataTable? table = new();

            MySqlDataAdapter adapter = new();
            MySqlCommand command = new(dbQuery.CheckServerStatus(), dbConn.getConnection());

            adapter.SelectCommand = command;

            adapter.Fill(table);

            int status = (int)table.Rows[0][columnName: "status"];

            if (status == 0)
            {
                this.Invoke(new Action(() =>
                {
                    serverTimer.Stop();
                    Logout();
                    MessageBox.Show("Server Stopped, Please login later", "Server Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }));
                UpdateLoginStatus();
            }

            table.Rows.Clear();
        }
        private void CheckAccountStatus()
        {
            DataTable? table = new();

            MySqlDataAdapter adapter = new();
            MySqlCommand command = new(dbQuery.CheckIsEnabled(), dbConn.getConnection());

            command.Parameters.AddWithValue("@p0", userID);

            adapter.SelectCommand = command;

            adapter.Fill(table);

            var isEnabled = table.Rows[0][columnName: "isEnabled"].ToString();

            if (isEnabled == "0")
            {
                this.Invoke(new Action(() =>
                {
                    serverTimer.Stop();
                    Logout();
                    MessageBox.Show("Your account has been locked, Please Contact the HR for more Information.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
                UpdateLoginStatus();
            }

            table.Rows.Clear();
        }
        private void UpdateLoginStatus()
        {
            dbConn.openConnection();

            MySqlDataAdapter adapter = new();
            MySqlCommand command = new(dbQuery.UpdateLoginStatus(), dbConn.getConnection());

            command.Parameters.AddWithValue("@p0", userID);

            command.ExecuteNonQuery();

            dbConn.closeConnection();
        }
        private void LogoutTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isProgrammaticClose && e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you want to continue and perform some action before closing?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    LoginStatus();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
            }
        }
        public void LoadForm(object Form)
        {
            if (this.MainPanel.Controls.Count > 0)
                this.MainPanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(f);
            this.MainPanel.Tag = f;
            f.Show();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Logout?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Logout();
            }
        }
        private void Logout()
        {
            isProgrammaticClose = true;
            LoginStatus();
            LoginForm loginForm = new();
            loginForm.Show();
            this.Close();
        }
        private void LoginStatus()
        {
            DBConn dbConn = new();

            DBQuery dbQuery = new DBQuery();

            string userID = retrievedTable.Rows[0][columnName: "userID"].ToString();
            using (MySqlConnection dbConnection = dbConn.getConnection())
            {
                dbConnection.Open();

                using (MySqlCommand acommand = new MySqlCommand(dbQuery.LoginStatus(), dbConnection))
                {
                    acommand.Parameters.AddWithValue("@p0", 0);
                    acommand.Parameters.AddWithValue("@p1", userID);

                    acommand.ExecuteNonQuery();
                }
            }
        }

        private void BtnDefaultColors()
        {
            HomeFormButton.BackColor = SystemColors.ActiveCaption;
            AccountDetailsButton.BackColor = SystemColors.ActiveCaption;
            DTRFormButton.BackColor = SystemColors.ActiveCaption;
            PayslipFormButton.BackColor = SystemColors.ActiveCaption;
            ManageAccoountFormButton.BackColor = SystemColors.ActiveCaption;
            TicketsFormButton.BackColor = SystemColors.ActiveCaption;
        }

        private void HomeFormButton_Click(object sender, EventArgs e)
        {
            LoadForm(new HomeForm());
            BtnDefaultColors();
            HomeFormButton.BackColor = SystemColors.ActiveBorder;
        }
        private void AccountDetailsButton_Click(object sender, EventArgs e)
        {
            LoadForm(new AccountDetailsForm());
            BtnDefaultColors();
            AccountDetailsButton.BackColor = SystemColors.ActiveBorder;
        }

        private void DTRFormButton_Click(object sender, EventArgs e)
        {
            LoadForm(new DTRForm());
            BtnDefaultColors();
            DTRFormButton.BackColor = SystemColors.ActiveBorder;
        }

        private void PayslipFormButton_Click(object sender, EventArgs e)
        {
            LoadForm(new PaySlipForm());
            BtnDefaultColors();
            PayslipFormButton.BackColor = SystemColors.ActiveBorder;
        }

        private void ManageAccoountFormButton_Click(object sender, EventArgs e)
        {
            LoadForm(new ManageAccountForm());
            BtnDefaultColors();
            ManageAccoountFormButton.BackColor = SystemColors.ActiveBorder;
        }

        private void TicketsFormButton_Click(object sender, EventArgs e)
        {
            LoadForm(new TicketsForm());
            BtnDefaultColors();
            TicketsFormButton.BackColor = SystemColors.ActiveBorder;
        }

        private void MenuForm_Enter(object sender, EventArgs e)
        {
            LoadForm(new HomeForm());
        }
    }
}
