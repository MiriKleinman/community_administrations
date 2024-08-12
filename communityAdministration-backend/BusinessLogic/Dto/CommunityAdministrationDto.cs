using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto
{
    public class CommunityAdministrationDto
    {

        public string CommunityAdministrationId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Logo { get; set; }
        public string? Color { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string EmailManager { get; set; } = null!;
        public string PhoneManager { get; set; } = null!;

    }
}
