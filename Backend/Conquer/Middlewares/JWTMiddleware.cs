using NovaGaming.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System;
using NovaGaming;

namespace Middlewares
{
    internal class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public JWTMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
            //_context = context;
        }
        public async Task Invoke(HttpContext context, ConquerDbContext _dbContext)
        {
            var token = context.Request.Headers["Authorization"]
                .FirstOrDefault();

            if (token != null)
                setContextToUser(context, _dbContext, token);

            await _next.Invoke(context);
        }

        private void setContextToUser(HttpContext context, ConquerDbContext _dbContext, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountId = jwtToken.Claims.First(x => x.Type == "Username").Value;
                var lastChangePassword = jwtToken.Claims.First(x => x.Type == "ServerStamp").Value;

                var account = _dbContext.Accounts.Where(e => e.Username == accountId).FirstOrDefault();
                if (account != null && long.Parse(lastChangePassword) == account.LastChangePassword)
                {
                    // attach account to context on successful jwt validation
                    context.Items[Constants.USER_TOKEN] = account;
                }
                
            }
            catch(Exception e)
            {
                // do nothing if jwt validation fails
                // account is not attached to context so request won't have access to secure routes
            }
        }
    }
}