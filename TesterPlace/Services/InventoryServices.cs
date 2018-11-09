using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace TesterPlace
{
    /// <summary>
    /// Service to load and add items to Xml-doc and dictionary
    /// 
    /// </summary>
    public class InventoryServices : IInventoryServices
    {
        private readonly Dictionary<string, InventoryItems> _inventoryItems;

        /// <summary>
        /// Constructor 
        /// Adds values from Xml-doc into a a dictionary
        /// </summary>
        public InventoryServices()
        {
            _inventoryItems = new Dictionary<string, InventoryItems>();
            XmlReader reader = XmlReader.Create(Environment.CurrentDirectory + "\\Data\\InventoryList.xml");
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Item"))
                {
                    if (reader.HasAttributes)
                    {
                        InventoryItems i = new InventoryItems();
                        i.Quantity = Int32.Parse(reader.GetAttribute("Quantity"));
                        i.ItemName = reader.GetAttribute("ItemName");
                        i.Price = Int32.Parse(reader.GetAttribute("Price"));

                        AddInventoryItems(i);
                    }
                }

            }

        }

        /// <summary>
        /// Adds object to dictionary
        /// 
        /// Funtion to add it to Xml to be written later
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>

        public InventoryItems AddInventoryItems(InventoryItems items)
        {
            if (items.ItemName != null)
            {
                _inventoryItems.Add(items.ItemName, items);
                return items;
            }

            return null;
        }

        /// <summary>
        /// Simple return of the current dictionary of InventoryItems
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, InventoryItems> GetInventoryItems()
        {
            return _inventoryItems;
        }
    }
}
