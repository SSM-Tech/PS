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

namespace PayrollSystemServer
{
    public partial class Form1 : Form
    {
        DataTable? userIdDT = new();
        public Form1()
        {
            InitializeComponent();
        }
        private void GeneratePayslip()
        {
            DBConn dbConn = new();

            DBQuery dbQuery = new DBQuery();

            DataTable? table = new();

            MySqlDataAdapter adapter = new();

            MySqlCommand command = new(dbQuery.LoginQuery(), dbConn.getConnection());
        }
        private void GenerateDTR()
        {

        }
        private void ComputePayslip()
        {

        }
        private void ComputeDTR()
        {

        }
    }
}
