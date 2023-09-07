using TechDemo.Console.Interfaces;

namespace TechDemo.Console.Commands;

public class HelpCommand : ICommand
{
    private const string HelpText =
        @"
        This application is for demonstration purposes.

        Press 'q' to quit.
         ";

    public string CommandName => "help";
    public string Description => "Display help text";
    public string[] ArgDefinitions => Array.Empty<string>();
    
    public void Execute(string[] args)
    {
        System.Console.Write(HelpText);
    }
}