using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Payroll_System
{
    public partial class EditAccountForm : Form
    {
        bool updateWasSuccessful;
        public event EventHandler UpdateSuccessfulEvent;
        DataTable? retrievedTable = UserDetails.UserDetail;
        string firstname;
        string lastname;
        private string selectedGender = "Prefer not to say";
        DateTime dOB;
        string? password;
        public EditAccountForm()
        {
            InitializeComponent();

            firstname = retrievedTable.Rows[0][columnName: "firstName"].ToString();
            lastname = retrievedTable.Rows[0][columnName: "lastName"].ToString();
            string sex = retrievedTable.Rows[0][columnName: "sex"].ToString();
            dOB = (DateTime)retrievedTable.Rows[0][columnName: "DOB"];

            TxtFirstName.Text = firstname;
            TxtLastName.Text = lastname;
            switch (sex)
            {
                case "Male":
                    selectedGender = "Male";
                    break;
                case "Female":
                    selectedGender = "Female";
                    break;
                case "Other":
                    selectedGender = "Other";
                    break;
            }

            switch (selectedGender)
            {
                case "Male":
                    RBTNMale.Checked = true;
                    break;
                case "Female":
                    RBTNFemale.Checked = true;
                    break;
                case "Other":
                    RBTNOther.Checked = true;
                    break;
                case "Prefer not to say":
                    RBTNPreferNotToSay.Checked = true;
                    break;
            }

            DOBCalendar.Value = dOB;

            DOBCalendar.Format = DateTimePickerFormat.Custom;
            DOBCalendar.CustomFormat = "MM/dd/yyyy";
        }
        private void ChangeAccountConfirm()
        {
            DBConn dbConn = new();

            DBQuery dbQuery = new DBQuery();

            password = retrievedTable.Rows[0][columnName: "password"].ToString();


            if (TxtPass.Text == password)
            {
                if (MessageBox.Show("Are you sure you want to Confirm Editing?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string staffID = retrievedTable.Rows[0][columnName: "staffID"].ToString();
                    using (MySqlConnection dbConnection = dbConn.getConnection())
                    {
                        dbConnection.Open();

                        using (MySqlCommand acommand = new MySqlCommand(dbQuery.UpdateAccountAndStaff(), dbConnection))
                        {
                            acommand.Parameters.Add("@p0", MySqlDbType.VarChar).Value = staffID;
                            acommand.Parameters.Add("@p1", MySqlDbType.VarChar).Value = TxtFirstName.Text;
                            acommand.Parameters.Add("@p2", MySqlDbType.VarChar).Value = TxtLastName.Text;
                            acommand.Parameters.Add("@p3", MySqlDbType.VarChar).Value = selectedGender;
                            acommand.Parameters.Add("@p4", MySqlDbType.Date).Value = DOBCalendar.Value;

                            int rowsAffected = acommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                updateWasSuccessful = true;
                                retrievedTable.Rows[0][columnName: "firstName"] = TxtFirstName.Text;
                                retrievedTable.Rows[0][columnName: "lastName"] = TxtLastName.Text;
                                retrievedTable.Rows[0][columnName: "sex"] = selectedGender;
                                retrievedTable.Rows[0][columnName: "DOB"] = DOBCalendar.Value;
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
            else
            {
                MessageBox.Show("Wrong Password", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            updateWasSuccessful = false;
            if (TxtFirstName.Text != "" && TxtLastName.Text != "")
            {
                ChangeAccountConfirm();
            }
            else
            {
                MessageBox.Show("No Empty Fields Allowed", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            if (updateWasSuccessful == true)
            {
                UpdateSuccessfulEvent?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Cancel Editing?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void RBTNMale_CheckedChanged(object sender, EventArgs e)
        {
            if (RBTNMale.Checked)
                selectedGender = "Male";
        }

        private void RBTNFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (RBTNFemale.Checked)
                selectedGender = "Female";
        }

        private void RBTNOther_CheckedChanged(object sender, EventArgs e)
        {
            if (RBTNOther.Checked)
                selectedGender = "Other";
        }

        private void RBTNPreferNotToSay_CheckedChanged(object sender, EventArgs e)
        {
            if (RBTNPreferNotToSay.Checked)
                selectedGender = "Prefer not to say";
        }
    }
}
