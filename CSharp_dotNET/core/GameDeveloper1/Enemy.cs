public class Enemy
{
    public string Name;
    private int HealthAmount;
    public int _HealthAmount {get {return HealthAmount;}}

    public List<Attack> Attacks;


    public Enemy(string n, int ha = 100)
    {
        Name = n;
        HealthAmount = ha;
        Attacks = new List<Attack>();
    }

    public void RandomAttack()
    {
        Random random = new Random();
        int RandomAttack = random.Next(0, Attacks.Count);
        System.Console.WriteLine($"Character {Name} attacks with {Attacks[RandomAttack].Name}!");
    }
}