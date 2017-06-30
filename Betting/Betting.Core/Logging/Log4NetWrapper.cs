using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betting.Interfaces.Logging;

namespace Betting.Core.Logging
{
    public class Log4NetWrapper: ILoggingProvider
    {
        public void Info(string message)
        {
        }

        public void Error(string message, Exception ex)
        {
        }
    }
}
