using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geoportal.Models;
using Microsoft.Extensions.Configuration;

namespace Geoportal.Services
{
    public class ConnectionString : IConnectionString
    {
        private IConfiguration _configuration;
        private string _configurationstring;
        public ConnectionString(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }

        public string GetConnectionString()
        {
            return _configurationstring;
        }

        public void SetConnectionString(User _user)
        {
             string conn= _configuration["DefaultConnection"];
            _configurationstring = conn.Replace("user", _user.Login).Replace("password", _user.Password);
        }
    }
}
