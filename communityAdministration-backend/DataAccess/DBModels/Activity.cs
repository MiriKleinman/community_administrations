using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class Activity
    {
        public Activity()
        {
            ParticipantInActivities = new HashSet<ParticipantInActivity>();
        }

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

        public virtual CommunityAdministration CommunityAdministration { get; set; } = null!;
        public virtual ICollection<ParticipantInActivity> ParticipantInActivities { get; set; }
    }
}
