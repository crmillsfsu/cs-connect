using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace JWT_API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    IConfiguration configuration;
    public UsersController(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost("/CreateToken")]
    public ActionResult Authenticate(User users){
        // authenticates user and create jwt token
        // hardcoded username and password
        if(users.username == "users" && users.password == "test" )
        {
            var issuer = configuration["JWT:Issuer"];
            var audience = configuration["JWT:Audience"];
            var Key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, users.username),
                    new Claim(JwtRegisteredClaimNames.Email, users.username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(6),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Key),
                    SecurityAlgorithms.HmacSha512Signature
                )};
                var handler = new JwtSecurityTokenHandler();
                var token = handler.CreateToken(tokenDescriptor);
                var jwtToken = handler.WriteToken(token);
            return Ok(jwtToken);
       }
       return Unauthorized();
    }

}

