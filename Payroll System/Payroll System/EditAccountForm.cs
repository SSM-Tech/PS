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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Payroll_System
{
    public partial class EditAccountForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;
        string staffID;
        string firstname;
        string lastname;
        string username;
        string sex;
        DateTime dOB;
        string password;
        bool usernameChecked;
        public EditAccountForm()
        {
            InitializeComponent();
            staffID = retrievedTable.Rows[0][columnName: "staffID"].ToString();
            firstname = retrievedTable.Rows[0][columnName: "firstName"].ToString();
            lastname = retrievedTable.Rows[0][columnName: "lastName"].ToString();
            username = retrievedTable.Rows[0][columnName: "username"].ToString();
            sex = retrievedTable.Rows[0][columnName: "sex"].ToString();
            dOB = ((DateTime)retrievedTable.Rows[0]["DOB"]).Date;

            TxtFirstName.Text = firstname;
            TxtLastName.Text = lastname;
            TxtUsername.Text = username;
            TxtSex.Text = sex;
            TxtDOB.Text = dOB.ToString();

        }
        private void ChangeAccountConfirm()
        {
            DBConn db = new();

            DBQuery dbQuery = new DBQuery();

            MySqlDataAdapter adapter = new();

            password = retrievedTable.Rows[0][columnName: "password"].ToString();

            
                if (TxtPass.Text == password)
                {
                    usernameChecked = false;
                    if (TxtUsername.Text != username)
                    {
                        DataTable? userNameTable = new();

                        MySqlCommand command = new(dbQuery.CheckUsername(), db.getConnection());

                        command.Parameters.Add("@p0", MySqlDbType.VarChar).Value = TxtUsername.Text;

                        adapter.SelectCommand = command;

                        adapter.Fill(userNameTable);

                        int rowCheck = 0;

                        if (userNameTable.Rows.Count > rowCheck)
                        {
                            MessageBox.Show("Username is already Taken", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            usernameChecked = true;

                        }
                    }
                    else
                    {
                        usernameChecked = true;
                    }
                    if (usernameChecked == true)
                    {
                        if (MessageBox.Show("Are you sure you want to Cancel Editing?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                        MySqlCommand command = new(dbQuery.UpdateAccountAndStaff(), db.getConnection());
                        command.Parameters.Add("@p0", MySqlDbType.VarChar).Value = TxtUsername.Text;
                        command.Parameters.Add("@p1", MySqlDbType.VarChar).Value = staffID;
                        command.Parameters.Add("@p2", MySqlDbType.VarChar).Value = TxtFirstName.Text;
                        command.Parameters.Add("@p3", MySqlDbType.VarChar).Value = TxtLastName.Text;
                        command.Parameters.Add("@p4", MySqlDbType.VarChar).Value = TxtSex.Text;
                        command.Parameters.Add("@p5", MySqlDbType.VarChar).Value = TxtDOB.Text;

                        
                        retrievedTable.Rows[0][columnName: "firstName"] = TxtFirstName.Text;
                        retrievedTable.Rows[0][columnName: "lastName"] = TxtLastName.Text;
                        retrievedTable.Rows[0][columnName: "username"] = TxtUsername.Text;
                        retrievedTable.Rows[0][columnName: "sex"] = TxtSex.Text;
                        //retrievedTable.Rows[0]["DOB"] = new DateTime(yyyy, mm, dd);
                    }
                    }
                    else
                    {
                        
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Password", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
            
        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (TxtFirstName.Text != "" && TxtLastName.Text != "" && TxtUsername.Text != "" && TxtSex.Text != "")
            {
                ChangeAccountConfirm();
            }
            else
            {
                MessageBox.Show("No Empty Fields Allowed", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    private void CancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Cancel Editing?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
