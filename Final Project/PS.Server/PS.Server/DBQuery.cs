using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Server
{
    internal class DBQuery
    {
        private string payslipGenerator = @"CALL `CheckAndGeneratePayslip`()";
        private string getAllUserID = @"CALL `getAllUserID`()";
        private string generatePayslipDetails = @"CALL `GeneratePayslipDetails`(@p0)";
        private string checkServerStatus = @"CALL `CheckServerStatus`()";
        private string changeServerStatus = @"CALL `ChangeServerStatus`(@p0)";
        private string eventLog = @"CALL `EventLog`(@p0)";
        private string callEventLog = @"CALL `GetEventLogs`()";
        private string updateDTRTotalHours = @"CALL `UpdateDTRTotalHours`()";

        public string PayslipGenerator()
        {
            return payslipGenerator;
        }
        public string GetAllUserID()
        {
            return getAllUserID;
        }
        public string GeneratePayslipDetails()
        {
            return generatePayslipDetails;
        }
        public string CheckServerStatus()
        {
            return checkServerStatus;
        }
        public string ChangeServerStatus()
        {
            return changeServerStatus;
        }
        public string EventLog()
        {
            return eventLog;
        }
        public string CallEventLog()
        {
            return callEventLog;
        }
        public string UpdateDTRTotalHours()
        {
            return updateDTRTotalHours;
        }
    }
}
