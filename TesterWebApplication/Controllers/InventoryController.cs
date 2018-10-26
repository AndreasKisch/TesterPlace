﻿using System;
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
        List<InventoryItems> ItemList = new List<InventoryItems>();
        
        public async Task<IActionResult> Index()
        {
            using (HttpResponseMessage res = await Helper.InvAPI.GetAsync("Inventory/GetInventoryItems"))
            {
                if (res.IsSuccessStatusCode)
                {
                    ItemList = await res.Content.ReadAsAsync<List<InventoryItems>>();

                }
                else
                {
                    throw new Exception(res.ReasonPhrase);
                }
            }
            return View(ItemList);
        }
    }
}