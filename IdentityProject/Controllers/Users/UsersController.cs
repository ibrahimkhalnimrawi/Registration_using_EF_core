using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Users;

namespace IdentityProject.Controllers.Users
{
    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        #region Constructor

        public UsersController(IServiceProvider serviceProvider) 
        {
            _usersService  = serviceProvider.GetRequiredService<IUsersService>();
        }

        #endregion

        #region Get Actions
        [HttpGet("GettAllUsers")]
        public async Task<IActionResult> GettAllUsers()
        {
            return Ok(await _usersService.GettAllUsers());
        }

        #endregion
    }
}
