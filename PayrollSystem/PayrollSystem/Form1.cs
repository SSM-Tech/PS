using MySql.Data.MySqlClient;
using System.Data;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Security.Principal;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Crypto.Tls;
using System.Text;

namespace PayrollSystem
{
    public partial class Form1 : Form
    {
        private DataTable? accDetail;

        public DataTable? AccDetail { get => accDetail; set => accDetail = value; }

        public Form1()
        {
            InitializeComponent();
            AccDetail = new DataTable();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClearButton_Click(sender, e);

        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text.ToString();
            string password = PasswordTextBox.Text.ToString();

            DB db = new();

            DataTable table = new();

            MySqlDataAdapter adapter = new();

            MySqlCommand command = new("SELECT * FROM `account` WHERE `username` = @usn AND `password` = @pass", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            int rowCheck = 0;

            if (UsernameTextBox.Text != "" && PasswordTextBox.Text != "")
            {
                if (table.Rows.Count > rowCheck)
                {
                    var isEnabled = table.Rows[rowCheck][columnName: "isEnabled"].ToString();

                    if (isEnabled == "1")
                    {
                        adapter.Fill(AccDetail);
                        ClearButton_Click(sender, e);
                        MessageBox.Show("Succesfuly Logged In", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        new HomeForm(AccDetail).Show();
                    }
                    else
                    {
                        MessageBox.Show("Your Account is currently locked, please contact HR for assistance", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Username and Password should not be empty", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            UsernameTextBox.Clear();
            PasswordTextBox.Clear();
            UsernameTextBox_Leave(sender, e);
            PasswordTextBox_Leave(sender, e);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        private void UsernameTextBox_Enter(object sender, EventArgs e)
        {
            UsernamePlaceHolderLabel.Hide();
            UsernameTextBox.SelectAll();
        }
        private void UsernameTextBox_Leave(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "")
            {
                UsernamePlaceHolderLabel.Show();
            }
        }
        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            PasswordPlaceHolderLabel.Hide();
            PasswordTextBox.SelectAll();
        }
        private void PasswordTextBox_Leave(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == "")
            {
                PasswordPlaceHolderLabel.Show();
            }
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoginButton_Click(sender, e);
            }
        }

        private void UsernamePlaceHolderLabel_Click(object sender, EventArgs e)
        {
            UsernameTextBox.Focus();
        }
        private void PasswordPlaceHolderLabel_Click(object sender, EventArgs e)
        {
            PasswordTextBox.Focus();
        }
        private void HidePasswordIcon_Click(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = false;
            HidePasswordIcon.Hide();
            ShowPasswordIcon.Show();
        }

        private void ShowPasswordIcon_Click(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = true;
            ShowPasswordIcon.Hide();
            HidePasswordIcon.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("If you forgot your password, Please contact HR for further assistance", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}