using BusinessLogic.Dto;
using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        public Task<int> LoginUser(string userId, string password);
        public Task<UserDto> GetUserById(string userId, string password);
        public Task<int> AddUser(UserDto user, string userId, string password);
        public Task<int> UpdateUser(string userId, string passWord, UserDto user);
        public Task<int> DeleteUser(string userId, string passWord);
    }
}
