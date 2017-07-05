using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.DataAccess
{
    public class DbBaseRepository
    {
        protected static string DatetimeFormat = "dd/MM/yyyy hh:mm:ss";

        protected string DateTimeToStr(DateTime dateTime)
        {
            return dateTime.ToString(DatetimeFormat);
        }

        protected string DateTimeToStr(DateTime? dateTime)
        {
            return dateTime?.ToString(DatetimeFormat) ?? "";
        }

        protected DateTime ToDateTime(string str)
        {
            // 05/07/2017 05:21:24
            var parts = str.Split(' ');
            var date = DateTime.Parse(parts[0]);
            var time = TimeSpan.Parse(parts[1]);

            date = date.Add(time);

            return date;
        }
    }
}
