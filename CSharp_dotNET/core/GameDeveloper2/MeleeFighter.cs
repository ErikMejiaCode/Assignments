class MeleeFighter : Enemy
{
    public MeleeFighter(string n, int ha = 120) : base(n, ha)
{   
    Attacks = new List<Attack>();
    Attacks.Add(new Attack("Punch", 20));
    Attacks.Add(new Attack("Kick", 15));
    Attacks.Add(new Attack("Tackle", 25));
}

    public override void showStat()
    {
        base.showStat();
    }

    public override void RandomAttack()
    {
        base.RandomAttack();
    }

    public void Rage()
    {
        Random random = new Random();
        Attack RageAttack = Attacks[random.Next(0, Attacks.Count)];
        RageAttack.DamageAmount = RageAttack.DamageAmount + 10;
        System.Console.WriteLine($"{Name} has attacked with {RageAttack.Name} for {RageAttack.DamageAmount} damage");
    }
}