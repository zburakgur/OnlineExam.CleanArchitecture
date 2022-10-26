using Infrastructure.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Jwt
{
    public class JwtHandler<TId> : IJwtHandler<TId>
    {        
        private readonly JwtOptions jwtOptions;

        public JwtHandler(JwtOptions options)
        {
            jwtOptions = options;
        }

        public TokenOutput Create(TId userId, int expiryMinutes = 0)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtOptions.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenOutput
            {
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
