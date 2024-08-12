using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class CommunityAdministration
    {
        public CommunityAdministration()
        {
            Activities = new HashSet<Activity>();
            Courses = new HashSet<Course>();
            Libraries = new HashSet<Library>();
            PlayingCenters = new HashSet<PlayingCenter>();
            Users = new HashSet<User>();
        }

        public string CommunityAdministrationId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Logo { get; set; }
        public string? Color { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Library> Libraries { get; set; }
        public virtual ICollection<PlayingCenter> PlayingCenters { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
