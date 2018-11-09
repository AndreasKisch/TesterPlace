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
            List<InventoryItems> ItemList = new List<InventoryItems>();

            using (HttpResponseMessage res = await APIHelper.InvAPI.GetAsync("Inventory/GetInventoryItems"))
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
            Helper.SessionHelper.Set<List<InventoryItems>>(HttpContext.Session, "iList", ItemList);

            return View(ItemList);
        }

        public IActionResult Edit(string itemName)
        {
            List<InventoryItems> iList = Helper.SessionHelper.Get<List<InventoryItems>>(HttpContext.Session, "iList");
            InventoryItems item = iList.Find(x => x.ItemName == itemName);

            return View(item);
        }

        public async Task<IActionResult> Create(InventoryItems iObj)
        {
            HttpResponseMessage res = await APIHelper.InvAPI.PostAsJsonAsync("Inventory/AddInventoryItems/", iObj);

            if (res.IsSuccessStatusCode)
                return Redirect("Index");

            return View();
        }




    }
}