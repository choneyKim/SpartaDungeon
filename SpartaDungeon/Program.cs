using System.Numerics;
using System.Reflection.Metadata;
using System.Threading;
using Txt_Game;

internal class Program
{
    public static Random ran = new Random();

    static void Main(string[] args)
    {
        printStartLogo();
        //nP == 플레이어 객체, sh == 샵 객체
        Player nP = Player.AddPlayer();
        Shop sh = new Shop(nP);
        Battle battle = new Battle(nP,sh);
        MainManu(nP,sh,battle);
        
    }
    public static void WrongInput()
    {
        Console.Write("잘못 된 입력 입니다");
        Console.ReadKey();
        Console.SetCursorPosition(0, 0);
    }
    private static void printStartLogo()
    {
        ShowHighlightedText_D("=====================================================================================================================");
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
        ShowHighlightedText_D("=======================================================================================================================");
        ShowHighlightedText_M("                                                  PRESS ANYKEY TO START                                                ");
        //이렇게 사용 \*^^*/
        ShowHighlightedText_D("=======================================================================================================================");
        Console.ReadKey();
    }
    public static void ShowHighlightedText_M(string text)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(text);
        Console.ResetColor();
    }
    //글자색 변경(console.ForgroundColor),리셋(ResetColor)
    public static void ShowHighlightedText_Y(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(text);
        Console.ResetColor();
    }
    //노란색
    public static void ShowHighlightedText_D(string text)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(text);
        Console.ResetColor();
    }
    //어두운회색
    public static void ShowHighlightedText_G(string text)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(text);
        Console.ResetColor();
    }
    //회색
    public static void ShowHighlightedText_R(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text);
        Console.ResetColor();
    }
    //빨간색
    public static void PrintTextWithHighlights(string s1, string s2, string s3 = "")
    {
        Console.Write(s1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(s2);
        Console.ResetColor();
        Console.WriteLine(s3);
    }
    //중간 글자색바뀌게(노란색)
    public static void Firstlettercolor(string s1, string s2 = "")
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(s1);
        Console.ResetColor();
        Console.WriteLine(s2);
    }
    //첫글자 색상변경(마젠타)
    public static void MainManu(Player nP, Shop sh, Battle battle)
    {
        while (true)
        {
            Console.Clear();

            ShowHighlightedText_D("++++++++++++++++++++++++++++++++");
            Console.WriteLine("마을에 오신 " + nP.Name + "님 환영합니다.");
            ShowHighlightedText_D("++++++++++++++++++++++++++++++++");
            Console.WriteLine("");
            Program.Firstlettercolor("1.", " 상태 보기");
            Program.Firstlettercolor("2.", " 인벤토리");
            Program.Firstlettercolor("3.", " 상점");
            Program.Firstlettercolor("4.", " 전투 시작");
            Console.WriteLine("");
            Console.Write("원하시는 행동을 선택하세요.\n>>"); string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    nP.Status();
                    break;
                case "2":
                    nP.ManageEquippedItems();
                    break;
                case "3":
                    sh.ShopPrint();
                    break;
                case "4":
                    battle.BattleDisplay();
                    break;
                default:
                    WrongInput();
                    break;
            }
        }
    }
}

//    int SelectNum(int min, int max)
//    {
//        bool isNum;
//        bool isBreak = true;
//        int selectNum;
//        isNum = int.TryParse(Console.ReadLine(), out selectNum);
//        do
//        {
//            if (isNum == false)
//            {
//                Console.WriteLine("숫자를 입력해 주십시오");
//            }
//            else if (selectNum < min || selectNum > max) Console.WriteLine($"{min}~{max}의 숫자를 입력해주세요");
//            else isBreak = false;

//        } while (isBreak);
//        return selectNum;
//    }
//}


class Shop
{
    Player p;
    InventoryManager shopInven = new InventoryManager();
    public Shop(Player player)
    {
        p = player;
        InitializeItems();
    }
    //string.RightPad(totalWidth)/LeftPad
    private void InitializeItems()
    {
        //무기
        shopInven.AddItem(new Item("버터 나이프", 100, "공격력 +2 | 빵에 버터를 바르기에 적합한 나이프 입니다", Item.ItemType.Weapon, Atk: 2));
        shopInven.AddItem(new Item("소형 검", 200, "공격력 +5 | 사냥에도 쓸만한 검입니다", Item.ItemType.Weapon, Atk: 5));
        shopInven.AddItem(new Item("청동검", 500, "공격력 +7 | 사용한 흔적이 있는 청동검입니다", Item.ItemType.Weapon, Atk: 7));
        shopInven.AddItem(new Item("철창", 1000, "공격력 +10 | 철로 만들어진 창입니다", Item.ItemType.Weapon, Atk: 10));
        shopInven.AddItem(new Item("철검", 2000, "공격력 +22 | 창보다 빠르게 휘두를 수 있는 검입니다", Item.ItemType.Weapon, Atk: 22));
        shopInven.AddItem(new Item("강철창", 4000, "공격력 + 50 | 강철로 만든 강력한 창입니다", Item.ItemType.Weapon, Atk: 50));
        shopInven.AddItem(new Item("백금검", 17000, "공격력 +150 | 백금으로 홀려서 강력한 공격을 가할 수 있습니다", Item.ItemType.Weapon, Atk: 150));
        shopInven.AddItem(new Item("얼음의 지팡이", 35000, "공격력 +200 | 휘두를때 눈보라가 일어나 약 100의 추가 데미지를 줍니다", Item.ItemType.Weapon, Atk: 200));
        //shopInven.AddItem(new Item("흡혈 지팡이", 70000, "공격력 +290", "휘두를때 마다 적의 HP를 200씩 뺏습니다"));

        //갑옷
        shopInven.AddItem(new Item("천 옷", 100, "방어력 +2 | 침대에서 잠자기 좋은 옷입니다", Item.ItemType.Armor, Def: 2));
        shopInven.AddItem(new Item("가죽 옷", 800, "방어력 +7 | 동물의 할퀴기를 막기에 좋은 갑옷입니다", Item.ItemType.Armor, Def: 7));
        shopInven.AddItem(new Item("무쇠 갑옷", 1700, "방어력 +9 | 무쇠로 만들어져 튼튼한 갑옷입니다.", Item.ItemType.Armor, Def: 9));
        shopInven.AddItem(new Item("강철 갑옷", 3300, "방어력 +15 | 강철로 만들어져 방어력이 향상된 갑옷 입니다.", Item.ItemType.Armor, Def: 15));
        shopInven.AddItem(new Item("수정 갑옷", 4500, "방어력 +20 | 신비한 수정으로 만들어진 갑옷 입니다.", Item.ItemType.Armor, Def: 20));
        shopInven.AddItem(new Item("성스러운 갑옷", 10000, "방어력 +55 | 성스러운 기운이 깃든 갑옷 입니다.", Item.ItemType.Armor, Def: 55));
        shopInven.AddItem(new Item("백금 갑옷", 20000, "방어력 + 130 | 금을 자랑하기 위해서 만든 갑옷이지만 의외로 딱딱합니다", Item.ItemType.Armor, Def: 130));
        //shopInven.AddItem(new Item("회복의 갑옷", 36000, "방어력 +150", " 방어를 누르면 한턴당 HP를 200 회복합니다"));
    }
    private void AddShopItem(string name, int price, string description, Item.ItemType type, int stat)
    {
        string formattedItem = $"{name,-20} Price: {price,-8} Description: {description,-60} Type: {type,-10} Stat: {stat,-5}";
        shopInven.AddItem(new Item(name, price, description, type, stat));
        Console.WriteLine(formattedItem);
    }
    public void ShopPrint()
    {
        while (true)
        {
            Console.Clear();
            Program.PrintTextWithHighlights("|", " 상점 ", "|");
            Program.ShowHighlightedText_D("+++++++++++++++++++++++++++++++");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Program.ShowHighlightedText_D("+++++++++++++++++++++++++++++++");
            Console.WriteLine("");
            Program.PrintTextWithHighlights("[ ", "보유 골드", "]");
            Console.WriteLine(p.Gold + " G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < shopInven.Count(); i++)
            {
                Item items = shopInven.ItemAccess(i);
                Console.WriteLine($"{items.Name} | 가격: {items.Price} G | {items.Description}");
            }
            Console.WriteLine("");
            Program.Firstlettercolor("1.", " 아이템 구매");
            Program.Firstlettercolor("2.", " 아이템 판매");
            Program.Firstlettercolor("0.", " 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");
            Console.SetCursorPosition(2, 15 + shopInven.Count());
            string? input = Console.ReadLine();
            switch (input)
            {
                case "1": ShopBuy(); break;
                case "2": ShopSell(); break;
                case "0": return;
                default: Program.WrongInput(); break;
            }
        }
    }
    void ShopBuy()
    {
        while (true)
        {
            Console.Clear();
            Program.PrintTextWithHighlights(" |", " 상점", "|");
            Program.PrintTextWithHighlights("아이템 ", "구매", "");
            Console.WriteLine("");
            Program.ShowHighlightedText_D("+++++++++++++++++++++++++++++++");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Program.ShowHighlightedText_D("+++++++++++++++++++++++++++++++");
            Console.WriteLine("");
            Program.PrintTextWithHighlights("[", "보유 골드", "]");
            Console.WriteLine(p.Gold + " G");
            shopInven.DisplayShopInventory();
            Console.WriteLine("");
            Program.Firstlettercolor("0.", " 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.\n>>");
            Console.SetCursorPosition(2, 15 + shopInven.Count());
            string? input = Console.ReadLine();

            if (Int32.TryParse(input, out int temp))
            {
                if (temp == 0)
                {
                    return;
                }
                temp -= 1;
                if (temp > -1 && temp <= shopInven.Count() && p.Gold >= shopInven.ItemAccess(temp).Price)
                {
                    if (!shopInven.ItemAccess(temp).HaveItem)
                    {
                        p.Gold -= shopInven.ItemAccess(temp).Price;
                        p.inven.AddItem(shopInven.ItemAccess(temp));
                        shopInven.ItemAccess(temp).HaveItem = true;
                        //shopInven.RemoveItem(shopInven.ItemAccess(temp));
                    }
                }
                else if (temp > -1 && temp <= shopInven.Count() && p.Gold < shopInven.ItemAccess(temp).Price)
                {
                    Program.ShowHighlightedText_R("돈이 부족합니다.");
                    Console.ReadKey();
                }
                else
                {
                    Program.WrongInput(); continue;
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
            Program.PrintTextWithHighlights(" |", " 상점", "|");
            Program.PrintTextWithHighlights("아이템", " 판매", "");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Program.PrintTextWithHighlights("[", "보유 골드", "]");
            Console.WriteLine(p.Gold + " G");
            p.inven.DisplayInventory();
            Program.Firstlettercolor("0.", " 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>"); string? input = Console.ReadLine();

            if (Int32.TryParse(input, out int temp) && temp <= p.inven.Count())
            {
                if (temp == 0)
                {
                    return;
                }
                temp -= 1;
                if (p.inven.ItemAccess(temp).Name == (p.WeaponSlot != null ? p.WeaponSlot.Name : "No"))
                {
                    p.inven.ItemAccess(temp).Equipped = false;
                    p.WeaponSlot = null;
                }
                if (p.inven.ItemAccess(temp).Name == (p.ArmorSlot != null ? p.ArmorSlot.Name : "No"))
                {
                    p.inven.ItemAccess(temp).Equipped = false;
                    p.ArmorSlot = null;
                }
                for (int i = 0; i < p.inven.Count(); i++)
                {
                    if (p.inven.ItemAccess(temp).Name == shopInven.ItemAccess(i).Name)
                    {
                        shopInven.ItemAccess(i).HaveItem = false;
                        break;
                    }
                }
                p.Gold += (int)(p.inven.ItemAccess(temp).Price * 0.85f);
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
    public string Name { get; set; }
    public JOB job;
    float Atk;
    public float totalAtk { get { return WeaponSlot != null ? WeaponSlot.Atk + Atk : Atk; } }
    float Def;
    public float totalDef { get { return ArmorSlot != null ? ArmorSlot.Def + Def : Def; } }
    public int Gold;
    public float Hp;
    public float M_Hp;
    public bool IsDead => Hp <= 0;
    public int Lv = 1;
    float Exp;
    float M_Exp;
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
    public Player(string name, JOB job)
    {
        Name = name;
        this.job = job;
        Atk = 10 + job.atk;
        Def = 5 + job.def;
        Gold = 1500;
        M_Hp = 100 + job.hp;
        Hp = M_Hp;
        Lv = 1;
        M_Exp = 100;
    }
    public class JOB
    {
        public enum Job
        {
            Warrior, Wizrd, Chef
        }
        public string jobName = "백수";
        public float atk;
        public int def;
        public int hp;
        public JOB(Job job)
        {
            switch (job)
            {
                case Job.Warrior:
                    jobName = "워리어";
                    atk = 5;
                    def = 3;
                    hp = -5;
                    break;
                case Job.Wizrd:
                    jobName = "워리어";
                    atk = -5;
                    def = -2;
                    break;
                case Job.Chef:
                    jobName = "쉐프";
                    def = 5;
                    hp = 10;
                    break;
            }
        }
    }
    public static Player AddPlayer()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("캐릭터 이름을 입력하여 주십시오.");
            string name = Console.ReadLine() ?? "철수";
            Console.WriteLine("직업을 입력하여 주십시오.");
            Console.WriteLine("1.워리어 2.위자드 3.쉐프");
            JOB job;
            switch (Console.ReadLine())
            {
                case "1":
                    job = new JOB(JOB.Job.Warrior);
                    break;
                case "2":
                    job = new JOB(JOB.Job.Wizrd);
                    break;
                case "3":
                    job = new JOB(JOB.Job.Chef);
                    break;
                default:
                    Program.WrongInput();
                    continue;
            }
            return new Player(name, job);
        }
    }
    public void Status()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("상태보기"); // 장착 반영 해야함
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("");
            Console.WriteLine($"이름. {Name}");
            Console.WriteLine($"Lv. {Lv.ToString("00")}");
            Console.WriteLine($"Chad({job.jobName})");
            Console.WriteLine($"공격력:{Atk}  {(WeaponSlot == null ? "" : $"(+{WeaponSlot.Atk})")}");
            Console.WriteLine($"방어력:{Def}  {(ArmorSlot == null ? "" : $"+({ArmorSlot.Def})")}");
            Console.WriteLine($"체력:{Hp} / {M_Hp}");
            Console.WriteLine($"Gold:{Gold}");
            Console.WriteLine("");
            Program.Firstlettercolor("0.", " 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해 주세요.\n>>");
            switch (Console.ReadLine())
            {
                case "0":
                    return;
                default:
                    Program.WrongInput();
                    break;
            }
        }

    }
    public Item? WeaponSlot { get; set; }
    public Item? ArmorSlot { get; set; }
    public void ManageEquippedItems()  //아이템이 여러개 있고 판매를 할때 아이템 갯수가 1>0으로 갈때만 장비가 벗겨지게 개선할 필요가 있음
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n장착 관리");
            inven.DisplayInventory();

            Console.Write("장착 또는 해제할 아이템 번호를 입력하세요 (0. 나가기): ");
            string? userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int itemIndex) && itemIndex >= 1 && itemIndex <= inven.Count())
            {
                Item selectedItem = inven.ItemAccess(itemIndex - 1);
                switch (selectedItem.type)
                {
                    case Item.ItemType.Weapon:
                        if (WeaponSlot == null)
                        {
                            WeaponSlot = selectedItem;
                            selectedItem.Equipped = true;
                        }
                        else if (WeaponSlot.Name == selectedItem.Name)
                        {
                            WeaponSlot = null;
                            selectedItem.Equipped = false;
                        }
                        else
                        {
                            selectedItem.Equipped = true;
                            WeaponSlot.Equipped = false;
                            WeaponSlot = selectedItem;
                        }
                        break;
                    case Item.ItemType.Armor:
                        if (ArmorSlot == null)
                        {
                            ArmorSlot = selectedItem;
                            selectedItem.Equipped = true;
                        }
                        else if (ArmorSlot.Name == selectedItem.Name)
                        {
                            ArmorSlot = null;
                            selectedItem.Equipped = false;
                        }
                        else
                        {
                            selectedItem.Equipped = true;
                            ArmorSlot.Equipped = false;
                            ArmorSlot = selectedItem;
                        }
                        break;
                }
            }
            else if (userInput == "0")
            {
                return;
            }
            else
            {
                Program.WrongInput();
            }
        }
    }

    
}
class Monster
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Hp { get; set; }
    public int Atk { get; set; }
    public bool IsDead => Hp <= 0;

    public static List<Monster> monsters = new List<Monster>();

    public Monster(string name, int level, int hP, int aTK)
    {
        Name = name;
        Level = level;
        Hp = hP;
        Atk = aTK;
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
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(i + 1);
                Console.ResetColor();
            }
            Console.Write($" Lv. {monsters[i].Level} {monsters[i].Name}  HP {(!monsters[i].IsDead ? monsters[i].Hp : "Dead")}");
            Console.WriteLine("");
            Console.ResetColor();
        }
    }
    public static int AttackMonster(int selectNum)
    {
        int randomAtk;
        int monsterAtkResult;
        int monsterAtk = monsters[selectNum - 1].Atk;
        if (monsterAtk % 10 == 0) randomAtk = monsterAtk / 10;
        else randomAtk = (monsterAtk / 10) + 1;
        monsterAtkResult = Program.ran.Next(monsterAtk - randomAtk, monsterAtk + randomAtk + 1);

        return monsterAtkResult;
    }
}
class Battle
{
    Player p;
    Monster m;
    Battle b;
    Shop s;
    float playerHp;
    public Battle(Player p, Shop s)
    {
        this.p = p;
        this.s = s;
    }
    public void BattleDisplay()
    {
        while (true)
        {
            Console.Clear();
            Program.ShowHighlightedText_M("Battle!!");
            Console.WriteLine();
            Monster.DisplayMonster();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("내정보");
            Console.WriteLine($"Lv. {p.Lv} {p.Name} ({p.job.jobName})");
            Console.WriteLine($"HP  {p.Hp} / {p.M_Hp}");
            Console.WriteLine();
            Console.WriteLine("1. 공격");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            string? input = Console.ReadLine();
            if (Int32.TryParse(input, out int temp))
            {
                if (temp == 1)
                {
                    playerHp = p.Hp;
                    BattleAttack();
                }
            }
            else
            {
                Program.WrongInput(); continue;
            }
        }
    }
    public void BattleAttack()
    {
        Monster.AddMonster();
        while (true)
        {
            bool IsClear = true;
            for (int i = 0; i < Monster.monsters.Count; i++)
            {
                IsClear = Monster.monsters[i].IsDead && IsClear;
            }
            Console.Clear();
            Program.ShowHighlightedText_M("Battle!!_공격대상 선택");
            Console.WriteLine();
            Monster.DisplayMonster();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("내정보");
            Console.WriteLine($"Lv. {p.Lv} {p.Name} ({p.job.jobName})");
            Console.WriteLine($"HP  {p.Hp} / {p.M_Hp}");
            Console.WriteLine();
            Console.WriteLine("0. 취소");
            Console.WriteLine("");
            Console.WriteLine("공격할 적을 선택해주세요.");
            Console.Write(">>");

            if (IsClear)
            {
                BattleResult(p.IsDead);
            }
            else
            {
                string? input = Console.ReadLine();
                if (Int32.TryParse(input, out int temp) && temp <= Monster.monsters.Count)
                {
                    temp -= 1;
                    BattleTurn(temp);
                }
                else
                {
                    Program.WrongInput(); continue;
                }
            }
        }
    }
    public void BattleResult(bool isdead)
    {
        Console.Clear();
        Program.ShowHighlightedText_M("Battle!! - Result");
        Console.WriteLine();
        Program.ShowHighlightedText_M(p.IsDead ? "You Lose" : "Victory");
        Console.WriteLine();
        Console.WriteLine(p.IsDead ? "" : $"던전에서 몬스터{Monster.monsters.Count}마리를 잡았습니다.");
        Console.WriteLine();
        Console.WriteLine($"Lv. {p.Lv} {p.Name} ({p.job})");
        Console.WriteLine($"HP  {playerHp} -> {p.Hp}");
        Console.WriteLine();
        Console.WriteLine("0. 다음");
        Console.WriteLine("");
        Console.ReadKey();
        Program.MainManu(p,s,b); 

    }
    public void BattleTurn(int temp)
    {
        if (!p.IsDead && !Monster.monsters[temp].IsDead)
        {
            Console.Clear();
            Program.ShowHighlightedText_M("Battle!!");
            Console.WriteLine();
            Console.WriteLine($"{p.Name} 의 공격!");
            Console.WriteLine($"{Monster.monsters[temp].Name} 을(를) 맞췄습니다. [데미지 : {p.totalAtk}]"); //Damage 계산이 아직 안되서 player.Atk사용
            Monster.monsters[temp].Hp -= (int)p.totalAtk; //p.Atk가 float형식이라 int로 명시적 형변환
            Console.WriteLine();
            Console.WriteLine($"Lv. {Monster.monsters[temp].Level} {Monster.monsters[temp].Name}");
            Console.WriteLine($"HP  {Monster.monsters[temp].Hp + p.totalAtk} - > {(Monster.monsters[temp].IsDead ? "Dead" : Monster.monsters[temp].Hp)}");
            Console.WriteLine();
            Console.WriteLine("0. 다음");
            Console.WriteLine("");
            Console.ReadKey();
            for (int i = 0; i < Monster.monsters.Count; i++)
            {
                if (Monster.monsters[i].IsDead == false)
                {
                    Console.Clear();
                    Program.ShowHighlightedText_M("Battle!!");
                    Console.WriteLine();
                    Console.WriteLine($"{Monster.monsters[i].Name} 의 공격!");
                    Console.WriteLine($"{p.Name} 을(를) 맞췄습니다. [데미지 : {Monster.monsters[i].Atk}]");
                    p.Hp -= Monster.monsters[i].Atk;
                    Console.WriteLine();
                    Console.WriteLine($"Lv. {p.Lv} {p.Name}");
                    Console.WriteLine($"HP  {p.Hp + Monster.monsters[i].Atk} - > {(p.IsDead ? "Dead" : p.Hp)}");
                    Console.WriteLine();
                    Console.WriteLine("0. 다음");
                    Console.WriteLine("");
                    if (p.IsDead == true) { BattleResult(p.IsDead); }
                    Console.ReadKey(); continue;
                }
            }
        }

    }
}