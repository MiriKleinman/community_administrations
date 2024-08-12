using BusinessLogic.Dto;
using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IMessageService
    {
        public Task<List<MessageDto>> GetMessageByAdresseeId(int? courseId, int? activityId, int? playingCenterId, int? libraryId, string? communityAdministrationId);
        public Task<int> AddMessage(MessageDto message, string userId);
        public Task<int> UpdateMessage(int messageId, MessageDto message, string userId);
        public Task<List<MessageDto>> GetMessagesByUserId(string userId);

    }
}
