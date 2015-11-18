using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstrukcjeProdukcyjne
{
    public class AllowRoles
    {
        public static string All = "pracownik,kierownik, admin";
        public static string Kierownik = "kierownik";

        public static string RoleCanLogon = "pracownik,kierownik,admin";
        public static string RoleCanAppExit = "kierownik, admin";
    }
}
