using Core.Entities;
using IdentityProject.AutoMapper;
using IdentityProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Account;

namespace IdentityProject.Controllers.Account
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountServices;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        #region Constructor

        public AccountController(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _accountServices =serviceProvider.GetRequiredService<IAccountServices>();
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #endregion

        #region Registration 
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool emailExists =await  _accountServices.CheckEmailIsExists(registerModel.Email);
            bool userNameExists =await _accountServices.CheckUserNameIsExists(registerModel.UserName);
            if (emailExists || userNameExists)
            {
                return BadRequest();
            }
            ApplicationUser user = ApplicationMapper<RegisterModel, ApplicationUser>.Map(registerModel);
            await _userManager.CreateAsync(user,registerModel.Password);
            return Ok(user);
        }
        #endregion

        #region LogIn

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (true)
                try
                {
                    if(!ModelState.IsValid)
                    {
                        return BadRequest();
                    }
                    var signInResult = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, false);
                    if (!signInResult.Succeeded)
                    {
                        return BadRequest(signInResult);
                    }
                    ApplicationUser applicationUser = await _accountServices.GetUserByUserName(loginModel.UserName);
                    string jwt = _accountServices.GenerateToken(applicationUser);
                    return Ok(jwt);

                }
                catch (Exception)
                {

                    throw;
                }
        }

        #endregion

        #region Logout
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
        #endregion
    }
}
