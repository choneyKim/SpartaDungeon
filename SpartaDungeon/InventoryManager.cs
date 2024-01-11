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
                Console.Write(PadRightForMixedText($"{i + 1} {(item.Equipped ? "[E]" : "")}{item.Name} ", 20));
                Console.Write(PadRightForMixedText($"| 가격: {item.Price} G ", 20));
                Console.Write(PadRightForMixedText($"| {(Items[i].type == 0 ? "공격력" : "방어력")} {(Items[i].type == 0 ? $"{Items[i].Atk}" : $"{Items[i].Def}")}", 15));
                Console.Write(PadRightForMixedText($"| {item.Description} ", 45));
                Console.WriteLine(PadRightForMixedText($"| 갯수: {item.Stack} ", 10));
            }
        }
        public void DisplayShopInventory()
        {
            Console.WriteLine("\n[아이템 목록]");
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].HaveItem == false)
                {
                    Console.Write(PadRightForMixedText($"{i+1} {Items[i].Name} ", 20));
                    Console.Write(PadRightForMixedText($"| 가격: {Items[i].Price} G ", 20));
                    Console.Write(PadRightForMixedText($"| {(Items[i].type == 0 ? "공격력" : "방어력")} {(Items[i].type == 0 ? $"{Items[i].Atk}" : $"{Items[i].Def}")}", 15));
                    Console.WriteLine(PadRightForMixedText($"| {Items[i].Description}", 45));

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(PadRightForMixedText($"{i + 1} {Items[i].Name} ", 20));
                    Console.Write(PadRightForMixedText($"| 가격: {Items[i].Price} G ", 20));
                    Console.Write(PadRightForMixedText($"| {(Items[i].type == 0 ? "공격력" : "방어력")} {(Items[i].type == 0 ? $"{Items[i].Atk}" : $"{Items[i].Def}")}", 15));
                    Console.WriteLine(PadRightForMixedText($"| {Items[i].Description}", 45));
                    Console.ResetColor();
                }

            }
        }
        public int GetPrintableLength(string str)
        {
            int length = 0;
            foreach (char c in str)
            {
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    length += 2; // 한글같이 길이가 긴 문자에 대해 길이를 2로 취급 
                }
                else
                {
                    length += 1; //나머지 문자에 대해서 길이를 1로 취급
                }
            }
            return length;
        }

        public string PadRightForMixedText(string str, int totlalLength)
        {
            int currentLenghth = GetPrintableLength(str);
            int paddingg = totlalLength - currentLenghth;
            return str.PadRight(str.Length + paddingg);
        }

    }
}