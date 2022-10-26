using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Jwt
{
    public class JwtHandler<TId> : IJwtHandler<TId>
    {
        private readonly JwtHeader jwtHeader;

        private readonly JwtOptions jwtOptions;

        private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        public JwtHandler(JwtOptions options)
        {
            jwtOptions = options;
            SecurityKey issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey));
            SigningCredentials signingCredentials = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);
            jwtHeader = new JwtHeader(signingCredentials);
        }

        public IJsonWebToken Create(TId userId, int expiryMinutes = 0)
        {
            var nowUtc = DateTime.UtcNow;
            var expires = nowUtc.AddMinutes(expiryMinutes == 0 ? jwtOptions.ExpiryMinutes : expiryMinutes);
            var payload = new JwtPayload(jwtOptions.Issuer, null, new List<Claim> { new Claim("sub", userId.ToString()), new Claim("unique_name", userId.ToString()) }, null, expires, nowUtc);
            var jwt = new JwtSecurityToken(jwtHeader, payload);
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new JsonWebToken
            {
                Token = token,
                Expires = long.Parse(jwt.Claims.First(x => x.Type == "exp").Value)
            };
        }

        public string GetClaim(string token, string claim)
        {
            var jwtSecurityToken = jwtSecurityTokenHandler.ReadJwtToken(token);

            if (jwtSecurityToken == null)
            {
                throw new NotSupportedException();
            }

            if (jwtSecurityToken.Claims == null || !jwtSecurityToken.Claims.Any(x => !string.IsNullOrEmpty(x.Type) && x.Type.Equals(claim)))
            {
                throw new SecurityTokenSignatureKeyNotFoundException();
            }

            return jwtSecurityToken.Claims.First(x => x.Type.Equals(claim)).Value;
        }
    }
}
