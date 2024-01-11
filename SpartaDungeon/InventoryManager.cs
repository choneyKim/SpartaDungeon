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
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == item.Name)
                {
                    Items[i].Stack++;
                    return;
                }
            }
            Items.Add(new Item(item.Name,item.Price,item.Description,item.type,item.Atk,item.Def));
        }
        public void RemoveItem(Item item)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i] == item)
                {
                    Items[i].Stack--;
                    if (Items[i].Stack <= 0)
                    {
                        Items.Remove(item);
                        return;
                    }
                }
            }
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
                Console.WriteLine($"{i + 1} {equippedStatus}{item.Name} | 가격: {item.Price} G | {item.Description} | 갯수: {item.Stack}");
            }
        }
        public void DisplayShopInventory()
        {
            Console.WriteLine("\n[아이템 목록]");
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].HaveItem == false)
                {
                    Console.WriteLine($"{i + 1} {Items[i].Name} | 가격: {Items[i].Price} G | {Items[i].Description}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{i + 1} {Items[i].Name} | 가격: {Items[i].Price} G | {Items[i].Description}");
                    Console.ResetColor();
                }

            }
        }
    }
}