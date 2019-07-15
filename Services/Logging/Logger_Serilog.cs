using System;
using Serilog;
using Serilog.Core;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Geoportal.Services.Logging
{
    public class Logger_Serilog : ILogger_custom
    {
        private readonly IConfiguration _configuration;
        private readonly Logger _logger;
       string path_to_log = Path.Combine("logs", "log.txt");
        public Logger_Serilog(IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = new LoggerConfiguration()
                .WriteTo.File(path_to_log, rollingInterval: RollingInterval.Day)
            .CreateLogger();
            //  .ReadFrom.Configuration(_configuration)
            //.CreateLogger();
        }


        public void LogInfo(string message)
        {
            _logger.Information(message);
        }

        public void LogFatal(Exception ex, string message)
        {
            _logger.Fatal(ex, message);
        }

        public void LogError(string error)
        {
            _logger.Error(error);
        }
    }
}
