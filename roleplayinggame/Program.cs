Player P1 = new Player("Ritari");
int p1HP = P1.HP;

class Player : Character
{
    public int HP { get; private set; }
    public int dmg { get; private set; }
    Random random = new Random();
    public Player(string name) : base(name)
    {
        HP = 10;
        dmg = random.Next(1, 7);
    }

}

class Enemy : Character
{
    public int HP { get; private set; }
    public int dmg { get; private set; }
    Random random = new Random();
    public Enemy(string name) : base(name)
    {
        HP = 8;
        dmg = random.Next(1, 5);
    }
}
class Character
{
    private string _name;
    public Character(string name)
    {
        _name = name;
    }
    private int _dmg;
    public Character(int dmg)
    {
        _dmg = dmg;
    }
    
}

class Game
{
    static void Main(string[] args)
    {
        Player player = new Player("Ritari");
        Shop shop = new Shop();

        while (true)
        {
            Console.WriteLine("1. Lähde mettään");
            Console.WriteLine("2. Lähde kylille");
            int pick = Convert.ToInt32(Console.ReadKey());
            
            if (pick == 1)
            {
                Enemy enemy = new Enemy("Örkki");
                Battle(player, enemy);
            }
            else if (pick == 2)
            {
                shop.VisitShop(player);
            }
        }
    }

    static void Battle(Player player, Enemy enemy)
    {
        while (player.IsAlive() && enemy.IsAlive())
        {
            player.Attack(enemy);
            if (enemy.IsAlive())
            {
                enemy.Attack(player);
            }
        }

        if (player.IsAlive())
        {
            Console.WriteLine($"You defeated {enemy.Name}!");
            player.Gold += 10;
        }
        else
        {
            Console.WriteLine("You were defeated...");
        }
    }
}
