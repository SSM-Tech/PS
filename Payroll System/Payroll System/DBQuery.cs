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
        private string updateAccountAndStaff = @"CALL `updateAccountAndStaff`(@p0, @p1, @p2, @p3, @p4, @p5)";

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
    }
}
