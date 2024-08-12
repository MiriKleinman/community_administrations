using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Dto
{
    public class CourseRegisteredDto
    {
        public int CourseRegisteredId { get; set; }
        public string UserId { get; set; } = null!;
        public int CourseId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool? Paid { get; set; }
    }
}
