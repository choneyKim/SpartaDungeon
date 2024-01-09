using System;
using System.collections.Genric;

namespace Txt_Game

    public class InventoryManager
{
    private List<Item> Items { get; private set; }

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

    public void DisplayInventory()
    {
        Console.WriteLine("\n");

    }
}
