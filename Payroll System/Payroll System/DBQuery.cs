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
        private string checkUsername = @"CALL `checkUsername`(@p0)";
        private string updateAccountAndStaff = @"CALL `updateAccountAndStaff`(@p0, @p1, @p2, @p3, @p4)";
        private string updateAccountPassword = @"CALL `updateAccountPassword`(@p0, @p1)";
        private string getAllAccountDetailsForLVL2 = @"CALL `getAllAccountDetailsForLVL2`(@p0)";
        private string getAllAccountDetailsForLVL3 = @"CALL `getAllAccountDetailsForLVL3`()";
        private string getManagerNames = @"CALL `getManagerNames`()";
        private string registerAccount = @"CALL `registerAccount`(@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12)";
        private string getSelectedManagerID = @"CALL `getSelectedManagerID`(@p0)";
        private string registerNewManager = @"CALL `registerNewManager`(@p0)";
        private string searchAccForLvl3 = @"CALL `searchAccforLvl3`(@p0)";
        private string searchAccForLvl2 = @"CALL `searchAccForLvl2`(@p0, @p1)";
        private string editUserAcc = @"CALL `editUserAcc`(@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11)";
        private string getManagerName = @"CALL `getManagerName`(@p0)";
        public string LoginQuery()
        {
            return loginQuery;
        }

        public string UserDetailsQuery()
        {
            return userDetailsQuery;
        }

        public string CheckUsername()
        {
            return checkUsername;
        }
        public string UpdateAccountAndStaff()
        {
            return updateAccountAndStaff;
        }
        public string UpdateAccountPassword()
        {
            return updateAccountPassword;
        }
        public string GetAllAccountDetailsForLVL2()
        {
            return getAllAccountDetailsForLVL2;
        }
        public string GetAllAccountDetailsForLVL3()
        {
            return getAllAccountDetailsForLVL3;
        }
        public string GetManagerNames()
        {
            return getManagerNames;
        }
        public string RegisterAccount()
        {
            return registerAccount;
        }
        public string GetSelectedManagerID()
        {
            return getSelectedManagerID;
        }
        public string RegisterNewManager()
        {
            return registerNewManager;
        }
        public string GetSearchAccForLvl3()
        {
            return searchAccForLvl3;
        }
        public string GetSearchAccForLvl2()
        {
            return searchAccForLvl2;
        }
        public string EditUserAcc()
        {
            return editUserAcc;
        }
        public string GetManagerName()
        {
            return getManagerName;
        }
    }
}
