
Soda Coke = new Soda("Coca Cola", "brown", 38, 140, false);
Coffee Cappuccino = new Coffee("French Vanilla Cappuccino", "light brown", 120, 110, "light", "coffee beans");
Wine Merlot = new Wine("Merlot", "red", 32, 120, "Bordeaux", 1992);

// Create a List of Drinks called ALlBeverages and add all instances to it
List<Drink> AllBeverages = new List<Drink>();
AllBeverages.Add(Coke);
AllBeverages.Add(Cappuccino);
AllBeverages.Add(Merlot);

// Loop through your List of AllBeverages and call the ShowDrink() method for each
foreach(Drink d in AllBeverages)
{
    d.ShowDrink();
}
