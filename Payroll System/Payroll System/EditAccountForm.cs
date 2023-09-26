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
        string firstname;
        string lastname;
        string username;
        string sex;
        string dOB;
        public EditAccountForm()
        {
            InitializeComponent();
            firstname = retrievedTable.Rows[0][columnName: "firstName"].ToString();
            lastname = retrievedTable.Rows[0][columnName: "lastName"].ToString();
            username = retrievedTable.Rows[0][columnName: "username"].ToString();
            sex = retrievedTable.Rows[0][columnName: "sex"].ToString();
            dOB = retrievedTable.Rows[0][columnName: "DOB"].ToString();

            TxtFirstName.Text = firstname;
            TxtLastName.Text = lastname;
            TxtUsername.Text = username;
            TxtSex.Text = sex;
            TxtDOB.Text = dOB;

        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            DBConn db = new();

            DBQuery dbQuery = new DBQuery();

            DataTable? table = new();

            MySqlDataAdapter adapter = new();

            MySqlCommand command = new(dbQuery.CheckUsername(), db.getConnection());

            command.Parameters.Add("@p0", MySqlDbType.VarChar).Value = TxtUsername.Text;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            int rowCheck = 0;

            if (rowCheck == 0)
            {
                if (TxtUsername.Text == TxtUsername.Text)
                {
                }
            }
            else
            {
                MessageBox.Show("Username is Taken?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
