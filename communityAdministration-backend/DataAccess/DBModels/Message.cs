using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class Message
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
