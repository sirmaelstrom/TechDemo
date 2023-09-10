using TechDemo.Console.Interfaces;
using TechDemo.Console.Libraries;

namespace TechDemo.Console.Commands;

public class PeanoIntegerCommand : ICommand
{
    public string CommandName => "PeanoIntegers";

    public string Description =>
        "Demonstrate Peano integers which are a way to represent natural numbers using a recursive structure.  Each integer is either 0 (Z) or the successor of another Peano integer (S)";

    public string[] ArgDefinitions => Array.Empty<string>();
    public void Execute(string[] args)
    {
        // Creating Peano integers
        PeanoIntegerLibrary.PeanoInteger zero = new PeanoIntegerLibrary.Zero();
        PeanoIntegerLibrary.PeanoInteger one = new PeanoIntegerLibrary.Succ(zero);
        PeanoIntegerLibrary.PeanoInteger two = new PeanoIntegerLibrary.Succ(one);

        // Perform operations
        PeanoIntegerLibrary.PeanoInteger sum = one.Add(two);
        PeanoIntegerLibrary.PeanoInteger difference = two.Subtract(one);

        // Display results
        System.Console.WriteLine($"0: {zero.ToInt()}");
        System.Console.WriteLine($"1: {one.ToInt()}");
        System.Console.WriteLine($"2: {two.ToInt()}");
        System.Console.WriteLine($"1 + 2 = {sum.ToInt()}");
        System.Console.WriteLine($"2 - 1 = {difference.ToInt()}");
    }
}