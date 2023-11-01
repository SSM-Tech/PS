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

namespace Payroll_System
{
    public partial class DTRForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;
        DataTable? dtDTR = new();
        DBConn dbConn = new();
        DBQuery dbQuery = new();
        public DTRForm()
        {
            InitializeComponent();
            ShowDTR();
        }

        private void ShowDTR()
        {
            dtDTR.Rows.Clear();

            string userID = retrievedTable.Rows[0][columnName: "userID"].ToString();
            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscGetDTR;
            mscGetDTR = new(dbQuery.GetUserDTR(), dbConn.getConnection());
            mscGetDTR.Parameters.Add("@p0", MySqlDbType.VarChar).Value = userID;
            mscAdapter.SelectCommand = mscGetDTR;
            mscAdapter.Fill(dtDTR);
            FilldgvDTR();
        }

        private void FilldgvDTR()
        {
            dgvDTR.DataSource = dtDTR;
            var dtrDateColumn = dgvDTR.Columns["dtrDate"];
            dtrDateColumn.HeaderText = "Date";
            dtrDateColumn.Width = 900;
            var dtrClockInColumn = dgvDTR.Columns["clockintime"];
            dtrClockInColumn.HeaderText = "Clock In";
            dtrClockInColumn.Width = 100;
            var dtrClockOutColumn = dgvDTR.Columns["clockouttime"];
            dtrClockOutColumn.HeaderText = "Clock Out";
            dtrClockOutColumn.Width = 100;
            var dtrTotalHoursColumn = dgvDTR.Columns["totalHours"];
            dtrTotalHoursColumn.HeaderText = "Total Hours";
            dtrTotalHoursColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            ShowDTR();
        }
    }
}
