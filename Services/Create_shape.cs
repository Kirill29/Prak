using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geoportal.Services
{
    public abstract class Create_shape
    {
        abstract public Shape Create(string Name,string Geometry,string Dbconn);
    }
}
