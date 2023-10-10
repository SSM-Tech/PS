using MySql.Data.MySqlClient;
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
        DataTable? allAccDet = new DataTable();
        DBConn dbConn = new();
        DBQuery dbQuery = new DBQuery();
        private string selectedStaffID;

        public ManageAccountForm()
        {
            InitializeComponent();
            ShowAccounts();
        }

        private void ShowAccounts()
        {
            allAccDet.Rows.Clear();

            string managerID = retrievedTable.Rows[0][columnName: "ownManagerID"].ToString();

            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscUserDetail;

            if (retrievedTable.Rows[0][columnName: "accountLevel"].ToString() == "3")
            {
                mscUserDetail = new(dbQuery.GetAllAccountDetailsForLVL3(), dbConn.getConnection());
                mscUserDetail.ExecuteReaderAsync();
                mscAdapter.SelectCommand = mscUserDetail;
                mscAdapter.Fill(allAccDet);
            }
            else
            {
                mscUserDetail = new(dbQuery.GetAllAccountDetailsForLVL2(), dbConn.getConnection());
                mscUserDetail.Parameters.Add("@p0", MySqlDbType.VarChar).Value = managerID;
                mscAdapter.SelectCommand = mscUserDetail;
                mscAdapter.Fill(allAccDet);
            }
            FillDGV();
        }
        private void FillDGV()
        {
            userDatasGrid.DataSource = allAccDet;
            userDatasGrid.Columns["Staff_ID"].Width = 75;
            userDatasGrid.Columns["Locked"].Width = 75;
            userDatasGrid.Columns["Staff_ID"].Width = 80;
            userDatasGrid.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            userDatasGrid.Columns["Firstname"].Width = 150;
            userDatasGrid.Columns["Lastname"].Width = 150;
            userDatasGrid.Columns["Position"].Width = 150;
        }
        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchAccount();
        }

        private void userDatasGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = userDatasGrid.Rows[e.RowIndex];

                selectedStaffID = selectedRow.Cells[0].Value?.ToString();
            }
        }
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if(selectedStaffID != null)
            {
                ManageAccountEditForm manageAccountEditForm = new ManageAccountEditForm();
                manageAccountEditForm.selectedStaffID = selectedStaffID;
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
            accountRegisterForm.RegistrationSuccess += AccountRegisterForm_RegistrationSuccess;
            accountRegisterForm.ShowDialog();
        }
        private void AccountRegisterForm_RegistrationSuccess(object sender, EventArgs e)
        {
            ShowAccounts();
        }
        private void SearchAccount()
        {
            allAccDet.Rows.Clear();
            string managerID = retrievedTable.Rows[0][columnName: "ownManagerID"].ToString();
            string search = txtBoxSearch.Text;
            MySqlDataAdapter? mscAdapter = new();

            MySqlCommand? mscSearchAcc;

            FillDGV();
            if (retrievedTable.Rows[0][columnName: "accountLevel"].ToString() == "3")
            {
                mscSearchAcc = new(dbQuery.GetSearchAccForLvl3(), dbConn.getConnection());
                mscSearchAcc.Parameters.Add("@p0", MySqlDbType.VarChar).Value = search;
                mscAdapter.SelectCommand = mscSearchAcc;
                mscAdapter.Fill(allAccDet);
            }
            else
            {
                mscSearchAcc = new(dbQuery.GetSearchAccForLvl2(), dbConn.getConnection());
                mscSearchAcc.Parameters.Add("@p0", MySqlDbType.VarChar).Value = search;
                mscSearchAcc.Parameters.Add("@p1", MySqlDbType.VarChar).Value = managerID;
                mscAdapter.SelectCommand = mscSearchAcc;
                mscAdapter.Fill(allAccDet);
            }
            FillDGV();
        }
    }
}
