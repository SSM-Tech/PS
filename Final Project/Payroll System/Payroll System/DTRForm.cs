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
            var dtrDateColumn = dgvDTR.Columns["dtrDate"];
            dtrDateColumn.DefaultCellStyle.Format = "MM/dd/yyyy , dddd";
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
                        // Set the entire row's background color to red for Saturday
                        row.DefaultCellStyle.BackColor = Color.LightSalmon;
                    }
                    else
                    {
                        // Set the entire row's background color to its default color
                        row.DefaultCellStyle.BackColor = dgvDTR.DefaultCellStyle.BackColor;
                    }
                }
            }
        }
    }
}
