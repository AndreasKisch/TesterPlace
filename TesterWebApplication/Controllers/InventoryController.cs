using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TesterWebApplication.Controllers
{
    public class InventoryController : Controller
    {


        public async Task<IActionResult> Index()
        {
            

            return View();
        }
    }
}