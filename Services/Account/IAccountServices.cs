using Core.Entities;
using Services.Attributes;

namespace Services.Account
{
    [IService]
    public interface IAccountServices
    {
        Task<bool> CheckEmailIsExists(string email);
        Task<bool> CheckUserNameIsExists(string userName);
        string GenerateToken(ApplicationUser applicationUser);
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<ApplicationUser> GetUserById(Guid userId);
        Task<ApplicationUser> GetUserByUserName(string userName);
    }
}