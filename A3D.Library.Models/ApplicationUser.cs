using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace A3D.Library.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<Activity> Activities { get; set; }
    }
}
