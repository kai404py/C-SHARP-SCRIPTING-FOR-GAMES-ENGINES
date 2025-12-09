// See https://aka.ms/new-console-template for more information

bool loop = true;

bool IsPrime(int number)
{
    if (number <= 1) return false;
    if (number == 2) return true;
    if (number % 2 == 0) return false;

    var boundary = (int)Math.Floor(Math.Sqrt(number));

    for (int i = 3; i <= boundary; i += 2)
        if (number % i == 0)
            return false;

    return true;
}

while (loop)
{
    Console.Write("Do you want to see some numbers? ");
    string? input = Console.ReadLine();

    if (input == null)
    {
        Console.WriteLine("Come on please");
    }
    else if (input.ToLower() == "yes")
    {
        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine(i);
        }
        loop = false;
    }
    else if (input.ToLower() == "no")
    {
        Console.WriteLine("Too bad");
        loop = false;
    }
    else
    {
        Console.WriteLine("Please answer yes or no");
    }
}

int currentNumber = 1;
while (true)
{
    if (IsPrime(currentNumber))
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{currentNumber} is a prime number");
        currentNumber++;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{currentNumber} is not a prime number");
        currentNumber++;
    }

}