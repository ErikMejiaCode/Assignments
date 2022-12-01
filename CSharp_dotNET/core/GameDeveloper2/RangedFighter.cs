class RangedFighter : Enemy
{
    public int DistanceField;
    public RangedFighter(string n, int ha, int df = 5) : base(n, ha)
    {
        DistanceField = df;
        Attacks = new List<Attack>();
        Attacks.Add(new Attack("Shoot Arrow", 20));
        Attacks.Add(new Attack("Throw Knife", 15));
    }

    public override void showStat()
    {
        base.showStat();
        System.Console.WriteLine($"Distance Field: {DistanceField}");
    }

    public void RangedAttack()
    {
        Random random = new Random();
        Attack RangeAttack = Attacks[random.Next(0, Attacks.Count)];
        if (DistanceField < 10){
            System.Console.WriteLine($"{Name} cannot attack due to the distance being {DistanceField}.");
        } else {
            System.Console.WriteLine($"Character {Name} attacks with {RangeAttack.Name} for {RangeAttack.DamageAmount} damage!");
        }
    }

    public void Dash()
    {
        DistanceField = 20;
        System.Console.WriteLine($"{Name} has used Dash, increasing their distance to {DistanceField}.");
    }

}
