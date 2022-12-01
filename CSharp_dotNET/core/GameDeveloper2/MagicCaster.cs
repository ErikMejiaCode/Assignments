class MagicCaster : Enemy
{
    public MagicCaster(string n, int ha = 80) : base(n, ha)
    {
        Attacks = new List<Attack>();
        Attacks.Add(new Attack("Fireball", 25));
        Attacks.Add(new Attack("Shield", 0));
        Attacks.Add(new Attack("Staff Strike", 15));
    }

    public override void showStat()
    {
        base.showStat();
    }

    public override void RandomAttack()
    {
        Random random = new Random();
        int RandomAttack = random.Next(0, Attacks.Count);
        if(Attacks[RandomAttack].Name == "Shield"){
            System.Console.WriteLine($"Character {Name} defends with {Attacks[RandomAttack].Name} for {Attacks[RandomAttack].DamageAmount} damage!");
        } else {
            System.Console.WriteLine($"Character {Name} attacks with {Attacks[RandomAttack].Name} for {Attacks[RandomAttack].DamageAmount} damage!");
        }
    }

    public void Heal(Enemy target)
    {
        target.HealthAmount += 40;
        if (target.Name == "Vivi"){
            System.Console.WriteLine($"Magic Caster {Name} restores their own health using Heal, total health is now {target.HealthAmount}.");
        }else {
            System.Console.WriteLine($"Magic Caster {Name} uses Heal on {target.Name}, total health is now {target.HealthAmount}.");
        }
    }
}