using BusinessLogic.Dto;
using BusinessLogic.Interfaces;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunityAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityAdministrationController : ControllerBase
    {
        ICommunityAdministrationService communityAdministrationService;
        public CommunityAdministrationController(ICommunityAdministrationService communityAdministrationService)
        {
            this.communityAdministrationService = communityAdministrationService;
        }
        [HttpPost, Route("AddCommunityAdministration/{userId}/{passWord}")]
        public async Task<int> AddCommunityAdministration(string userId, string passWord, CommunityAdministrationDto communityAdministration)
        {
            return await communityAdministrationService.AddCommunityAdministration(userId, passWord, communityAdministration);
        }
        [HttpDelete, Route("DeleteCommunityAdministration/{userId}/{password}/{CommunityAdministrationId}")]
        public async Task<int> DeleteCommunityAdministration(string userId, string password, string CommunityAdministrationId)
        {
            return await communityAdministrationService.DeleteCommunityAdministration(userId, password, CommunityAdministrationId);

        }
        [HttpGet, Route("GetNamesListOfCommunityAdministration")]
        public async Task<List<NameCommunityAdministration>> GetNamesListOfCommunityAdministration()
        {
            return await communityAdministrationService.GetNamesListOfCommunityAdministration();
        }
        [HttpGet, Route("GetCommunityAdministrations/{managerId}/{managerPassword}")]
        public async Task<List<CommunityAdministrationDto>> GetCommunityAdministrations(string managerId, string managerPassword)
        {
            return await communityAdministrationService.GetCommunityAdministrations(managerId, managerPassword);
        }
        [HttpPut, Route("UpdateCommunityAdministration/{userId}/{password}/{CommunityAdministrationId}")]
        public async Task<int> UpdateCommunityAdministration(string userId, string password, string CommunityAdministrationId, DataAccess.DBModels.CommunityAdministration communityAdministration)
        {
            return await communityAdministrationService.UpdateCommunityAdministration(userId, password, CommunityAdministrationId, communityAdministration);

        }
        [HttpGet, Route("GetCommunityAdministrationById/{CommunityAdministrationId}")]
        public async Task<DataAccess.DBModels.CommunityAdministration> GetCommunityAdministrationById(string CommunityAdministrationId)
        {
            return await communityAdministrationService.GetCommunityAdministrationById(CommunityAdministrationId);

        }

    }
}
