class Bicycle : Vehicle, INeedFuel
{
    public string FuelType {get;set;}
    public int FuelTotal {get;set;}
    public Bicycle(string Name, int NumPassengers, string Color, bool HasEngine, int TopSpeed) : base(Name, NumPassengers, Color, HasEngine, TopSpeed)
    {
        HasEngine = false;
        FuelType = "Strong Legs";
        FuelTotal = 10;
    }

    public void GiveFuel(int Amount)
    {
        FuelTotal += Amount;
        System.Console.WriteLine($"Fuel has been added, new Fuel Total is {FuelTotal}");
    }
}