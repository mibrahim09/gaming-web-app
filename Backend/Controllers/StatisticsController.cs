using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using NovaGaming.DbContexts;
using NovaGaming.Models;
using NovaGaming.sakila;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NovaGaming.Controllers
{
    [Route("api/Statistics")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        public enum TopsType : byte
        {
            Potency = 1,
            Money = 2,
            Virtue = 3,
            PK = 4,
            Trojan = 15,
            Warrior = 25,
            Archer = 45,
            Fire = 145,
            Water = 135
        }
        private readonly ConquerDbContext _context;
        public StatisticsController(ConquerDbContext context)
        {
            _context = context;
        }
        // GET: api/<UserController>
        [HttpGet]
        public ServerStatistics Get()
        {
            var result = new ServerStatistics();
            try
            {
                using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    socket.Connect("127.0.0.1", 3306);
                    result.IsOnline = true;
                }
            }
            catch
            {

            }
            var dbResult = _context.Stats.FirstOrDefault();
            result.LastCounterClockWinner = dbResult.LastCcwin;
            result.LastTwinCityWinner = dbResult.LastTcwin;
            result.LastGuildWarWinner = dbResult.LastGwwin;
            return result;
        }

        // GET api/<UserController>/5
        [HttpGet("{rankType}")]
        public IEnumerable<Top> Get(string rankType)
        {
            try
            {
                TopsType topsType = (TopsType)Enum.Parse(typeof(TopsType), rankType);
                return _context.Tops.Where(e => e.Toptype == (int)topsType).ToList();
            }
            catch
            {
                return null;// Invalid type.
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
