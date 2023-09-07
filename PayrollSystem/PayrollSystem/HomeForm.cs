using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to exit the application?","ALERT",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes){
                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            }
        }
    }
}
