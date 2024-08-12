using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto
{
    public class ActivityDto
    {
        public int ActivityId { get; set; }
        public string CommunityAdministrationId { get; set; } = null!;
        public string ActivityName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? Cost { get; set; }
        public string TargetAudience { get; set; } = null!;
        public DateTime EndTimeOfPreview { get; set; }
        public int MaxParticipants { get; set; }
        public string? Logo { get; set; }
        public string? Color { get; set; }
        public string? Day { get; set; }
        public string? BeginngTime { get; set; }
        public string? EndTime { get; set; }
        public string? Date { get; set; }
    }
}
