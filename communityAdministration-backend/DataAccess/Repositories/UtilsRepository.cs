using DataAccess.DBModels;
using DataAccess.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UtilsRepository : IUtilsRepository
    {
        CommunityAdministrationContext _dbContext;
        ILogger<User> logger;
        public UtilsRepository(CommunityAdministrationContext _dbContext, ILogger<User> logger)
        {
            this._dbContext = _dbContext;
            this.logger = logger;

        }
        public async Task<bool> CheckPermissionOfManager(string userId, string communityAdministrationId)
        {
            User user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
                return false;
            if (user.IsManager && user.CommunityAdministrationId == communityAdministrationId)
                return true;
            return false;
        }
        public async Task<bool> CheckPermissionOfChangeCourseRegister(string userId, int courseRegisteredId)
        {
            CourseRegistered courseRegistered = await _dbContext.CourseRegistereds.FindAsync(courseRegisteredId);
            Course course = await _dbContext.Courses.FindAsync(courseRegistered.CourseId);
            return await CheckPermissionOfManager(userId, course.CommunityAdministrationId) || userId == courseRegistered.UserId;
        }
        public async Task<bool> CheckPermissionOfAccessToCourseData(string userId, int courseId)
        {
            Course course = await _dbContext.Courses.FindAsync(courseId);
            if (course != null)
                return await CheckPermissionOfManager(userId, course.CommunityAdministrationId);
            return false;
        }
        public async Task<bool> CheckPermissionOfAccessToActivityData(string userId, int activityId)
        {
            Activity activity = await _dbContext.Activities.FindAsync(activityId);
            return await CheckPermissionOfManager(userId, activity.CommunityAdministrationId);

        }
        public async Task<bool> CheckPermissionOfUser(string userId, string communityAdministrationId)
        {
            User user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
                return false;
            if (user.CommunityAdministrationId == communityAdministrationId)
                return true;
            return false;
        }

    }
}
