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
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Payroll_System
{
    public partial class MenuForm : Form
    {
        DataTable? retrievedTable = UserDetails.UserDetail;

        public MenuForm()
        {
            InitializeComponent();
            string username = retrievedTable.Rows[0][columnName: "username"].ToString().ToUpper();
            string acclevel = retrievedTable.Rows[0][columnName: "accountLevel"].ToString();
            if (acclevel != "1")
            {
                ManageAccoountFormButton.Visible = true;
                TicketsFormButton.Visible = true;
                Application.DoEvents();
            }
            UsernameLabel.Text = "Welcome " + username;
            LoadForm(new HomeForm());

        }
        public void LoadForm(object Form)
        {
            if (this.MainPanel.Controls.Count > 0)
                this.MainPanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(f);
            this.MainPanel.Tag = f;
            f.Show();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Logout?", "ALERT", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                LoginForm loginForm = new();
                loginForm.Show();
                this.Close();
            }
        }
        private void HomeFormButton_Click(object sender, EventArgs e)
        {
            LoadForm(new HomeForm());
        }
        private void AccountDetailsButton_Click(object sender, EventArgs e)
        {
            LoadForm(new AccountDetailsForm());
        }

        private void DTRFormButton_Click(object sender, EventArgs e)
        {
            LoadForm(new DTRForm());
        }

        private void PayslipFormButton_Click(object sender, EventArgs e)
        {
            LoadForm(new PaySlipForm());
        }

        private void ManageAccoountFormButton_Click(object sender, EventArgs e)
        {
            LoadForm(new ManageAccountForm());
        }

        private void TicketsFormButton_Click(object sender, EventArgs e)
        {
            LoadForm(new TicketsForm());
        }
    }
}
