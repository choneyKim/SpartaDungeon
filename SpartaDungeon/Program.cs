using Txt_Game;

internal class Program
{
    public static Random ran = new Random();
    public static void WrongInput()
    {
        Console.WriteLine("잘못 된 입력 입니다");
        Console.ReadKey();
    }
    private static void printStartLogo()
    {
        Console.WriteLine("=====================================================================================================================");
        Console.WriteLine("");

        Console.WriteLine("      ooooo   ooooo   .oooooo.   ooooo        oooooo   oooo                          ");
        Console.WriteLine("      `888'   `888'  d8P'  `Y8b  `888'         `888.   .8'                           ");
        Console.WriteLine("       888     888  888      888  888           `888. .8'                            ");
        Console.WriteLine("       888ooooo888  888      888  888            `888.8'                             ");
        Console.WriteLine("       888     888  888      888  888             `888'                              ");
        Console.WriteLine("       888     888  `88b    d88'  888       o      888                               ");
        Console.WriteLine("      o888o   o888o  `Y8bood8P'  o888ooooood8     o888o                              ");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("                oooooooooo.   ooooo     ooo ooooo      ooo   .oooooo.    oooooooooooo    .oooooo.   ooooo      ooo ");
        Console.WriteLine("                `888'   `Y8b  `888'     `8' `888b.     `8'  d8P'  `Y8b   `888'     `8  d8P'  `Y8b  `888b.     `8'  ");
        Console.WriteLine("                 888      888  888       8   8 `88b.    8  888            888         888      888  8 `88b.    8   ");
        Console.WriteLine("                 888      888  888       8   8   `88b.  8  888            888oooo8    888      888  8   `88b.  8   ");
        Console.WriteLine("                 888      888  888       8   8     `88b.8  888     ooooo  888    '    888      888  8     `88b.8   ");
        Console.WriteLine("                 888     d88'  `88.    .8'   8       `888  `88.    .88'   888       o `88b    d88'  8       `888   ");
        Console.WriteLine("                o888bood8P'      `YbodP'    o8o        `8   `Y8bood8P'   o888ooooood8  `Y8bood8P'  o8o        `8   ");

        Console.WriteLine("");
        Console.WriteLine("=======================================================================================================================");
        Console.WriteLine("                                                  PRESS ANYKEY TO START                                                ");
        Console.WriteLine("=======================================================================================================================");
        Console.ReadKey();
    }
    static void Main(string[] args)
    {
        printStartLogo();
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
    public Shop(Player player)
    {
        p = player;
        InitializeItems();
    }
    private void InitializeItems()
    {
        //무기
        shopInven.AddItem(new Item("버터 나이프", 100,"빵에 버터를 바르기에 적합한 나이프 입니다", Item.ItemType.Weapon, Atk: 2));
        shopInven.AddItem(new Item("소형 검", 200, "사냥에도 쓸만한 검입니다", Item.ItemType.Weapon, Atk : 5));
        shopInven.AddItem(new Item("청동검", 500, "사용한 흔적이 있는 청동검입니다", Item.ItemType.Weapon, Atk: 7));
        shopInven.AddItem(new Item("철창", 1000, "철로 만들어진 창입니다", Item.ItemType.Weapon, Atk: 10));
        shopInven.AddItem(new Item("철검", 2000, "창보다 빠르게 휘두를 수 있는 검입니다", Item.ItemType.Weapon, Atk:22));
        shopInven.AddItem(new Item("강철창", 4000, "강철로 만든 강력한 창입니다", Item.ItemType.Weapon, Atk:50));
        shopInven.AddItem(new Item("백금검", 17000, "백금으로 홀려서 강력한 공격을 가할 수 있습니다", Item.ItemType.Weapon, Atk:150));
        shopInven.AddItem(new Item("얼음의 지팡이",35000, "휘두를때 눈보라가 일어나 약 100의 추가 데미지를 줍니다", Item.ItemType.Weapon, Atk:200));
        //shopInven.AddItem(new Item("흡혈 지팡이", 70000, "공격력 +290", "휘두를때 마다 적의 HP를 200씩 뺏습니다"));

        //갑옷
        shopInven.AddItem(new Item("천 옷", 100, "침대에서 잠자기 좋은 옷입니다", Item.ItemType.Armor, Def:2));
        shopInven.AddItem(new Item("가죽 옷", 800, "동물의 할퀴기를 막기에 좋은 갑옷입니다", Item.ItemType.Armor, Def:7));
        shopInven.AddItem(new Item("무쇠 갑옷", 1700, "무쇠로 만들어져 튼튼한 갑옷입니다.", Item.ItemType.Armor, Def: 9));
        shopInven.AddItem(new Item("강철 갑옷", 3300, "강철로 만들어져 방어력이 향상된 갑옷 입니다.", Item.ItemType.Armor, Def:15));
        shopInven.AddItem(new Item("수정 갑옷", 4500, "신비한 수정으로 만들어진 갑옷 입니다.", Item.ItemType.Armor, Def:20));
        shopInven.AddItem(new Item("성스러운 갑옷", 10000, "성스러운 기운이 깃든 갑옷 입니다.", Item.ItemType.Armor, Def:15));
        shopInven.AddItem(new Item("백금 갑옷", 20000, "금을 자랑하기 위해서 만든 갑옷이지만 의외로 딱딱합니다", Item.ItemType.Armor, Def:130));
        //shopInven.AddItem(new Item("회복의 갑옷", 36000, "방어력 +150", " 방어를 누르면 한턴당 HP를 200 회복합니다"));
    }
    public void ShopPrint()
    {
        while (true)
        {
            Console.Clear();
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
            Console.Clear();
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
            Console.Clear();
            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(p.Gold);
            p.inven.DisplayInventory();
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
                if (p.inven.ItemAccess(temp).Name == p.WeaponSlot.Name)
                {
                    p.WeaponSlot = null;
                }
                if (p.inven.ItemAccess(temp).Name == p.ArmorSlot.Name)
                {
                    p.ArmorSlot = null;
                }
                p.Gold += (int)(p.inven.ItemAccess(temp).Price * 0.85f);
                shopInven.AddItem(p.inven.ItemAccess(temp));
                p.inven.RemoveItem(p.inven.ItemAccess(temp));
            }
            else
            {
                Program.WrongInput(); continue;
            }
        }
    }
}
class Player
{
    public InventoryManager inven = new InventoryManager();
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
    public class JOB
    {
        public string Warrior;

        public string Wizard;

        public string Chef;
    }
    public static Player AddPlayer()

    {
        Console.WriteLine("캐릭터 이름을 입력하여 주십시오.");
        string name = Console.ReadLine() ?? "철수";
        Console.WriteLine("직업을 입력하여 주십시오.");
        string job = Console.ReadLine() ?? "백수";
        return new Player(name, job);
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
    public Item? WeaponSlot { get; set; }
    public Item? ArmorSlot { get; set; }
    public void ManageEquippedItems()
    {
        Console.WriteLine("\n장착 관리");
        inven.DisplayInventory();

        Console.Write("장착 또는 해제할 아이템 번호를 입력하세요 (0. 나가기): ");
        string? userInput = Console.ReadLine();

        if (int.TryParse(userInput, out int itemIndex) && itemIndex >= 1 && itemIndex <= inven.Count())
        {
            Item selectedItem = inven.ItemAccess(itemIndex - 1);
            selectedItem.Equipped = !selectedItem.Equipped;
            if (selectedItem.Equipped)
            {
                Console.WriteLine($"{selectedItem.Name}을(를) 장착했습니다.");

            }
            else
            {
                Console.WriteLine($"{selectedItem.Name}을(를) 해제했습니다.");
            }
            switch (selectedItem.type)
            {
                case Item.ItemType.Weapon:
                    WeaponSlot = selectedItem.Name == WeaponSlot.Name ? null : selectedItem;
                    break;
                case Item.ItemType.Armor:
                    ArmorSlot = selectedItem.Name == ArmorSlot.Name ? null : selectedItem;
                    break;
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