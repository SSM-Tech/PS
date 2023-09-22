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
        private string loginQuery = @"SELECT * FROM `account` WHERE `username` = @usn AND `password` = @pass";
        private string userDetailsQuery = @"
                    SELECT 
                        a.*,
                        stf.managerID,
                        stf.firstName,
                        stf.lastName,
                        stf.sex,
                        stf.DOB,
                        stf.position,
                        stf.salary,
                        stf.allowance
                    FROM account a
                    JOIN staff stf ON a.staffID = stf.staffID
                    JOIN station stn ON stf.stationNO = stn.stationNO
                    JOIN manager m ON stf.managerID = m.managerID
                    Where a.staffID = @staffID";

        public string LoginQuery()
        {
            return loginQuery;
        }

        public string UserDetailsQuery()
        {
            return userDetailsQuery;
        }
    }
}
