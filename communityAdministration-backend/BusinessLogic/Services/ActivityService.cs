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
using DataAccess.Repositories;

namespace BusinessLogic.Services
{
    public class ActivityService : IActivityService
    {
        IActivityRepository activityRepository;
        IMapper mapper;
        public ActivityService(IActivityRepository activityRepository, IMapper mapper)
        {
            this.activityRepository = activityRepository;
            this.mapper = mapper;
        }
 
     
        public async Task<int> AddActivity(ActivityDto activity, string userId)
        {
            Activity resActivity = mapper.Map<Activity>(activity);
            return await activityRepository.AddActivity(resActivity, userId);
        }

     

        public async Task<int> AddParticipantToActivity(ParticipantInActivityDto participantInActivity, string userId)
        {
            ParticipantInActivity resParticipantInActivity = mapper.Map<ParticipantInActivity>(participantInActivity);
            return await activityRepository.AddParticipantToActivity(resParticipantInActivity, userId);
        }

   

        public async Task<List<ActivityDto>> CombinationSearch(string communityAdministrationId, string? activityName, string? description, string dateDescription, int? maxCost, string? targetAudience)
        {
            List<ActivityDto> resActivities = new List<ActivityDto>();
            List<Activity> activities = await activityRepository.CombinationSearch(communityAdministrationId,activityName, description, dateDescription, maxCost, targetAudience);
            foreach(var activity in activities)
            {
                resActivities.Add(mapper.Map<ActivityDto>(activity));
            }
            return resActivities;
        }
        public async Task<bool> CheckForDelete(int courseId, string userId)
        {
            return await activityRepository.CheckForDelete(courseId, userId);
        }
        public async Task<int> DeleteActivity(int activityId, string userId)
        {
          return await activityRepository.DeleteActivity(activityId, userId);
        }

        public async Task<int> DeleteParticipantInActivity(string userId, int participantId)
        {
             return await activityRepository.DeleteParticipantInActivity(userId, participantId);
        }

        public async Task<List<ActivityDto>> GetActivities(string communityAdministrationId)
        {
            List<Activity> activities = await activityRepository.GetActivities(communityAdministrationId);
            List<ActivityDto> resActivities = new List<ActivityDto>();
            foreach (var activity in activities)
            {
                resActivities.Add(mapper.Map<ActivityDto>(activity));
            }
            return resActivities;
        }
        public async Task<ActivityDto> GetActivityById(int activityId)
        {
            Activity activity = await activityRepository.GetActivityById(activityId);
            return mapper.Map<ActivityDto>(activity);
        }

        public async Task<List<ParticipantInActivityDto>> GetParticipantInActivities(int activityId, string userId)
        {
            List<ParticipantInActivity> participantInActivities = await activityRepository.GetParticipantInActivities(activityId, userId);
            List<ParticipantInActivityDto> resParticipants = new List<ParticipantInActivityDto>();
            if (participantInActivities != null) { 
            foreach (var participant in participantInActivities)
            {
                resParticipants.Add(mapper.Map<ParticipantInActivityDto>(participant));
            }}
            return resParticipants;
        }

        public async Task<int> UpdateActivity(int activityId, ActivityDto activity, string userId)
        {
            Activity resActivity = mapper.Map<Activity>(activity);
           return await activityRepository.UpdateActivity(activityId, resActivity, userId);
        }

        public async Task<int> UpdateParticipantInActivity(string userId, int participantId, ParticipantInActivityDto participantInActivity)
        {
            return await activityRepository.UpdateParticipantInActivity(userId, participantId, mapper.Map<ParticipantInActivity>(participantInActivity));

        }
        public async Task<int> CheckNumberOfParticipants(int activityId)
        {
            return await activityRepository.CheckNumberOfParticipants(activityId);
        }
    }
}
