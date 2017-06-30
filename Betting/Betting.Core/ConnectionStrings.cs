using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.Core
{
    public class ConnectionStrings
    {
        public static string Sql
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
            }
        }
        public static string Mongo
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["mongo"].ConnectionString;
            }
        }
    }
}
