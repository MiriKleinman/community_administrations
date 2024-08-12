using DataAccess.DBModels;
using DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {

        CommunityAdministrationContext _dbContext;
        ILogger<User> logger;
        IUtilsRepository utilsRepository;
        IConfiguration config;
        public UserRepository(CommunityAdministrationContext _dbContext, ILogger<User> logger, IUtilsRepository utilsRepository, IConfiguration config)
        {
            this._dbContext = _dbContext;
            this.logger = logger;
            this.utilsRepository = utilsRepository;
            this.config = config;

        }
        public async Task<int> LoginUser(string userId, string password)
        {
            if (await checkPermissionOfMainManager(userId, password)==1)
                return 5;
            User user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
                return 3;
            if (user.Password != password)
                return 4;
            if (user.IsManager)
                return 1;
            return 2;

        }
        public async Task<User> GetUserById(string userId, string password)
        {
            User user = await _dbContext.Users.FindAsync(userId);
            if (user == null || user.Password != password )
                return null;
            return user;
        }
        public async Task<int> AddUser(User user, string userId,string password)
        {
           
            User resUser = await _dbContext.Users.FindAsync(user.UserId);
            if (resUser != null)
                return 3;
            if ((user.IsManager && await utilsRepository.CheckPermissionOfManager(userId, user.CommunityAdministrationId)) || !user.IsManager|| await checkPermissionOfMainManager(userId, password) == 1|| await checkPermissionOfMainManager(userId,password)==1)
            {
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            return 2;
        }
        public async Task<int> UpdateUser(string userId,string password, User user)
        {
            User prevUser = await _dbContext.Users.FindAsync(userId);

            if (prevUser == null)
                return 2;
            var res = await checkPermissionOfMainManager(userId, password);
            if (prevUser.Password != password &&res!=1)
                return 3;
            prevUser.UserId = user.UserId;
            prevUser.Password = user.Password;
            prevUser.Email = user.Email;
            prevUser.FirstName = user.FirstName;
            prevUser.LastName = user.LastName;
            prevUser.Phone = user.Phone;
            _dbContext.Users.Update(prevUser);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        public async Task<int> DeleteUser(string userId,string password)
        {

            User user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
                return 2;
            var res = await checkPermissionOfMainManager(userId, password);

            if (user.Password != password&&res!=1)
                return 3;
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        public async Task<int>checkPermissionOfMainManager(string userId,string password)
        {
            string userIdConfig = config.GetSection("MainManager").GetSection("userId").Value;
            string passswordConfig = config.GetSection("MainManager").GetSection("password").Value;
            if (userId == userIdConfig && password == passswordConfig)
                return 1;
            return 2;

        }
    }
}
