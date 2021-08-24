using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using NovaGaming.DbContexts;
using NovaGaming.Dtos;
using NovaGaming.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using NovaGaming.sakila;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using NovaGaming.Services;
using NovaGaming.Middlewares;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NovaGaming.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ConquerDbContext _context;
        private readonly IMapper _mapper;
        private IConfiguration _config;
        public UserController(ConquerDbContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }
        // POST api/<UserController>
        [Route("login")]
        [HttpPost]
        public IActionResult Post([FromBody] Account loginDto)
        {
            var result = _context.Accounts.Where(e => e.Username == loginDto.Username && e.Password == loginDto.Password).FirstOrDefault();
            if (result == null) return BadRequest(new { error = "Invalid username or password!" });

            var mappedResult = _mapper.Map<LoginDto>(result);// convert result to LoginDto
            var tokenString = AuthService.GenerateJSONWebToken(mappedResult, _config);
            return Ok(tokenString);
        }
        [Route("register")]
        [HttpPost]
        public IActionResult PostRegister([FromBody] RegisterDto registerDto)
        {
            var result = _context.Accounts.Where(e => e.Username == registerDto.Username).FirstOrDefault();
            if (result != null) return BadRequest(new { error = "Please choose another username!" });


            var mappedResult = _mapper.Map<Account>(registerDto);// convert result to Account
            mappedResult.LastChangePassword = Environment.TickCount;

            var resultContext = _context.Accounts.Add(mappedResult);
            _context.SaveChanges();

            var loginDto = _mapper.Map<LoginDto>(mappedResult);// Convert to LoginDto
            var token = AuthService.GenerateJSONWebToken(loginDto, _config);

            return Ok(token);
        }

        [Route("forgotpass")]
        [HttpPost]
        public IActionResult Post([FromBody] ForgotPassword forgotPassword, [FromServices] IRecoverPasswordService recoverPasswordService)
        {
            var result = recoverPasswordService.ForgotPass(forgotPassword);
            switch (result)
            {
                case RecoverPasswordService.State.InvalidEmailOrPass:
                    return BadRequest(new JsonResult(new { message = "Invalid information!" }));
                case RecoverPasswordService.State.ServerIssue:
                default:
                    return BadRequest(new JsonResult(new { message = "Please try again later" }));
                case RecoverPasswordService.State.OK:
                    return Ok(new JsonResult(new { message = "Recovery mail sent!" }));

            }
        }

        [Route("changepassword/{username}/{token}")]
        [HttpPost]
        public IActionResult Post(string username, string token, [FromBody] ResetPassword resetPassword)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(token)) return BadRequest();

            var result = _context.Accounts
                .Where(e => e.Username == username && e.TokenChangePass == token)
                .FirstOrDefault();

            if (result == null) return BadRequest(new JsonResult(new { message = "Invalid information" }));

            result.Password = resetPassword.NewPassword;
            result.TokenChangePass = null;
            _context.SaveChanges();

            return Ok();
        }

    }
}
