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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Payroll_System
{
    public partial class MenuForm : Form
    {
        DBConn dbConn = new();
        DBQuery dbQuery = new DBQuery();
        DataTable? retrievedTable = UserDetails.UserDetail;
        private System.Timers.Timer serverTimer;
        private bool isProgrammaticClose = false;
        private string? userID;
        private bool isServerDown = false;
        private string? username;
        private string? accLevel;

        public MenuForm()
        {
            InitializeComponent();

            if (retrievedTable != null && retrievedTable.Rows.Count > 0)
            {
                userID = retrievedTable.Rows[0][columnName: "userID"]?.ToString();
                username = retrievedTable.Rows[0][columnName: "username"]?.ToString();
                accLevel = retrievedTable.Rows[0][columnName: "accountLevel"].ToString();
            }
            serverTimer = new System.Timers.Timer(60000);
            serverTimer.Elapsed += ServerTimerElapsed;
            serverTimer.AutoReset = true;
            serverTimer.Enabled = true;

            serverTimer.Start();

            FormClosing += new FormClosingEventHandler(OnFormClosing);
            
            if (accLevel != "1")
            {
                ManageAccoountFormButton.Visible = true;
                Application.DoEvents();
            }
            if(username != null)
            {
                UsernameLabel.Text = "Welcome " + username.ToUpper();
            }
            LoadForm(new HomeForm());
            BtnDefaultColors();
            HomeFormButton.BackColor = SystemColors.ActiveBorder;
        }
        private void ServerTimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            CheckServerStatus();
            if(isServerDown != true)
            {
                CheckAccountStatus();
                CheckLoginStatus();
            }
            
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
                    isServerDown = true;
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

        private void CheckLoginStatus()
        {
            DataTable? table = new();

            MySqlDataAdapter adapter = new();
            MySqlCommand command = new(dbQuery.CheckLoginStatus(), dbConn.getConnection());

            command.Parameters.AddWithValue("@p0", userID);

            adapter.SelectCommand = command;

            adapter.Fill(table);

            var isEnabled = table.Rows[0][columnName: "isLoggedIn"].ToString();

            if (isEnabled == "0")
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke(new Action(() =>
                    {
                        serverTimer.Stop();
                        Logout();
                        MessageBox.Show("Your account has been Logged Out, Please Login again.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                }
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

        private void OnFormClosing(object? sender, FormClosingEventArgs e)
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
        public void LoadForm(object? Form)
        {
            if (this.MainPanel.Controls.Count > 0)
                this.MainPanel.Controls.RemoveAt(0);
            if (Form != null)
            {
                Form f = (Form)Form;
                if (f != null)
                {
                    f.TopLevel = false;
                    f.Dock = DockStyle.Fill;
                    this.MainPanel.Controls.Add(f);
                    this.MainPanel.Tag = f;
                    f.Show();
                }
            }
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Logout?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (username != null && userID != null)
                {
                    dbConn.openConnection();
                    MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), dbConn.getConnection());
                    mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = username.ToLower() + " has logged out";
                    mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = userID;
                    mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = null;
                    mscEventLog.ExecuteNonQuery();
                    dbConn.closeConnection();
                }
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
            if (retrievedTable != null && retrievedTable.Rows.Count > 0)
            {
                string userID = retrievedTable.Rows[0][columnName: "userID"]?.ToString()!;

                if (userID != null)
                {
                    DBConn dbConn = new();
                    DBQuery dbQuery = new DBQuery();

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
            HolidaysButton.BackColor = SystemColors.ActiveCaption;
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
            LoadForm(new TicketsDTRForm());
            BtnDefaultColors();
            TicketsFormButton.BackColor = SystemColors.ActiveBorder;
        }

        private void MenuForm_Enter(object sender, EventArgs e)
        {
            LoadForm(new HomeForm());
        }

        private void HolidaysButton_Click(object sender, EventArgs e)
        {
            LoadForm(new HolidaysForm());
            BtnDefaultColors();
            HolidaysButton.BackColor = SystemColors.ActiveBorder;
        }
    }
}
