using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class UnitTimeOfLibrary
    {
        public int UnitTimeId { get; set; }
        public int LibraryId { get; set; }
        public string TargetAudience { get; set; } = null!;
        public string Day { get; set; } = null!;
        public string BeginngTime { get; set; } = null!;
        public string EndTime { get; set; } = null!;

        public virtual Library Library { get; set; } = null!;
    }
}
