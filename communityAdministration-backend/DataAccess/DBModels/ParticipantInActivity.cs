using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class ParticipantInActivity
    {
        public int ParticipantId { get; set; }
        public string UserId { get; set; } = null!;
        public int ActivityId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual Activity Activity { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
