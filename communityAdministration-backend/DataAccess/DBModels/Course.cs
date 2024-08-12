using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class Course
    {
        public Course()
        {
            CourseRegistereds = new HashSet<CourseRegistered>();
        }

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

        public virtual CommunityAdministration CommunityAdministration { get; set; } = null!;
        public virtual ICollection<CourseRegistered> CourseRegistereds { get; set; }
    }
}
