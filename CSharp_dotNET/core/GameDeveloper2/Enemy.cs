public class Enemy
{
    public string Name;
    public int HealthAmount;
    public int _HealthAmount {get {return HealthAmount;}}

    public List<Attack> Attacks;


    public Enemy(string n, int ha = 100)
    {
        Name = n;
        HealthAmount = ha;
        Attacks = new List<Attack>();
    }

    public virtual void showStat()
    {
        System.Console.WriteLine($"Name: {Name}");
        System.Console.WriteLine($"Health: {HealthAmount}");
    }

    public virtual void RandomAttack()
    {
        Random random = new Random();
        int RandomAttack = random.Next(0, Attacks.Count);
        System.Console.WriteLine($"Character {Name} attacks with {Attacks[RandomAttack].Name} for {Attacks[RandomAttack].DamageAmount} damage!");
    }
}