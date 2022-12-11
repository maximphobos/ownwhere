using OwnWhereApp;

var initialList = new List<int>() { 1, 2, 3, 4 };

RepeatWithNewNumberAddition://label for GoTo operator below
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Your current collection of integers is: {String.Join(",", initialList)}");
Console.ForegroundColor = ConsoleColor.White;

string? userEnteredString = string.Empty;
int enteredIntegerNumber = 0;
bool isInteger = false;
bool isEnteredIntegerAboveZero = false;
bool isExists = false;

while (string.IsNullOrWhiteSpace(userEnteredString) || !isInteger || !isEnteredIntegerAboveZero || isExists)
{
    Console.Write("Please, enter any integer number wich current collection doesn't exist above zero:");

    userEnteredString = Console.ReadLine();

    isInteger = int.TryParse(userEnteredString, out enteredIntegerNumber);

    if (isInteger)
    {
        isEnteredIntegerAboveZero = enteredIntegerNumber > 0;
        isExists = initialList.Any(x => x == enteredIntegerNumber);

        if (!isEnteredIntegerAboveZero)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You've entered: {enteredIntegerNumber} number, which is less or equal zero, please try again (!)");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else if (isExists)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You've entered: {enteredIntegerNumber} number, which current collection already exists, " +
                $"please try again (!)");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"You've entered: {userEnteredString} , which is not a integer number, please try again (!)");
        Console.ForegroundColor = ConsoleColor.White;
    }
}

initialList.Add(enteredIntegerNumber);
initialList.Sort();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"We've successfully added your {enteredIntegerNumber} to initial collection.");
Console.WriteLine($"Here is the updated sorted collection: {String.Join(",", initialList)}");
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine($"Even numbers in updated collection are: {String.Join(",", initialList.MyWhere(i => i % 2 == 0))}");
Console.WriteLine($"Odd numbers in updated collection are: {String.Join(",", initialList.MyWhere(i => i % 2 != 0))}");

Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("Good Job! Let's continue!");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine();

goto RepeatWithNewNumberAddition;
