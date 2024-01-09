internal class Program
{
    static void Main(string[] args)
    {
        Player.AddPlayer();
    }
}

class Item
{
    public string Name { get; set; } 
    public int Price { get; set; }
    public string Description { get; set; }

    public Item(string name, int price, string description)
    {
        Name = name; 
        Price = price; 
        Description = description;
    }
}
class Shop
{
    public void ShopPrint()
    {
        Console.WriteLine("상점");
        Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
        Console.WriteLine("");
        Console.WriteLine("[보유 골드]");
        Console.WriteLine(/*playerGold*/);
        Console.WriteLine("");
        Console.WriteLine("[아이템 목록]");
        //sell ItemPrint
        Console.WriteLine("");
        Console.WriteLine("1. 아이템 구매");
        Console.WriteLine("0. 나가기");
        Console.WriteLine("");
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        Console.Write(">>");
    }
}
class Player
{
    string Name { get; set; }
    int Lv = 1;
    string Job = "전사";
    float Atk = 10;
    float Def = 5;
    float Hp = 100;
    int Gold = 1500;
    float M_Hp;
    float Exp;
    float M_Exp;
    public Player(string name, string job)
    {
        Name = name;
        Job = job;
    }
    public List<Item> playerItem = new List<Item>();

    public static void AddPlayer()
    {
        Console.WriteLine("캐릭터 이름을 입력하여 주십시오.");
        string name = Console.ReadLine();
        Console.WriteLine("직업을 입력하여 주십시오.");
        string job = Console.ReadLine();
        new Player(name, job);
    }
    public void Status()
    {
        Console.WriteLine("상태보기");
        Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        Console.WriteLine("");
        Console.WriteLine($"이름. {Name}");
        Console.WriteLine($"Lv. {Lv}");
        Console.WriteLine($"Chad({Job})");
        Console.WriteLine($"공격력:{Atk}");
        Console.WriteLine($"방어력:{Def}");
        Console.WriteLine($"체력:{Hp}");
        Console.WriteLine($"Gold:{Gold}");
        Console.WriteLine("");
        Console.WriteLine("0. 나가기");
        Console.WriteLine("");
        Console.WriteLine("원하시는 행동을 입력해 주세요.");
        Console.Write(">>");
    }

}

class Monster
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public int ATK { get; set; }
    int monsterNum;
    int monsterName;
    public List<Monster> monsters = new List<Monster>();

    public Monster(string name, int level, int hP, int aTK)
    {
        Name = name;
        Level = level;
        HP = hP;
        ATK = aTK;
    }


    public void AddMonster()
    {
        monsterNum = new Random().Next(1, 5);

        for (int i = 0; i < monsterNum; i++)
        {
            monsterName = new Random().Next(1, 4);
            switch (monsterName)
            {
                case 1:
                    {
                        monsters.Add(new Monster("미니언", 2, 15, 5));
                        break;
                    }
                case 2:
                    {
                        monsters.Add(new Monster("공허충", 3, 10, 9));
                        break;
                    }
                case 3:
                    {
                        monsters.Add(new Monster("대포미니언", 5, 25, 8));
                        break;
                    }
            }
        }
    }
    public void DisplayMonster()
    {
        for (int i = 0; i<monsters.Count; i++) 
        {
            Console.Write($"Lv. {monsters[i].Level} {monsters[i].Name}  HP {monsters[i].HP}");
        }
    }
}