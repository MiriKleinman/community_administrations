using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class Library
    {
        public Library()
        {
            UnitTimeOfLibraries = new HashSet<UnitTimeOfLibrary>();
        }

        public int LibraryId { get; set; }
        public string CommunityAdministrationId { get; set; } = null!;

        public virtual CommunityAdministration CommunityAdministration { get; set; } = null!;
        public virtual ICollection<UnitTimeOfLibrary> UnitTimeOfLibraries { get; set; }
    }
}
