// iterate and print values 
static void PrintList(List<string> MyList)
{
    foreach (string entry in MyList)
    {
        System.Console.WriteLine($"{entry}");
    }
}

PrintList(new List<string>() {"Erik", "Nalle", "Jair"});



//Given a List of integers, calculate and print the sum of the values.
static void SumOfNumbers(List<int> IntList)
{
    int sum = 0;
    for (int i = 0; i < IntList.Count; i++)
    {
        sum += IntList[i];
    }
    System.Console.WriteLine(sum);
}

SumOfNumbers(new List<int>() {1, 2, 5, 15, 20});



//Given a List of integers, find and return the largest value in the List.
static int FindMax(List<int> IntList)
{
    int max = IntList[0];
    for (int i = 1; i < IntList.Count; i++)
    {
        if (IntList[i] > max)
        {
            max = IntList[i];
        }
    }
        return max;
}
    System.Console.WriteLine(FindMax(new List<int>() {1,2,5,15,20}));



//Given a List of integers, return the List with all the values squared. 
//(Hint: use your PrintList method to check that it worked!)
static void PrintIntList(List<int> SquaredIntList)
{
    System.Console.WriteLine("Squared Numbers:");
    foreach (int entry in SquaredIntList)
    {
        System.Console.WriteLine($"{entry}");
    }
}

static List<int> SquareValues(List<int> IntList)
{
    for (int i = 0; i < IntList.Count; i++)
    {
        IntList[i] *= IntList[i];
    }
    return IntList;
}

PrintIntList(new List<int>(SquareValues(new List<int>() {1,2,5,15,20})));



//Given an array of integers, return the array with all values below 0 replaced with 0.
static int[] NonNegatives(int[] IntArray)
{
    for (int i = 0; i < IntArray.Length; i++)
    {
        if (IntArray[i] < 0) 
        {
            IntArray[i] = 0;
        }
    }
    return IntArray;
}
int[] IntArray = { 1, 2, 3, 5, -9, -8, 10, 11 };
NonNegatives(IntArray);

foreach(int entries in IntArray)
{
    System.Console.WriteLine($"{entries}");
}



//Given a dictionary, print the contents of the said dictionary.
Dictionary<string, string> MyDictionary = new Dictionary<string, string>();
MyDictionary.Add("Name", "Sandra");
MyDictionary.Add("Language", "C#");
MyDictionary.Add("Location", "England");
MyDictionary.Add("Found Me", "Hello");

static void PrintDictionary(Dictionary<string, string> MyDictionary)
{
    foreach (KeyValuePair<string, string> entry in MyDictionary)
    {
        System.Console.WriteLine($"{entry.Key} - {entry.Value}");
    }
}

PrintDictionary(MyDictionary);



//Given a search term, return true or false whether the given term is a key in a dictionary.
static bool FindKey(Dictionary<string, string> MyDictionary, string SearchTerm)
{
    if (MyDictionary.ContainsKey(SearchTerm))
    {
        return true;
    }
    else
    {
        return false;
    }
}

System.Console.WriteLine(FindKey(MyDictionary, "Found Me"));
System.Console.WriteLine(FindKey(MyDictionary, "Missing"));



//Given a List of names and a List of integers, create a dictionary where the key is a name from 
//the List of names and the value is a number from the List of numbers. Assume that the two Lists will 
//be of the same length. Don't forget to print your results to make sure it worked.

// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
// 	"Julie": 6,
// 	"Harold": 12,
// 	"James": 7,
// 	"Monica": 10
// } 
List<string> Names = new List<string>() {"Julie", "James", "Monica", "Harold"};
List<int> Numbers = new List<int>() {6, 12, 7, 10};

static Dictionary<string,int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string, int> UserDictionary = new Dictionary<string, int>();
    for (int i = 0; i < Names.Count; i++)
    {
        UserDictionary.Add(Names[i], Numbers[i]);
    }
    return UserDictionary;
}
Dictionary<string, int> UserDictionary = GenerateDictionary(Names, Numbers);
foreach (KeyValuePair<string, int> entries in UserDictionary)
{
    System.Console.WriteLine($"{entries.Key} : {entries.Value}");
}



