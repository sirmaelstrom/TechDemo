using TechDemo.Console.Interfaces;
using TechDemo.Console.Libraries;

namespace TechDemo.Console.Commands;

public class FibonacciClosureCommand : ICommand
{
    public string CommandName => "FibonacciClosure";
    public string Description => "Demonstrates a Fibonacci closure (a function that encapsulates some state) that generates Fibonacci numbers.";
    public string[] ArgDefinitions => Array.Empty<string>();
    public void Execute(string[] args)
    {
        Func<int> fibonacci = FibonacciLibrary.CreateFibonacciClosure();

        for (int i = 0; i < 10; i++)
        {
            int result = fibonacci();
            System.Console.WriteLine($"Fibonacci({i}) = {result}");
        }
    }
}