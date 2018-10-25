using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TesterPlace.Controller
{
  
    public class PingController : ControllerBase
    {
        [HttpGet]
        [Route("api/ping")]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }
    }
}