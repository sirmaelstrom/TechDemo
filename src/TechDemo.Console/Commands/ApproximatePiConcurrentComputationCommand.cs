using TechDemo.Console.Interfaces;
using TechDemo.Console.Libraries;

namespace TechDemo.Console.Commands;

public class ApproximatePiConcurrentComputationCommand : ICommand
{
    public string CommandName => "ApproximatePiConcurrent";
    public string Description => "Demonstrate approximation of Pi utilizing Nilakantha Series with parallel processing";
    public string[] ArgDefinitions => new []
    {
        "Enter number of terms to calculate in series"
    };
    public void Execute(string[] args)
    {
        var input = args[0];
        while (true)
        {
            if (int.TryParse(input, out var parsedInt))
            {
                var result = ConcurrentComputationLibrary.CalculatePi(parsedInt);
                System.Console.WriteLine($"Result: {result}");
                break;
            }

            System.Console.WriteLine("Value not integer, please try again");
            input = System.Console.ReadLine();
        }
    }
}