using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystemServer
{
    internal class DBQuerry
    {
        private string getAllUserID = @"CALL `getAllUserID`()";
        private string generatePayslip = @"CALL `CheckAndGeneratePayslip`()";
        private string generatePayslipDetails = @"CALL `GeneratePayslipDetails`(@p0)";

        public string GetAllUserID()
        {
            return getAllUserID;
        }
        public string GeneratePayslip()
        {
            return generatePayslip;
        }
        public string GeneratePayslipDetails()
        {
            return generatePayslipDetails;
        }
    }
}
