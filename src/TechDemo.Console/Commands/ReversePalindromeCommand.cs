using TechDemo.Console.Interfaces;
using TechDemo.Console.Libraries;

namespace TechDemo.Console.Commands;

public class ReversePalindromeCommand : ICommand
{
    private StringManipulationLibrary _sml = new();
    public string CommandName => "ReversePalindrome";

    public string Description =>
        "Demonstrates accepting input, reversing string and checking if the string was a palindrome";

    public string[] ArgDefinitions => new []
    {
        "Enter a non-empty string"
    };
    
    public void Execute(string[] args)
    {
        var str = args[0];
        var reverse = _sml.ReverseString(str);

        System.Console.WriteLine($"Entered String was {str} and reversed string is {reverse}");
        System.Console.WriteLine($"String is{(reverse == str ? "" : " not")} Palindrome");
    }
}