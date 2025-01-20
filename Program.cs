abstract class Damage //Abstract class
{
    public int Hand()
    {
        return 10;
    }
    public int Leg()
    {
        return 15;
    }
    public int Head()
    {
        return 5;
    }

    public string PlayerAkey1()
    {
        return "Q";
    }
    public string PlayerAkey2()
    {
        return "W";
    }
    public string PlayerAkey3()
    {
        return "E";
    }
    public int PlayerBkey1()
    {
        return 7;
    }
    public int PlayerBkey2()
    {
        return 8;
    }
    public int PlayerBkey3()
    {
        return 9;
    }
}
class Attack : Damage //  inheritance
{
    public int AttackPlayer(string player, string mode, int health)
    {
        if (player == "PlayerA")
        {
            if (mode == PlayerAkey1() || mode == PlayerAkey1().ToLower())
            {
                health -= Hand(); // abstract class usage
            }
            else if (mode == PlayerAkey2() || mode == PlayerAkey2().ToLower())
            {
                health -= Leg(); // abstract class usage
            }
            else if (mode == PlayerAkey3() || mode == PlayerAkey3().ToLower())
            {
                health -= Head(); // abstract class usage
            }
        }
        else if (player == "PlayerB")
        {
            if (mode.ToString().Contains(PlayerBkey1().ToString()))
            {
                health -= Hand(); // abstract class usage
            }
            else if (mode.ToString().Contains(PlayerBkey2().ToString()))
            {
                health -= Leg(); // abstract class usage
            }
            else if (mode.ToString().Contains(PlayerBkey3().ToString()))
            {
                health -= Head(); // abstract class usage
            }
        }
        return health;

    }
}
class Start : Damage // Inheritance
{

    private string? PlayerA_Name;

    private string? PlayerB_Name;

    public string? playerA_Name //Encapsulation
    {
        get => PlayerA_Name;
        set => PlayerA_Name = value;
    }
    public string? playerB_Name //Encapsulation
    {
        get => PlayerB_Name;
        set => PlayerB_Name = value;
    }
    private bool IsAllDigits(string input) //validation to not allow numbers
    {
        return input.All(char.IsDigit);
    }
    public int HealthA = 100;
    public int HealthB = 100;
    public void PlayerName()
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("Enter Player A's name: ");
        playerA_Name = Console.ReadLine();
        while (string.IsNullOrEmpty(playerA_Name) || IsAllDigits(playerA_Name)) // Allows input untill validation is right.
        {
            if (string.IsNullOrEmpty(playerA_Name))
            {
                Console.WriteLine("Player A name should not be left empty.");
            }
            else
            {
                Console.WriteLine("Player A name should not be all digits.");
            }
            playerA_Name = Console.ReadLine();
        }



        Console.WriteLine("Enter Player B's name: ");
        playerB_Name = Console.ReadLine();
        while (string.IsNullOrEmpty(playerB_Name) || IsAllDigits(playerB_Name)) // Allows input untill validation is right.
        {
            if (string.IsNullOrEmpty(playerB_Name))
            {
                Console.WriteLine("Player B name should not be left empty.");
            }
            else
            {
                Console.WriteLine("Player B name should not be all digits.");
            }
            playerB_Name = Console.ReadLine();
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Fight Begins {PlayerA_Name} vs {PlayerB_Name}");


        while (HealthA > 0 && HealthB > 0)// Attack Logic starts...
        {
            string AttackKey = Console.ReadKey(true).KeyChar.ToString();
            if (AttackKey == PlayerAkey1() || AttackKey == PlayerAkey1().ToLower() || AttackKey == PlayerAkey2() || AttackKey == PlayerAkey2().ToLower() || AttackKey == PlayerAkey3() || AttackKey == PlayerAkey3().ToLower())
            {
                Attack start = new Attack();
                int value = start.AttackPlayer("PlayerA", AttackKey, HealthB);
                HealthB = value;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{playerA_Name} attacked {playerB_Name}. Remaining Health for {playerB_Name}: " + value);
            }
            else if (AttackKey.ToString().Contains(PlayerBkey1().ToString()) || AttackKey.ToString().Contains(PlayerBkey2().ToString()) || AttackKey.ToString().Contains(PlayerBkey3().ToString()))
            {
                Attack start = new Attack();
                int value = start.AttackPlayer("PlayerB", AttackKey, HealthA);
                HealthA = value;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{playerB_Name} attacked {playerA_Name}. Remaining Health for {playerA_Name}: " + value);
            }
        }
        Console.Clear(); // Battle result...
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Green;
        if (HealthA < 0)
        {
            Console.WriteLine($"{playerB_Name} won the battle.");
        }
        else if (HealthB < 0)
        {
            Console.WriteLine($"{playerA_Name} won the battle.");
        }

        string result = ""; //Closing teh console...
        while (result != "close")
        {
            Console.WriteLine("Type 'close' to exit:");
            result = Console.ReadLine()?.ToLower();
        }
    }

}
class Game
{
    static void Main()
    {
        Damage d = new Start();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Welcome to the OOPS Battle war...");
        Console.WriteLine($"\nPlayers A and B will enter their names, and the battle will begin. Attacks can be performed using Hand, Leg, or Head. Player A's keys are {d.PlayerAkey1()}, {d.PlayerAkey2()}, and {d.PlayerAkey3()}, while Player B's keys are {d.PlayerBkey1()}, {d.PlayerBkey2()}, and {d.PlayerBkey3()}.\n \nType \"Start\" to begin the battle.");
        string StartBattle = Console.ReadLine();
        if (StartBattle.Contains("Start") || StartBattle.Contains("start"))
        {
            Start start = new Start();// Starting the battle...
            start.PlayerName();
        }
        else
        {
            Console.WriteLine("Game has been aborted.");
        }
    }
}