using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geoportal.Services.Logging
{
    public interface ILogger_custom
    {
        void LogInfo(string message);

        void LogFatal(Exception ex, string message);

        void LogError(string error);
    }
}
