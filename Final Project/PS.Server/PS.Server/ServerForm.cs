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
            serverTimer.Start();

            logsTimer = new System.Timers.Timer(10000);
            logsTimer.Elapsed += LogsTimerElapsed;
            logsTimer.AutoReset = true;

            loadingTimer = new System.Timers.Timer(10000);
            loadingTimer.Elapsed += LoadingTimerElapsed;
            loadingTimer.Start();

            dbConn.openConnection();
            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscSearchAcc;
            mscSearchAcc = new(dbQuery.CheckServerStatus(), dbConn.getConnection());
            mscAdapter.SelectCommand = mscSearchAcc;
            mscAdapter.Fill(dtServerStatus);

            dbConn.closeConnection();
        }
        private void ServerForm_Load(object? sender, EventArgs e)
        {
            formLoaded = true;
            GetTotalNumberOfLogs();
        }
        private void ServerTimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {

            PayslipGenerator();
            GetAllUserID();
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
            if(dtServerStatus != null)
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
            GetAllUserID();
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
            logsTimer.Start();
            loadingTimer.Stop();
        }
        private void PayslipGenerator()
        {

            dbConn.openConnection();
            try
            {
                MySqlCommand mscServerCheck = new(dbQuery.PayslipGenerator(), dbConn.getConnection());
                int rowsAffected = mscServerCheck.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                dbConn.closeConnection();
            }
        }
        private void GetAllUserID()
        {
            if(dtUserID != null)
            { 
                dtUserID.Rows.Clear();
            }

            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscSearchAcc;
            mscSearchAcc = new(dbQuery.GetAllUserID(), dbConn.getConnection());
            if (mscAdapter != null && mscSearchAcc != null)
            {
                mscAdapter.SelectCommand = mscSearchAcc;
                if (dtUserID != null)
                {
                    mscAdapter.SelectCommand = mscSearchAcc;
                    if (dtUserID.Rows != null)
                    {
                        mscAdapter.Fill(dtUserID);
                    }
                }
            }

        }
        private void GeneratePayslipDetails()
        {
            try
            {
                dbConn.openConnection();
                if (dtUserID != null)
                {
                    foreach (DataRow row in dtUserID.Rows)
                    {
                        int userID = Convert.ToInt32(row["userID"]);
                        MySqlCommand mscGeneratePayslipDet = new MySqlCommand(dbQuery.GeneratePayslipDetails(), dbConn.getConnection());
                        mscGeneratePayslipDet.Parameters.Clear();
                        mscGeneratePayslipDet.Parameters.Add("@p0", MySqlDbType.Int32).Value = userID;
                        int rowsAffected = mscGeneratePayslipDet.ExecuteNonQuery();
                    }
                }
            }
            catch
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
            try
            {
                dbConn.openConnection();

                MySqlCommand mscChangeServerStats = new MySqlCommand(dbQuery.ChangeServerStatus(), dbConn.getConnection());
                mscChangeServerStats.Parameters.Add("@p0", MySqlDbType.Int32).Value = 1;
                mscChangeServerStats.ExecuteNonQuery();

                dbConn.closeConnection();

                dbConn.openConnection();

                MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), dbConn.getConnection());
                mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = "Server Started";
                mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = null;
                mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = 1;
                mscEventLog.ExecuteNonQuery();

                dbConn.closeConnection();
            }
            catch
            {
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
            try
            {
                dbConn.openConnection();

                MySqlCommand mscChangeServerStats = new MySqlCommand(dbQuery.ChangeServerStatus(), dbConn.getConnection());
                mscChangeServerStats.Parameters.Add("@p0", MySqlDbType.Int32).Value = 0;
                mscChangeServerStats.ExecuteNonQuery();

                dbConn.closeConnection();

                dbConn.openConnection();

                MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), dbConn.getConnection());
                mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = "Server Terminated";
                mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = null;
                mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = 1;
                mscEventLog.ExecuteNonQuery();

                dbConn.closeConnection();
            }
            catch
            {
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
                dbConn.openConnection();

                MySqlCommand mscChangeServerStats = new MySqlCommand(dbQuery.GetTotalNumberOfLogs(), dbConn.getConnection());
                newTotalLog = Convert.ToInt32(mscChangeServerStats.ExecuteScalar());

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                dbConn.closeConnection();
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
                        dbConn.openConnection();
                        MySqlDataAdapter? msdEventLog = new();
                        MySqlCommand? mscEventLog;
                        mscEventLog = new(dbQuery.CallEventLogs(), dbConn.getConnection());
                        msdEventLog.SelectCommand = mscEventLog;
                        msdEventLog.Fill(dtEventLogs);
                        dbConn.closeConnection();

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
                    catch
                    {
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
            MySqlCommand mscUpdateDTRTotalHours = new(dbQuery.GenerateDTRTotalHours(), dbConn.getConnection());
            dbConn.openConnection();
            try
            {
                int rowsAffected = mscUpdateDTRTotalHours.ExecuteNonQuery();
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

        private void FillPayrollDetail()
        {
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("yyyy-MM-dd");
            try
            {
                dbConn.openConnection();
                if (dtUserID != null)
                {

                    foreach (DataRow row in dtUserID.Rows)
                    {
                        int userID = Convert.ToInt32(row["userID"]);
                        MySqlCommand mscGeneratePayslipDet = new MySqlCommand(dbQuery.FillPayrollDetail(), dbConn.getConnection());
                        mscGeneratePayslipDet.Parameters.Clear();
                        mscGeneratePayslipDet.Parameters.AddWithValue("@p0", userID);
                        mscGeneratePayslipDet.Parameters.AddWithValue("@p1", formattedDate);

                        try
                        {
                            int rowsAffected = mscGeneratePayslipDet.ExecuteNonQuery();
                        }
                        catch
                        {
                        }
                    }
                }
                dbConn.closeConnection();
            }
            catch
            {
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PayslipGenerator();
            GetAllUserID();
            GeneratePayslipDetails();
            GetTotalNumberOfLogs();
            if (newTotalLog > storedTotalLog)
            {
                EventLog();
                storedTotalLog = newTotalLog;
            }
            GenerateDTRTotalHours();
            FillPayrollDetail();
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
                if (txtStatus.Text == "RUNNING")
                {
                    if (MessageBox.Show("Do you want to Terminate the Server first?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        TerminateServer();
                    }
                }
                isServerTerminated = true;
                Application.Exit();
            }
            ScrollToBottom();
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
                dbConn.openConnection();
                MySqlCommand mscClockIn = new(dbQuery.LogoutAll(), dbConn.getConnection());
                mscClockIn.ExecuteNonQuery();

                MySqlCommand mscEventLog = new MySqlCommand(dbQuery.EventLog(), dbConn.getConnection());
                mscEventLog.Parameters.Add("@p0", MySqlDbType.VarChar).Value = "Logging out all users";
                mscEventLog.Parameters.Add("@p1", MySqlDbType.VarChar).Value = null;
                mscEventLog.Parameters.Add("@p2", MySqlDbType.VarChar).Value = 1;
                mscEventLog.ExecuteNonQuery();

                EventLog();
                GetTotalNumberOfLogs();
                storedTotalLog = newTotalLog;
                dbConn.closeConnection();
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
