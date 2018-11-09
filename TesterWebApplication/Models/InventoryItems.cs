using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesterWebApplication
{
    /// <summary>
    /// Model to display values in View
    /// </summary>
    public class InventoryItems
    {

        public int Quantity { get; set; }

        public string ItemName { get; set; }

        public double Price { get; set; }

    }
}
