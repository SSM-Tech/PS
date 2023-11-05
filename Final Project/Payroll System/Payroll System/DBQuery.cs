using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_System
{
    internal class DBQuery
    {
        private string loginQuery = @"CALL `getLogin`(@p0, @p1)";
        private string userDetailsQuery = @"CALL `getAccDetails`(@p0)";
        private string updateAccountPassword = @"CALL `updateAccountPassword`(@p0, @p1)";
        private string registerAccount = @"CALL `registerAccount`(@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11)";
        private string getUserAcc = @"CALL `getUserAcc`(@p0)";
        private string editUserAcc = @"CALL `editUserAcc`(@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13)";
        private string loginStatus = @"CALL `loginStatus`(@p0, @p1)";
        private string checkIsEnabled = @"CALL `checkIsEnabled`(@p0)";
        private string checkServerStatus = @"CALL `CheckServerStatus`()";
        private string getUserDTR = @"CALL `getUserDTR`(@p0)";
        private string updateLoginStatus = @"CALL `UpdateLoginStatus`(@p0)";
        private string deleteUser = @"CALL `DeleteUser`(@p0)";
        private string clockInOut = @"CALL `ClockInOut`(@p0, @p1, @p2, @p3, @p4)";
        private string getPayslip = @"CALL `GetPayslip`(@p0)";
        public string LoginQuery()
        {
            return loginQuery;
        }
        public string LoginStatus()
        {
            return loginStatus;
        }
        public string CheckIsEnabled()
        {
            return checkIsEnabled;
        }
        public string UserDetailsQuery()
        {
            return userDetailsQuery;
        }
        public string UpdateAccountPassword()
        {
            return updateAccountPassword;
        }
        public string RegisterAccount()
        {
            return registerAccount;
        }
        public string GetUserAcc()
        {
            return getUserAcc;
        }
        public string EditUserAcc()
        {
            return editUserAcc;
        }
        public string CheckServerStatus()
        {
            return checkServerStatus;
        }
        public string GetUserDTR()
        {
            return getUserDTR;
        }
        public string UpdateLoginStatus()
        {
            return updateLoginStatus;
        }
        public string DeleteUser()
        {
            return deleteUser;
        }
        public string ClockInOut()
        {
            return clockInOut;
        }
        public string GetPayslip()
        {
            return getPayslip;
        }
    }
}
