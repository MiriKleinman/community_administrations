using BusinessLogic.Dto;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICourseService
    {
        //public Task<int> AddCourse(CourseDto course, string userId, IFormFile userfile);
        public Task<int> AddCourse(CourseDto course, string userId);

        public Task<int> AddCourseRegistered(CourseRegisteredDto courseRegistered, string userId);

        public Task<List<CourseDto>> CombinationSearch(string userId, string? courseName, string? targetAudience, string? courseTime, DateTime? EndTimeOfRegister, string? operatorName, int? maxParticipants, int? maxCost, string? remarks);

        public Task<int> DeleteCourse(int courseId, string userId);
        public Task<bool> CheckForDelete(int courseId, string userId);
        public Task<List<CourseDto>> GetCourses(string communityAdministrationId);
        public Task<List<Course>> GetCoursesByTargetAudience(string communityAdministrationId, string targetAudience);
        public Task<Course> GetCourseById(int courseId);
        public Task<List<Course>> GetCoursesByTargetAudienceMainManager(string targetAudience, string userId, string password);

        public Task<int> UpdateCourse(int courseId, CourseDto course, string userId);

        public Task<int> UpdateCourseRegistered(int courseRegisteredId, CourseRegisteredDto courseRegistered, string userId);

        public Task<int> DeleteCourseRegistered(int courseRegisteredId, string userId);

        public Task<List<CourseRegisteredDto>> GetCourseRegisteredsByCourseId(int courseId, string userId);
        public Task<int> CheckNumberOfParticipants(int courseId);
        public Task<bool> Payment(int courseRegisteredId, string userId);
    }
}
