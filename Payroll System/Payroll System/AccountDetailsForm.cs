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
    public partial class AccountDetailsForm : Form
    {
        public event EventHandler UpdateSuccessfulEvent;
        DataTable? retrievedTable = UserDetails.UserDetail;
        MenuForm menuForm = new MenuForm();

        public AccountDetailsForm()
        {
            InitializeComponent();
            ShowAccDetails();

        }

        public void ShowAccDetails()
        {
            string username = retrievedTable.Rows[0][columnName: "username"].ToString();
            string accLevel = retrievedTable.Rows[0][columnName: "accountLevel"].ToString();
            string firstName = retrievedTable.Rows[0][columnName: "firstName"].ToString();
            string lastName = retrievedTable.Rows[0][columnName: "lastName"].ToString();
            string sex = retrievedTable.Rows[0][columnName: "sex"].ToString();
            string staffID = retrievedTable.Rows[0][columnName: "staffID"].ToString();
            DateTime dOB = (DateTime)retrievedTable.Rows[0][columnName: "DOB"];
            string formattedDate = dOB.ToString("MM/dd/yyyy");
            string userID = retrievedTable.Rows[0][columnName: "userID"].ToString();
            string stationNum = retrievedTable.Rows[0][columnName: "stationNo"].ToString();
            string salary = retrievedTable.Rows[0][columnName: "salary"].ToString();
            string allowance = retrievedTable.Rows[0][columnName: "allowance"].ToString();
            TxtFullName.Text = firstName + " " + lastName;
            TxtUsername.Text = username;
            TxtAccLvl.Text = accLevel;
            TxtSex.Text = sex;
            TxtDOB.Text = formattedDate;
            TxtStaffID.Text = staffID;
            TxtUserID.Text = userID;
            TxtStationNum.Text = stationNum;
            TxtSalary.Text = salary;
            TxtAllowance.Text = allowance;
        }

        private void StaffIDHideIcon_Click(object sender, EventArgs e)
        {
            TxtStaffID.UseSystemPasswordChar = false;
            StaffIDHideIcon.Hide();
            StaffIDShowIcon.Show();
        }
        private void StaffIDShowIcon_Click(object sender, EventArgs e)
        {
            TxtStaffID.UseSystemPasswordChar = true;
            StaffIDHideIcon.Show();
            StaffIDShowIcon.Hide();
        }
        private void AccLvlHideIcon_Click(object sender, EventArgs e)
        {
            TxtAccLvl.UseSystemPasswordChar = false;
            AccLvlHideIcon.Hide();
            AccLvlShowIcon.Show();
        }
        private void AccLvlShowIcon_Click(object sender, EventArgs e)
        {
            TxtAccLvl.UseSystemPasswordChar = true;
            AccLvlHideIcon.Show();
            AccLvlShowIcon.Hide();
        }
        private void SalaryHideIcon_Click(object sender, EventArgs e)
        {
            TxtSalary.UseSystemPasswordChar = false;
            SalaryHideIcon.Hide();
            SalaryShowIcon.Show();
        }
        private void SalaryShowIcon_Click(object sender, EventArgs e)
        {
            TxtSalary.UseSystemPasswordChar = true;
            SalaryHideIcon.Show();
            SalaryShowIcon.Hide();

        }
        private void UserIDHideIcon_Click(object sender, EventArgs e)
        {
            TxtUserID.UseSystemPasswordChar = false;
            UserIDHideIcon.Hide();
            UserIDShowIcon.Show();
        }
        private void UserIDShowIcon_Click(object sender, EventArgs e)
        {
            TxtUserID.UseSystemPasswordChar = true;
            UserIDHideIcon.Show();
            UserIDShowIcon.Hide();
        }
        private void StaNumHideIcon_Click(object sender, EventArgs e)
        {
            TxtStationNum.UseSystemPasswordChar = false;
            StaNumHideIcon.Hide();
            StaNumShowIcon.Show();
        }
        private void StaNumShowIcon_Click(object sender, EventArgs e)
        {
            TxtStationNum.UseSystemPasswordChar = true;
            StaNumHideIcon.Show();
            StaNumShowIcon.Hide();
        }
        private void AllowanceHideIcon_Click(object sender, EventArgs e)
        {
            TxtAllowance.UseSystemPasswordChar = false;
            AllowanceHideIcon.Hide();
            AllowanceShowIcon.Show();
        }
        private void AllowanceShowIcon_Click(object sender, EventArgs e)
        {
            TxtAllowance.UseSystemPasswordChar = true;
            AllowanceHideIcon.Show();
            AllowanceShowIcon.Hide();
        }
        private void EditAccountButton_Click(object sender, EventArgs e)
        {
            EditAccountForm editAccountForm = new EditAccountForm();
            editAccountForm.UpdateSuccessfulEvent += EditAccountForm_UpdateSuccessfulEvent;
            editAccountForm.ShowDialog();
        }
        private void EditAccountForm_UpdateSuccessfulEvent(object sender, EventArgs e)
        {
            // Refresh data in AccountDetailsForm
            ShowAccDetails();

        }
        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            EditPasswordForm editPasswordForm = new EditPasswordForm();
            editPasswordForm.ShowDialog();
        }
    }
}
