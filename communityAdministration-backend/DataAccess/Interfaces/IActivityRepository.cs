using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IActivityRepository
    {
        public Task<List<Activity>> GetActivities(string communityAdministrationId);
        public Task<Activity> GetActivityById(int activityId);
        public Task<int> AddActivity(Activity activity, string userId);
        public Task<int> AddParticipantToActivity(ParticipantInActivity participatInActivity, string userId);
        public Task<List<Activity>> CombinationSearch(string communityAdministrationId, string? activityName, string? description, string dateDescription, int? maxCost, string? targetAudience);
        public Task<bool> CheckForDelete(int courseId, string userId);
        public Task<int> DeleteActivity(int activityId, string userId);
        public Task<int> UpdateActivity(int activityId, Activity activity, string userId);

        public Task<List<ParticipantInActivity>> GetParticipantInActivities(int activityId, string userId);
        public Task<int> UpdateParticipantInActivity(string userId, int participantId, ParticipantInActivity participantInActivity);
        public Task<int> DeleteParticipantInActivity(string userId, int participantId);
        public Task<int> CheckNumberOfParticipants(int courseId);
        public Task<List<ParticipantInActivity>> GetParticipantsInActivityByActivityId(int activityId, string userId);



    }
}
