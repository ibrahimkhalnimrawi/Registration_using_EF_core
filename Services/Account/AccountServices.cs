using Core.Entities;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Services.Attributes;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace Services.Account
{
    public class AccountServices : BaseService<ApplicationUser>, IAccountServices
    {
        private readonly IConfiguration _configuration;
        public AccountServices(IServiceProvider serviceProvider, IConfiguration configuration) : base(serviceProvider)
        {
            _configuration = configuration;
        }

        public async Task<bool> CheckEmailIsExists(string email)
        {
            try
            {
                var result = await _applicationDbContext.ApplicationUser.Where(applicationUser => applicationUser.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
                if (result != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> CheckUserNameIsExists(string userName)
        {
            try
            {
                var result = await _applicationDbContext.ApplicationUser.Where(applicationUser => applicationUser.UserName == userName).FirstOrDefaultAsync();
                if (result != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _applicationDbContext.ApplicationUser.Where(applicationUser => applicationUser.Email == email).FirstOrDefaultAsync();
        }

        public async Task<ApplicationUser> GetUserById(Guid userId)
        {
            return await _applicationDbContext.ApplicationUser.FindAsync(userId);
        }

        public async Task<ApplicationUser> GetUserByUserName(string userName)
        {
            return await _applicationDbContext.ApplicationUser.Where(applicationUser => applicationUser.UserName == userName).FirstOrDefaultAsync();
        }


        #region Token

        public string GenerateToken(ApplicationUser applicationUser)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, applicationUser.Email),
                new Claim(ClaimTypes.NameIdentifier,applicationUser.Id),
                new Claim(ClaimTypes.Name, applicationUser.UserName),
                new Claim(ClaimTypes.GivenName, applicationUser.FirstName+ " " + applicationUser.LastName)
            };
            var secretKey = _configuration.GetSection("AppSettings:SecretKey").Value;
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        #endregion
    }
}
