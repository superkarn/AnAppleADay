﻿using System;

namespace A3D.Library.Models
{
    public class ActivityInstance : BaseModel
    {
        public int Id { get; set; }

        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public int CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }

        public int StatusId { get; set; }
        public ActivityStatus Status { get; set; }

        public string Value { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
