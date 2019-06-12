using System;
using System.Collections.Generic;

namespace Geoportal
{
    public partial class DemandArchiveErs
    {
        public long DemandArchiveErsNr { get; set; }
        public int? WorkstationsNr { get; set; }
        public int? Status { get; set; }
        public DateTime? DtstampBeginDemand { get; set; }
        public DateTime? DtstampEndDemand { get; set; }
        public int? RegionTypesNr { get; set; }
        public int? Priority { get; set; }
        public int? ErrorCode { get; set; }
        public long? RouteId { get; set; }
        public long? MapId { get; set; }
        public int? ProgressPercentage { get; set; }
        public int? ConfirmDeleteAfterArchive { get; set; }
        public long? ScanId { get; set; }
        public short? SensorId { get; set; }
        public string MessageFromService { get; set; }
        public int? NumberOfDemandArchiveNr { get; set; }
        public long? DocId { get; set; }
        public string ServerToShare { get; set; }
        public string PathToShare { get; set; }
        public string ServiceTypeToShare { get; set; }
        public string UserToShare { get; set; }
        public string PasswordToShare { get; set; }
        public string PathToProfEbgd { get; set; }
        public int? TypesDemandNr { get; set; }
        public string Level { get; set; }
        public string DomainNameToShare { get; set; }
        public int? ProgressPercentageRemote { get; set; }
        public long? ProductId { get; set; }
        public long? CmrId { get; set; }
        public long? OfpId { get; set; }
        public int? UsesysidIns { get; set; }
        public int? UsesysidUpd { get; set; }
        public long? ObjectId { get; set; }
        public long? TrackId { get; set; }
        public long? DelId { get; set; }
    }
}
