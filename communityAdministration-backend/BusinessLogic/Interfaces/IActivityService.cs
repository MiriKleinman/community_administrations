using BusinessLogic.Dto;
using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IActivityService
    {
        public Task<List<ActivityDto>> GetActivities(string communityAdministrationId);
        public Task<ActivityDto> GetActivityById(int activityId);
        public Task<int> AddActivity(ActivityDto activity, string userId);
        public Task<int> AddParticipantToActivity(ParticipantInActivityDto participatInActivity, string userId);
        public Task<List<ActivityDto>> CombinationSearch(string communityAdministrationId, string? activityName, string? description, string dateDescription, int? maxCost, string? targetAudience);
        public Task<bool> CheckForDelete(int courseId, string userId);
        public Task<int> DeleteActivity(int activityId, string userId);
        public Task<int> UpdateActivity(int activityId, ActivityDto activity, string userId);

        public Task<List<ParticipantInActivityDto>> GetParticipantInActivities(int activityId, string userId);
        public Task<int> UpdateParticipantInActivity(string userId, int participantId, ParticipantInActivityDto participantInActivity);
        public Task<int> DeleteParticipantInActivity(string userId, int participantId);
        public Task<int> CheckNumberOfParticipants(int courseId);
    }
}
