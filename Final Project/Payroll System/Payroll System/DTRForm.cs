using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        private bool formLoaded = false;
        public DTRForm()
        {
            InitializeComponent();
            formLoaded = true;
            ShowDTR();

        }

        private void ShowDTR()
        {
            if (!formLoaded)
            {
                return;
            }
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

            dgvDTR.Columns["clockedIn"].Visible = false;
            dgvDTR.Columns["clockedOut"].Visible = false;

            var dtrDateColumn = dgvDTR.Columns["dtrDate"];
            dtrDateColumn.DefaultCellStyle.Format = "MM/dd/yyyy , dddd";
            dtrDateColumn.HeaderText = "Date";
            dtrDateColumn.Width = 900;

            var dtrClockInColumn = dgvDTR.Columns["clockintime"];
            dtrClockInColumn.HeaderText = "Clock In";
            dtrClockInColumn.DefaultCellStyle.Format = "h:mm:ss tt";
            dtrClockInColumn.Width = 100;

            var dtrClockOutColumn = dgvDTR.Columns["clockouttime"];
            dtrClockOutColumn.HeaderText = "Clock Out";
            dtrClockOutColumn.DefaultCellStyle.Format = "h:mm:ss tt";
            dtrClockOutColumn.Width = 100;

            var dtrTotalHoursColumn = dgvDTR.Columns["totalHours"];
            dtrTotalHoursColumn.HeaderText = "Total Hours";
            dtrTotalHoursColumn.DefaultCellStyle.Format = "HH:mm:ss";
            dtrTotalHoursColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvDTR.RowPrePaint += dgvDTR_RowPrePaint;
            dgvDTR.ClearSelection();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            ShowDTR();
        }

        private void dgvDTR_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                dgvDTR.Columns[e.ColumnIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void dgvDTR_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                dgvDTR.Columns[e.ColumnIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void dgvDTR_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDTR.Rows[e.RowIndex];
                if (row.Cells["dtrDate"].Value != null && row.Cells["dtrDate"].Value is DateTime date)
                {
                    if (date.DayOfWeek == DayOfWeek.Sunday)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = dgvDTR.DefaultCellStyle.BackColor;
                    }
                }
            }
        }

        private void dgvDTR_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            e.ToolTipText = "";
        }

        private void dgvDTR_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvDTR.Columns[e.ColumnIndex].Name == "totalHours")
            {
                if (e.Value != null && e.Value is decimal)
                {
                    decimal decimalValue = (decimal)e.Value;
                    // Convert the decimal to a TimeSpan
                    TimeSpan timeSpan = TimeSpan.FromHours((double)decimalValue);
                    // Convert the TimeSpan to a DateTime (assuming today's date)
                    DateTime dateTime = DateTime.Today.Add(timeSpan);
                    // Format the DateTime as a 24-hour time string
                    e.Value = dateTime.ToString("HH:mm:ss");
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
