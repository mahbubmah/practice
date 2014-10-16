using System.Collections.Generic;

namespace ShopAppDB.DLL.DAO
{
    class Shop
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Item> Items { get; set; }

        public Shop(string name, string address)
        {
            Name = name;
            Address = address;
            Items=new List<Item>();
        }

        public string Add(Item anItem)
        {
            if (HasThisItem(anItem.ProductID))
            {
                UpdateItem(anItem);
            }

            Items.Add(anItem);
            return "item Added";
        }

        private void UpdateItem(Item anItem)
        {
            foreach (var item in Items)
            {
                if (anItem.ProductID == item.ProductID)
                {
                    item.Quantity += anItem.Quantity;
                }
            }
        }

        public bool HasThisItem(string ProductID)
        {
            foreach (var anitem in Items)
            {
                if (anitem.ProductID ==ProductID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
