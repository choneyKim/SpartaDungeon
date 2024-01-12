using System;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading;
using Txt_Game;

internal class Program
{
    public static Random ran = new Random();
    public static List<Potion> healPotion = new List<Potion>();
    public static List<Potion> manaPotion = new List<Potion>();
    public static List<Potion> hpFood = new List<Potion>();
    public static List<Potion> mpfood = new List<Potion>();
    static void Main(string[] args)
    {
        printStartLogo();
        //nP == 플레이어 객체, sh == 샵 객체
        Player nP = Player.AddPlayer();
        Shop sh = new Shop(nP);
        Battle battle = new Battle(nP, sh);
        healPotion.Add(new Potion("힐 포션", 15, "HP 15 회복"));
        manaPotion.Add(new Potion("마나 포션", 15, "MP 15 회복"));
        hpFood.Add(new Potion("내가 만든 쿠키", 20, "HP 20 회복"));
        mpfood.Add(new Potion("파워에이드", 20, "MP 20 회복"));
        MainManu(nP, sh, battle);

    }
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
            Program.Firstlettercolor("5.", " 회복아이템");
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
                    if (nP.IsDead == true)
                    {
                        Console.WriteLine("체력을 회복하여 주십시오");
                        Console.ReadKey();
                    }
                    else battle.BattleDisplay();
                    break;
                case "5":
                    Recovery(nP);
                    break;
                default:
                    WrongInput();
                    break;
            }
        }
    }

    private static void Recovery(Player P)
    {
        while (true)
        {
            Console.Clear();

            PrintTextWithHighlights("[", "회복", "]");
            Console.WriteLine("");
            Console.WriteLine("현재 HP: "+P.Hp+"/"+P.M_Hp);
            Console.WriteLine("현재 MP: "+P.mp+"/"+P.M_mp);
            Console.WriteLine("");
            PrintTextWithHighlights("["," 사용하기","]");
            Firstlettercolor("1. ","힐 포션: " +"HP를 15 회복시켜줍니다.(남은포션: " + healPotion.Count + ")");
            Firstlettercolor("2. ","마나 포션: " +"MP를 15 회복시켜줍니다.(남은포션: " + manaPotion.Count + ")");
            Firstlettercolor("3. ","내가 만든 쿠키: " + "HP를 20 회복시켜줍니다.(남은포션: " + hpFood.Count + ")");
            Firstlettercolor("4. ","파워에이드: " + "MP를 20 회복시켜줍니다.(남은포션: " + mpfood.Count + ")");

            Firstlettercolor("0.", " 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.\n>>"); string? input = Console.ReadLine();
            bool isnum = int.TryParse(input, out int popo);

            switch (input)
            {
                case "1":
                    if (healPotion.Count < 0)
                    {
                        Console.WriteLine("포션이 부족합니다.");
                        Console.ReadKey();
                        continue;
                    }
                    UsingPotion(P, popo);
                    break;
                case "2":
                    if (manaPotion.Count < 0)
                    {
                        Console.WriteLine("포션이 부족합니다.");
                        Console.ReadKey();
                        continue;
                    }
                    UsingPotion(P, popo);
                    break;
                case "3":
                    if (hpFood.Count < 0)
                    {
                        Console.WriteLine("포션이 부족합니다.");
                        Console.ReadKey();
                        continue;
                    }
                    UsingPotion(P, popo);
                    break;
                case "4":
                    if (mpfood.Count < 0)
                    {
                        Console.WriteLine("포션이 부족합니다.");
                        Console.ReadKey();
                        continue;
                    }
                    UsingPotion(P,popo);
                    break;
                case "0":
                    return;
                default:
                    WrongInput();
                    break;
            }
        }

    }
    
    private static void UsingPotion(Player player, int num)
    {
        if (num == 1)
        {
            if (player.Hp >= player.M_Hp)
            {
                Console.WriteLine("최대체력 입니다.");
                Console.ReadKey();
                return;
            }
            player.Hp += healPotion[0].Point;
            if (player.Hp < player.M_Hp)
            {
                player.Hp += healPotion[0].Point;
                if (player.Hp >= player.M_Hp)
                {
                    player.Hp = player.M_Hp;
                }
                Console.WriteLine("HP 회복을 완료했습니다.");
                Console.WriteLine("체력이" + healPotion[0].Point + "만큼 회복되었습니다.");
                healPotion.RemoveAt(0);
                Console.ReadKey();
            }
            return;
        }
        if (num == 2)
        {
            if (player.mp >= player.M_mp)
            {
                Console.WriteLine("최대마나 입니다.");
                Console.ReadKey();
                return;
            }
            player.mp += manaPotion[0].Point;
            if (player.mp < player.M_mp)
            {
                player.mp += manaPotion[0].Point;
                if (player.mp >= player.M_mp)
                {
                    player.mp = player.M_mp;
                }
                Console.WriteLine("MP 회복을 완료했습니다.");
                Console.WriteLine("마나가" + manaPotion[0].Point + "만큼 회복되었습니다.");
                manaPotion.RemoveAt(0);
                Console.ReadKey();
            }
            return;
        }
        if (num == 3)
        {
            if (player.Hp >= player.M_Hp)
            {
                Console.WriteLine("최대체력 입니다.");
                Console.ReadKey();
                return;
            }
            player.Hp += hpFood[0].Point;
            if (player.Hp < player.M_Hp)
            {
                player.Hp += hpFood[0].Point;
                if (player.Hp >= player.M_Hp)
                {
                    player.Hp = player.M_Hp;
                }
                Console.WriteLine("HP 회복을 완료했습니다.");
                Console.WriteLine("체력이" + hpFood[0].Point + "만큼 회복되었습니다.");
                hpFood.RemoveAt(0);
                Console.ReadKey();
            }
            return;
        }
        if (num == 4)
        {
            if (player.mp >= player.M_mp)
            {
                Console.WriteLine("최대마나 입니다.");
                Console.ReadKey();
                return;
            }
            player.mp += mpfood[0].Point;
            if (player.mp < player.M_mp)
            {
                player.mp += mpfood[0].Point;
                if (player.mp >= player.M_mp)
                {
                    player.mp = player.M_mp;
                }
                Console.WriteLine("MP 회복을 완료했습니다.");
                Console.WriteLine("마나가" + mpfood[0].Point + "만큼 회복되었습니다.");
                mpfood.RemoveAt(0);
                Console.ReadKey();
            }
            return;
        }
    }
    public static void WrongInput()
    {
        Console.Write("잘못 된 입력 입니다");
        Console.ReadKey();
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

}
class Shop
{
    Player p;
    InventoryManager shopInven = new InventoryManager();

    public object name { get; private set; }

    public Shop(Player player)
    {
        p = player;
        InitializeItems();
    }
    //string.RightPad(totalWidth)/LeftPad
    private void InitializeItems()
    {
        //무기
        shopInven.AddItem(new Item("버터 나이프", 100, "빵에 버터를 바르기에 적합한 나이프 입니다", Item.ItemType.Weapon, Atk: 2));
        shopInven.AddItem(new Item("소형 검", 200, "사냥에도 쓸만한 검입니다", Item.ItemType.Weapon, Atk: 5));
        shopInven.AddItem(new Item("청동검", 500, "사용한 흔적이 있는 청동검입니다", Item.ItemType.Weapon, Atk: 7));
        shopInven.AddItem(new Item("철창", 1000, "철로 만들어진 창입니다", Item.ItemType.Weapon, Atk: 10));
        shopInven.AddItem(new Item("철검", 2000, "창보다 빠르게 휘두를 수 있는 검입니다", Item.ItemType.Weapon, Atk: 22));
        shopInven.AddItem(new Item("강철창", 4000, "강철로 만든 강력한 창입니다", Item.ItemType.Weapon, Atk: 50));
        shopInven.AddItem(new Item("백금검", 17000, "백금으로 홀려서 강력한 공격을 가할 수 있습니다", Item.ItemType.Weapon, Atk: 150));
        shopInven.AddItem(new Item("얼음의 지팡이", 35000, "휘두를때 눈보라가 일어나 약 100의 추가 데미지를 줍니다", Item.ItemType.Weapon, Atk: 200));
        //shopInven.AddItem(new Item("흡혈 지팡이", 70000, "공격력 +290", "휘두를때 마다 적의 HP를 200씩 뺏습니다"));

        //갑옷
        shopInven.AddItem(new Item("천 옷", 100, "침대에서 잠자기 좋은 옷입니다", Item.ItemType.Armor, Def: 2));
        shopInven.AddItem(new Item("가죽 옷", 800, "동물의 할퀴기를 막기에 좋은 갑옷입니다", Item.ItemType.Armor, Def: 7));
        shopInven.AddItem(new Item("무쇠 갑옷", 1700, "무쇠로 만들어져 튼튼한 갑옷입니다.", Item.ItemType.Armor, Def: 9));
        shopInven.AddItem(new Item("강철 갑옷", 3300, "강철로 만들어져 방어력이 향상된 갑옷 입니다.", Item.ItemType.Armor, Def: 15));
        shopInven.AddItem(new Item("수정 갑옷", 4500, "신비한 수정으로 만들어진 갑옷 입니다.", Item.ItemType.Armor, Def: 20));
        shopInven.AddItem(new Item("성스러운 갑옷", 10000, "성스러운 기운이 깃든 갑옷 입니다.", Item.ItemType.Armor, Def: 55));
        shopInven.AddItem(new Item("백금 갑옷", 20000, "백금을 자랑하기 위해서 만든 갑옷이지만 의외로 딱딱합니다", Item.ItemType.Armor, Def: 130));

        //shopInven.AddItem(new Item("회복의 갑옷", 36000, "방어력 +150", " 방어를 누르면 한턴당 HP를 200 회복합니다"));
    }
    public static int GetPrintableLength(string str)
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
    public static string PadRightForMixedText(string str, int totlalLength)
    {
        int currentLenghth = GetPrintableLength(str);
        int paddingg = totlalLength - currentLenghth;
        return str.PadRight(str.Length + paddingg);
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
            Program.ShowHighlightedText_D("+++++++++++++++++++++++++++++++++");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Program.ShowHighlightedText_D("+++++++++++++++++++++++++++++++++");
            Console.WriteLine("");
            Program.PrintTextWithHighlights("[ ", "보유 골드", "]");
            Console.WriteLine(p.Gold + " G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < shopInven.Count(); i++)
            {
                Item items = shopInven.ItemAccess(i);
                Console.Write(PadRightForMixedText($"{items.Name} ", 15));
                Console.Write(PadRightForMixedText($"| 가격: {items.Price} G ", 20));
                Console.Write(PadRightForMixedText($"| {(items.type == 0 ? "공격력" : "방어력")} {(items.type == 0 ? $"{items.Atk}" : $"{items.Def}")}", 15));
                Console.WriteLine(PadRightForMixedText($"| {items.Description}", 30));

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
    public int mp;
    public int M_mp;
    public bool IsDead => Hp <= 0;
    public int Lv = 1;
    public float Exp;
    float M_Exp;
    public void CheckLvUp(int ex)
    {
        Exp += ex;
        if (Exp >= M_Exp)
        {
            Lv++;
            Atk += 0.5f;
            Def++;
            M_Hp += 10;
            Exp = 0;
            M_Exp *= 1.5f;
            M_mp += 10;
        }
    }
    public Player(string name, JOB job)
    {
        Name = name;
        this.job = job;
        Atk = 1000 + job.atk;
        Def = 5 + job.def;
        Gold = 1500;
        M_Hp = 100 + job.hp;
        Hp = M_Hp;
        Lv = 1;
        M_Exp = 20;
        M_mp = 50 + job.mp;
        mp = M_mp;
    }

   // 스킬 계수 정리
   //return 뒤의 양수는 모두 데미지 관련
    public float FirstSkill()
    {
        switch (job.joben)
        {
            case JOB.Job.Warrior:
                if (mp < 10)
                {
                    return -1; // -1 은 마나가 부족시 
                }
                mp -= 10;
                return 15;
            case JOB.Job.Wizrd:
                if (mp < 10)
                {
                    return -1;// -1은 마나가 부족시 
                }
                Program.ran.Next(1, 5);
                if (Program.ran.Next(1, 5) < 3)
                {
                    mp -= 10;
                }
                return totalAtk + totalAtk * 0.2f;
            case JOB.Job.Chef:
                if (mp < 10)
                {
                    return -1;
                }
                mp -= 10;
                Hp += 5;
                if (Hp > M_Hp)
                {
                    Hp = M_Hp;
                }
                return Def;
            default:
                return -2; // -2는 직업을 못불러 왔을때 
        }
    }
    public float SecondSkill()
    {
        switch (job.joben)
        {
            case JOB.Job.Warrior:
                if (mp < 30)
                {
                    return -1;
                }
                mp -= 30;
                return Program.ran.Next(10, 46);
            case JOB.Job.Wizrd:
                if (mp < 30)
                {
                    return -1;
                }
                if (WeaponSlot != null)
                {
                    WeaponSlot.Equipped = false;
                }
                if (ArmorSlot != null)
                {
                    ArmorSlot.Equipped = false;
                }
                WeaponSlot = null;
                ArmorSlot = null;
                return 40;
            case JOB.Job.Chef:
                if (mp < 10)
                {
                    return -1;
                }
                mp -= 10;
                return totalAtk + Def;
            default:
                return -2;
        }
    }
    public float ThirdSkill()
    {
        switch (job.joben)
        {
            case JOB.Job.Warrior:
                if (mp < 30)
                {
                    return -1;
                }
                mp -= 30;
                if (WeaponSlot == null)
                {
                    return 10;//데미지 무기공격력 4배|| 방어구 장착 안할시 기본데미지 10
                }
                else
                {
                    return WeaponSlot.Atk * 4;
                }
            case JOB.Job.Wizrd:
                if (mp < M_mp / 2)
                {
                    return -1;
                }
                int temp = mp;
                mp -= M_mp / 2;
                return temp * 2;
            case JOB.Job.Chef:
                if (mp < 30)
                {
                    return -1;
                }
                mp -= 30;
                if (ArmorSlot == null)
                {
                    return 10; //데미지 방어력 *4 || 방어구 장착 안할시 기본데미지 10
                }
                else
                {
                    return ArmorSlot.Def * 4;
                }
            default:
                return -2;
        }
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
        public int mp;
        public Job joben;
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
                    jobName = "위자드";
                    atk = -5;
                    def = -2;
                    mp = 20;
                    break;
                case Job.Chef:
                    jobName = "쉐프";
                    def = 5;
                    hp = 10;
                    break;
            }
            joben = job;
        }
    }
    public static Player AddPlayer()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("캐릭터 이름을 입력하여 주십시오.");
            string name = Console.ReadLine() ?? "철수";
            w:
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
                    Console.Clear();
                    goto w;
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
            Console.WriteLine($"Exp:{Exp} / {M_Exp}");
            Console.WriteLine($"공격력:{Atk}  {(WeaponSlot == null ? "" : $"(+{WeaponSlot.Atk})")}");
            Console.WriteLine($"방어력:{Def}  {(ArmorSlot == null ? "" : $"+({ArmorSlot.Def})")}");
            Console.WriteLine($"체력:{Hp} / {M_Hp}");
            Console.WriteLine($"마나:{mp} / {M_mp}");
            Console.WriteLine($"Gold:{Gold} G");
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


    public int PlayerDamage(int monArmor)
    {
        int randomAtk;
        int playerAtkResult;
        int playerAtk = (int)totalAtk;
        if (playerAtk % 10 == 0) randomAtk = playerAtk / 10;
        else randomAtk = (playerAtk / 10) + 1;
        playerAtkResult = Program.ran.Next(playerAtk - randomAtk, playerAtk + randomAtk + 1);

        int Damage = (playerAtkResult - monArmor > 0 ? playerAtkResult - monArmor : 0);
        return Damage;
    }
}
class Monster
{
    public string Name { get; set; }
    public int Level { get; set; }
    public float Hp { get; set; }
    public int M_Hp { get; set; }
    public float Atk { get; set; }
    public int Def { get; set; }
    public bool IsDead => Hp <= 0;
    public List<Item> dropTable = new List<Item>();
    int dropLv;// 1 = 10%  10 = 100%

    public static List<Monster> monsters = new List<Monster>();

    public Monster(string name, int level, int hP,int m_hp, int aTK, int def, int dLv = 0, params Item[] drop)
    {
        Name = name;
        Level = level;
        Hp = hP;
        M_Hp = m_hp;
        Atk = aTK;
        Def = def;
        dropLv = dLv;
        foreach (var item in drop)
        {
            dropTable.Add(item);
        }
    }
    public static void AddMonster(Battle stage)
    {
        int dif = stage.stage; 
        for (int i = 0; i < Program.ran.Next(1, 5); i++)
        {

            switch (Program.ran.Next(1, 4))
            {
                case 1:
                    {
                        monsters.Add(new Monster("미니언", 1 + dif, 13 + dif * 2, 13 + dif * 2, 19 + dif, 6 + dif, 2, new Item("나무 검", 100, "훈련용으로 사용되는 물건이다", Item.ItemType.Weapon, Atk: 1)));
                        break;
                    }
                case 2:
                    {
                        monsters.Add(new Monster("공허충", 2 + dif, 8 + dif * 2, 8 + dif * 2, 17+ dif, 4 + dif));
                        break;
                    }
                case 3:
                    {
                        monsters.Add(new Monster("대포미니언", 4 + dif, 23 + dif * 2, 23 + dif * 2, 15+ dif, 12+ dif));
                        break;
                    }
            }
        }
    }
    public void GetReward(Player p, ref int gold, ref int exp)
    {
        p.CheckLvUp(Level);
        exp += Level;
        p.Gold += Level * 10;
        gold += Level * 10;
        if (Program.ran.Next(1, 11) <= dropLv)
        {
            Item t = dropTable[Program.ran.Next(0, dropTable.Count - 1)];
            Console.WriteLine(t.Name + " 을 획득했습니다.");
            p.inven.AddItem(t);
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
    public static int MonsterDamage(int selectNum, int playerArmor)
    {
        int randomAtk;
        int monsterAtkResult;
        int monsterAtk = (int)monsters[selectNum].Atk;
        if (monsterAtk % 10 == 0) randomAtk = monsterAtk / 10;
        else randomAtk = (monsterAtk / 10) + 1;
        monsterAtkResult = Program.ran.Next(monsterAtk - randomAtk, monsterAtk + randomAtk + 1);

        int Damage = (monsterAtkResult - playerArmor > 0 ? monsterAtkResult - playerArmor : 0);
        return Damage;
    }
}
class Battle
{
    Player p;
    //Monster m;
    //Battle b;
    Shop s;
    float playerHp;
    public int stage = 1;
    float skillDmg;
    bool useSkill = false;
    int skillSelect = 0;
    public Battle(Player p, Shop s)
    {
        this.p = p;
        this.s = s;
    }
    public void BattleDisplay()
    {
        Monster.monsters.RemoveAll(x => x.IsDead == true || x.IsDead == false);
        Monster.AddMonster(this);
        while (true)
        {
            Console.Clear();
            Program.ShowHighlightedText_Y($"Battle!! - Stage {stage}");
            Console.WriteLine();
            Monster.DisplayMonster();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("내정보");
            Console.WriteLine($"Lv. {p.Lv} {p.Name} ({p.job.jobName})");
            Console.WriteLine($"HP  {p.Hp} / {p.M_Hp}");
            Console.WriteLine($"Mp  {p.mp} / {p.M_mp}");
            Console.WriteLine();
            Console.WriteLine("1. 공격");
            Console.WriteLine("2. 스킬");
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
                else if (temp == 2)
                {

                    if (useSkill == true)
                    {
                        Console.WriteLine("이미 스킬이 선택되었습니다.");
                        Console.ReadKey();
                    }
                    else
                    {
                        useSkill = true;
                        skillDmg = SkillChoice();
                        if (useSkill == true) BattleAttack();
                    }

                }
                else Program.WrongInput(); continue;
            }
            else
            {
                Program.WrongInput(); continue;
            }

        }
    }
    public void BattleAttack()
    {
        while (true)
        {
            bool IsClear = true;
            Console.Clear();
            Program.ShowHighlightedText_Y($"Battle!! - Stage {stage} _ {(useSkill == true ? "스킬" : "공격")}대상 선택");
            Console.WriteLine();
            Monster.DisplayMonster();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("내정보");
            Console.WriteLine($"Lv. {p.Lv} {p.Name} ({p.job.jobName})");
            Console.WriteLine($"HP  {p.Hp} / {p.M_Hp}");
            Console.WriteLine($"Mp  {p.mp} / {p.M_mp}");
            Console.WriteLine();
            Console.WriteLine("0. 취소");
            Console.WriteLine("");
            Console.WriteLine($"{(useSkill == true ? "스킬을 사용할" : "공격할")} 적을 선택해주세요.");
            Console.Write(">>");


            string? input = Console.ReadLine();
            if (Int32.TryParse(input, out int temp) && temp <= Monster.monsters.Count)
            {
                if (temp == 0)
                {
                    return;
                }
                else
                {
                    temp -= 1;
                    BattleTurn(temp);
                    for (int i = 0; i < Monster.monsters.Count; i++)
                    {
                        IsClear = Monster.monsters[i].IsDead && IsClear;
                    }
                    if (IsClear)
                    {
                        BattleResult(p.IsDead);
                        return;
                    }
                    else return;
                }
            }
            else
            {
                Program.WrongInput(); continue;
            }

        }
    }
    public void BattleResult(bool isdead)
    {
        int getGold = 0;
        int getExp = 0;
        Console.Clear();
        Program.ShowHighlightedText_Y($"Stage {stage} - Result ");
        Console.WriteLine();
        Program.ShowHighlightedText_Y(p.IsDead ? "You Lose" : "Victory");
        Console.WriteLine();
        Console.WriteLine(p.IsDead ? "" : $"던전에서 몬스터{Monster.monsters.Count}마리를 잡았습니다.");
        Console.WriteLine();
        Console.WriteLine($"Lv. {p.Lv} {p.Name} ({p.job.jobName})");
        Console.WriteLine($"HP  {playerHp} -> {p.Hp}");

        //사망과 부활 공식

        if (isdead)
        {
            Console.WriteLine("몬스터에게 잡아먹혔습니다.");
            Console.WriteLine("경험치가 10% 감소합니다.");
            getExp = (int)(p.Exp* 0.1f * -1);
            p.Exp += getExp;
            Console.WriteLine($"현재 경험치: {p.Exp }") ;
            Console.WriteLine("완전 회복 상태로 부활합니다.") ;
            p.Hp = p.M_Hp;  
        }

        else
        {
            Console.WriteLine("");
            Console.WriteLine("획득 보상");
            for (int i = 0; i < Monster.monsters.Count; i++)
            {
                Monster.monsters[i].GetReward(p, ref getGold, ref getExp);
            }
            Console.WriteLine("Gold: " + getGold);
            Console.WriteLine("Exp " + getExp);
            Console.WriteLine("");
            p.mp += 10;
            if (p.mp > p.M_mp)
            {
                p.mp = p.M_mp;
            }
        }
        Console.WriteLine();
        Console.WriteLine("0. 다음");
        Console.WriteLine("");
        if (p.IsDead == false) stage++;
        Console.ReadKey();
        Program.MainManu(p, s, this);

    }
    public void BattleTurn(int temp)
    {
        if (!p.IsDead && !Monster.monsters[temp].IsDead)
        {
            int random = Program.ran.Next(1, 101);
            int damage_sub = 0;
            if (random <= 15) { damage_sub = 160; }
            else if (random > 85) { damage_sub = 0; }
            else { damage_sub = 100; }
            int pDamage = 0;
            if (useSkill)
            {
                pDamage = (int)skillDmg*(damage_sub)/100;
            }
            else pDamage = p.PlayerDamage(Monster.monsters[temp].Def)*(damage_sub)/100;
            Console.Clear();
            Program.ShowHighlightedText_Y("Battle!!");
            Console.WriteLine();
            Console.WriteLine($"{p.Name} 의 공격!");

            
            //스킬 사용시

            if (useSkill)
            {
                switch (p.job.joben)
                {
                    case Player.JOB.Job.Warrior:
                        switch (skillSelect)
                        {
                            case 1:
                                Program.PrintTextWithHighlights("플레이어가", "머리치기", $"를 시전합니다.  " +
                                    $"[데미지 : {(random <= 15 ? pDamage + " (치명타)" : (random > 85 ? pDamage + " (회피)" : pDamage))}]");
                                break;
                            case 2:
                                Program.PrintTextWithHighlights("플레이어가", "운칠기삼", $"을 시전합니다.  " +
                                    $"[데미지 : {(random <= 15 ? pDamage + " (치명타)" : (random > 85 ? pDamage + " (회피)" : pDamage))}]");
                                break;
                            case 3:
                                Program.PrintTextWithHighlights("플레이어가", "웨폰스페셜리스트", $"를 시전합니다.  " +
                                    $"[데미지 : {(random <= 15 ? pDamage + " (치명타)" : (random > 85 ? pDamage + " (회피)" : pDamage))}]");
                                break;

                        }
                        break;
                    case Player.JOB.Job.Wizrd:
                        switch (skillSelect)
                        {
                            case 1:
                                Program.PrintTextWithHighlights("플레이어가", "마나순환", $"을 시전합니다.  " +
                                    $"[데미지 : {(random <= 15 ? pDamage + " (치명타)" : (random > 85 ? pDamage + " (회피)" : pDamage))}]");
                                break;
                            case 2:
                                Program.PrintTextWithHighlights("플레이어가", "발버둥", $"을 시전합니다.  " +
                                    $"[데미지 : {(random <= 15 ? pDamage + " (치명타)" : (random > 85 ? pDamage + " (회피)" : pDamage))}]");
                                break;
                            case 3:
                                Program.PrintTextWithHighlights("플레이어가", "마나공격", $"을 시전합니다.  " +
                                    $"[데미지 : {(random <= 15 ? pDamage + " (치명타)" : (random > 85 ? pDamage + " (회피)" : pDamage))}]");
                                break;

                        }
                        break;

                    case Player.JOB.Job.Chef:
                        switch (skillSelect)
                        {
                            case 1:
                                Program.PrintTextWithHighlights("플레이어가", "체력보충제", $"를 시전합니다.  " +
                                    $"[데미지 : {(random <= 15 ? pDamage + " (치명타)" : (random > 85 ? pDamage + " (회피)" : pDamage))}]");
                                break;
                            case 2:
                                Program.PrintTextWithHighlights("플레이어가", "공방일체", $"를 시전합니다.  " +
                                    $"[데미지 : {(random <= 15 ? pDamage + " (치명타)" : (random > 85 ? pDamage + " (회피)" : pDamage))}]");
                                break;
                            case 3:
                                Program.PrintTextWithHighlights("플레이어가", "아머 마스터", $"를 시전합니다.  " +
                                    $"[데미지 : {(random <= 15 ? pDamage + " (치명타)" : (random > 85 ? pDamage + " (회피)" : pDamage))}]");
                                break;

                        }
                        break;
                }
            }
            else Console.WriteLine($"{Monster.monsters[temp].Name} 을(를) 맞췄습니다. " +
                $"[데미지 : {(random <= 15 ? pDamage+" (치명타)" : (random > 85 ? pDamage+ " (회피)" : pDamage))}]");
            Console.WriteLine();
            Monster.monsters[temp].Hp -= pDamage;
            Console.WriteLine($"Lv. {Monster.monsters[temp].Level} {Monster.monsters[temp].Name}");
            Console.WriteLine($"HP  {Monster.monsters[temp].Hp+pDamage} - > {(Monster.monsters[temp].IsDead ? "Dead" : Monster.monsters[temp].Hp)}");
            Console.WriteLine();
            Console.WriteLine("0. 다음");
            useSkill = false;
            Console.WriteLine("");
            Console.ReadKey();
            for (int i = 0; i < Monster.monsters.Count; i++)
            {
                if (Monster.monsters[i].IsDead == false)
                {
                    int mDamage = Monster.MonsterDamage(i, (int)p.totalDef);
                    Console.Clear();
                    Program.ShowHighlightedText_Y("Battle!!");
                    Console.WriteLine();
                    Console.WriteLine($"{Monster.monsters[i].Name} 의 공격!");
                    Console.WriteLine($"{p.Name} 을(를) 맞췄습니다. [데미지 : {mDamage}]");
                    if (p.Hp - mDamage < 0)
                    {
                        p.Hp = 0;
                    }
                    else p.Hp -= mDamage;
                    Console.WriteLine();
                    Console.WriteLine($"Lv. {p.Lv} {p.Name}");
                    Console.WriteLine($"HP  {p.Hp + mDamage} - > {(p.IsDead ? "Dead" : p.Hp)}");
                    Console.WriteLine();
                    Console.WriteLine("0. 다음");
                    Console.WriteLine("");
                    if (p.IsDead == true) { BattleResult(p.IsDead); }
                    Console.ReadKey(); continue;
                }
            }
        }
    }
    
   //skill 선택
    public float SkillChoice()
    {
        float temp = 0;
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
            Console.WriteLine($"Mp  {p.mp} / {p.M_mp}");
            Console.WriteLine();
            switch (p.job.joben)
            {
                case Player.JOB.Job.Warrior:
                    Console.WriteLine("1.머리치기 - Mp 10");
                    Console.WriteLine("  심플하게 15의 데미지를 준다.");
                    Console.WriteLine("");
                    Console.WriteLine("2.운칠기삼 - Mp 30");
                    Console.WriteLine("  10부터 45의 랜덤한 데미지");
                    Console.WriteLine("");
                    Console.WriteLine("3.웨펀스페셜리스트 - Mp 30");
                    Console.WriteLine("  장비한 무기의 4배 데미지 (장비미착용 데미지:10)");
                    break;
                case Player.JOB.Job.Wizrd:
                    Console.WriteLine("1.마나순환 -Mp 10");
                    Console.WriteLine("  1.2배의 데미지 운이 좋으면 마나를 사용하지 않는다");
                    Console.WriteLine("");
                    Console.WriteLine("2.발버둥 -Mp 30");
                    Console.WriteLine("  데미지 40을 주지만 장비가 벗겨진다");
                    Console.WriteLine("");
                    Console.WriteLine($"3.마나공격 -Mp {p.M_mp / 2}");
                    Console.WriteLine("  mp최대치의 절반을 소모해 현재 mp의 두배 데미지");
                    break;
                case Player.JOB.Job.Chef:
                    Console.WriteLine("1.체력보충제 - Mp 10");
                    Console.WriteLine("  체력을 소량 회복하고 방어력에 비례한 데미지를 준다");
                    Console.WriteLine("");
                    Console.WriteLine("2.공방일체 -Mp 15 ");
                    Console.WriteLine("  토탈공격력에 방어력만큼 추가한 데미지를 준다");
                    Console.WriteLine("");
                    Console.WriteLine("3.아머 마스터 -Mp 30");
                    Console.WriteLine("  장비한 방어구의 4배 데미지 (장비미착용 데미지:10)");
                    break;
            }
            Console.WriteLine("");
            Console.WriteLine("0. 뒤로");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            string? input = Console.ReadLine();
            bool isNum = int.TryParse(input, out skillSelect);
            switch (input)
            {
                case "1":
                    temp = p.FirstSkill();
                    break;
                case "2":
                    temp = p.SecondSkill();
                    break;
                case "3":
                    temp = p.ThirdSkill();
                    break;
                case "0":
                    useSkill = false;
                    return -5; // 임의 -5 값 -> 이전 화면 돌아가기
                default:
                    Program.WrongInput();
                    continue;
            }
            if (temp == -1) // -1 마나가 부족할 때 
            {
                Console.WriteLine("마나가 부족합니다.");
                Console.ReadKey();
            }
            else
            {
                return temp;
            }
        }
    }
}