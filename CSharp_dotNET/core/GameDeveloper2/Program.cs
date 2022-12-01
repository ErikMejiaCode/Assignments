Enemy Shadow = new Enemy("Jack Frost");

Attack Freeze = new Attack("Ice Attack", 20);
Attack Fire = new Attack("Fire Attack", 25);
Attack Tackle = new Attack("Body Slam", 20);

Shadow.Attacks.Add(Freeze);
Shadow.Attacks.Add(Fire);
Shadow.Attacks.Add(Tackle);

System.Console.WriteLine("");
System.Console.WriteLine("====================== Enemies ====================");
System.Console.WriteLine("");

Shadow.RandomAttack();
System.Console.WriteLine("----------------------------------------------------");

MeleeFighter Ryu = new MeleeFighter("Ryu", 120);
Ryu.showStat();
Ryu.RandomAttack();
Ryu.Rage();
System.Console.WriteLine("----------------------------------------------------");

RangedFighter Aloy = new RangedFighter("Aloy", 100);
Aloy.showStat();
Aloy.RangedAttack();
Aloy.Dash();
Aloy.showStat();
Aloy.RangedAttack();
System.Console.WriteLine("----------------------------------------------------");

MagicCaster Vivi = new MagicCaster("Vivi");
Vivi.showStat();
Vivi.RandomAttack();
Vivi.Heal(Aloy);
Vivi.Heal(Vivi);
System.Console.WriteLine("");