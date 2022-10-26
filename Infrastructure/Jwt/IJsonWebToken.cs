namespace Infrastructure.Jwt
{
    public interface IJsonWebToken
    {
        long Expires { get; set; }

        string Token { get; set; }
    }
}
