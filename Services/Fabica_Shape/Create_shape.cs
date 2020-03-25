using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geoportal.Services
{
	public abstract class Create_shape
	{
		public abstract Shape Create(string Name, string Geometry, string Dbconn);

		public abstract Shape Create(string name, string geometry_multiPolgon, string geometry_multiLineString,
			string geometry_multiPoint, string dbconn);
	}
}