using System.Collections.Generic;

namespace A3D.Library.Models
{
    public class ApplicationUser : BaseIdModel
    {
        public string Username { get; set; }
        public bool IsActive { get; set; } = true;
        public string Email { get; set; }
        public string CreatedDate { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }
}
