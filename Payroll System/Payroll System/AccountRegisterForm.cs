﻿using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Payroll_System
{
    public partial class AccountRegisterForm : Form
    {
        bool registerWasSuccessful;
        public event EventHandler Success;

        DBConn dbConn = new();
        DBQuery dbQuery = new DBQuery();
        DataTable? retrievedTable = UserDetails.UserDetail;
        DataTable? managerNames = new DataTable();
        MySqlDataAdapter? adapter = new();
        static Random random = new Random();

        public AccountRegisterForm()
        {
            InitializeComponent();
            cBGender.SelectedIndex = 0;
            cBAccResLVL.SelectedIndex = 0;
            txtBDOB.Text = dTPBOD.Value.ToString("MM/dd/yyyy");
        }
        static string GenerateRandomPassword(int minLength, int maxLength)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int length = random.Next(minLength, maxLength);
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }
        public string AccountLevel(string selectedItem)
        {
            switch (selectedItem)
            {
                case "Level 1":
                    return "1";
                case "Level 2":
                    return "2";
                default:
                    return "1";
            }
        }

        private void Register()
        {
            string stationNo = txtBStationNo.Text;
            string firstname = txtBFirstname.Text;
            string lastname = txtBLastname.Text;
            string username = $"{firstname.Replace(" ", "").ToLower()}.{lastname.Replace(" ", "").ToLower()}";
            string password = GenerateRandomPassword(5, 5);
            string gender = cBGender.SelectedItem.ToString();
            string accountLevel = AccountLevel(cBAccResLVL.SelectedItem.ToString());
            DateTime dob = dTPBOD.Value;
            string position = txtBPosition.Text;
            decimal salary = decimal.Parse(txtBSalary.Text);
            decimal allowance = decimal.Parse(txtBSalary.Text);
            using (MySqlConnection dbConnection = dbConn.getConnection())
            {
                dbConnection.Open();

                using (MySqlCommand regCommand = new MySqlCommand(dbQuery.RegisterAccount(), dbConnection))
                {
                    regCommand.Parameters.Add("@p0", MySqlDbType.VarChar).Value = firstname;
                    regCommand.Parameters.Add("@p1", MySqlDbType.VarChar).Value = lastname;
                    regCommand.Parameters.Add("@p2", MySqlDbType.VarChar).Value = gender;
                    regCommand.Parameters.Add("@p3", MySqlDbType.DateTime).Value = dob;
                    regCommand.Parameters.Add("@p4", MySqlDbType.VarChar).Value = position;
                    regCommand.Parameters.Add("@p5", MySqlDbType.Decimal).Value = salary;
                    regCommand.Parameters.Add("@p6", MySqlDbType.Decimal).Value = allowance;
                    regCommand.Parameters.Add("@p7", MySqlDbType.VarChar).Value = stationNo;
                    regCommand.Parameters.Add("@p8", MySqlDbType.VarChar).Value = username;
                    regCommand.Parameters.Add("@p9", MySqlDbType.VarChar).Value = password;
                    regCommand.Parameters.Add("@p10", MySqlDbType.VarChar).Value = "1";
                    regCommand.Parameters.Add("@p11", MySqlDbType.VarChar).Value = accountLevel;

                    int rowsAffected = regCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Username: " + username + "\nPassword: " + password, "Successfully Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        registerWasSuccessful = true;
                        OnRegistrationSuccess(EventArgs.Empty);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Failed to Register.", "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        protected virtual void OnRegistrationSuccess(EventArgs e)
        {
            Success?.Invoke(this, e);
        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            registerWasSuccessful = false;
            if (txtBFirstname.Text == "" || txtBLastname.Text == "")
            {
                ShowAlert("No Empty Fields Allowed");
            }
            else if (cBGender.SelectedIndex == -1 || cBAccResLVL.SelectedIndex == -1)
            {
                ShowAlert("No Empty Fields Allowed");
            }
            else if (txtBPosition.Text == "" || txtBSalary.Text == "" || txtBAllowance.Text == "" ||txtBStationNo.Text == "")
            {
                ShowAlert("No Empty Fields Allowed");
            }
            else
            {
                Register();
            }
        }
        void ShowAlert(string message)
        {
            MessageBox.Show(message, "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'
                && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if ((txtBSalary.Text.IndexOf('.') > -1) && (txtBSalary.Text.Substring(txtBSalary.Text.IndexOf('.') + 1).Length >= 2) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBAllowance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar)
        && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'
                && (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if ((txtBAllowance.Text.IndexOf('.') > -1) && (txtBAllowance.Text.Substring(txtBAllowance.Text.IndexOf('.') + 1).Length >= 2) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dTPBOD_ValueChanged(object sender, EventArgs e)
        {
            txtBDOB.Text = dTPBOD.Value.ToString("MM/dd/yyyy");
        }
    }
}
