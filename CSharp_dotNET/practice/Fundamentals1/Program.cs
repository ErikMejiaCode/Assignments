// Create a loop that prints all values from 1-255
for(int i = 1; i <= 255; i++) {
    Console.WriteLine(i);
}


//Create a new loop that generates 5 random numbers between 10 and 20 and print out the sum of these values.
Random randomNumber = new Random();
int sum = 0;
int oneRandomNumber = 0;
for (int i = 1; i <= 5; i++) {
    oneRandomNumber = randomNumber.Next(10,21);
    Console.WriteLine(oneRandomNumber);
    sum += oneRandomNumber;
}
Console.WriteLine($"The sum of the random numbers generated is {sum}");


//Create a new loop that prints all values from 1 to 100 that are divisible by 3 OR 5, but NOT both.
for (int i = 1; i <= 100; i++) {
    if (i % 3 == 0 && i % 5 == 0){
        continue;
    }
    if (i % 3 == 0 || i % 5 == 0) {
        Console.WriteLine(i);
    }
}


// Modify the previous loop to print 'Fizz' for multiples of 3 and 'Buzz' for multiples of 5
for(int i = 1; i < 101; i++)
{
    if(i % 3 == 0 && i % 5 == 0)
    {
        continue;
    }
    if(i % 3 == 0)
    {
        Console.WriteLine($"{i}, Fizz");
    }
    if(i % 5 == 0)
    {
        Console.WriteLine($"{i}, Buzz");
    }
}


// Modify the previous loop once more to now also print 'FizzBuzz' for numbers that are multiples of both 3 and 5
for(int i = 1; i < 101; i++)
{
    if(i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine($"{i}, FizzBuzz");
    }
    if(i % 3 == 0)
    {
        Console.WriteLine($"{i}, Fizz");
    }
    if(i % 5 == 0)
    {
        Console.WriteLine($"{i}, Buzz");
    }
}

