using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto
{
    public class MessageDto
    {
        public int MessageId { get; set; }
        public int? CourseId { get; set; }
        public int? ActivityId { get; set; }
        public int? LibraryId { get; set; }
        public int? PlayingCenterId { get; set; }
        public string? CommunityAdministrationId { get; set; }
        public string MessageContent { get; set; } = null!;
        public DateTime EndTimeOfMessage { get; set; }
        public DateTime? CreationDateOfMessage { get; set; }

    }
}
