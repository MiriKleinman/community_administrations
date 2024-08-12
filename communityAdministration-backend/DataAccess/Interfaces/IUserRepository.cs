using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUserRepository
    {
        public  Task<int> LoginUser(string userId, string password);
        public  Task<User> GetUserById(string userId, string password);
        public  Task<int> AddUser(User user, string userId, string password);
        public  Task<int> UpdateUser(string userId, string passWord, User user);
        public  Task<int> DeleteUser(string userId, string passWord);
        public Task<int> checkPermissionOfMainManager(string userId, string password);




    }
}
