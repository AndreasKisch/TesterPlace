using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace TesterPlace
{
    public class InventoryServices : IInventoryServices
    {
        private readonly Dictionary<string, InventoryItems> _inventoryItems;

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
                        i.ID = Int32.Parse(reader.GetAttribute("Id"));
                        i.ItemName = reader.GetAttribute("ItemName");
                        i.Price = Int32.Parse(reader.GetAttribute("Price"));

                        AddInventoryItems(i);
                    }
                }

            }

        }


        public InventoryItems AddInventoryItems(InventoryItems items)
        {
            _inventoryItems.Add(items.ItemName, items);

            return items;
        }

        public Dictionary<string, InventoryItems> GetInventoryItems()
        {
            return _inventoryItems;
        }
    }
}
