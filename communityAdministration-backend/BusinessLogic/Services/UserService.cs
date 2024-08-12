using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Interfaces;
using DataAccess.DBModels;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {


        IUserRepository userRepository;
        IMapper mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public async Task<int> LoginUser(string userId, string password)
        {
            return await userRepository.LoginUser(userId, password);
        }
        public async Task<int> AddUser(UserDto user, string userId, string password)
        {
            User resUser = mapper.Map<User>(user);
            return await userRepository.AddUser(resUser,userId, password);
        }
        public async Task<int> DeleteUser(string userId,string passWord)
        {
            return await userRepository.DeleteUser(userId, passWord);
        }

        public async Task<UserDto> GetUserById(string userId, string passWord)
        {

            UserDto user = mapper.Map<UserDto>(await userRepository.GetUserById(userId,passWord));
            return user;
        }
        public async Task<int> UpdateUser(string userId,string passWord, UserDto user)
        {
            User resUser = mapper.Map<User>(user);
          return  await userRepository.UpdateUser(userId, passWord, resUser);
        }       
    }
}
