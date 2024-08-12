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
    public class LibraryController : ControllerBase
    {
       ILibraryService libraryService;
        public LibraryController(ILibraryService libraryService)
        {
            this.libraryService = libraryService;
        }
        [HttpGet, Route("GetLibrary/{communityAdministrationId}")]
        public async Task<List<UnitTimeOfLibraryDto>> GetLibrary(string communityAdministrationId)
        {
            return await libraryService.GetLibrary(communityAdministrationId);
        }
        [HttpGet, Route("GetLibraryId/{communityAdministrationId}")]
        public async Task<int> GetLibraryId(string communityAdministrationId)
        {
            return await libraryService.GetLibraryId(communityAdministrationId);
        }
        [HttpGet, Route("GetUnitTimeOfLibrary/{unitTimeId}")]
        public async Task<UnitTimeOfLibraryDto> GetUnitTimeOfLibrary(int unitTimeId)
        {
            return await libraryService.GetUnitTimeOfLibrary(unitTimeId);
        }
        [HttpPut, Route("UpdateUnitTimeOfLibrary/{unitTimeId}/{userId}")]
        public async Task<int> UpdateUnitTimeOfLibrary(int unitTimeId, UnitTimeOfLibraryDto unitTimeOfLibrary, string userId)
        {
           return await libraryService.UpdateUnitTimeOfLibrary(unitTimeId, unitTimeOfLibrary, userId);
        }
        [HttpDelete, Route("DeleteUnitTimeOfLibrary/{unitTimeId}/{userId}")]
        public async Task<int> DeleteUnitTimeOfLibrary(int unitTimeId, string userId)
        {
            return await libraryService.DeleteUnitTimeOfLibrary(unitTimeId, userId);
        }
        [HttpPost, Route("AddUnitTimeOfLIbrary/{userId}")]
        public async Task<int> AddUnitTimeOfLIbrary(UnitTimeOfLibraryDto unitTimeOfLibrary, string userId)
        {
            return await libraryService.AddUnitTimeOfLIbrary(unitTimeOfLibrary, userId);
        }
        [HttpPost, Route("AddLibrary/{userId}")]
        public async Task<int> AddLibrary(LibraryDto library, string userId)
        {
            return await libraryService.AddLibrary(library, userId);
        }
    }
}
