using System;
namespace Geoportal.Models
{
    public class FileModel
    {
        public FileModel()
        {
        }
        public int workstations_nr { get; set; }
        public int status { get; set; }
        public int dtstamp_begin_demand { get; set; }
        public int region_types_nr { get; set; }
        public int types_demand_nr { get; set; }
        public int priority { get; set; }
        public string Name { get; set; }
    }
}
