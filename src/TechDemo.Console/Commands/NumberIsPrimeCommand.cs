using TechDemo.Console.Interfaces;
using TechDemo.Console.Libraries;

namespace TechDemo.Console.Commands;

public class NumberIsPrimeCommand : ICommand
{
    public string CommandName => "NumberIsPrime";
    public string Description => "Demonstrates method for determining if entered numeric value is prime";
    public string[] ArgDefinitions => new []
    {
        "Enter an integer value"
    };
    public void Execute(string[] args)
    {
        var input = args[0];
        while (true)
        {
            if (int.TryParse(input, out var parsedInt))
            {
                var isPrime = IntegerLibrary.IsPrime(parsedInt);
                System.Console.WriteLine($"The value {parsedInt} is{(isPrime ? "" : " not")} prime");
                break;
            }

            System.Console.WriteLine("Value not integer, please try again");
            input = System.Console.ReadLine();
        }
    }
}