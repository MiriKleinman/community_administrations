using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IMessageRepository
    {
        public Task<List<Message>> GetMessageByAdresseeId(int? courseId, int? activityId, int? playingCenterId, int? libraryId, string? communityAdministrationId);
        public  Task<int> AddMessage(Message message, string userId);
        public Task<int> UpdateMessage(int messageId, Message messagent , string userId);
        public Task<List<Message>> GetMessagesByUserId(string userId);

    }
}
