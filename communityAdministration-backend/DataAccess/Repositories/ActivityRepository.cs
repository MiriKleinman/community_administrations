using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DBModels;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccess.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        CommunityAdministrationContext _dbContext;
        ILogger<Activity> logger;
        IUtilsRepository utilsRepository;
        public ActivityRepository(CommunityAdministrationContext _dbContext, ILogger<Activity> logger, IUtilsRepository utilsRepository)
        {
            this.utilsRepository = utilsRepository;
            this._dbContext = _dbContext;
            this.logger = logger;
        }

        public async Task<int> AddActivity(Activity activity, string userId)
        {
            if (await utilsRepository.CheckPermissionOfManager(userId, activity.CommunityAdministrationId))
            {
                await _dbContext.Activities.AddAsync(activity);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            return 2;
        }

        public async Task<int> AddParticipantToActivity(ParticipantInActivity participatInActivity, string userId)
        {
            Activity activity = await _dbContext.Activities.FindAsync(participatInActivity.ActivityId);
            if (!(await utilsRepository.CheckPermissionOfUser(userId, activity.CommunityAdministrationId)) && await utilsRepository.CheckPermissionOfManager(userId, activity.CommunityAdministrationId))
                return 2;
            if (!await utilsRepository.CheckPermissionOfUser(participatInActivity.UserId, activity.CommunityAdministrationId))
                return 3;
            if (activity.EndTimeOfPreview < DateTime.Now)
                return 4;
            List<ParticipantInActivity> participants = await _dbContext.ParticipantInActivities.Where(particpant => particpant.ActivityId == participatInActivity.ActivityId).ToListAsync();
            if (participants.Count() < activity.MaxParticipants)
            {
                await _dbContext.ParticipantInActivities.AddAsync(participatInActivity);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            return 2;
        }

        public async Task<List<Activity>> CombinationSearch(string communityAdministrationId, string? activityName, string? description, string dateDescription, int? maxCost, string? targetAudience)
        {
            var activities = _dbContext.Activities.Where(activity => (activity.CommunityAdministrationId == communityAdministrationId) &&
                                                                         (activity.ActivityName.Contains(activityName) || activityName == null) &&
                                                                         (activity.Description.Contains(description) || description == null) &&
                                                                         (activity.Cost < maxCost || maxCost == null) &&
                                                                         (activity.TargetAudience.Contains(targetAudience) || targetAudience == null) &&
                                                                         (activity.EndTimeOfPreview >= DateTime.Now));
            return await activities.ToListAsync();
        }

        public async Task<bool> CheckForDelete(int activityId, string userId)
        {
            List<ParticipantInActivity> participantInActivity = await _dbContext.ParticipantInActivities.Where(participantInActivity => participantInActivity.ActivityId == activityId).ToListAsync();
            if (!await utilsRepository.CheckPermissionOfAccessToActivityData(userId, activityId) || (participantInActivity.Count > 0))
                return false;
            return true;
        }
        public async Task<int> DeleteActivity(int activityId, string userId)
        {
            var resActivity = await _dbContext.Activities.FindAsync(activityId);
            _dbContext.Activities.Remove(resActivity);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        //public async Task<int> DeleteActivity(int activityId, string userId)
        //{
        //    Activity activity = await _dbContext.Activities.FindAsync(activityId);
        //    if (!await utilsRepository.CheckPermissionOfManager(userId, activity.CommunityAdministrationId))
        //        return 3;
        //    var participants = await _dbContext.ParticipantInActivities.Where(participant => participant.ActivityId == activityId).ToListAsync();
        //    if (participants == null)
        //    {
        //        var res = await _dbContext.Activities.FindAsync(activityId);
        //        _dbContext.Activities.Remove(res);
        //        await _dbContext.SaveChangesAsync();
        //        return 1;
        //    }
        //    return 2;
        //}

        public async Task<List<Activity>> GetActivities(string communityAdministrationId)
        {
            return await _dbContext.Activities.Where(activity => activity.CommunityAdministrationId == communityAdministrationId && activity.EndTimeOfPreview > DateTime.Now).ToListAsync();
        }
        public async Task<Activity> GetActivityById(int activityId)
        {
            return await _dbContext.Activities.FindAsync(activityId);
        }

        public async Task<List<ParticipantInActivity>> GetParticipantInActivities(int activityId, string userId)
        {
            Activity activity = await _dbContext.Activities.FindAsync(activityId);
            if (!await utilsRepository.CheckPermissionOfManager(userId, activity.CommunityAdministrationId))
                return null;
            return await _dbContext.ParticipantInActivities.Where(participant => participant.ActivityId == activityId).ToListAsync();


        }

        public async Task<int> UpdateActivity(int activityId, Activity activity, string userId)
        {
            if (!await utilsRepository.CheckPermissionOfManager(userId, activity.CommunityAdministrationId))
                return 3;
            Activity prevActivity = await _dbContext.Activities.FindAsync(activityId);
            List<ParticipantInActivity> participants = await _dbContext.ParticipantInActivities.Where(participant => participant.ActivityId == activityId).ToListAsync();
            if (activity.MaxParticipants < participants.Count())
                return 2;
            prevActivity.ActivityId = activityId;
            prevActivity.ActivityName = activity.ActivityName;
            prevActivity.Cost = activity.Cost;
            prevActivity.Day = activity.Day;
            prevActivity.BeginngTime = activity.BeginngTime;
            prevActivity.EndTime = activity.EndTime;
            prevActivity.Description = activity.Description;
            prevActivity.EndTimeOfPreview = activity.EndTimeOfPreview;
            prevActivity.Logo = activity.Logo;
            prevActivity.Color = activity.Color;
            _dbContext.Activities.Update(prevActivity);
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<int> UpdateParticipantInActivity(string userId, int participantId,ParticipantInActivity participant)
        {
            ParticipantInActivity participantInActivity = await _dbContext.ParticipantInActivities.FindAsync(participantId);
            Activity activity = await _dbContext.Activities.FindAsync(participantInActivity.ActivityId);
            if (!(participantInActivity.UserId == userId || await utilsRepository.CheckPermissionOfManager(userId, activity.CommunityAdministrationId)))
                return 2;
            ParticipantInActivity prevParticipantInActivity = await _dbContext.ParticipantInActivities.FindAsync(participantId);
            prevParticipantInActivity.ParticipantId = participantId;
            prevParticipantInActivity.FirstName = participant.FirstName;
            prevParticipantInActivity.Email = participant.Email;
            prevParticipantInActivity.LastName = participant.LastName;
            prevParticipantInActivity.Phone = participant.Phone;
            _dbContext.ParticipantInActivities.Update(prevParticipantInActivity);
            await _dbContext.SaveChangesAsync();
            return 1;


        }
        public async Task<int> DeleteParticipantInActivity(string userId, int participantId)
        {
            ParticipantInActivity participant = await _dbContext.ParticipantInActivities.FindAsync(participantId);
            Activity activity = await _dbContext.Activities.FindAsync(participant.ActivityId);
            if (!(participant.UserId == userId || await utilsRepository.CheckPermissionOfManager(userId, activity.CommunityAdministrationId)))
                return 2;
            _dbContext.ParticipantInActivities.Remove(participant);
            await _dbContext.SaveChangesAsync();
            return 1;
        }
        public async Task<int> CheckNumberOfParticipants(int activityId)
        {
            Activity activity = await _dbContext.Activities.FindAsync(activityId);
            List<ParticipantInActivity> participantsInActivity = await _dbContext.ParticipantInActivities.Where(participantsInActivity => participantsInActivity.ActivityId == activityId).ToListAsync();
            return participantsInActivity.Count;
        }
        public async Task<List<ParticipantInActivity>> GetParticipantsInActivityByActivityId(int activityId, string userId)
        {
            if (!await utilsRepository.CheckPermissionOfAccessToActivityData(userId, activityId))
                return null;
            return await _dbContext.ParticipantInActivities.Where(participantInActivity => participantInActivity.ActivityId == activityId).ToListAsync();
        }


    }
}
