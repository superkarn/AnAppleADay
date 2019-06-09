using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace A3D.Library.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsActive { get; set; } = true;

        // This has to be string
        public string CreatedDate { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }
}
