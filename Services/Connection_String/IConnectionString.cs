using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geoportal.Models;

namespace Geoportal.Services
{
	public interface IConnectionString
	{
		string GetConnectionString();

		void SetConnectionString(User _user);
	}
}