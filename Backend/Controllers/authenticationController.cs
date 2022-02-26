using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Backend.Database;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class authenticationController: Controller
    {
        private readonly CliDB _db;
        private readonly AppSettings _appSettings;

        public authenticationController(CliDB db, IOptions<AppSettings> appSettings)
        {
            _db = db;
            _appSettings = appSettings.Value;
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginDTO login)
        {
            var result=_db
                .Accounts
                .Include(m=>m.User)
                .Include(m=>m.Manager)
                .Include(m=>m.Writer)
                .Where(m=>m.Username==login.Username && m.Password==login.Password)
                .FirstOrDefault();
            if (result!=null && (result.User!=null || result.Writer!=null || result.Manager!=null))
            {
                result.Password=""; //کاری نادرست از نظر پایگاه داده ای

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", result.Username) }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenstring= tokenHandler.WriteToken(token);

                return Ok(new {Account=result , Token=tokenstring});  // کاری نادرست از نظر امنیت
            }
            return Unauthorized(new {Message="این نام کاربری یا پسورد صحیح نمی باشد"});
        }
    }
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}