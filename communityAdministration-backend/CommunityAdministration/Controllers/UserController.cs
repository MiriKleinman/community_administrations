using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunityAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService UserService;
        IMapper mapper;
        public UserController(IUserService UserService, IMapper mapper)
        {
            this.UserService = UserService;
            this.mapper = mapper;

        }
        [HttpGet, Route("LoginUser/{userId}/{password}")]
        public async Task<int> LoginUser(string userId, string password)
        {
            return await UserService.LoginUser(userId, password);
        }

        [HttpGet, Route("GetUserById/{userId}/{passWord}")]
        public async Task<UserDto> GetUserById(string userId, string passWord)
        {
            return await UserService.GetUserById(userId, passWord);
        }
        [HttpPut, Route("UpdateUser/{userId}/{passWord}")]
        public async Task<int> UpdateUser(string userId,string passWord, UserDto user)
        {
           return await UserService.UpdateUser(userId,passWord, user);
        }
        [HttpPost, Route("AddUser/{userId}/{password}")]
        public async Task<int> AddUser(UserDto user, string userId,string password)
        {
            return await UserService.AddUser(user,userId,password);
        }
        [HttpDelete, Route("DeleteUser/{userId}/{passWord}")]
        public async Task<int> DeleteUser(string userId,string passWord)
        {
            return await UserService.DeleteUser(userId,passWord);

        }

    }
}
