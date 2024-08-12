using BusinessLogic.Dto;
using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICommunityAdministrationService
    {
        public Task<int> AddCommunityAdministration(string userId, string passWord, CommunityAdministrationDto communityAdministration);
        public Task<int> UpdateCommunityAdministration(string userId, string passWord, string CommunityAdministrationId, CommunityAdministration communityAdministration);
        public Task<int> DeleteCommunityAdministration(string userId, string passWord, string CommunityAdministrationId);
        public Task<List<CommunityAdministrationDto>> GetCommunityAdministrations(string managerId, string managerPassword);
        public Task<List<NameCommunityAdministration>> GetNamesListOfCommunityAdministration();
        public Task<CommunityAdministration> GetCommunityAdministrationById(string communityAdministrationId);
    }
}
