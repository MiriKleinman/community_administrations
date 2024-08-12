using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ILibraryRepository
    {
        public Task<List<UnitTimeOfLibrary>> GetLibrary(string communityAdministrationId);
        public Task<int> GetLibraryId(string communityAdministrationId);
        public Task<UnitTimeOfLibrary> GetUnitTimeOfLibrary(int unitTimeId);
        public Task<int> UpdateUnitTimeOfLibrary(int unitTimeId, UnitTimeOfLibrary unitTimeOfLibrary, string userId);
        public Task<int> DeleteUnitTimeOfLibrary(int unitTimeId, string userId);
        public Task<int> AddUnitTimeOfLIbrary(UnitTimeOfLibrary unitTimeOfLibrary, string userId);
        public Task<int> AddLibrary(Library library, string userId);
    }
}
