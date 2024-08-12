using BusinessLogic.Dto;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunityAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IMessageService messageService;
        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        [HttpGet, Route("GetMessageByAdresseeId")]
        public async Task<List<MessageDto>> GetMessageByAdresseeId([FromQuery]int courseId, [FromQuery] int activityId, [FromQuery] int playingCenterId, [FromQuery] int libraryId, [FromQuery] string communityAdministrationId)
        {
            return await messageService.GetMessageByAdresseeId(courseId, activityId, playingCenterId, libraryId, communityAdministrationId);
        }
        [HttpPost, Route("AddMessage/{userId}")]
        public async Task<int> AddMessage(MessageDto message, string userId)
        {
            return await messageService.AddMessage(message,userId);
        }
        [HttpPut, Route("UpdateMessage/{messageId}/{userId}")]
        public Task<int> UpdateMessage(int messageId, MessageDto message, string userId)
        {
            return messageService.UpdateMessage(messageId, message,userId);
        }
        [HttpGet, Route("GetMessagesByUserId/{userId}")]
        public async Task<List<MessageDto>> GetMessagesByUserId(string userId)
        {
            return await messageService.GetMessagesByUserId(userId);
        }

    }
}
