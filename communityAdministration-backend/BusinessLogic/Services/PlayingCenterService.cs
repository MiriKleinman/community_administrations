using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Interfaces;
using DataAccess.DBModels;
using DataAccess.Interfaces;
using DataAccess.Repositories;

namespace BusinessLogic.Services
{
    public class PlayingCenterService : IPlayingCenterService
    {
        IPlayingCenterRepository playingCenterRepository;
        IMapper mapper;
        public PlayingCenterService(IPlayingCenterRepository playingCenterRepository, IMapper mapper)
        {
            this.playingCenterRepository = playingCenterRepository;
            this.mapper = mapper;
        }

        public async Task<int> AddPlayingCenter(PlayingCenterDto playingCenter, string userId)
        {
            PlayingCenter resPlayingCenter = mapper.Map<PlayingCenter>(playingCenter);
            return await playingCenterRepository.AddPlayingCenter(resPlayingCenter, userId);
        }

        public async Task<int> AddUnitTimeOfPlayingCenter(UnitTimeOfPlayingCenterDto unitTimeOfPlayingCenter, string userId)
        {
            UnitTimeOfPlayingCenter resUnitTimeOfPlayingCenter = mapper.Map<UnitTimeOfPlayingCenter>(unitTimeOfPlayingCenter);
            return await playingCenterRepository.AddUnitTimeOfPlayingCenter(resUnitTimeOfPlayingCenter, userId);
        }

        public async Task<int> DeleteUnitTimeOfPlayingCenter(int unitTimeId, string userId)
        {
            return await playingCenterRepository.DeleteUnitTimeOfPlayingCenter(unitTimeId, userId);
        }

        public async Task<List<UnitTimeOfPlayingCenterDto>> GetPlayingCenter(string communityAdministrationId)
        {
            List<UnitTimeOfPlayingCenter> playingCenter = await playingCenterRepository.GetPlayingCenter(communityAdministrationId);
            List<UnitTimeOfPlayingCenterDto> resPlayingCenter = new();
            foreach (var unitTimeOfPlayingCenter in playingCenter)
            {
                resPlayingCenter.Add(mapper.Map<UnitTimeOfPlayingCenterDto>(unitTimeOfPlayingCenter));
            }
            return resPlayingCenter;
        }
        public async Task<int> GetPlayingCenterId(string communityAdministrationId)
        {
            return await playingCenterRepository.GetPlayingCenterId(communityAdministrationId);
        }

        public async Task<UnitTimeOfPlayingCenterDto> GetUnitTimeOfPlayingCenter(int unitTimeId)
        {
            UnitTimeOfPlayingCenter unitTime = await playingCenterRepository.GetUnitTimeOfPlayingCenter(unitTimeId);
            return mapper.Map<UnitTimeOfPlayingCenterDto>(unitTime);
        }

        public async Task<int> UpdateUnitTimeOfPlayingCenter(int unitTimeId, UnitTimeOfPlayingCenterDto unitTimeOfPlayingCenter, string userId)
        {
            UnitTimeOfPlayingCenter resUnitTimeOfPlayingCenter = mapper.Map<UnitTimeOfPlayingCenter>(unitTimeOfPlayingCenter);
            return await playingCenterRepository.UpdateUnitTimeOfPlayingCenter(unitTimeId, resUnitTimeOfPlayingCenter, userId);
        }
    }
}
