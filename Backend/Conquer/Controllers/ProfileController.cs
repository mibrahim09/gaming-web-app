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
using Microsoft.AspNetCore.Authorization;
using NovaGaming.Middlewares;
using AuthorizeAttribute = NovaGaming.Middlewares.AuthorizeAttribute;
using NovaGaming.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NovaGaming.Controllers
{
    [Authorize(Role.User)]
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ConquerDbContext _context;
        private readonly IMapper _mapper;
        private IConfiguration _config;
        public ProfileController(ConquerDbContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var account = (Account)HttpContext.Items[Constants.USER_TOKEN];
            var accountDto = _mapper.Map<ProfileUserDto>(account);

            var character = _context.Characters.Where(e => e.Uid == account.Uid).FirstOrDefault();
            var characterDto = _mapper.Map<ProfileCharacterDto>(character);

            var transactions = _context.Payments.Where(e => e.Username == account.Username).ToList();
            var transactionsDto = _mapper.Map<List<ProfileTransactionsDto>>(transactions);


            return Ok(new JsonResult(new
            {
                account = accountDto,
                character = characterDto,
                transactions = transactionsDto
            }));
        }
        [HttpPost]
        [Route("changepass")]
        public IActionResult Post([FromBody] ChangePassword changePassword)
        {
            var accountFromContext = (Account)HttpContext.Items[Constants.USER_TOKEN];
            var account = _context.Accounts.Where(e => e.Username == accountFromContext.Username).FirstOrDefault();

            if (changePassword.OldPassword == account.Password)
            {
                account.Password = changePassword.NewPassword;
                account.LastChangePassword = Environment.TickCount;
                _context.SaveChanges();

                var loginDto = _mapper.Map<LoginDto>(account);
                var token = AuthService.GenerateJSONWebToken(loginDto, _config);

                return Ok(new JsonResult(new { token = token }));
            }
            else
                return BadRequest("Old password doesnt match!");

        }
    }
}
