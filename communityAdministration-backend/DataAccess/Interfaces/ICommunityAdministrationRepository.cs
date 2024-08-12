using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICommunityAdministrationRepository
    {
        public Task<int> AddCommunityAdministration(string userId, string passWord, CommunityAdministration communityAdministration, User user);
        public Task<int> UpdateCommunityAdministration(string userId, string passWord, string CommunityAdministrationId, CommunityAdministration communityAdministration);
        public Task<int> DeleteCommunityAdministration(string userId, string passWord, string CommunityAdministrationId);
        public Task<List<NameCommunityAdministration>> GetNamesListOfCommunityAdministration();
        public Task<CommunityAdministration> GetCommunityAdministrationById(string communityAdministrationId);
        public Task<List<CommunityAdministration>> GetCommunityAdministrations(string managerId, string managerPassword);

    }
}
