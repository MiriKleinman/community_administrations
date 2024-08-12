using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class User
    {
        public User()
        {
            CourseRegistereds = new HashSet<CourseRegistered>();
            ParticipantInActivities = new HashSet<ParticipantInActivity>();
        }

        public string UserId { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string CommunityAdministrationId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public bool IsManager { get; set; }

        public virtual CommunityAdministration CommunityAdministration { get; set; } = null!;
        public virtual ICollection<CourseRegistered> CourseRegistereds { get; set; }
        public virtual ICollection<ParticipantInActivity> ParticipantInActivities { get; set; }
    }
}
