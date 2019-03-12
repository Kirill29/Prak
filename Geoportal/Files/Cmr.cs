using System;
using System.Collections.Generic;

namespace Geoportal.Files
{
    public partial class Cmr
    {
        public Cmr()
        {
            Cmr1 = new HashSet<Cmr1>();
        }

        public int CmrId { get; set; }
        public DateTime? DateMake { get; set; }
        public int? Scale { get; set; }
        public double? SkoSgo { get; set; }
        public double? SkoHgo { get; set; }
        public double? StepNet { get; set; }
        public string Legenda { get; set; }
        public string CmrName { get; set; }
        public int? CmrTypeCode { get; set; }
        public string Nomenclature { get; set; }
        public short? YearMake { get; set; }
        public byte[] Picture { get; set; }
        public double? NeLat { get; set; }
        public double? NeLong { get; set; }
        public double? NwLat { get; set; }
        public double? NwLong { get; set; }
        public double? SeLat { get; set; }
        public double? SeLong { get; set; }
        public double? SwLat { get; set; }
        public double? SwLong { get; set; }
        public short? FormatCode { get; set; }
        public string CmrIdent { get; set; }
        public int? MdId { get; set; }
        public int? UsesysidIns { get; set; }
        public int? UsesysidUpd { get; set; }
        public int? CoordSysCode { get; set; }
        public byte[] Metadata { get; set; }
        public double? Resolution { get; set; }
        public bool? ComplE { get; set; }
        public bool? ComplW { get; set; }
        public bool? ComplS { get; set; }
        public bool? ComplN { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public short? CmrKindCode { get; set; }
        public bool Deleted { get; set; }
        public int? DatumCode { get; set; }
        public double? FillingProcent { get; set; }

        public virtual ICollection<Cmr1> Cmr1 { get; set; }
    }
}
