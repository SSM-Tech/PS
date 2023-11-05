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
    public partial class AccountDetailsShowForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;
        public AccountDetailsShowForm()
        {
            InitializeComponent();
            ShowDetails();
        }

        private void ShowDetails()
        {
            string username = retrievedTable.Rows[0][columnName: "username"].ToString();
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
            string sss = retrievedTable.Rows[0][columnName: "SSS"].ToString();
            string pagibig = retrievedTable.Rows[0][columnName: "PagIbig"].ToString();
            string philhealth = retrievedTable.Rows[0][columnName: "PhilHealth"].ToString();
            txtFullname.Text = firstName + " " + lastName;
            txtUsername.Text = username;
            txtGender.Text = sex;
            txtDOB.Text = formattedDate;
            txtStaffID.Text = staffID;
            txtUserID.Text = userID;
            txtStation.Text = stationNum;
            txtSalary.Text = salary;
            txtAllowance.Text = allowance;
            txtSSS.Text = sss;
            txtPagIbig.Text = pagibig;
            txtPhilHealth.Text = philhealth;
        }

        private void AccountDetailsShowForm_Load(object sender, EventArgs e)
        {

        }
    }
}
