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
    public class CommunityAdministrationService : ICommunityAdministrationService
    {

        ICommunityAdministrationRepository CommunityAdministrationRepository;
        IMapper mapper;
        public CommunityAdministrationService(ICommunityAdministrationRepository CommunityAdministrationRepository, IMapper mapper)
        {
            this.CommunityAdministrationRepository = CommunityAdministrationRepository;
            this.mapper = mapper;
        }
        public async Task<int> AddCommunityAdministration(string userId, string passWord, CommunityAdministrationDto communityAdministration)
        {
            CommunityAdministration newCommunityAdministration = new();
            newCommunityAdministration.Email = communityAdministration.Email;
            newCommunityAdministration.Phone = communityAdministration.Phone;
            newCommunityAdministration.CommunityAdministrationId = communityAdministration.CommunityAdministrationId;
            newCommunityAdministration.Address = communityAdministration.Address;
            newCommunityAdministration.Color = communityAdministration.Color;
            newCommunityAdministration.Logo = communityAdministration.Logo;
            newCommunityAdministration.Name = communityAdministration.Name;
            User user = new();
            user.Email = communityAdministration.Email;
            user.FirstName = communityAdministration.FirstName;
            user.IsManager = true;
            user.LastName = communityAdministration.LastName;
            user.Password = communityAdministration.Password;
            user.Phone = communityAdministration.Phone;
            user.UserId = communityAdministration.UserId;
            user.CommunityAdministrationId = communityAdministration.CommunityAdministrationId;
            return await CommunityAdministrationRepository.AddCommunityAdministration(userId, passWord, newCommunityAdministration, user);
        }

        public async Task<int> DeleteCommunityAdministration(string userId, string passWord, string CommunityAdministrationId)
        {
            return await CommunityAdministrationRepository.DeleteCommunityAdministration(userId, passWord, CommunityAdministrationId);
        }

        public async Task<List<NameCommunityAdministration>> GetNamesListOfCommunityAdministration()
        {
            return await CommunityAdministrationRepository.GetNamesListOfCommunityAdministration();
        }

        public async  Task<int> UpdateCommunityAdministration(string userId, string passWord, string CommunityAdministrationId, CommunityAdministration communityAdministration)
        {
            return await CommunityAdministrationRepository.UpdateCommunityAdministration(userId, passWord, CommunityAdministrationId, communityAdministration);
        }
        public async Task<List<CommunityAdministrationDto>> GetCommunityAdministrations(string managerId, string managerPassword)
        {
            List<CommunityAdministration> resCommunityAdministration = await CommunityAdministrationRepository.GetCommunityAdministrations(managerId, managerPassword);
            List<CommunityAdministrationDto> communityAdministrations = new();
            if (resCommunityAdministration == null)
                return null;
            foreach (var communityAdministration in resCommunityAdministration)
            {
                communityAdministrations.Add(mapper.Map<CommunityAdministrationDto>(communityAdministration));
            }
            return communityAdministrations;
        }
        public async Task<CommunityAdministration> GetCommunityAdministrationById(string communityAdministrationId)
        {
            return await CommunityAdministrationRepository.GetCommunityAdministrationById(communityAdministrationId);
        }

    }
}
