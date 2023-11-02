using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Payroll_System
{
    public partial class ServerForm : Form
    {
        DBConn dbConn = new();
        DBQuery dbQuery = new();
        DataTable? dtUserID = new();
        DataTable? dtServerStatus = new();
        DataTable? dtEventLogs = new();
        private System.Timers.Timer serverTimer;
        private System.Timers.Timer logsTimer;
        private bool formLoaded = false;
        public ServerForm()
        {
            InitializeComponent();
            this.Load += ServerForm_Load;
            serverTimer = new System.Timers.Timer(3600000);
            serverTimer.Elapsed += ServerTimerElapsed;
            serverTimer.AutoReset = true;
            serverTimer.Start();

            logsTimer = new System.Timers.Timer(10000);
            logsTimer.Elapsed += LogsTimerElapsed;
            logsTimer.AutoReset = true;
            logsTimer.Start();

            dtServerStatus.Rows.Clear();

            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscSearchAcc;
            mscSearchAcc = new(dbQuery.CheckServerStatus(), dbConn.getConnection());
            mscAdapter.SelectCommand = mscSearchAcc;
            mscAdapter.Fill(dtServerStatus);

            int serverStatus = (int)dtServerStatus.Rows[0][columnName: "status"];

            if (serverStatus == 1)
            {
                ServerStarted();
            }
            else
            {
                ServerTerminated();
            }
            PayslipGenerator();
            GetAllUserID();
            GeneratePayslipDetails();
            EventLog();
        }
        private void ServerForm_Load(object sender, EventArgs e)
        {
            formLoaded = true;
            EventLog();
        }
        private void ServerTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            PayslipGenerator();
            GetAllUserID();
            GeneratePayslipDetails();
        }
        private void LogsTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            EventLog();
        }
        private void PayslipGenerator()
        {
            MySqlCommand mscServerCheck = new(dbQuery.PayslipGenerator(), dbConn.getConnection());
            dbConn.openConnection();
            try
            {
                int rowsAffected = mscServerCheck.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing the query: " + ex.Message);
            }
            finally
            {
                dbConn.closeConnection();
            }
        }
        private void GetAllUserID()
        {
            dtUserID.Rows.Clear();

            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscSearchAcc;
            mscSearchAcc = new(dbQuery.GetAllUserID(), dbConn.getConnection());
            mscAdapter.SelectCommand = mscSearchAcc;
            mscAdapter.Fill(dtUserID);
        }
        private void GeneratePayslipDetails()
        {
            try
            {
                dbConn.openConnection();

                foreach (DataRow row in dtUserID.Rows)
                {
                    int userID = Convert.ToInt32(row["userID"]);
                    MySqlCommand mscGeneratePayslipDet = new MySqlCommand(dbQuery.GeneratePayslipDetails(), dbConn.getConnection());
                    mscGeneratePayslipDet.Parameters.Clear();
                    mscGeneratePayslipDet.Parameters.Add("@p0", MySqlDbType.Int32).Value = userID;

                    try
                    {
                        int rowsAffected = mscGeneratePayslipDet.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                        }
                        else
                        {
                        }
                    }
                    catch (MySqlException ex)
                    {
                    }
                }
            }
            catch (MySqlException ex)
            {
            }
            catch (Exception ex)
            {
            }
            finally
            {
                dbConn.closeConnection();
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Run the Server?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                StartServer();
                ServerStarted();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Terminate the Server?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                TerminateServer();
                ServerTerminated();
            }
        }
        private void StartServer()
        {
            dbConn.openConnection();

            MySqlCommand mscChangeServerStats = new MySqlCommand(dbQuery.ChangeServerStatus(), dbConn.getConnection());
            mscChangeServerStats.Parameters.Add("@p0", MySqlDbType.Int32).Value = 1;
            mscChangeServerStats.ExecuteNonQuery();

            MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), dbConn.getConnection());
            mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = "Server Started";
            mscEventLog.ExecuteNonQuery();

            dbConn.closeConnection();

            EventLog();
        }
        private void ServerStarted()
        {
            txtStatus.ForeColor = System.Drawing.Color.Lime;
            btnStart.BackColor = System.Drawing.Color.Gray;
            btnStop.BackColor = System.Drawing.Color.Red;
            txtStatus.Text = "RUNNING";
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }
        private void TerminateServer()
        {
            dbConn.openConnection();

            MySqlCommand mscChangeServerStats = new MySqlCommand(dbQuery.ChangeServerStatus(), dbConn.getConnection());
            mscChangeServerStats.Parameters.Add("@p0", MySqlDbType.Int32).Value = 0;
            mscChangeServerStats.ExecuteNonQuery();

            MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), dbConn.getConnection());
            mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = "Server Terminated";
            mscEventLog.ExecuteNonQuery();

            dbConn.closeConnection();

            EventLog();
        }
        private void ServerTerminated()
        {
            txtStatus.ForeColor = System.Drawing.Color.Red;
            btnStart.BackColor = System.Drawing.Color.Lime;
            btnStop.BackColor = System.Drawing.Color.Gray;
            txtStatus.Text = "TERMINATED";
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
        private void EventLog()
        {
            if (!formLoaded)
            {
                return;
            }

            dtEventLogs.Rows.Clear();
            dbConn.openConnection();
            MySqlDataAdapter? msdEventLog = new();

            MySqlCommand? mscEventLog;
            mscEventLog = new(dbQuery.CallEventLog(), dbConn.getConnection());
            msdEventLog.SelectCommand = mscEventLog;
            msdEventLog.Fill(dtEventLogs);
            dbConn.closeConnection();

            richTextBox1.Invoke((MethodInvoker)delegate
            {
                richTextBox1.Clear();
                foreach (DataRow row in dtEventLogs.Rows)
                {
                    string dateTime = Convert.ToString(row["eventDateTime"]);
                    if (DateTime.TryParse(dateTime, out DateTime parsedDateTime))
                    {
                        string formattedDate = parsedDateTime.ToString("MM/dd/yyyy");
                        string eventDescription = Convert.ToString(row["eventDescription"]);
                        richTextBox1.AppendText($"> {formattedDate}\t: {eventDescription}" + Environment.NewLine);
                    }
                }
            });
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PayslipGenerator();
            GetAllUserID();
            GeneratePayslipDetails();
            EventLog();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit the Server?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (txtStatus.Text == "RUNNING")
                {
                    if (MessageBox.Show("Do you want to Terminate the Server first?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        TerminateServer();
                    }
                }
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}
