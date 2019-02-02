namespace A3D.Authentication.Models
{
    public class JwtAppSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int ExpirationTime { get; set; }
    }
}
