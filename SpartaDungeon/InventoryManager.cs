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

        public void ManageEquippedItems()
        {
            Console.WriteLine("\n장착 관리");
            DisplayInventory();

            Console.Write("장착 또는 해제할 아이템 번호를 입력하세요 (0. 나가기): ");
            string? userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int itemIndex) && itemIndex >= 1 && itemIndex <= Items.Count)
            {
                Item selectedItem = Items[itemIndex - 1];
                selectedItem.Equipped = !selectedItem.Equipped;

                if (selectedItem.Equipped)
                {
                    Console.WriteLine($"{selectedItem.Name}을(를) 장착했습니다.");
                }
                else
                {
                    Console.WriteLine($"{selectedItem.Name}을(를) 해제했습니다.");
                }
            }
            else if (userInput == "0")
            {
                return;
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
            }
        }
    }
}