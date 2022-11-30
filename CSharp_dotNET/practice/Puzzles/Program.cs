//Coin Flip 
static string CoinFlip()
{
    System.Console.WriteLine("============ Coin Flip! ==============");

    Random random = new Random();

    if (random.Next(2) == 0)
    {
        return "Heads";
    }
    else
    {
        return "Tails";
    }
}
System.Console.WriteLine(CoinFlip());



//Dice Roll
static int DiceRoll()
{
    System.Console.WriteLine("============ Dice Roll! ==============");

    Random random = new Random();
    return random.Next(1, 7);
}
System.Console.WriteLine(DiceRoll());

//Dice Roll with variable dice size
static int VariableDiceRoll(int sides)
{
    System.Console.WriteLine("============ Variable Dice Roll! ==============");

    Random random = new Random();
    return random.Next(1, sides + 1);
}
System.Console.WriteLine(VariableDiceRoll(50));



//Stat Roll 
static List<int> StatRoll()
{
    System.Console.WriteLine("============ Stat Roll! ==============");

    List<int> Results = new List<int>();
    for (int i = 0; i < 4; i++)
    {
        Results.Add(DiceRoll());
    }
    return Results;
}
List<int> Res = StatRoll();
// This is a shorthand way to print a List
Console.WriteLine(string.Join(", ", Res));


//Write function to roll any number of times
static List<int> VariableStatRoll(int rolls)
{
    System.Console.WriteLine("============ Variable Stat Roll! ==============");
    List<int> Results = new List<int>();
    for (int i = 0; i < rolls; i++)
    {
        Results.Add(DiceRoll());
    }
    // Extra bonus: print the largest value rolled
    Console.WriteLine($"Largest value: {FindMax(Results)}");
    return Results;
}

List<int> ResMulti = VariableStatRoll(6);
Console.WriteLine(string.Join(", ", ResMulti));


//Print the largest value rolled
static int FindMax(List<int> numbers)
{
    int max = 0;
    foreach (int num in numbers)
    {
        if (num > max)
        {
            max = num;
        }
    }
    return max;
}



// Roll until
// Write a new function that will roll your dice until you land on a certain result. 
//For example, you could tell your code to keep rolling until your 6-sided die rolls the number 2
static string RollUntil(int number)
{
    // Check that the number is within 1 to 6
    if (number < 1 || number > 6)
    {
        return "Invalid number";
    }
    // Track how many rolls we've had
    // It starts at 1 since we begin result with a dice roll
    int count = 1;
    int result = DiceRoll();
    while (result != number)
    {
        result = DiceRoll();
        count++;
    }
    return $"Rolled a {number} after {count} tries";
}

Console.WriteLine(RollUntil(8));
Console.WriteLine(RollUntil(3));