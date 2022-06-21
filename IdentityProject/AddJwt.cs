using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace IdentityProject
{
    public static class AddJwt
    {
        public static void AddStandAloneJwt(this IServiceCollection @this, IConfiguration configuration)
        {
            @this.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:SecretKey").Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });
        }
    }
}
