using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto
{
    public class UnitTimeOfPlayingCenterDto
    {
        public int UnitTimeId { get; set; }
        public int PlayingCenterId { get; set; }
        public string OperatorName { get; set; } = null!;
        public string Day { get; set; }
        public string BeginningTime { get; set; } = null!;
        public string EndTime { get; set; } = null!;
    }
}
