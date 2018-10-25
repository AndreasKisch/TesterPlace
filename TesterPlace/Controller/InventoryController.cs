using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TesterPlace.Controller
{

    [Route("inventory/")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryServices _services;

        [HttpGet]
        [Route("ping")]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }

        public InventoryController(IInventoryServices services)
        {
            _services = services;
        }


        [HttpPost]
        [Route("AddInventoryItems")]
        public ActionResult<InventoryItems> AddInventoryItem(InventoryItems items)
        {
            var inventoryItems = _services.AddInventoryItems(items);

            if(inventoryItems == null)
            {
                return NotFound();
            }

            return inventoryItems;
        }



        [HttpGet]
        [Route("GetInventoryItems")]
        public ActionResult<Dictionary<string, InventoryItems>> GetInventoryItems()
        {
            var inventoryItems = _services.GetInventoryItems();

            if (inventoryItems.Count == 0)
            {
                return NotFound();
            }

            return inventoryItems;
        }
    }
}