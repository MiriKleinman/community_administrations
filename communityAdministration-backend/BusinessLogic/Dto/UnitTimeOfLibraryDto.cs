using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto
{
    public class UnitTimeOfLibraryDto
    {
        public int UnitTimeId { get; set; }
        public int LibraryId { get; set; }
        public string TargetAudience { get; set; } = null!;
        public string Day { get; set; }
        public string BeginngTime { get; set; } = null!;
        public string EndTime { get; set; } = null!;
    }
}
