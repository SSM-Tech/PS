using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_System
{
    static class UserDetails
    {
        static DataTable? userDetail;

        public static DataTable? UserDetail { 
            get => userDetail; 
            set => userDetail = value; 
        }
    }
}
