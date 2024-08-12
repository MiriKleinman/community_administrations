using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IPlayingCenterRepository
    {
        public Task<List<UnitTimeOfPlayingCenter>> GetPlayingCenter(string communityAdministrationId);
        public Task<int> GetPlayingCenterId(string communityAdministrationId);
        public Task<UnitTimeOfPlayingCenter> GetUnitTimeOfPlayingCenter(int unitTimeId);
        public Task<int> UpdateUnitTimeOfPlayingCenter(int unitTimeId, UnitTimeOfPlayingCenter unitTimeOfPlayingCenter, string userId);
        public Task<int> DeleteUnitTimeOfPlayingCenter(int unitTimeId, string userId);
        public Task<int> AddUnitTimeOfPlayingCenter(UnitTimeOfPlayingCenter unitTimeOfPlayingCenter, string userId);
        public Task<int> AddPlayingCenter(PlayingCenter playingCenter, string userId);
    }
}
