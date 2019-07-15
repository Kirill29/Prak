using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geoportal.Services
{ //абстрактный класс для рамки
    public abstract class Shape
    {
        protected string Name { get; set; }
        protected string Geometry { get; set; }
        protected string DbConnection { get; set; }
        //public Shape(string name,string geom,string DbConn)
        //{
        //    Name=name;
        //    Geometry = geom;
        //    DbConnection = DbConn;
        //}
        public abstract string Add_shape();
        
    }
}
