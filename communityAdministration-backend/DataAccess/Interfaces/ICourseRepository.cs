using DataAccess.DBModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICourseRepository
    {

        //public Task<int> AddCourse(Course course, string userId, IFormFile userfile);
        public Task<int> AddCourse(Course course, string userId);

        public Task<int> AddCourseRegistered(CourseRegistered courseRegistered, string userId);

        public Task<List<Course>> CombinationSearch(string communityAdministrationId, string? courseName, string? targetAudience, string? courseTime, DateTime? EndTimeOfRegister, string? operatorName, int? maxParticipants, int? maxCost, string? remarks);

        public Task<bool> CheckForDelete(int courseId, string userId);
        public Task<int> DeleteCourse(int courseId, string userId);

        public Task<List<Course>> GetCourses(string communityAdministrationId);
        public Task<List<Course>> GetCoursesByTargetAudience(string communityAdministrationId, string targetAudience);
        public Task<Course> GetCourseById(int courseId);
        public Task<List<Course>> GetCoursesByTargetAudienceMainManager(string targetAudience, string userId, string password);

        public Task<int> UpdateCourse(int courseId, Course course, string userId);

        public Task<int> UpdateCourseRegistered(int courseRegisteredId, CourseRegistered courseRegistered, string userId);

        public Task<int> DeleteCourseRegistered(int courseRegisteredId, string userId);

        public Task<List<CourseRegistered>> GetCourseRegisteredsByCourseId(int courseId, string userId);
        public Task<int> CheckNumberOfParticipants(int courseId);
        public Task<bool> Payment(int courseRegisteredId, string userId);



    }
}
