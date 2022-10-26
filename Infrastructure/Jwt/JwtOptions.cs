namespace Infrastructure.Jwt
{
    public class JwtOptions
    {
        public int ExpiryMinutes { get; set; }

        public string Issuer { get; set; }

        public string SecretKey { get; set; }
    }
}
