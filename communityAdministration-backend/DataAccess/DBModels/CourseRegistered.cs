using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class CourseRegistered
    {
        public int CourseRegisteredId { get; set; }
        public string UserId { get; set; } = null!;
        public int CourseId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool? Paid { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
