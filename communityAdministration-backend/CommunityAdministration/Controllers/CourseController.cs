using BusinessLogic.Dto;
using BusinessLogic.Interfaces;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunityAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        ICourseService courseService;
        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }
        //[HttpGet, Route("GetCourses/{communityAdministrationId}")]
        //public async Task<List<CourseDto>> GetCourses(string communityAdministrationId)
        //{
        //    return await courseService.GetCourses(communityAdministrationId);
        //}
        [HttpGet, Route("GetCoursesByTargetAudience/{communityAdministrationId}/{targetAudience}")]
        public async Task<List<Course>> GetCoursesByTargetAudience(string communityAdministrationId, string targetAudience)
        {
            return await courseService.GetCoursesByTargetAudience(communityAdministrationId, targetAudience);
        }
        [HttpGet, Route("GetCoursesByTargetAudienceMainManager/{targetAudience}/{userId}/{password}")]
        public async Task<List<Course>> GetCoursesByTargetAudienceMainManager(string targetAudience, string userId, string password)
        {
            return await courseService.GetCoursesByTargetAudienceMainManager(targetAudience, userId, password);
        }
        [HttpGet, Route("GetCourseById/{courseId}")]
        public async Task<Course> GetCourseById(int courseId)
        {
            return await courseService.GetCourseById(courseId);
        }
        //[HttpPost, Route("AddCourse/{userId}/{userfile}")]
        //public async Task<int> AddCourse([FromQuery]CourseDto course,string userId, IFormFile userfile)
        //{
        //  return  await courseService.AddCourse(course, userId, userfile);
        //}
        [HttpPost, Route("AddCourse/{userId}")]
        public async Task<int> AddCourse(CourseDto course, string userId)
        {
            return await courseService.AddCourse(course, userId);
        }
        [HttpPut, Route("UpdateCourse/{courseId}/{userId}")]
        public async Task<int> UpdateCourse(int courseId, CourseDto course, string userId)
        {
           return await courseService.UpdateCourse(courseId, course, userId);
        }
        [HttpGet, Route("CheckForDelete/{courseId}/{userId}")]
        public async Task<bool> CheckForDelete(int courseId, string userId)
        {
            return await courseService.CheckForDelete(courseId, userId);
        }
        [HttpDelete, Route("DeleteCourse/{courseId}/{userId}")]
        public async Task<int> DeleteCourse(int courseId, string userId)
        {
            return await courseService.DeleteCourse(courseId, userId);
        }
        [HttpPost, Route("AddCourseRegistered/{userId}")]
        public async Task<int> AddCourseRegistered(CourseRegisteredDto courseRegistered, string userId)
        {
           return  await courseService.AddCourseRegistered(courseRegistered, userId);
        }
        [HttpGet, Route("CombinationSearch/{communityAdministrationId}")]
        public async Task<List<CourseDto>> CombinationSearch(string communityAdministrationId, string? courseName, string? targetAudience, string? courseTime, DateTime? EndTimeOfRegister, string? operatorName, int? maxParticipants, int? maxCost, string? remarks)
        {
            return await courseService.CombinationSearch(communityAdministrationId, courseName, targetAudience, courseTime, EndTimeOfRegister, operatorName, maxParticipants, maxCost, remarks);
        }
        [HttpGet, Route("GetCourseRegisteredsByCourseId/{courseId}/{userId}")]
        public async Task<List<CourseRegisteredDto>> GetCourseRegisteredsByCourseId(int courseId, string userId)
        {
            return await courseService.GetCourseRegisteredsByCourseId(courseId, userId);
        }
        [HttpPut, Route("UpdateCourseRegistered/{courseRegisteredId}/{userId}")]

        public async Task<int> UpdateCourseRegistered(int courseRegisteredId, CourseRegisteredDto courseRegistered, string userId)
        {
            return await courseService.UpdateCourseRegistered(courseRegisteredId, courseRegistered, userId);
        }
        [HttpDelete, Route("DeleteCourseRegistered/{courseRegisteredId}/{userId}")]
        public async Task<int> DeleteCourseRegistered(int courseRegisteredId, string userId)
        {
            return await courseService.DeleteCourseRegistered(courseRegisteredId, userId);
        }
        [HttpGet, Route("CheckNumberOfParticipants/{courseId}")]
        public async Task<int> CheckNumberOfParticipants(int courseId)
        {
            return await courseService.CheckNumberOfParticipants(courseId);
        }
        [HttpPut, Route("Payment/{courseRegisteredId}/{userId}")]
        public async Task<bool> Payment(int courseRegisteredId, string userId)
        {
            return await courseService.Payment(courseRegisteredId, userId);
        }
    }
}















