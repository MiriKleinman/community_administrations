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

namespace BusinessLogic.Services
{
    public class MessageService : IMessageService
    {
        IMessageRepository messageRepository;
        IMapper mapper;
        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            this.messageRepository = messageRepository;
            this.mapper = mapper;
        }


        public async Task<int> AddMessage(MessageDto message, string userId)
        {
            Message resMessage = mapper.Map<Message>(message);
            return await messageRepository.AddMessage(resMessage, userId);
        }

        public async Task<List<MessageDto>> GetMessageByAdresseeId(int? courseId, int? activityId, int? playingCenterId, int? libraryId, string? communityAdministrationId)
        {
            List<MessageDto> listMessages = new List<MessageDto>();
            List<Message> resMessages = await messageRepository.GetMessageByAdresseeId(courseId, activityId, playingCenterId, libraryId, communityAdministrationId);

            foreach (var message in resMessages)
            {
                listMessages.Add(mapper.Map<MessageDto>(message));
            }
            return listMessages;
        }
        public async Task<int> UpdateMessage(int messageId, MessageDto message, string userId)
        {
            Message resMessage = mapper.Map<Message>(message);
            return await messageRepository.UpdateMessage(messageId, resMessage, userId);
        }
        public async Task<List<MessageDto>> GetMessagesByUserId(string userId)
        {
            List<MessageDto> listMessages = new List<MessageDto>();
            List<Message> resMessages = await messageRepository.GetMessagesByUserId(userId);

            foreach (var message in resMessages)
            {
                listMessages.Add(mapper.Map<MessageDto>(message));
            }
            return listMessages;
        }

    }
}
