using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geoportal.Services
{
	public class Create_shape_SHP : Create_shape
	{
		public override Shape Create(string Name, string Geometry, string Dbconn)
		{
			return new Shape_SHP(Name, Geometry, Dbconn);
		}

		public override Shape Create(string name, string geometry_multiPolgon, string geometry_multiLineString,
			string geometry_multiPoint, string dbconn)
		{
			throw new NotImplementedException();
		}
	}
}