// See https://aka.ms/new-console-template for more information

//Ints
int myAge = 18;
int myRandonNumber = 3;
int intInputNumber;
int randomNumber1 = 42;
int randomNumber2 = 7;
int intUserGuessNumber;
int currentYear = DateTime.Now.Year;

//floats
double kelvinToCelsius = 273.15;

//Strings
string myName = "Kai";
string inputYear;
string inputName;
string inputCelsius;
string inputNumber;
string userGuess;

//String Arrays
string[] randomFactsP1 = ["Your brain is constantly eating itself.", "Earlobes have no biological purpose."];
string[] randomFactsP2 = ["This process is called phagocytosis, where cells envelop and consume smaller cells or molecules to remove them from the system. Don’t worry! Phagocytosis isn't harmful, but actually helps preserve your grey matter.", "While they are rich in nerve endings and may play a role in social bonding, many scientists argue that earlobes don’t have any true biological purpose. "];

//Bool
bool loopA = true;

Console.Write($"Hello my names is {myName}, Whats yours? ");

inputName = Console.ReadLine();
Console.WriteLine($"Hello, {inputName}!");

Console.Write($"I'm {myAge} years old, what year where you born? ");

inputYear = Console.ReadLine();
inputYear = (currentYear - int.Parse(inputYear)).ToString();
Console.WriteLine($"You are {inputYear} years old.\n");

for (int i = 0; i < randomFactsP1.Length; i++)
{
    Console.WriteLine(randomFactsP1[i]);
    Console.WriteLine(randomFactsP2[i] + "\n");
}

Console.WriteLine($"{randomNumber1} + {randomNumber2} = {randomNumber1 + randomNumber2} \n");

Console.Write("Please enter a number: ");
inputNumber = Console.ReadLine();
intInputNumber = int.Parse(inputNumber);

Console.WriteLine($"My number plus your number = {myRandonNumber + intInputNumber}");

while (loopA)
{
    Console.Write("What was my number: ");
    
    userGuess = Console.ReadLine();
    intUserGuessNumber = int.Parse(userGuess);

    if (intUserGuessNumber == myRandonNumber)
    {
        Console.WriteLine("Correct!");
        loopA = false;
    }
    else
    {
        Console.WriteLine("Wrong, try again!");
    }

}


Console.Write("Please enter the temperature in Celsius: ");
inputCelsius = Console.ReadLine();
double celsius = double.Parse(inputCelsius);

double kelvin = celsius + kelvinToCelsius;
double fahrenheit = (celsius * 9/5) + 32;
Console.WriteLine($"The temperature in Kelvin is: {kelvin} Kelvin");
Console.WriteLine($"The temperature in Fahrenheit is: {fahrenheit} Fahrenheit");

Console.Write("Please enter a number: ");
inputNumber = Console.ReadLine();
intInputNumber = int.Parse(inputNumber);

int number1 = intInputNumber;

Console.Write("Please enter a number: ");
inputNumber = Console.ReadLine();
intInputNumber = int.Parse(inputNumber);

int number2 = intInputNumber;

Console.WriteLine($"{number1} + {number2} = {number1 + number2}");
Console.WriteLine($"{number1} - {number2} = {number1 - number2}");
Console.WriteLine($"{number1} * {number2} = {number1 * number2}");
Console.WriteLine($"{number1} / {number2} = {number1 / number2}");