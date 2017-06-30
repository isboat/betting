using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.DataAccess
{
    public class DbBaseRepository
    {
        protected string DateTimeToStr(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy hh:mm:ss");
        }

        protected string DateTimeToStr(DateTime? dateTime)
        {
            return dateTime?.ToString("dd/MM/yyyy hh:mm:ss") ?? "";
        }

        protected DateTime ToDateTime(string str)
        {
            return DateTime.Parse(str);
        }
    }
}
