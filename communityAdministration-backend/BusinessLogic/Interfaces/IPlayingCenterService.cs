using BusinessLogic.Dto;
using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IPlayingCenterService
    {
        public Task<List<UnitTimeOfPlayingCenterDto>> GetPlayingCenter( string communityAdministrationId);
        public Task<int> GetPlayingCenterId(string communityAdministrationId);
        public Task<UnitTimeOfPlayingCenterDto> GetUnitTimeOfPlayingCenter(int unitTimeId);
        public Task<int> UpdateUnitTimeOfPlayingCenter(int unitTimeId, UnitTimeOfPlayingCenterDto unitTimeOfPlayingCenter, string userId);
        public Task<int> DeleteUnitTimeOfPlayingCenter(int unitTimeId, string userId);
        public Task<int> AddUnitTimeOfPlayingCenter(UnitTimeOfPlayingCenterDto unitTimeOfPlayingCenter, string userId);
        public Task<int> AddPlayingCenter(PlayingCenterDto playingCenter, string userId);
    }
}
