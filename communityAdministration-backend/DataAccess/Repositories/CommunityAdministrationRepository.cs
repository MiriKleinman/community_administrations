using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DBModels;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace DataAccess.Repositories
{
    public class CommunityAdministrationRepository : ICommunityAdministrationRepository
    {
        IConfiguration config;
        CommunityAdministrationContext _dbContext;
        ILogger<Activity> logger;
        IUtilsRepository utilsRepository;
        IUserRepository userRepository;
        public CommunityAdministrationRepository(CommunityAdministrationContext _dbContext, ILogger<Activity> logger, IUtilsRepository utilsRepository, IConfiguration config, IUserRepository userRepository)

        {
            this.utilsRepository = utilsRepository;
            this._dbContext = _dbContext;
            this.logger = logger;
            this.config = config;
            this.userRepository = userRepository;

        }

        public async Task<int> AddCommunityAdministration(string userId, string password, CommunityAdministration communityAdministration, User user)
        {
            if (await _dbContext.CommunityAdministrations.FindAsync(communityAdministration.CommunityAdministrationId) != null)
                return 3;
            if (await CheckPermissionOfMainManager(userId, password))
            {
                await _dbContext.CommunityAdministrations.AddAsync(communityAdministration);
                await _dbContext.SaveChangesAsync();
                await userRepository.AddUser(user, userId, password);
                return 1;
            }
            return 2;

        }
        public async Task<int> UpdateCommunityAdministration(string userId, string password, string CommunityAdministrationId, CommunityAdministration communityAdministration)
        {
            CommunityAdministration prevCommunityAdministration = await _dbContext.CommunityAdministrations.FindAsync(CommunityAdministrationId);
            if (prevCommunityAdministration == null)
                return 3;
            if (await CheckPermissionOfMainManager(userId, password))
            {
                prevCommunityAdministration.CommunityAdministrationId = communityAdministration.CommunityAdministrationId;
                prevCommunityAdministration.Name = communityAdministration.Name;
                prevCommunityAdministration.Email = communityAdministration.Email;
                prevCommunityAdministration.Phone = communityAdministration.Phone;
                prevCommunityAdministration.Address = communityAdministration.Address;
                _dbContext.CommunityAdministrations.Update(prevCommunityAdministration);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            return 2;
        }
        public async Task<int> DeleteCommunityAdministration(string userId, string password, string communityAdministrationId)
        {
            CommunityAdministration communityAdministration = await _dbContext.CommunityAdministrations.FindAsync(communityAdministrationId);
            if (communityAdministration == null)
                return 3;
            if (await CheckPermissionOfMainManager(userId, password))
            {
                _dbContext.CommunityAdministrations.Remove(communityAdministration);
                await _dbContext.SaveChangesAsync();
                await userRepository.DeleteUser(userId, password);
                return 1;
            }
            return 2;
        }
        public async Task<List<NameCommunityAdministration>> GetNamesListOfCommunityAdministration()
        {
            List<NameCommunityAdministration> namesListOfCommunityAdministration = new List<NameCommunityAdministration>();
            await _dbContext.CommunityAdministrations.ForEachAsync((c) => namesListOfCommunityAdministration.Add(new NameCommunityAdministration() { CommunityAdministrationName = c.Name, CommunityAdministrationId = c.CommunityAdministrationId }));
            return namesListOfCommunityAdministration;
        }
        public async Task<List<CommunityAdministration>> GetCommunityAdministrations(string managerId, string managerPassword)
        {
            if (await CheckPermissionOfMainManager(managerId, managerPassword))
            {
                return await _dbContext.CommunityAdministrations.ToListAsync();
            }
            return null;
        }
        public async Task<bool> CheckPermissionOfMainManager(string userId, string password)
        {
            string userIdConfig = config.GetSection("MainManager").GetSection("userId").Value;
            string passswordConfig = config.GetSection("MainManager").GetSection("password").Value;
            if (password == passswordConfig && userId == userIdConfig)
                return true;
            return false;
        }

        public async Task<CommunityAdministration> GetCommunityAdministrationById(string communityAdministrationId)
        {
            CommunityAdministration communityAdministration = await _dbContext.CommunityAdministrations.FindAsync(communityAdministrationId);
            if (communityAdministration == null)
                return null;
            return communityAdministration;
        }
    }
}

