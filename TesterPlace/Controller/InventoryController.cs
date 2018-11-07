using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TesterPlace.Controller
{
    /// <summary>
    /// Handels task to do with InventoryItems
    /// 
    /// </summary>
    [Route("inventory/")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryServices _services;
        
               

        public InventoryController(IInventoryServices services)
        {
            _services = services;

        }

        /// <summary>
        /// Calls services to add new inventoryItem
        /// to the dictionary and Xml-doc
        /// </summary>
        /// <param name="items">Object to be added</param>
        /// <returns>success message</returns>
        [HttpPost]
        [Route("AddInventoryItems")]
        public ActionResult<InventoryItems> AddInventoryItems(InventoryItems items)
        {

            var inventoryItems = _services.AddInventoryItems(items);
            if (inventoryItems == null)
            {
                return NotFound();
            }

            return Ok(inventoryItems);
        }

        /// <summary>
        /// Gets container for current items
        /// in dictionary
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetInventoryItems")]
        public ActionResult<List<InventoryItems>> GetInventoryItems()
        {
            var inventoryItems = _services.GetInventoryItems();

            if (inventoryItems.Count == 0)
            {
                return NotFound();
            }

            return inventoryItems.Values.ToList();
        }


    }
}