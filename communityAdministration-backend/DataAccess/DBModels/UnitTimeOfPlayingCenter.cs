using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class UnitTimeOfPlayingCenter
    {
        public int UnitTimeId { get; set; }
        public int PlayingCenterId { get; set; }
        public string OperatorName { get; set; } = null!;
        public string Day { get; set; } = null!;
        public string BeginningTime { get; set; } = null!;
        public string EndTime { get; set; } = null!;

        public virtual PlayingCenter PlayingCenter { get; set; } = null!;
    }
}
