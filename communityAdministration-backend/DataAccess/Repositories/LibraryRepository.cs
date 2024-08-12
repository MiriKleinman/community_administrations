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
    public class LibraryRepository : ILibraryRepository
    {
        CommunityAdministrationContext _dbContext;
        ILogger<Library> logger;
        IUtilsRepository utilsRepository;
        public LibraryRepository(CommunityAdministrationContext _dbContext, ILogger<Library> logger, IUtilsRepository utilsRepository)
        {
            this._dbContext = _dbContext;
            this.logger = logger;
            this.utilsRepository = utilsRepository;

        }

        public async Task<int> AddLibrary(Library library, string userId)
        {
            if (!await utilsRepository.CheckPermissionOfManager(userId, library.CommunityAdministrationId))
                return 2;
            await _dbContext.Libraries.AddAsync(library);
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<int> AddUnitTimeOfLIbrary(UnitTimeOfLibrary unitTimeOfLibrary, string userId)
        {
            Library library = await _dbContext.Libraries.FindAsync(unitTimeOfLibrary.LibraryId);
            if (!await utilsRepository.CheckPermissionOfManager(userId, library.CommunityAdministrationId))
                return 2;
            await _dbContext.UnitTimeOfLibraries.AddAsync(unitTimeOfLibrary);
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteUnitTimeOfLibrary(int unitTimeId, string userId)
        {

            var library = await _dbContext.UnitTimeOfLibraries.Include(u => u.Library).Where(u => u.UnitTimeId == unitTimeId).FirstOrDefaultAsync();
            if (!await utilsRepository.CheckPermissionOfManager(userId, library.Library.CommunityAdministrationId))
                return 2;
            var res = await _dbContext.UnitTimeOfLibraries.FindAsync(unitTimeId);
            _dbContext.UnitTimeOfLibraries.Remove(res);
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<List<UnitTimeOfLibrary>> GetLibrary(string communityAdministrationId)
        {
            CommunityAdministration communityAdministration = await _dbContext.CommunityAdministrations.FindAsync(communityAdministrationId);
            var library = await _dbContext.Libraries.Where((library) => library.CommunityAdministrationId == communityAdministration.CommunityAdministrationId).FirstOrDefaultAsync();
            return await _dbContext.UnitTimeOfLibraries.Where(u => u.LibraryId == library.LibraryId).ToListAsync();
        }

        public async Task<int> GetLibraryId(string communityAdministrationId)
        {
            CommunityAdministration communityAdministration = await _dbContext.CommunityAdministrations.FindAsync(communityAdministrationId);
            var library = await _dbContext.Libraries.Where((library) => library.CommunityAdministrationId == communityAdministration.CommunityAdministrationId).FirstOrDefaultAsync();
            return library.LibraryId;
        }

        public async Task<UnitTimeOfLibrary> GetUnitTimeOfLibrary(int unitTimeId)
        {
            return await _dbContext.UnitTimeOfLibraries.FindAsync(unitTimeId);
        }
        public async Task<int> UpdateUnitTimeOfLibrary(int unitTimeId, UnitTimeOfLibrary unitTimeOfLibrary, string userId)
        {
            var prevUnitTimeOfLibrary = await _dbContext.UnitTimeOfLibraries.Include(u => u.Library).Where(u => u.UnitTimeId == unitTimeId).FirstOrDefaultAsync();
            if (!await utilsRepository.CheckPermissionOfManager(userId, prevUnitTimeOfLibrary.Library.CommunityAdministrationId))
                return 2;
            prevUnitTimeOfLibrary.BeginngTime = unitTimeOfLibrary.BeginngTime;
            prevUnitTimeOfLibrary.Day = unitTimeOfLibrary.Day;
            prevUnitTimeOfLibrary.EndTime = unitTimeOfLibrary.EndTime;
            prevUnitTimeOfLibrary.TargetAudience = unitTimeOfLibrary.TargetAudience;
            unitTimeOfLibrary.UnitTimeId = unitTimeId;
            _dbContext.UnitTimeOfLibraries.Update(prevUnitTimeOfLibrary);
            await _dbContext.SaveChangesAsync();
            return 1;

        }
    }
}
