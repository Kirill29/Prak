using System;
using System.Collections.Generic;

namespace Geoportal
{
	public partial class FilesCmr
	{
		public int FilesCmrId { get; set; }
		
		public int? CmrId { get; set; }
		
		public string FileName { get; set; }
		
		public string FileSize { get; set; }
		
		public short? FilesType { get; set; }
		
		public string RootDir { get; set; }
		
		public string CurrentDir { get; set; }
		
		public long? DemandArchiveErsNr { get; set; }
		
		public long? FilesDemandArchiveNr { get; set; }
		
		public DateTime? DateSendDemand { get; set; }
		
		public long? FilesIsArchivedNr { get; set; }
		
		public int? UsesysidUpd { get; set; }
		
		public int? UsesysidIns { get; set; }
		
		public byte[] File { get; set; }
		
		public string Md5 { get; set; }
		
		public bool? Deleted { get; set; }
		
		public short? StoreTypeCode { get; set; }
	}
}