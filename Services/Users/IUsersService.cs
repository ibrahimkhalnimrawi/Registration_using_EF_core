using Core.Entities;
using Services.Attributes;

namespace Services.Users
{
    [IService]
    public interface IUsersService
    {
        Task<List<ApplicationUser>> GettAllUsers();
    }
}