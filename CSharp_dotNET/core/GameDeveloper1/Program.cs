Enemy Shadow = new Enemy("Jack Frost");

Attack Freeze = new Attack("Ice Attack", 20);
Attack Fire = new Attack("Fire Attack", 25);
Attack Tackle = new Attack("Body Slam", 20);

Shadow.Attacks.Add(Freeze);
Shadow.Attacks.Add(Fire);
Shadow.Attacks.Add(Tackle);

Shadow.RandomAttack();