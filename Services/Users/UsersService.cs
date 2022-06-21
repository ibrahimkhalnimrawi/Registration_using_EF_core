using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Users
{
    public class UsersService : BaseService<ApplicationUser>, IUsersService
    {
        public UsersService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        public async Task<List<ApplicationUser>> GettAllUsers()
        {
            return await _applicationDbContext.ApplicationUser.ToListAsync();
        }
    }
}
