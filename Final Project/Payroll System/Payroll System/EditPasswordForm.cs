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
    public partial class EditPasswordForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;
        String oldPass;
        public EditPasswordForm()
        {
            InitializeComponent();
            oldPass = retrievedTable.Rows[0][columnName: "password"].ToString();
        }
        private void ChangePassword()
        {
            DBConn dbConn = new();

            DBQuery dbQuery = new DBQuery();

            string staffID = retrievedTable.Rows[0][columnName: "staffID"].ToString();
            using (MySqlConnection dbConnection = dbConn.getConnection())
            {
                dbConnection.Open();

                using (MySqlCommand acommand = new MySqlCommand(dbQuery.UpdateAccountPassword(), dbConnection))
                {
                    acommand.Parameters.Add("@p0", MySqlDbType.VarChar).Value = TxtNewPass.Text;
                    acommand.Parameters.Add("@p1", MySqlDbType.VarChar).Value = staffID;

                    int rowsAffected = acommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        retrievedTable.Rows[0][columnName: "password"] = TxtNewPass.Text;
                        MessageBox.Show("Successfully changed Password", "Password Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        TxtOldPass.Text = "";
                        TxtConfOldPass.Text = "";
                        TxtNewPass.Text = "";
                        TxtConfNewPass.Text = "";

                        oldPass = retrievedTable.Rows[0][columnName: "password"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("Failed to update the database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtOldPass.Text) || string.IsNullOrWhiteSpace(TxtConfOldPass.Text))
            {
                MessageBox.Show("No Empty Fields Allowed", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrWhiteSpace(TxtNewPass.Text) || string.IsNullOrWhiteSpace(TxtConfNewPass.Text))
            {
                MessageBox.Show("No Empty Fields Allowed", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (oldPass != TxtOldPass.Text)
            {
                MessageBox.Show("Wrong Old Password", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (TxtOldPass.Text != TxtConfOldPass.Text)
            {
                MessageBox.Show("Old Password Didn't Match", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (TxtNewPass.Text != TxtConfNewPass.Text)
            {
                MessageBox.Show("New Password Didn't Match", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (TxtNewPass.Text.Length < 8)
            {
                MessageBox.Show("New Password should be 8 - 16 characters", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (TxtOldPass.Text == TxtNewPass.Text)
            {
                MessageBox.Show("Old and New password cannot be the same", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MessageBox.Show("Are you sure you want to Change Password?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ChangePassword();
            }
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Cancel Change Password?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }


    }
}
