using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestGenerationAPI.Entity;
using TestGenerationAPI.services;

namespace TestGenerationAPI.Controllers
{
    public class UserData
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
    [Route("[Controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private UserManagementService _userMangementService;

        private IOptions<JwtTokenConfig> _jwtTokenConfig;
        public LoginController(UserManagementService UserManagementService, IOptions<JwtTokenConfig> jwtTokenConfiguration)
        {
            _userMangementService = UserManagementService;
            _jwtTokenConfig = jwtTokenConfiguration;

        }
        [HttpPost("Register")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public ActionResult<string> Register(UserModel model)
        {
            return _userMangementService.CreateUser(model);
        }

        [HttpPost("Login")]
        public IResult Login([FromBody] UserData model)
        {
            UserModel loggedInUser = null;
            if (!string.IsNullOrEmpty(model.UserName) &&
                    !string.IsNullOrEmpty(model.Password))
            {
                loggedInUser = _userMangementService.UserLogin(model.UserName, model.Password);



                if (loggedInUser is null) return Results.NotFound("User not found");

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, loggedInUser.Name),
                    new Claim(ClaimTypes.Role, loggedInUser.Role)
                };

                var token = new JwtSecurityToken
                (
                    issuer: _jwtTokenConfig.Value.Issuer,
                    audience: _jwtTokenConfig.Value.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(60),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenConfig.Value.Key)),
                        SecurityAlgorithms.HmacSha256)
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Results.Ok(tokenString);
            }

            return Results.BadRequest("Invalid user credentials");
        }

        
        
    }
}
