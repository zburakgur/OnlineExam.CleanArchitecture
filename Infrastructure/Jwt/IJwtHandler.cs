using Infrastructure.Auth;

namespace Infrastructure.Jwt
{
    public interface IJwtHandler<TId>
    {
        TokenOutput Create(TId userId, int expiryMinutes = 0);
    }
}
