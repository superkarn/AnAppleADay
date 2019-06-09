using System.Collections.Generic;

namespace A3D.Library.Models.LookUp
{
    public class ActivityInstanceStatus : BaseLookUpModel
    {
        public static IEnumerable<ActivityInstanceStatus> GetValues()
        {
            yield return ActivityInstanceStatus.Skipped;
            yield return ActivityInstanceStatus.Partial;
            yield return ActivityInstanceStatus.Completed;
        }

        public static readonly ActivityInstanceStatus Skipped = new ActivityInstanceStatus()
        {
            Id = 1,
            Name = "Skipped",
            Description = "Activity Instance was skipped (not completed)"
        };

        public static readonly ActivityInstanceStatus Partial = new ActivityInstanceStatus()
        {
            Id = 2,
            Name = "Partial",
            Description = "Activity Instance was partially completed"
        };

        public static readonly ActivityInstanceStatus Completed = new ActivityInstanceStatus()
        {
            Id = 3,
            Name = "Completed",
            Description = "Activity Instance was completed"
        };
    }
}
