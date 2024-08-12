using DataAccess.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUtilsRepository
    {
        public Task<bool> CheckPermissionOfUser(string userId, string communityAdministrationId);
        public Task<bool> CheckPermissionOfManager(string userId, string communityAdministrationId);
        public Task<bool> CheckPermissionOfChangeCourseRegister(string userId, int courseRegisteredId);
        public Task<bool> CheckPermissionOfAccessToCourseData(string userId, int courseId);
        public Task<bool> CheckPermissionOfAccessToActivityData(string userId, int activityId);


    }
}
