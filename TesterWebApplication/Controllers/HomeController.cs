using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TesterWebApplication.Models;

namespace TesterWebApplication.Controllers
{
    /// <summary>
    /// Controller to be modified at later date
    /// 
    /// </summary>
    public class HomeController : Controller
    {
      
        public  IActionResult Index()
        {
           

            return View();
        }             

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
