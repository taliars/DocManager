using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DocManager.Core.AuthEntities;
using DocManager.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DocManager.API.Controllers
{
    public class AccountContoller : Controller
    {
        private readonly OrderDbContext orderDbContext;

        public AccountContoller(OrderDbContext orderDbContext)
        {
            this.orderDbContext = orderDbContext;
        }

        [HttpPost("/token")]
        public IActionResult Token(string username, string password)
        {
            var claimsIdentity = GetClaimsIdentity(username, password);

            if (claimsIdentity == null)
            {
                return BadRequest(new { ErrorText = "Invaliad userame or password" });
            }

            var now = DateTime.Now;

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: "DocManager.Api",
                audience: "DocManager.Client",
                notBefore: now,
                claims: claimsIdentity.Claims,
                expires: now.Add(TimeSpan.FromHours(9)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("hardcodedkey")), SecurityAlgorithms.HmacSha256));

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var encodedJwtSecurityToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            var response = new
            {
                access_token = encodedJwtSecurityToken,
                username = claimsIdentity.Name
            };

            return Json(response);
        }

        private ClaimsIdentity GetClaimsIdentity(string username, string password)
        {
            var login = orderDbContext.Set<DbLogin>()
                .FirstOrDefault(x => x.UserName == password && x.UserName == username);

            if (login == null)
            {
                return null;
            }

            var defaultNameClaimType = ClaimsIdentity.DefaultNameClaimType;
            var defaultRoleClaimType = ClaimsIdentity.DefaultRoleClaimType;

            var claims = new List<Claim>{
                    new Claim(defaultNameClaimType, username),
                    new Claim(defaultRoleClaimType, login.Role),
                };

            var claimsIdentity = new ClaimsIdentity(claims, "Token", defaultNameClaimType, defaultRoleClaimType);

            return claimsIdentity;
        }
    }
}