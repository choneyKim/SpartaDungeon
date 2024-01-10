using System;
using System.Collections.Generic;

namespace Txt_Game
{

    public class InventoryManager
    {
        private List<Item> Items { get;  set; }

        public InventoryManager()

        {
            Items = new List<Item>();
        }
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }
        public int Count()
        {
            return Items.Count;
        }
        public Item ItemAccess(int index)
        {
            return Items[index];
        }
        public void DisplayInventory()
        {
            Console.WriteLine("\n[아이템 목록]");
            for (int i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];
                string equippedStatus = item.Equipped ? "[E]" : "";
                Console.WriteLine($"{i + 1} {equippedStatus}{item.Name} | 가격: {item.Price} G | {item.Description}");
            }
        }
    }
}