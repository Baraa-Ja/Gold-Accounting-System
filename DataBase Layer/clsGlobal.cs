using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataBase_Layer
{
    public class clsGlobal
    {
        public static string Conectionstring = ConfigurationManager.ConnectionStrings["MyDataBaseConnection"].ConnectionString;
    }
}
