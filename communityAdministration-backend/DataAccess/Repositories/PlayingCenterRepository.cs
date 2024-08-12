using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DBModels;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories
{
    public class PlayingCenterRepository : IPlayingCenterRepository
    {
        CommunityAdministrationContext _dbContext;
        ILogger<PlayingCenter> logger;
        IUtilsRepository utilsRepository;
        public PlayingCenterRepository(CommunityAdministrationContext _dbContext, ILogger<PlayingCenter> logger, IUtilsRepository utilsRepository)
        {
            this._dbContext = _dbContext;
            this.logger = logger;
            this.utilsRepository = utilsRepository;

        }
        public async Task<int> AddPlayingCenter(PlayingCenter playingCenter, string userId)
        {
            if (!await utilsRepository.CheckPermissionOfManager(userId, playingCenter.CommunityAdministrationId))
                return 2;
            await _dbContext.PlayingCenters.AddAsync(playingCenter);
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<int> AddUnitTimeOfPlayingCenter(UnitTimeOfPlayingCenter unitTimeOfPlayingCenter, string userId)
        {
            var playingCenter = await _dbContext.PlayingCenters.FindAsync(unitTimeOfPlayingCenter.PlayingCenterId);
            if (!await utilsRepository.CheckPermissionOfManager(userId, playingCenter.CommunityAdministrationId))
                return 2;
            await _dbContext.UnitTimeOfPlayingCenters.AddAsync(unitTimeOfPlayingCenter);
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteUnitTimeOfPlayingCenter(int unitTimeId, string userId)
        {
            var playingCenter = await _dbContext.UnitTimeOfPlayingCenters.Include(unitTime => unitTime.PlayingCenter).Where(unitTime => unitTime.UnitTimeId == unitTimeId).FirstOrDefaultAsync();
            if (!await utilsRepository.CheckPermissionOfManager(userId, playingCenter.PlayingCenter.CommunityAdministrationId))
                return 2;
            var res = await _dbContext.UnitTimeOfPlayingCenters.FindAsync(unitTimeId);
            _dbContext.UnitTimeOfPlayingCenters.Remove(res);
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<List<UnitTimeOfPlayingCenter>> GetPlayingCenter(string communityAdministrationId)
        {
            CommunityAdministration communityAdministration = await _dbContext.CommunityAdministrations.FindAsync(communityAdministrationId);
            var playingCenter = await _dbContext.PlayingCenters.Where(playingCenter=>playingCenter.CommunityAdministrationId== communityAdministration.CommunityAdministrationId).FirstOrDefaultAsync();
            return await _dbContext.UnitTimeOfPlayingCenters.Where(u => u.PlayingCenterId == playingCenter.PlayingCenterId).ToListAsync();
        }
        public async Task<int> GetPlayingCenterId(string communityAdministrationId)
        {
            CommunityAdministration communityAdministration = await _dbContext.CommunityAdministrations.FindAsync(communityAdministrationId);
            var playingCenter = await _dbContext.PlayingCenters.Where((playingCenter) => playingCenter.CommunityAdministrationId == communityAdministration.CommunityAdministrationId).FirstOrDefaultAsync();
            return playingCenter.PlayingCenterId;
        }
        public async Task<UnitTimeOfPlayingCenter> GetUnitTimeOfPlayingCenter(int unitTimeId)
        {
            return await _dbContext.UnitTimeOfPlayingCenters.FindAsync(unitTimeId);
        }
        public async Task<int> UpdateUnitTimeOfPlayingCenter(int unitTimeId, UnitTimeOfPlayingCenter unitTimeOfPlayingCenter, string userId)
        {
            var prevUnitTimeOfPlayingCenter = await _dbContext.UnitTimeOfPlayingCenters.Include(unitTime => unitTime.PlayingCenter).Where(unitTime => unitTime.UnitTimeId == unitTimeId).FirstOrDefaultAsync();
            if (!await utilsRepository.CheckPermissionOfManager(userId, prevUnitTimeOfPlayingCenter.PlayingCenter.CommunityAdministrationId))
                return 2;
            prevUnitTimeOfPlayingCenter.BeginningTime = unitTimeOfPlayingCenter.BeginningTime;
            prevUnitTimeOfPlayingCenter.Day = unitTimeOfPlayingCenter.Day;
            prevUnitTimeOfPlayingCenter.EndTime = unitTimeOfPlayingCenter.EndTime;
            prevUnitTimeOfPlayingCenter.OperatorName = unitTimeOfPlayingCenter.OperatorName;
            _dbContext.UnitTimeOfPlayingCenters.Update(prevUnitTimeOfPlayingCenter);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
    }
}
