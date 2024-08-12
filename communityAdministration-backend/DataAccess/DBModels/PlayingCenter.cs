using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class PlayingCenter
    {
        public PlayingCenter()
        {
            UnitTimeOfPlayingCenters = new HashSet<UnitTimeOfPlayingCenter>();
        }

        public int PlayingCenterId { get; set; }
        public string CommunityAdministrationId { get; set; } = null!;

        public virtual CommunityAdministration CommunityAdministration { get; set; } = null!;
        public virtual ICollection<UnitTimeOfPlayingCenter> UnitTimeOfPlayingCenters { get; set; }
    }
}
