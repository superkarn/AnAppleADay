﻿using System;
using System.Collections.Generic;

namespace A3D.Library.Models
{
    public class Activity : BaseModel
    {
        public int Id { get; set; }

        public int CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

        public bool IsActive { get; set; } = true;

        public int PrivacyId { get; set; }
        public ActivityPrivacy Privacy { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ValueUnit { get; set; }
        public string Schedule { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime? LastCompletedDate { get; set; }

        public ICollection<ActivityInstance> ActivityInstances { get; set; }
        public ICollection<ActivityNotification> ActivityNotifications { get; set; }
    }
}
