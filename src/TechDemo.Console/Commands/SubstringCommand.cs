using TechDemo.Console.Interfaces;
using TechDemo.Console.Libraries;

namespace TechDemo.Console.Commands;

public class SubstringCommand : ICommand
{
    private readonly StringManipulationLibrary _sml = new();
    public string CommandName => "SubstringManipulation";
    public string Description => "Demonstrates multiple methods of extracting all substrings from an input string";

    public string[] ArgDefinitions => new[]
    {
        "Enter a non-empty string"
    };
    
    public void Execute(string[] args)
    {
        var str = args[0];
        
        System.Console.WriteLine("Substrings for given string are: ");
        System.Console.WriteLine(_sml.GenerateSubstrings(str));
        
        System.Console.WriteLine("\nUsing manual pre-increment method: ");
        System.Console.WriteLine(_sml.GenerateSubstringsManualPreIncrement(str));
    }
}