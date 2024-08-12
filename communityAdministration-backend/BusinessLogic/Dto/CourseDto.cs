using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto
{
    public class CourseDto
    {

        public int CourseId { get; set; }
        public string CommunityAdministrationId { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public string TargetAudience { get; set; } = null!;
        public int CostForLesson { get; set; }
        public string OperatorName { get; set; } = null!;
        public int MaxParticipants { get; set; }
        public string? Remarks { get; set; }
        public DateTime EndTimeOfPreview { get; set; }
        public DateTime EndTimeOfRegister { get; set; }
        public string? Logo { get; set; }
        public string? Color { get; set; }
        public string? Day { get; set; }
        public string? BeginngTime { get; set; }
        public string? EndTime { get; set; }
        public int? CountOfRegistereds { get; set; }

    }
}
