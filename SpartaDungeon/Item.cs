namespace Txt_Game
{
    public class Item
    {
        public enum ItemType
        {
            Weapon,Armor
        }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool Equipped { get; set; }
        public float Atk { get; set; }
        public int Def { get; set; }

        public Type type;
        public Item(string name, int price,string description ,Type type,float Atk = 0,int Def = 0)
        {
            this.type = type;
            Name = name;
            Price = price;
            Description = description;
            this.Atk = Atk;
            this.Def = Def;
            Equipped = false;

        }
        //public void DisplayInventory()
        //{
        //    string eqquippedStatus = equipped ? "[E]" : "";
        //    Console.WriteLine($"{equipeedstatus}{name} | 가격 : {price} G | {Description}"    }
    }
}
