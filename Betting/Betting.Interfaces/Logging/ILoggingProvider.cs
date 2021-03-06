﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betting.Interfaces.Logging
{
    public interface ILoggingProvider
    {
        void Info(string message);

        void Error(string message, Exception ex);
    }
}
