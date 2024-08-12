using BusinessLogic.Dto;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunityAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        IActivityService activityService;
        public ActivityController(IActivityService activityService)
        {
            this.activityService = activityService;
        }
        [HttpGet, Route("GetActivities/{communityAdministrationId}")]
        public async Task<List<ActivityDto>> GetActivities(string communityAdministrationId)
        {
            return await activityService.GetActivities(communityAdministrationId);
        }
        [HttpGet, Route("GetActivityById/{activityId}")]
        public async Task<ActivityDto> GetActivityById(int activityId)
        {
            return await activityService.GetActivityById(activityId);
        }
        [HttpPost, Route("AddActivity/{userId}")]
        public async Task<int> AddActivity(ActivityDto activity, string userId)
        {
            return await activityService.AddActivity(activity, userId);
        }
        [HttpPut, Route("UpdateActivity/{activityId}/{userId}")]
        public async Task<int> UpdateActivity(int activityId, ActivityDto activity, string userId)
        {
            return await activityService.UpdateActivity(activityId, activity, userId);
        }
        [HttpGet, Route("CheckForDelete/{courseId}/{userId}")]
        public async Task<bool> CheckForDelete(int courseId, string userId)
        {
            return await activityService.CheckForDelete(courseId, userId);
        }
        [HttpDelete, Route("DeleteActivity/{activityId}/{userId}")]
        public async Task<int> DeleteActivity(int activityId, string userId)
        {
          return  await activityService.DeleteActivity(activityId, userId);
        }
        [HttpPost, Route("AddParticipantToActivity/{userId}")]
        public async Task<int> AddParticipantToActivity(ParticipantInActivityDto participantInActivity, string userId)
        {
           return await activityService.AddParticipantToActivity(participantInActivity, userId);
        }
        [HttpGet, Route("CombinationSearch")]
        public async Task<List<ActivityDto>> CombinationSearch(string communityAdministrationId, string? activityName, string? description, string? dateDescription, int? maxCost, string? targetAudience)
        {
            return await activityService.CombinationSearch(communityAdministrationId, activityName, description, dateDescription, maxCost, targetAudience);
        }
        [HttpGet, Route("GetParticipantInActivities/{activityId}/{userId}")]
        public async Task<List<ParticipantInActivityDto>> GetParticipantInActivities(int activityId, string userId)
        {
            return await activityService.GetParticipantInActivities(activityId, userId);
        }
        [HttpPut, Route("UpdateParticipantInActivity/{userId}/{participantId}")]
        public async Task<int> UpdateParticipantInActivity(string userId, int participantId, ParticipantInActivityDto participantInActivity)
        {
            return await activityService.UpdateParticipantInActivity(userId, participantId, participantInActivity);
        }
        [HttpDelete, Route("DeleteParticipantInActivity/{userId}/{participantId}")]
        public async Task<int> DeleteParticipantInActivity(string userId, int participantId)
        {
            return await activityService.DeleteParticipantInActivity(userId, participantId);
        }
        [HttpGet, Route("CheckNumberOfParticipants/{activityId}")]
        public async Task<int> CheckNumberOfParticipants(int activityId)
        {
            return await activityService.CheckNumberOfParticipants(activityId);
        }
    }
}
