using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geoportal.Services.Fabica_Shape
{
    public class Create_shape_draw : Create_shape
    {
        public override Shape Create(string name, string geometry_multiPolgon, string geometry_multiLineString, string geometry_multiPoint, string dbconn)
        {
            return new Shape_draw(name, geometry_multiPolgon, geometry_multiLineString, geometry_multiPoint,dbconn);
        }

        public override Shape Create(string Name, string Geometry, string Dbconn)
        {
            throw new NotImplementedException();
        }
    }
}
