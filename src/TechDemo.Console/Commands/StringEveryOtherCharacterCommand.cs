using TechDemo.Console.Interfaces;
using TechDemo.Console.Libraries;

namespace TechDemo.Console.Commands;

public class StringEveryOtherCharacterCommand : ICommand
{
    private const string Alpha = "abcdefghijklmnopqrstuvwxyz";
    private readonly StringManipulationLibrary _sml = new();

    public string CommandName => "StringEveryOtherCharacter";
    public string Description => "Demonstrates displaying every other character in a string 'abcdefghijklmnopqrstuvwxyz', then the same in reverse.";
    public string[] ArgDefinitions => Array.Empty<string>();
    public void Execute(string[] args)
    {
        System.Console.WriteLine(_sml.EveryOther(Alpha));
        System.Console.WriteLine(_sml.EveryOtherReverse(Alpha));
    }
}