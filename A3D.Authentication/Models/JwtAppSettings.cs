namespace A3D.Authentication.Models
{
    public class JwtAppSettings
    {
        public string Issuer { get; set; } = "https://localhost:44339";
        public string Audience { get; set; } = "https://localhost:44339";
        public string Key { get; set; } = "1234567890abcdefghijklmnopqrstuvwxyz";
    }
}
