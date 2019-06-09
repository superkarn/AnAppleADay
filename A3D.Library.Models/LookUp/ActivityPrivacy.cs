namespace A3D.Library.Models.LookUp
{
    public class ActivityPrivacy : BaseLookUpModel
    {
        public static readonly ActivityPrivacy Private = new ActivityPrivacy()
        {
            Id = 1,
            Name = "Private",
            Description = "Can be viewed only by owner"
        };

        public static readonly ActivityPrivacy Public = new ActivityPrivacy()
        {
            Id = 2,
            Name = "Public",
            Description = "Can be viewed by anybody"
        };
    }
}
