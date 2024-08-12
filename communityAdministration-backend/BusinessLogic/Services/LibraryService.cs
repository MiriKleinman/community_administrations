using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Interfaces;
using DataAccess.DBModels;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class LibraryService : ILibraryService
    {
        ILibraryRepository libraryRepository;
        IMapper mapper;
        public LibraryService(ILibraryRepository libraryRepository, IMapper mapper)
        {
            this.libraryRepository = libraryRepository;
            this.mapper = mapper;
        }

        public async Task<int> AddLibrary(LibraryDto library, string userId)
        {
            Library resLibrary = mapper.Map<Library>(library);
            return await libraryRepository.AddLibrary(resLibrary,  userId);
        }

        public async Task<int> AddUnitTimeOfLIbrary(UnitTimeOfLibraryDto unitTimeOfLibrary, string userId)
        {
            UnitTimeOfLibrary resUnitTimeOfLibrary = mapper.Map<UnitTimeOfLibrary>(unitTimeOfLibrary);
            return await libraryRepository.AddUnitTimeOfLIbrary(resUnitTimeOfLibrary,  userId);
        }

        public async Task<int> DeleteUnitTimeOfLibrary(int unitTimeId, string userId)
        {
            return await libraryRepository.DeleteUnitTimeOfLibrary(unitTimeId,  userId);
        }

        public async Task<List<UnitTimeOfLibraryDto>> GetLibrary(string communityAdministrationId)
        {
            List<UnitTimeOfLibrary> library = await libraryRepository.GetLibrary(communityAdministrationId);
            List<UnitTimeOfLibraryDto> resLibrary = new();
            if (library == null)
                return null;
            foreach(var unitTimeOfLibrary in library)
            {
                resLibrary.Add(mapper.Map<UnitTimeOfLibraryDto>(unitTimeOfLibrary));
            }
            return resLibrary;
        }

        public async Task<int> GetLibraryId(string communityAdministrationId)
        {
            return await libraryRepository.GetLibraryId(communityAdministrationId);
        }

        public async Task<UnitTimeOfLibraryDto> GetUnitTimeOfLibrary(int unitTimeId)
        {
            UnitTimeOfLibrary unitTime = await libraryRepository.GetUnitTimeOfLibrary(unitTimeId);
            return mapper.Map<UnitTimeOfLibraryDto>(unitTime);
        }

        public async Task<int> UpdateUnitTimeOfLibrary(int unitTimeId, UnitTimeOfLibraryDto unitTimeOfLibrary, string userId)
        {
            UnitTimeOfLibrary resUnitTimeOfLibrary = mapper.Map<UnitTimeOfLibrary>(unitTimeOfLibrary);
            return await libraryRepository.UpdateUnitTimeOfLibrary(unitTimeId, resUnitTimeOfLibrary, userId);
        }
    }
}
