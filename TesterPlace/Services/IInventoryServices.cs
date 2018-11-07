using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesterPlace
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInventoryServices
    {
        InventoryItems AddInventoryItems(InventoryItems items);
        Dictionary<string, InventoryItems> GetInventoryItems();
    }
}
