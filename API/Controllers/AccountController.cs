using System.Linq;
using Fisher.Bookstore.Data;
using Fisher.Bookstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> SignInManager , IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = SignInManager;
            this.configuration = configuration;
        }

    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] ApplicationUser registration)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        ApplicationUser user = new ApplicationUser
        {
            Email = regristration.Email,
            UserName = registration.Email,
            IOrderedEnumerable = registration.Email
        };

        IdentityResult result = await userManager.CreateAsync(user, registration.Password);

        if (!result.Succeeded)
        {
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError(err.Code, err.Description);
            }

            return BadRequest(ModelState);
        }
        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] ApplicationUser login)
    {
        var result = await signInManager.PasswordSignInAsync(login.Email, login.Password, isPersistent: false, lockoutOnFailiure: false);
        if (!result.Succeed)
        {
            return Unauthorized();
        }

    ApplicationUser user = await userManager.FindByEmailAsync(login.Email);
    JwtSecurityToken token = await GenerateTokenAsync(user);
    string serializedToken = new JwtSecurityTokenHandler().WriteToken(token);

    var response = new {Token = serializedToken};
    return Ok(response);
    }

   private async Task<JwtSecurityToken> GenerateTokenAsync(ApplicationUser user)
   {
       var claims = new List<Claim>()
       {
           new Claim(JwtRegristrationClaimNames.Sub, user.UserName),
           new Claim(JwtRegristrationClaimNames.Jti, Guid.NewGuid().ToString()),
           new Claim(ClaimTypes.NameIdentifier, user.Id),
           new Claim(ClaimTypes.Name, user.UserName),
       };

       var expirationDays = configuration.GetValue<int>
       ("JWTConfiguration:TokenExpirationDays");

       var signingKey = Encoding.UTF8.GetBytes(configuration.GetValue<string>
       ("JWTConfiguration:Key"));

       var token = new JwtSecurityToken(
           issuer: configuration.GetValue<string>("JWTConfiguration:Issuer"),
           audience: configuration.GetValue<string>("JWTConfiguration:Audience"),
           claims: claims,
           expires: DateTime.UtcNow.Add(TimeSpan.FromDays(expirationDays)),
           notBefore: DateTime.UtcNow,
           signingCredentials: new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256)
       );

       return token;
   } 

   [Authorize]
   [HttpGet("profile")]
   public IActionResult Profile()
   {
       return Ok(User.Identity.Name);
   }


}
