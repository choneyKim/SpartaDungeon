﻿using Txt_Game;

internal class Program
{
    public static Random ran = new Random();
    public static void WrongInput()
    {
        Console.WriteLine("");
        Console.WriteLine("잘못 된 입력 입니다");
        Console.ReadKey();
    }
    static void Main(string[] args)
    {

    }
    int SelectNum(int min, int max)
    {
        bool isNum;
        bool isBreak = true;
        int selectNum;
        isNum = int.TryParse(Console.ReadLine(), out selectNum);
        do
        {
            if (isNum == false)
            {
                Console.WriteLine("숫자를 입력해 주십시오");
            }
            else if (selectNum < min || selectNum > max) Console.WriteLine($"{min}~{max}의 숫자를 입력해주세요");
            else isBreak = false;

        } while (isBreak);
        return selectNum;
    }
}


class Shop
{
    Player p;
    InventoryManager shopInven = new InventoryManager();
    public void ShopPrint()
    {
        while (true)
        {
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(p.Gold);
            Console.WriteLine("");
            shopInven.DisplayInventory();
            Console.WriteLine("");
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>"); string? input = Console.ReadLine();
            switch (input)
            {
                case "1": ShopBuy(); break;
                case "2": ShopSell(); break;
                case "0": return;
                default: Program.WrongInput();continue;
            }
        }
    }

    void ShopBuy()
    {
        while (true)
        {
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(p.Gold);
            shopInven.DisplayInventory();
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            string? input = Console.ReadLine();
            if (Int32.TryParse(input,out int temp))
            {
                if (temp == 0)
                {
                    return;
                }
                temp -= 1;
                if (temp > -1 && temp <= shopInven.Count() && p.Gold >= shopInven.ItemAccess(temp).Price)
                {
                    p.Gold -= shopInven.ItemAccess(temp).Price;
                    p.inven.AddItem(shopInven.ItemAccess(temp));
                    shopInven.RemoveItem(shopInven.ItemAccess(temp));
                    continue;
                }
                else if (temp > -1 && temp <= shopInven.Count() && p.Gold < shopInven.ItemAccess(temp).Price)
                {
                    Console.WriteLine("돈이 부족합니다.");
                    Console.ReadKey();continue;
                }
                else
                {
                    Program.WrongInput();continue;
                }
            }
            else
            {
                Program.WrongInput(); continue;
            }
        }
    }
    void ShopSell()
    {
        while (true)
        {
            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(p.Gold);
            //playerInvenPrint
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>"); string? input = Console.ReadLine();
            if (Int32.TryParse(input, out int temp))
            {
                if (temp == 0)
                {
                    return;
                }
                temp -= 1;
                p.Gold += (int)(shopInven.ItemAccess(temp).Price * 0.85f);
                shopInven.AddItem(p.inven.ItemAccess(temp));
                p.inven.RemoveItem(p.inven.ItemAccess(temp));
            }
            else
            {
                Program.WrongInput(); continue;
            }
        }
    }
    public Shop(Player p)
    {
        this.p = p;
    }
}
class Player
{
    public InventoryManager inven;
    string Name { get; set; }
    int Lv = 1;
    string Job = "전사";
    float Atk = 10;
    float Def = 5;
    float Hp = 100;
    public int Gold = 1500;
    float M_Hp = 100;
    float Exp;
    float M_Exp = 100;
    public void CheckLvUp()
    {
        if (Exp >= M_Exp)
        {
            Lv++;
            Atk += 0.5f;
            Def++;
            M_Hp += 10;
            Exp = 0;
            M_Exp *= 1.5f;
        }
    }
    public Player(string name, string job)
    {
        Name = name;
        Job = job;
    }
    public List<Item> playerItem = new List<Item>();

    public static void AddPlayer()
    {
        Console.WriteLine("캐릭터 이름을 입력하여 주십시오.");
        string name = Console.ReadLine() ?? "철수";
        Console.WriteLine("직업을 입력하여 주십시오.");
        string job = Console.ReadLine() ?? "백수";
        new Player(name, job);
    }
    public void Status()
    {
        Console.WriteLine("상태보기");
        Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        Console.WriteLine("");
        Console.WriteLine($"이름. {Name}");
        Console.WriteLine($"Lv. {Lv.ToString("00")}");
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
    public bool IsDead => HP <= 0;

    public static List<Monster> monsters = new List<Monster>();

    public Monster(string name, int level, int hP, int aTK)
    {
        Name = name;
        Level = level;
        HP = hP;
        ATK = aTK;
    }


    public static void AddMonster()
    {

        for (int i = 0; i < Program.ran.Next(1, 5); i++)
        {

            switch (Program.ran.Next(1, 4))
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
    public static void DisplayMonster()
    {
        for (int i = 0; i < monsters.Count; i++)
        {
            if (monsters[i].IsDead)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            Console.Write($"Lv. {monsters[i].Level} {monsters[i].Name}  HP {(!monsters[i].IsDead ? monsters[i].HP : "Dead")}");
            Console.WriteLine("");
            Console.ResetColor();
        }
    }
    public static int AttackMonster(int selectNum)
    {
        int randomAtk;
        int monsterAtkResult;
        int monsterAtk = monsters[selectNum - 1].ATK;
        if (monsterAtk % 10 == 0) randomAtk = monsterAtk / 10;
        else randomAtk = (monsterAtk / 10) + 1;
        monsterAtkResult = Program.ran.Next(monsterAtk - randomAtk, monsterAtk + randomAtk + 1);

        return monsterAtkResult;
    }
}