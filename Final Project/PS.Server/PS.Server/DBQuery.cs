﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
        private string eventLog = @"CALL `EventLog`(@p0, @p1, @p2)";
        private string callEventLogs = @"CALL `GetEventLogs`()";
        private string generateDTRTotalHours = @"CALL `GenerateDTRTotalHours`()";
        private string fillPayrollDetail = @"CALL `FillPayslipDetail`(@p0, @p1)";
        private string loginQuery = @"CALL `LoginServer`(@p0, @p1)";
        private string logoutAll = @"CALL `SetLoginToZero`()";
        private string getTotalNumberOfLogs = @"CALL `GetTotalNumberOfLogs`()";

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
        public string CallEventLogs()
        {
            return callEventLogs;
        }
        public string GenerateDTRTotalHours()
        {
            return generateDTRTotalHours;
        }
        public string FillPayrollDetail()
        {
            return fillPayrollDetail;
        }
        public string LoginQuery()
        {
            return loginQuery;
        }
        public string LogoutAll()
        {
            return logoutAll;
        }
        public string GetTotalNumberOfLogs()
        {
            return getTotalNumberOfLogs;
        }
    }
}
