using Infrastructure.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure.Extensions
{
    public static class JwtExtension
    {
        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new JwtOptions();
            var section = configuration.GetSection("JwtOptions");
            section.Bind(options);
            services.AddSingleton(x => options);
            services.AddSingleton(typeof(IJwtHandler<>), typeof(JwtHandler<>));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;// options.Issuer.ToLower().StartsWith("https");
                    //cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey)),

                        ValidateIssuer = true,
                        ValidIssuer = options.Issuer,

                        ValidateAudience = false,                        
                        //ValidateLifetime = true,
                        
                        ClockSkew = TimeSpan.Zero,
                    };
                });
        }
    }
}
