using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geoportal.Services
{
    public class Create_shape_WKT : Create_shape
    {
       
        public override Shape Create(string Name, string Geometry, string Dbconn)
        {
            return new Shape_WKT(Name, Geometry,Dbconn);
        }
    }
}
