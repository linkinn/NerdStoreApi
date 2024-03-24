using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSE.Identity.API.Models;

namespace NSE.Identity.API.Controllers
{
    [ApiController]
    [Route("api/identity")]
    public class AuthContronller : Controller
    {
        // private readonly IAspNetUser _aspNetUser;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthContronller(
            // IAspNetUser aspNetUser,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager)
        {
            // _aspNetUser = aspNetUser;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("new-account")]
        public async Task<ActionResult> Register(UserRegister userRegister)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = new IdentityUser
            {
                UserName = userRegister.Email,
                Email = userRegister.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRegister.Password);

            if (result.Succeeded)
            {
              await _signInManager.SignInAsync(user, false);
              return Ok();
            }

            return BadRequest();
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, true);

            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }

        // private async Task<UserResponseLogin> GenerateJwt(string email)
        // {
        //     var user = await _userManager.FindByEmailAsync(email);
        //     var claims = await _userManager.GetClaimsAsync(user);

        //     var identityClaims = await _aspNetUser.GetClaims();
        //     var token = _aspNetUser.GenerateJwt(claims, identityClaims);

        //     return new UserResponseLogin
        //     {
        //         AccessToken = token,
        //         ExpiresIn = TimeSpan.FromHours(_aspNetUser.GetTokenExpiration())
        //     };
        // }
    }
}