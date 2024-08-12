using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DBModels;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DataAccess.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;


namespace DataAccess.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        CommunityAdministrationContext _dbContext;
        ILogger<Course> logger;
        IUtilsRepository utilsRepository;
        IUserRepository userRepository;
        public CourseRepository(CommunityAdministrationContext _dbContext, ILogger<Course> logger, IUtilsRepository utilsRepository, IUserRepository userRepository)
        {
            this._dbContext = _dbContext;
            this.logger = logger;
            this.utilsRepository = utilsRepository;
            this.userRepository = userRepository;
        }

        public async Task<int> AddCourse(Course course, string userId)
        {
            if (!await utilsRepository.CheckPermissionOfManager(userId, course.CommunityAdministrationId))
                return 2;
            //string filename = userfile.FileName;
            //filename = Path.GetFileName(filename);
            //string uploadFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", filename);
            //await using var stream = new FileStream(uploadFilePath, FileMode.Create);
            //await userfile.CopyToAsync(stream);
            //await _dbContext.SaveChangesAsync();
            //course.Logo = "images/" + userfile.FileName;
            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<int> AddCourseRegistered(CourseRegistered courseRegistered, string userId)
        {
            Course course = await _dbContext.Courses.FindAsync(courseRegistered.CourseId);
            if (!(await utilsRepository.CheckPermissionOfUser(userId, course.CommunityAdministrationId)) && await utilsRepository.CheckPermissionOfManager(userId, course.CommunityAdministrationId))
                return 2;
            if (await _dbContext.CourseRegistereds.FindAsync(courseRegistered.CourseRegisteredId) != null)
                return 3;
            List<CourseRegistered> courseRegistereds = await _dbContext.CourseRegistereds.Where(courseRegister => courseRegistered.CourseId == courseRegister.CourseId).ToListAsync();
            if (courseRegistereds.Count > course.MaxParticipants)
                return 4;
            await _dbContext.CourseRegistereds.AddAsync(courseRegistered);
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<List<Course>> CombinationSearch(string userId, string? courseName, string? targetAudience, string? courseTime, DateTime? EndTimeOfRegister, string? operatorName, int? maxParticipants, int? maxCost, string? remarks)
        {
            User user = await _dbContext.Users.FindAsync(userId);
            var courses = _dbContext.Courses.Where(course => (course.CommunityAdministrationId == user.CommunityAdministrationId) &&
                                                            (course.CourseName.Equals(courseName) || courseName == null) &&
                                                            (course.TargetAudience.Equals(targetAudience) || targetAudience == null) &&
                                                            (course.EndTimeOfRegister < DateTime.Now || EndTimeOfRegister == null) &&
                                                            (course.Remarks.Contains(remarks) || remarks == null) &&
                                                            (course.OperatorName.Equals(operatorName) || operatorName == null) &&
                                                            (course.MaxParticipants == maxParticipants || maxParticipants == null) &&
                                                            (course.CostForLesson <= maxCost || maxCost == null));
            return await courses.ToListAsync();
        }
        public async Task<bool> CheckForDelete(int courseId, string userId)
        {
            List<CourseRegistered> courseRegistereds = await _dbContext.CourseRegistereds.Where(courseRegistered => courseRegistered.CourseId == courseId).ToListAsync();
            if (!await utilsRepository.CheckPermissionOfAccessToCourseData(userId, courseId) || (courseRegistereds.Count > 0))
                return false;
            return true;
        }
        public async Task<int> DeleteCourse(int courseId, string userId)
        {
            var resCourse = await _dbContext.Courses.FindAsync(courseId);
            _dbContext.Courses.Remove(resCourse);
            await _dbContext.SaveChangesAsync();
            return 1;
        }


        public async Task<List<Course>> GetCourses(string communityAdministrationId)
        {
            return await _dbContext.Courses.Where(course => course.CommunityAdministrationId == communityAdministrationId).ToListAsync();
        }
        public async Task<List<Course>> GetCoursesByTargetAudience(string communityAdministrationId, string targetAudience)
        {
            return await _dbContext.Courses.Where(course => course.CommunityAdministrationId == communityAdministrationId && course.TargetAudience.Equals(targetAudience)).ToListAsync();
        }
        public async Task<List<Course>> GetCoursesByTargetAudienceMainManager(string targetAudience, string userId, string password)
        {
            if (await userRepository.checkPermissionOfMainManager(userId, password) != 1)
                return null;
            return await _dbContext.Courses.Where(course => course.TargetAudience.Equals(targetAudience)).ToListAsync();
        }
        public async Task<int> UpdateCourse(int courseId, Course course, string userId)
        {
            if (!await utilsRepository.CheckPermissionOfAccessToCourseData(userId, courseId))
                return 2;
            List<CourseRegistered> courseRegistereds = await _dbContext.CourseRegistereds.Where(courseRegistered => courseRegistered.CourseId == courseId).ToListAsync();
            if (courseRegistereds.Count > course.MaxParticipants)
                return 3;
            Course prevCourse = await _dbContext.Courses.FindAsync(courseId);
            prevCourse.CostForLesson = course.CostForLesson;
            prevCourse.CourseName = course.CourseName;
            prevCourse.Day = course.Day;
            prevCourse.BeginngTime = course.BeginngTime;
            prevCourse.EndTime = course.EndTime;
            prevCourse.EndTimeOfRegister = course.EndTimeOfRegister;
            prevCourse.EndTimeOfPreview = course.EndTimeOfPreview;
            prevCourse.MaxParticipants = course.MaxParticipants;
            prevCourse.OperatorName = course.OperatorName;
            prevCourse.Remarks = course.Remarks;
            prevCourse.TargetAudience = course.TargetAudience;
            prevCourse.Logo = course.Logo;
            prevCourse.Color = course.Color;
            _dbContext.Courses.Update(prevCourse);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        public async Task<int> UpdateCourseRegistered(int courseRegisteredId, CourseRegistered courseRegistered, string userId)
        {
            if (!(await utilsRepository.CheckPermissionOfChangeCourseRegister(userId, courseRegisteredId)))
                return 2;
            CourseRegistered prevCourseRegistered = await _dbContext.CourseRegistereds.FindAsync(courseRegisteredId);
            prevCourseRegistered.Email = courseRegistered.Email;
            prevCourseRegistered.Age = courseRegistered.Age;
            prevCourseRegistered.FirstName = courseRegistered.FirstName;
            prevCourseRegistered.LastName = courseRegistered.LastName;
            prevCourseRegistered.Phone = courseRegistered.Phone;
            _dbContext.CourseRegistereds.Update(prevCourseRegistered);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        public async Task<int> DeleteCourseRegistered(int courseRegisteredId, string userId)
        {
            if (!(await utilsRepository.CheckPermissionOfChangeCourseRegister(userId, courseRegisteredId)))
                return 2;
            CourseRegistered prevCourseRegistered = await _dbContext.CourseRegistereds.FindAsync(courseRegisteredId);
            _dbContext.CourseRegistereds.Remove(prevCourseRegistered);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        public async Task<List<CourseRegistered>> GetCourseRegisteredsByCourseId(int courseId, string userId)
        {
            if (!await utilsRepository.CheckPermissionOfAccessToCourseData(userId, courseId))
                return null;
            return await _dbContext.CourseRegistereds.Where(courseRegistered => courseRegistered.CourseId == courseId).ToListAsync();
        }

        public async Task<int> CheckNumberOfParticipants(int courseId)
        {
            Course course = await _dbContext.Courses.FindAsync(courseId);
            List<CourseRegistered> courseRegistereds = await _dbContext.CourseRegistereds.Where(courseRegistered => courseRegistered.CourseId == courseId).ToListAsync();
            return courseRegistereds.Count;
        }

        public async Task<Course> GetCourseById(int courseId)
        {
            return await _dbContext.Courses.FindAsync(courseId);
        }
        public async Task SetPicture(int courseId, string fileName)
        {
            try
            {
                Course s = _dbContext.Courses.Find(courseId);
                if (s != null)
                {
                    s.Logo = fileName;
                    _dbContext.Update(s);
                    await _dbContext.SaveChangesAsync();
                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error in SetPicture function " + ex.Message);
            }
        }
        public async Task UploadFile(int studentId, IFormFile userfile)
        {
            try
            {

            }

            catch (Exception ex)
            {
                throw new Exception("Error in SetPicture function " + ex.Message);
            }
        }
        public async Task<bool> Payment(int courseRegisteredId, string userId)
        {
            CourseRegistered courseRegistered = await _dbContext.CourseRegistereds.FindAsync(courseRegisteredId);
            if (courseRegistered != null && courseRegistered.Paid == true)
                return false;
            courseRegistered.Paid = true;
            _dbContext.CourseRegistereds.Update(courseRegistered);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

