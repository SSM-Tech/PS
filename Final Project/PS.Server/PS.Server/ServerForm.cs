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

namespace PS.Server
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
        private System.Timers.Timer loadingTimer;
        private bool formLoaded = false;
        private bool isServerTerminated = false;
        private int storedTotalLog = 0;
        private int newTotalLog = 1;
        public ServerForm()
        {
            InitializeComponent();
            this.Load += ServerForm_Load;
            serverTimer = new System.Timers.Timer(3600000);
            serverTimer.Elapsed += ServerTimerElapsed;
            serverTimer.AutoReset = true;


            logsTimer = new System.Timers.Timer(10000);
            logsTimer.Elapsed += LogsTimerElapsed;
            logsTimer.AutoReset = true;

            loadingTimer = new System.Timers.Timer(10000);
            loadingTimer.Elapsed += LoadingTimerElapsed;
            loadingTimer.Start();

            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscSearchAcc;
            mscSearchAcc = new(dbQuery.CheckServerStatus(), dbConn.getConnection());
            mscAdapter.SelectCommand = mscSearchAcc;
            mscAdapter.Fill(dtServerStatus);

        }
        private void ServerForm_Load(object? sender, EventArgs e)
        {
            formLoaded = true;
            GetTotalNumberOfLogs();
        }
        private void ServerTimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            PayslipGenerator();
            GeneratePayslipDetails();
            GenerateDTRTotalHours();
            FillPayrollDetail();
        }
        private void LogsTimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            GetTotalNumberOfLogs();
            if (newTotalLog > storedTotalLog)
            {
                EventLog();
                storedTotalLog = newTotalLog;
            }
        }
        private void LoadingTimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            if (dtServerStatus != null)
            {
                int serverStatus = (int)dtServerStatus.Rows[0][columnName: "status"];

                if (serverStatus == 1)
                {
                    this.Invoke(new Action(ServerStarted));
                }
                else
                {
                    this.Invoke(new Action(ServerTerminated));
                }
            }

            PayslipGenerator();
            GeneratePayslipDetails();
            GenerateDTRTotalHours();
            FillPayrollDetail();
            this.Invoke(new Action(ScrollToBottom));
            btnRefresh.Invoke((MethodInvoker)delegate
            {
                btnRefresh.Enabled = true;
                btnRefresh.BackColor = System.Drawing.Color.Yellow;
            });
            GetTotalNumberOfLogs();
            if (newTotalLog > storedTotalLog)
            {
                EventLog();
                storedTotalLog = newTotalLog;
            }
            serverTimer.Start();
            logsTimer.Start();
            loadingTimer.Stop();
        }
        private void PayslipGenerator()
        {
            try
            {
                using (MySqlConnection connection = dbConn.getConnection())
                {
                    connection.Open();

                    using (MySqlCommand mscPayslipGenerator = new(dbQuery.PayslipGenerator(), connection))
                    {
                        mscPayslipGenerator.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GeneratePayslipDetails> " + ex.Message);
            }
        }
        private void GeneratePayslipDetails()
        {
            try
            {
                using (MySqlConnection connection = dbConn.getConnection())
                {
                    connection.Open();

                    using (MySqlCommand mscGeneratePayslipDet = new MySqlCommand(dbQuery.GeneratePayslipDetails(), connection))
                    {
                        mscGeneratePayslipDet.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GeneratePayslipDetails> " + ex.Message);
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Run the Server?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                StartServer();
                ServerStarted();
                GetTotalNumberOfLogs();
                storedTotalLog = newTotalLog;
            }
            ScrollToBottom();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Terminate the Server?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                TerminateServer();
                ServerTerminated();
                GetTotalNumberOfLogs();
                storedTotalLog = newTotalLog;
            }
            ScrollToBottom();
        }
        private void StartServer()
        {
            using (MySqlConnection connection = dbConn.getConnection())
            {
                connection.Open();

                using (MySqlCommand mscChangeServerStats = new MySqlCommand(dbQuery.ChangeServerStatus(), connection))
                {
                    mscChangeServerStats.Parameters.Add("@p0", MySqlDbType.Int32).Value = 1;
                    mscChangeServerStats.ExecuteNonQuery();
                }
                using (MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), connection))
                {
                    mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = "Server Started";
                    mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = 0;
                    mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = 1;
                    mscEventLog.ExecuteNonQuery();
                }
            }
            EventLog();
        }
        private void ServerStarted()
        {
            txtStatus.ForeColor = System.Drawing.Color.Lime;
            btnStart.BackColor = System.Drawing.Color.Gray;
            btnStop.BackColor = System.Drawing.Color.Red;
            btnExit.BackColor = System.Drawing.Color.Gray;
            btnLogoffAll.BackColor = System.Drawing.Color.Red;
            txtStatus.Text = "RUNNING";
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnExit.Enabled = false;
            btnLogoffAll.Enabled = true;
        }
        private void TerminateServer()
        {
            using (MySqlConnection connection = dbConn.getConnection())
            {
                connection.Open();

                using (MySqlCommand mscChangeServerStats = new MySqlCommand(dbQuery.ChangeServerStatus(), connection))
                {
                    mscChangeServerStats.Parameters.Add("@p0", MySqlDbType.Int32).Value = 0;
                    mscChangeServerStats.ExecuteNonQuery();
                }

                using (MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), connection))
                {
                    mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = "Server Terminated";
                    mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = 0;
                    mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = 1;
                    mscEventLog.ExecuteNonQuery();
                }
            }
            EventLog();
        }
        private void ServerTerminated()
        {
            txtStatus.ForeColor = System.Drawing.Color.Red;
            btnStart.BackColor = System.Drawing.Color.Lime;
            btnStop.BackColor = System.Drawing.Color.Gray;
            btnExit.BackColor = System.Drawing.Color.Red;
            btnLogoffAll.BackColor = System.Drawing.Color.Gray;
            txtStatus.Text = "TERMINATED";
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnExit.Enabled = true;
            btnLogoffAll.Enabled = false;
        }
        private void GetTotalNumberOfLogs()
        {
            try
            {
                using (MySqlConnection connection = dbConn.getConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(dbQuery.GetTotalNumberOfLogs(), connection))
                    {
                        newTotalLog = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in GetTotalNumberOfLogs(): {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EventLog()
        {
            if (!formLoaded)
            {
                return;
            }

            int maxRetries = 3;
            int retryCount = 0;

            while (retryCount < maxRetries)
            {
                if (dtEventLogs != null)
                {
                    try
                    {
                        dtEventLogs.Rows.Clear();

                        MySqlDataAdapter? msdEventLog = new();
                        MySqlCommand? mscEventLog = new();

                        using (MySqlConnection connection = dbConn.getConnection())
                        {
                            connection.Open();

                            using (mscEventLog = new(dbQuery.CallEventLogs(), connection))
                            {
                                msdEventLog.SelectCommand = mscEventLog;
                                msdEventLog.Fill(dtEventLogs);
                            }
                        }

                        richTextBox1.Invoke((MethodInvoker)delegate
                        {
                            richTextBox1.Clear();
                            foreach (DataRow row in dtEventLogs.Rows)
                            {
                                string? dateTime = Convert.ToString(row["eventDateTime"]);
                                if (DateTime.TryParse(dateTime, out DateTime parsedDateTime))
                                {
                                    string formattedDate = parsedDateTime.ToString("MMM. dd, hh:mm:ss tt");
                                    string? eventDescription = Convert.ToString(row["eventDescription"]);
                                    richTextBox1.AppendText($"PS Server> {formattedDate}>> {eventDescription}" + Environment.NewLine);
                                }
                            }
                        });

                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("EventLog> " + ex.Message);

                        retryCount++;
                        Thread.Sleep(1000);
                    }
                }
            }
            if (retryCount == maxRetries)
            {
                MessageBox.Show("All retry attempts failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerateDTRTotalHours()
        {
            try
            {
                using(MySqlConnection connection = dbConn.getConnection())
                {
                    connection.Open();

                    using (MySqlCommand mscUpdateDTRTotalHours = new(dbQuery.GenerateDTRTotalHours(), connection))
                    {
                        mscUpdateDTRTotalHours.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GenerateDTRTotalHours>" + ex.Message);
            }
            finally
            {
            }
        }

        private void FillPayrollDetail()
        {
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("yyyy-MM-dd");
            if (dtUserID != null)
            {
                foreach (DataRow row in dtUserID.Rows)
                {
                    if (int.TryParse(row["userID"].ToString(), out int userID))
                    {
                        try
                        {
                            using (MySqlCommand mscGeneratePayslipDet = new MySqlCommand(dbQuery.FillPayrollDetail(), dbConn.getConnection()))
                            {
                                mscGeneratePayslipDet.Parameters.Clear();
                                mscGeneratePayslipDet.Parameters.AddWithValue("@p0", userID);
                                mscGeneratePayslipDet.Parameters.AddWithValue("@p1", formattedDate);

                                mscGeneratePayslipDet.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error processing userID {userID}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Invalid userID format: {row["userID"]}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PayslipGenerator();
            GeneratePayslipDetails();
            GenerateDTRTotalHours();
            FillPayrollDetail();

            GetTotalNumberOfLogs();
            if (newTotalLog > storedTotalLog)
            {
                EventLog();
                storedTotalLog = newTotalLog;
            }

            ScrollToBottom();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            ScrollToBottom();
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Exit the Server?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                isServerTerminated = true;
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (isServerTerminated)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnLogoffAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Logout all users?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                using (MySqlConnection connection = dbConn.getConnection())
                {
                    connection.Open();

                    using (MySqlCommand mscClockIn = new MySqlCommand(dbQuery.LogoutAll(), connection))
                    {
                        mscClockIn.ExecuteNonQuery();
                    }

                    using (MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), connection))
                    {
                        mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = "Logging out all users";
                        mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = 0;
                        mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = 1;
                        mscEventLog.ExecuteNonQuery();
                    }
                }


                EventLog();
                GetTotalNumberOfLogs();
                storedTotalLog = newTotalLog;
            }

            ScrollToBottom();
        }
        private void ScrollToBottom()
        {
            richTextBox1.ScrollToCaret();
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
        }
    }
}
