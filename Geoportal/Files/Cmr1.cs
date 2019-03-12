using System;
using System.Collections.Generic;

namespace Geoportal.Files
{
    public partial class Cmr1
    {
        public int CmrId { get; set; }
        public int DeletId { get; set; }

        public virtual Cmr Cmr { get; set; }
    }
}
