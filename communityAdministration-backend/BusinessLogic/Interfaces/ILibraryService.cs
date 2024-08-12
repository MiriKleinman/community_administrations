using BusinessLogic.Dto;
using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ILibraryService
    {
        public Task<List<UnitTimeOfLibraryDto>> GetLibrary(string communityAdministrationId);
        public Task<int> GetLibraryId(string communityAdministrationId);
        public Task<UnitTimeOfLibraryDto> GetUnitTimeOfLibrary(int unitTimeId);
        public Task<int> UpdateUnitTimeOfLibrary(int unitTimeId, UnitTimeOfLibraryDto unitTimeOfLibrary, string userId);
        public Task<int> DeleteUnitTimeOfLibrary(int unitTimeId, string userId);
        public Task<int> AddUnitTimeOfLIbrary(UnitTimeOfLibraryDto unitTimeOfLibrary, string userId);
        public Task<int> AddLibrary(LibraryDto library, string userId);
    }
}
