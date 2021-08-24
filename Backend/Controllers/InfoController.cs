using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using NovaGaming.DbContexts;
using NovaGaming.Models;
using NovaGaming.sakila;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NovaGaming.Controllers
{
    [Route("api/info")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly ConquerDbContext _context;
        private readonly IConfiguration _config;

        public InfoController(ConquerDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {

            var mega = _config["Downloads:Mega"];
            var google = _config["Downloads:Google"];

            return Ok(new JsonResult(new
            {
                mega = mega,
                google = google
            }));
        }

    }
}
