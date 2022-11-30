// Create 4 vehicles using each constructor at least once
Vehicle car = new Vehicle("Tesla Model 3", "Red");
Vehicle bicycle = new Vehicle("Schwinn", 1, "Silver", false, 30);
Vehicle horse = new Vehicle("Strong", 2, "Brown", false, 20);
Vehicle scooter = new Vehicle("Scooter", 1, "Black", true, 15);

// Put all the vehicles created into a List
List<Vehicle> AllVehicles = new List<Vehicle>();
AllVehicles.Add(car);
AllVehicles.Add(bicycle);
AllVehicles.Add(horse);
AllVehicles.Add(scooter);

// Loop through the List and have each vehicle run its ShowInfo() method
foreach(Vehicle items in AllVehicles)
{
    items.ShowInfo();
}


// Make one of the vehicles travel 100 miles
car.Travel(100);
scooter.Travel(10);

// Print the information of the vehicle to verify the distance traveled went up
car.ShowInfo();
scooter.ShowInfo();

// Bonus: it is best to make DistanceTraveled be private so it can only be edited using the 
//Travel method, which prevents unwanted changes.