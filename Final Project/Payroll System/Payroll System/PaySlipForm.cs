using Google.Protobuf.WellKnownTypes;
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
    public partial class PaySlipForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;
        DataTable? dtPayslip = new();
        DBConn dbConn = new();
        DBQuery dbQuery = new();
        private bool formLoaded = false;
        private string cellValue;
        public PaySlipForm()
        {
            InitializeComponent();
            formLoaded = true;
            ShowPayslip();
            foreach (DataGridViewColumn column in dgvPayslip.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void ShowPayslip()
        {
            if (!formLoaded)
            {
                return;
            }
            dtPayslip.Rows.Clear();

            string userID = retrievedTable.Rows[0][columnName: "userID"].ToString();
            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscGetPayslip;
            mscGetPayslip = new(dbQuery.GetPayslip(), dbConn.getConnection());
            mscGetPayslip.Parameters.Add("@p0", MySqlDbType.VarChar).Value = userID;
            mscAdapter.SelectCommand = mscGetPayslip;
            mscAdapter.Fill(dtPayslip);

            FilldgvPayslip();
        }
        private void FilldgvPayslip()
        {
            dgvPayslip.DataSource = dtPayslip;

            dgvPayslip.Columns["payslipID"].Visible = false;
            dgvPayslip.Columns["payslipDetailID"].Visible = false;
            dgvPayslip.Columns["userID"].Visible = false;
            dgvPayslip.Columns["subtotal"].Visible = false;
            dgvPayslip.Columns["allowance"].Visible = false;
            dgvPayslip.Columns["deduction"].Visible = false;

            var payslipCombinedColumn = dgvPayslip.Columns["combined_column"];
            payslipCombinedColumn.HeaderText = "Payslip ID";
            payslipCombinedColumn.Width = 200;

            var payslipStartDateColumn = dgvPayslip.Columns["startDate"];
            payslipStartDateColumn.DefaultCellStyle.Format = "MM/dd/yyyy";
            payslipStartDateColumn.HeaderText = "Start Date";
            payslipStartDateColumn.Width = 200;

            var payslipEndDateColumn = dgvPayslip.Columns["endDate"];
            payslipEndDateColumn.DefaultCellStyle.Format = "MM/dd/yyyy";
            payslipEndDateColumn.HeaderText = "End Date";
            payslipEndDateColumn.Width = 200;

            var payslipTotalHours = dgvPayslip.Columns["totalHours"];
            payslipTotalHours.HeaderText = "Total Hours";
            payslipTotalHours.DefaultCellStyle.Format = "HH:mm:ss";
            payslipTotalHours.Width = 200;

            var payslipTotalSalary = dgvPayslip.Columns["totalSalary"];
            payslipTotalSalary.HeaderText = "Total Salary in Php";
            payslipTotalSalary.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (cellValue != null)
            {
                ViewPayslipForm viewPayslipForm = new ViewPayslipForm();
                viewPayslipForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a row first");
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowPayslip();
        }

        private void dgvPayslip_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvPayslip.Columns[e.ColumnIndex].Name == "totalHours")
            {
                if (e.Value != null && e.Value is decimal)
                {
                    decimal decimalValue = (decimal)e.Value;
                    int hours = (int)decimalValue;
                    decimal minutesDecimal = (decimalValue - hours) * 60;
                    int minutes = (int)minutesDecimal;
                    int seconds = (int)((minutesDecimal - minutes) * 60);

                    e.Value = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
                    e.FormattingApplied = true;
                }
            }
        }

        private void dgvPayslip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvPayslip.Rows[e.RowIndex];
                cellValue = selectedRow.Cells[1].Value?.ToString();
                if (!string.IsNullOrEmpty(cellValue) && int.TryParse(cellValue, out int selectedPayslipID))
                {
                    UserDetails.SelectedPayslipID = selectedPayslipID;
                }
                else
                {
                    MessageBox.Show("Invalid or empty cell value.", "Error");
                }
            }
        }
    }
}
