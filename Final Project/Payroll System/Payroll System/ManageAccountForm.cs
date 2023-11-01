﻿using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
    public partial class ManageAccountForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;
        int? selectedStaffID = UserDetails.SelectedStaffID;
        DataTable? allAccDet = new DataTable();
        DBConn dbConn = new();
        DBQuery dbQuery = new DBQuery();
        private string cellValue;

        public ManageAccountForm()
        {
            InitializeComponent();
            ShowAccounts();
        }

        private void ShowAccounts()
        {
            allAccDet.Rows.Clear();

            string search = txtBoxSearch.Text;
            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscSearchAcc;
            mscSearchAcc = new(dbQuery.GetUserAcc(), dbConn.getConnection());
            mscSearchAcc.Parameters.Add("@p0", MySqlDbType.VarChar).Value = search;
            mscAdapter.SelectCommand = mscSearchAcc;
            mscAdapter.Fill(allAccDet);
            FillDGV();
        }
        private void FillDGV()
        {
            userDatasGrid.DataSource = allAccDet;
            var dgvStaffIDColum = userDatasGrid.Columns["Staff_ID"];
            dgvStaffIDColum.HeaderText = "Staff ID";
            dgvStaffIDColum.Width = 75;
            userDatasGrid.Columns["Locked"].Width = 75;
            userDatasGrid.Columns["Username"].Width = 400;
            userDatasGrid.Columns["Firstname"].Width = 150;
            userDatasGrid.Columns["Lastname"].Width = 150;
            userDatasGrid.Columns["Position"].Width = 150;
            var dgvStationNoColum = userDatasGrid.Columns["Station_No"];
            dgvStationNoColum.HeaderText = "Station No";
            dgvStationNoColum.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            ShowAccounts();
        }

        private void userDatasGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = userDatasGrid.Rows[e.RowIndex];
                cellValue = selectedRow.Cells[0].Value?.ToString();
                if (!string.IsNullOrEmpty(cellValue) && int.TryParse(cellValue, out int selectedStaffID))
                {
                    UserDetails.SelectedStaffID = selectedStaffID;
                }
                else
                {
                    MessageBox.Show("Invalid or empty cell value.", "Error");
                }
            }
        }
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (cellValue != null)
            {
                ManageAccountEditForm manageAccountEditForm = new ManageAccountEditForm();
                manageAccountEditForm.Success += Success;
                manageAccountEditForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a row first");
            }
        }
        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            AccountRegisterForm accountRegisterForm = new AccountRegisterForm();
            accountRegisterForm.Success += Success;
            accountRegisterForm.ShowDialog();
        }
        private void Success(object sender, EventArgs e)
        {
            ShowAccounts();
        }

        private void userDatasGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string targetColumnName = "Locked";

                if (userDatasGrid.Columns[e.ColumnIndex].Name == targetColumnName)
                {
                    if (e.Value != null && int.TryParse(e.Value.ToString(), out int cellValue) && cellValue == 0)
                    {
                        e.Value = "Yes";
                        e.FormattingApplied = true;
                    }
                    else
                    {
                        e.Value = "No";
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBoxSearch.Text = "";
            searchPlaceholder.Show();
        }

        private void txtBoxSearch_Enter(object sender, EventArgs e)
        {
            searchPlaceholder.Hide();
            txtBoxSearch.SelectAll();
        }

        private void txtBoxSearch_Leave(object sender, EventArgs e)
        {
            if (txtBoxSearch.Text == "")
            {
                searchPlaceholder.Show();
            }
        }

        private void searchPlaceholder_Click(object sender, EventArgs e)
        {
            txtBoxSearch.Focus();
        }
    }
}