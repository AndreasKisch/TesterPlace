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
        /// <summary>
        /// Check to see if you can access API
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ping")]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }
    }
}