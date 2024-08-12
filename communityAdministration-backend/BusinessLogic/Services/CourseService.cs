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
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Services
{
    public class CourseService : ICourseService
    {
        ICourseRepository courseRepository;
        IMapper mapper;
        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            this.courseRepository = courseRepository;
            this.mapper = mapper;
        }
        //public async Task<int> AddCourse(CourseDto course, string userId, IFormFile userfile)
        //{
        //    return await courseRepository.AddCourse(mapper.Map<Course>(course), userId, userfile);
        //}
        public async Task<int> AddCourse(CourseDto course, string userId)
        {
            return await courseRepository.AddCourse(mapper.Map<Course>(course), userId);
        }

        public async Task<int> AddCourseRegistered(CourseRegisteredDto courseRegistered, string userId)
        {
            return await courseRepository.AddCourseRegistered(mapper.Map<CourseRegistered>(courseRegistered), userId);
        }

        public async Task<int> CheckNumberOfParticipants(int courseId)
        {
            return await courseRepository.CheckNumberOfParticipants(courseId);
        }

        public async Task<List<CourseDto>> CombinationSearch(string userId, string? courseName, string? targetAudience, string? courseTime, DateTime? EndTimeOfRegister, string? operatorName, int? maxParticipants, int? maxCost, string? remarks)
        {
            List<CourseDto> courses = new();
            List<Course> resCourses = await courseRepository.CombinationSearch(userId, courseName, targetAudience, courseTime, EndTimeOfRegister, operatorName, maxParticipants, maxCost, remarks);
            if (resCourses == null)
                return null;
            foreach (var course in resCourses)
            {
                courses.Add(mapper.Map<CourseDto>(course));
            }
            return courses;

        }
        public async Task<bool> CheckForDelete(int courseId, string userId)
        {
            return await courseRepository.CheckForDelete(courseId, userId);
        }
        public async Task<int> DeleteCourse(int courseId, string userId)
        {
            return await courseRepository.DeleteCourse(courseId, userId);
        }

        public async Task<int> DeleteCourseRegistered(int courseRegisteredId, string userId)
        {
            return await courseRepository.DeleteCourseRegistered(courseRegisteredId, userId);
        }

        public async Task<Course> GetCourseById(int courseId)
        {
            return await courseRepository.GetCourseById(courseId);
        }

        public async Task<List<CourseRegisteredDto>> GetCourseRegisteredsByCourseId(int courseId, string userId)
        {
            List<CourseRegistered> resCourseRegistered = await courseRepository.GetCourseRegisteredsByCourseId(courseId, userId);
            List<CourseRegisteredDto> courseRegisterds = new();
            if (resCourseRegistered == null)
                return null;
            foreach (var courseRegisterd in resCourseRegistered)
            {
                courseRegisterds.Add(mapper.Map<CourseRegisteredDto>(courseRegisterd));
            }
            return courseRegisterds;
        }

        public async Task<List<CourseDto>> GetCourses(string communityAdministrationId)
        {
            List<CourseDto> courses = new();
            List<Course> resCourses = await courseRepository.GetCourses(communityAdministrationId);
            if (resCourses == null)
                return null;
            foreach (var course in resCourses)
            {
                courses.Add(mapper.Map<CourseDto>(course));
            }
            return courses;
        }

        public async Task<List<Course>> GetCoursesByTargetAudience(string communityAdministrationId, string targetAudience)
        {
            return await courseRepository.GetCoursesByTargetAudience(communityAdministrationId, targetAudience);

        }
        public async Task<List<Course>> GetCoursesByTargetAudienceMainManager(string targetAudience, string userId, string password)
        {
           return await courseRepository.GetCoursesByTargetAudienceMainManager(targetAudience, userId, password);
        }
        public async Task<int> UpdateCourse(int courseId, CourseDto course, string userId)
        {
            return await courseRepository.UpdateCourse(courseId, mapper.Map<Course>(course), userId);
        }

        public async Task<int> UpdateCourseRegistered(int courseRegisteredId, CourseRegisteredDto courseRegistered, string userId)
        {
            return await courseRepository.UpdateCourseRegistered(courseRegisteredId, mapper.Map<CourseRegistered>(courseRegistered), userId);
        }
        public async Task<bool> Payment(int courseRegisteredId, string userId)
        {
            return await courseRepository.Payment(courseRegisteredId, userId);
        }
    }
}
