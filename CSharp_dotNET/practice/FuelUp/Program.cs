// Create 4 vehicles using each constructor at least once
Car car = new Car("Tesla Model 3", 5, "Red", false, 180);
Bicycle bicycle = new Bicycle("Schwinn", 1, "Silver", false, 30);
Horse horse = new Horse("Strong", 2, "Brown", false, 20);

// Put all the vehicles created into a List
// List<Vehicle> AllVehicles = new List<Vehicle>();
// AllVehicles.Add(car);
// AllVehicles.Add(bicycle);
// AllVehicles.Add(horse);
// AllVehicles.Add(scooter);

// Loop through the List and have each vehicle run its ShowInfo() method
// foreach (Vehicle items in AllVehicles)
// {
//     items.ShowInfo();
// }

// Make one of the vehicles travel 100 miles
// car.Travel(100);
// scooter.Travel(10);

// Print the information of the vehicle to verify the distance traveled went up
// car.ShowInfo();
// scooter.ShowInfo();

Car Tesla = new Car("Marvel", 5, "Red", false, 180);
Horse Bronco = new Horse("Flash", 2, "Brown", false, 40);
Bicycle OffRoad = new Bicycle("Off Road", 1, "Red", false, 20);

List<Vehicle> AllVehicles = new List<Vehicle>();
AllVehicles.Add(car);
AllVehicles.Add(horse);
AllVehicles.Add(bicycle);

List<INeedFuel> NeedsFuel = new List<INeedFuel>();

foreach(Vehicle vehicle in AllVehicles)
{
    if (vehicle is INeedFuel)
    {
        NeedsFuel.Add((INeedFuel)vehicle);
    }
}


foreach(INeedFuel i in NeedsFuel)
{
    i.GiveFuel(10);
}


