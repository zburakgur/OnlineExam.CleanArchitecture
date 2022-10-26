namespace Infrastructure.Jwt
{
    public interface IJwtHandler<TId>
    {
        IJsonWebToken Create(TId userId, int expiryMinutes = 0);

        string GetClaim(string token, string claim);
    }
}
