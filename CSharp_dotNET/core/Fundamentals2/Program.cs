
// Three basic Arrays 
//Create an array with the integers 0 through 9 inside.
int[] numArray = new int[9];
int[] numArray2 = {1,2,3,4,5,6,7,8,9};
// Create an array with the names "Tim", "Martin", "Nikki", and "Sara".
string[] namesArray = {"Tim", "Martin", "Nikki", "Sarah"};
//Create an array of length 10. Then fill it with alternating true/false values, 
//starting with true. (Tip: do this using logic! Do not hard-code the values in!)
bool[] boolArray = new bool[10];
for (int i = 0; i < boolArray.Length; i+=2){
    boolArray[i] = true;
    System.Console.WriteLine(boolArray[i]);
    System.Console.WriteLine(boolArray[i+1]);
}

//List of flavors
//Create a List of ice cream flavors that holds at least 5 different flavors. (Feel free to add
// more than 5!)
List<string> iceCream = new List<string>();
iceCream.Add("Chocolate");
iceCream.Add("Vanilla");
iceCream.Add("Chocolate Chip");
iceCream.Add("Cookies & Cream");
iceCream.Add("Strawberry");


// Output the length of the List after you added the flavors.
System.Console.WriteLine(iceCream.Count);


// Output the third flavor in the List.
System.Console.WriteLine(iceCream[2]);

// Now remove the third flavor using its index location.
iceCream.RemoveAt(2);

// Output the length of the List again. It should now be one fewer.
System.Console.WriteLine(iceCream.Count);



//User Dictionaries
Dictionary<string, string> newDictionary = new Dictionary<string, string>();
Random random = new Random();
string randomIceCream = iceCream[random.Next(namesArray.Length)];
string randomIceCream1 = iceCream[random.Next(namesArray.Length)];
string randomIceCream2 = iceCream[random.Next(namesArray.Length)];
string randomIceCream3 = iceCream[random.Next(namesArray.Length)];

newDictionary.Add(namesArray[0], randomIceCream);
newDictionary.Add(namesArray[1], randomIceCream1);
newDictionary.Add(namesArray[2], randomIceCream2);
newDictionary.Add(namesArray[3], randomIceCream3);

foreach (KeyValuePair<string, string> entries in newDictionary)
    {
    System.Console.WriteLine($"{entries.Key} - {entries.Value}");
    }
