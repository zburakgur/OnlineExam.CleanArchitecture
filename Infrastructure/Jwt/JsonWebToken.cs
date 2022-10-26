namespace Infrastructure.Jwt
{
    public class JsonWebToken : IJsonWebToken
    {
        public long Expires { get; set; }

        public string Token { get; set; }
    }
}
