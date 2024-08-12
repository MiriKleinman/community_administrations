using BusinessLogic.Dto;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunityAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayingCenterController : ControllerBase
    {
        IPlayingCenterService playingCenterService;
        public PlayingCenterController(IPlayingCenterService playingCenterService)
        {
            this.playingCenterService = playingCenterService;
        }
        [HttpGet, Route("GetPlayingCenter/{communityAdministrationId}")]
        public async Task<List<UnitTimeOfPlayingCenterDto>> GetUnitTimeOfPlayingCenter( string communityAdministrationId)
        {
            return await playingCenterService.GetPlayingCenter(communityAdministrationId);
        }
        [HttpGet, Route("GetPlayingCenterId/{communityAdministrationId}")]
        public async Task<int> GetPlayingCenterId(string communityAdministrationId)
        {
            return await playingCenterService.GetPlayingCenterId(communityAdministrationId);
        }
        [HttpGet, Route("GetUnitTimeOfPlayingCenter/{unitTimeId}")]
        public async Task<UnitTimeOfPlayingCenterDto> GetUnitTimeOfPlayingCenter(int unitTimeId)
        {
            return await playingCenterService.GetUnitTimeOfPlayingCenter(unitTimeId);
        }
        [HttpPut, Route("UpdateUnitTimeOfPlayingCenter/{unitTimeId}/{userId}")]
        public async Task<int> UpdateUnitTimeOfPlayingCenter(int unitTimeId, UnitTimeOfPlayingCenterDto unitTimeOfPlayingCenter, string userId)
        {
          return  await playingCenterService.UpdateUnitTimeOfPlayingCenter(unitTimeId, unitTimeOfPlayingCenter, userId);
        }
        [HttpDelete, Route("DeleteUnitTimeOfPlayingCenter/{unitTimeId}/{userId}")]
        public async Task<int> DeleteUnitTimeOfPlayingCenter(int unitTimeId, string userId)
        {
            return await playingCenterService.DeleteUnitTimeOfPlayingCenter(unitTimeId, userId);
        }
        [HttpPost, Route("AddUnitTimeOfPlayingCenter/{userId}")]
        public async Task<int> AddUnitTimeOfPlayingCenter(UnitTimeOfPlayingCenterDto unitTimeOfPlayingCenter, string userId)
        {
            return await playingCenterService.AddUnitTimeOfPlayingCenter(unitTimeOfPlayingCenter, userId);
        }
        [HttpPost, Route("AddPlayingCenter/{userId}")]
        public async Task<int> AddPlayingCenter(PlayingCenterDto playingCenter, string userId)
        {
            return await playingCenterService.AddPlayingCenter(playingCenter, userId);
        }
    }
}
