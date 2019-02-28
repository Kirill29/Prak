using System;
using System.Collections.Generic;

namespace Geoportal
{
    public partial class FilesDemandArchiveErs
    {
        public long FilesDemandArchiveErsNr { get; set; }
        public long DemandArchiveErsNr { get; set; }
        public string PathFileName { get; set; }
        public long? FileSizeInBytes { get; set; }
        public int? Status { get; set; }
        public long? UniqueIdentForRetrieve { get; set; }
        public int? ErrorCode { get; set; }
        public int? ProgressPercentage { get; set; }
        public string RealMd5 { get; set; }
        public string ExpectedMd5 { get; set; }
        public string MessageFromService { get; set; }
        public long? FileSizeInBytesArchived { get; set; }
        public string ServerToShare { get; set; }
        public string PathToShare { get; set; }
        public string ServiceTypeToShare { get; set; }
        public string UserToShare { get; set; }
        public string PasswordToShare { get; set; }
        public int? ProgressPercentageRemote { get; set; }
        public string DomainNameToShare { get; set; }
        public long? CmrId { get; set; }
        public int? UsesysidIns { get; set; }
        public int? UsesysidUpd { get; set; }
        public long? UniqueIdentAresp { get; set; }
    }
}
