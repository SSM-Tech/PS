using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Encoders;
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
    public partial class ManageAccountEditForm : Form
    {
        //DataTable? retrievedTable = UserDetails.UserDetail;
        //DataTable? allAccDet = new DataTable();
        public event EventHandler Success;
        bool editWasSuccessful;
        int? selectedStaffID = UserDetails.SelectedStaffID;
        DataTable? dtSelectedUser = new DataTable();
        DataTable? managerNames = new DataTable();
        DataTable? retrievedTable = UserDetails.UserDetail;
        DBConn dbConn = new();
        DBQuery dbQuery = new DBQuery();
        MySqlDataAdapter adapter = new();
        static Random random = new Random();
        string firstname;
        string lastname;
        int genderIndex;
        DateTime dob;
        int accLvlIndex;
        int managerID;
        int managerIndex;
        int lockAcc;
        string position;
        decimal salary;
        decimal allowance;

        public ManageAccountEditForm()
        {
            InitializeComponent();
            MySqlCommand? msqManagerNames;

            msqManagerNames = new(dbQuery.GetManagerNames(), dbConn.getConnection());
            msqManagerNames.ExecuteReaderAsync();
            adapter.SelectCommand = msqManagerNames;
            adapter.Fill(managerNames);

            foreach (DataRow row in managerNames.Rows)
            {
                cBManager.Items.Add(row["firstName"].ToString());
            }
            MySqlCommand mscGetUserDetails = new(dbQuery.UserDetailsQuery(), dbConn.getConnection());
            mscGetUserDetails.Parameters.Add("@p0", MySqlDbType.Int32).Value = selectedStaffID;

            adapter.SelectCommand = mscGetUserDetails;

            adapter.Fill(dtSelectedUser);

            firstname = dtSelectedUser.Rows[0][columnName: "firstName"].ToString();
            lastname = dtSelectedUser.Rows[0][columnName: "lastName"].ToString();
            string gender = dtSelectedUser.Rows[0][columnName: "sex"].ToString();
            dob = (DateTime)dtSelectedUser.Rows[0][columnName: "DOB"];
            int accountLvl = (int)dtSelectedUser.Rows[0][columnName: "accountLevel"];
            managerID = (int)dtSelectedUser.Rows[0][columnName: "managerID"];
            lockAcc = (int)dtSelectedUser.Rows[0][columnName: "isEnabled"];
            position = dtSelectedUser.Rows[0][columnName: "position"].ToString();
            salary = (decimal)dtSelectedUser.Rows[0][columnName: "salary"];
            allowance = (decimal)dtSelectedUser.Rows[0][columnName: "allowance"];

            DataTable? dataTable = new DataTable();
            MySqlCommand mscGetManagerName = new(dbQuery.GetManagerName(), dbConn.getConnection());
            mscGetManagerName.Parameters.Add("@p0", MySqlDbType.Int32).Value = managerID;

            adapter.SelectCommand = mscGetManagerName;
            adapter.Fill(dataTable);

            switch (accountLvl)
            {
                case 1:
                    cBAccResLVL.SelectedIndex = 0;
                    break;
                case 2:
                    cBAccResLVL.SelectedIndex = 1;
                    break;
                case 3:
                    cBAccResLVL.SelectedIndex = 2;
                    break;
            }
            switch (gender)
            {
                case "Male":
                    cBGender.SelectedIndex = 0;
                    break;
                case "Female":
                    cBGender.SelectedIndex = 1;
                    break;
                case "Other":
                    cBGender.SelectedIndex = 2;
                    break;
                case "Prefer not to say":
                    cBGender.SelectedIndex = 3;
                    break;
            }
            switch (lockAcc)
            {
                case 0:
                    cBLockAcc.SelectedIndex = 0;
                    break;
                case 1:
                    cBLockAcc.SelectedIndex = 1;
                    break;
            }

            txtBFirstname.Text = firstname;
            txtBLastname.Text = lastname;
            dTPBOD.Value = dob;
            txtBDOB.Text = dTPBOD.Value.ToString("MM/dd/yyyy");
            cBManager.SelectedIndex = cBManager.Items.IndexOf(dataTable.Rows[0][columnName: "firstName"].ToString());
            txtBPosition.Text = position;
            txtBSalary.Text = salary.ToString();
            txtBAllowance.Text = allowance.ToString();

            genderIndex = cBGender.SelectedIndex;
            accLvlIndex = cBAccResLVL.SelectedIndex;
            managerIndex = cBManager.SelectedIndex;

            ConfirmButton.Enabled = false;
            if (retrievedTable.Rows[0][columnName: "accountLevel"].ToString() == "2")
            {
                cBAccResLVL.Enabled = false;
                cBManager.Enabled = false;
                txtBSalary.ReadOnly = true;
                txtBAllowance.ReadOnly = true;
            }

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            genderIndex = cBGender.SelectedIndex;
            accLvlIndex = cBAccResLVL.SelectedIndex;
            string gender;
            int accLvl = 1;


            switch (genderIndex)
            {
                case 0:
                    gender = "Male";
                    break;
                case 1:
                    gender = "Female";
                    break;
                case 2:
                    gender = "Other";
                    break;
                default:
                    gender = "Prefer not to say";
                    break;
            }
            switch (accLvlIndex)
            {
                case 0:
                    accLvl = 1;
                    break;
                case 1:
                    accLvl = 2;
                    break;
                case 2:
                    accLvl = 3;
                    break;
            }
            DBConn dbConn = new();

            DBQuery dbQuery = new DBQuery();
            using (MySqlConnection dbConnection = dbConn.getConnection())
            {
                dbConnection.Open();

                using (MySqlCommand acommand = new MySqlCommand(dbQuery.EditUserAcc(), dbConnection))
                {
                    DataTable mSD = new DataTable();
                    string managerName = cBManager.SelectedItem.ToString();
                    MySqlCommand commandMSD = new(dbQuery.GetSelectedManagerID(), dbConn.getConnection());

                    commandMSD.Parameters.Add("@p0", MySqlDbType.VarChar).Value = managerName;
                    adapter.SelectCommand = commandMSD;
                    adapter.Fill(mSD);
                    double managerID = (double)mSD.Rows[0][columnName: "managerID"];
                    string stationNo = mSD.Rows[0][columnName: "stationNo"].ToString();

                    acommand.Parameters.AddWithValue("@p0", selectedStaffID);
                    acommand.Parameters.AddWithValue("@p1", txtBFirstname.Text);
                    acommand.Parameters.AddWithValue("@p2", txtBLastname.Text);
                    acommand.Parameters.AddWithValue("@p3", gender);
                    acommand.Parameters.AddWithValue("@p4", dTPBOD.Value);
                    acommand.Parameters.AddWithValue("@p5", txtBPosition.Text);
                    acommand.Parameters.AddWithValue("@p6", txtBSalary.Text);
                    acommand.Parameters.AddWithValue("@p7", txtBAllowance.Text);
                    acommand.Parameters.AddWithValue("@p8", stationNo);
                    acommand.Parameters.AddWithValue("@p9", cBLockAcc.SelectedIndex);
                    acommand.Parameters.AddWithValue("@p10", accLvl);
                    acommand.Parameters.AddWithValue("@p11", managerID);

                    int rowsAffected = acommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Accoun Detail Successfully Changed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        editWasSuccessful = true;
                        OnEditSuccess(EventArgs.Empty);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update the database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        protected virtual void OnEditSuccess(EventArgs e)
        {
            Success?.Invoke(this, e);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Reset the Password?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string password = GenerateRandomPassword(5, 5);
                DBConn dbConn = new();

                DBQuery dbQuery = new DBQuery();

                using (MySqlConnection dbConnection = dbConn.getConnection())
                {
                    dbConnection.Open();

                    using (MySqlCommand acommand = new MySqlCommand(dbQuery.UpdateAccountPassword(), dbConnection))
                    {
                        acommand.Parameters.Add("@p0", MySqlDbType.VarChar).Value = password;
                        acommand.Parameters.Add("@p1", MySqlDbType.VarChar).Value = selectedStaffID;

                        int rowsAffected = acommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("The Account's new password is " + password, "Successfully changed Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update the database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
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

        private void txtBFirstname_TextChanged(object sender, EventArgs e)
        {
            if (txtBFirstname.Text != firstname && txtBFirstname.Text != "")
            {
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;
            }
        }

        private void txtBLastname_TextChanged(object sender, EventArgs e)
        {
            if (txtBLastname.Text != lastname && txtBLastname.Text != "")
            {
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;
            }
        }

        private void cBGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBGender.SelectedIndex != genderIndex)
            {
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;
            }
        }

        private void dTPBOD_ValueChanged(object sender, EventArgs e)
        {
            txtBDOB.Text = dTPBOD.Value.ToString("MM/dd/yyyy");
            if (dTPBOD.Value != dob)
            {
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;
            }
        }

        private void cBAccResLVL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBAccResLVL.SelectedIndex != accLvlIndex)
            {
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;
            }
        }

        private void cBManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBManager.SelectedIndex != managerIndex)
            {
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;
            }
        }

        private void cBLockAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBLockAcc.SelectedIndex != lockAcc)
            {
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;
            }
        }

        private void txtBPosition_TextChanged(object sender, EventArgs e)
        {
            if (txtBPosition.Text != position && txtBPosition.Text != "")
            {
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;
            }
        }

        private void txtBSalary_TextChanged(object sender, EventArgs e)
        {
            if (txtBSalary.Text != salary.ToString() && txtBSalary.Text != "")
            {
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;
            }
        }

        private void txtBAllowance_TextChanged(object sender, EventArgs e)
        {
            if (txtBAllowance.Text != allowance.ToString() && txtBAllowance.Text != "")
            {
                ConfirmButton.Enabled = true;
            }
            else
            {
                ConfirmButton.Enabled = false;
            }
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
    }
}
