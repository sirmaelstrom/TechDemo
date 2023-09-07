using System.Diagnostics;
using TechDemo.Console.Interfaces;

namespace TechDemo.Console;

public class InteractiveUserInterface
{
    private const string GreetingMessage = @"Welcome to HeathDev Technical Interview Examples! Press ""q"" to quit.";

    /// <summary>
    /// We are storing our commands in a dictionary for fast indexing later on.
    /// </summary>
    private readonly Dictionary<char, ICommand> _availableCommands;

    /// <summary>
    /// A class for showing messages to the user
    /// </summary>
    /// <param name="availableCommands">Commands available to the user.</param>
    public InteractiveUserInterface(List<ICommand> availableCommands)
    {
        _availableCommands = new Dictionary<char, ICommand>();
        var i = 1;
        availableCommands.ForEach(cmd => _availableCommands.Add(i++.ToString()[0], cmd));
    }

    /// <summary>
    /// Display a friendly welcome message to the user and start up the interactive UI.
    /// </summary>
    public void Start()
    {
        System.Console.Write(GreetingMessage);
        DisplayRepl();
    }

    /// <summary>
    /// Start our read–eval–print loop (REPL).
    /// </summary>
    private void DisplayRepl()
    {
        DisplayAvailableCommands();
        while (true)
        {
            var key = System.Console.ReadKey(true);
            var pressedCharacter = key.KeyChar;
            if (pressedCharacter == 'q') { return; }

            if (!_availableCommands.ContainsKey(pressedCharacter)) continue;
            
            var commandToExecute = _availableCommands[pressedCharacter];
            var args = PromptUserForArgs(commandToExecute.ArgDefinitions);
            commandToExecute.Execute(args);
            DisplayAvailableCommands();
        }
    }

    /// <summary>
    /// Display a list of available commands
    /// </summary>
    private void DisplayAvailableCommands()
    {
        // We always want a line above the commands
        System.Console.WriteLine();
        System.Console.WriteLine("Available commands:");
        System.Console.WriteLine();
        foreach (var key in _availableCommands.Keys)
        {
            var command = _availableCommands[key];
            System.Console.WriteLine($"{key}) {command.CommandName}: {command.Description}");
        }
    }

    /// <summary>
    /// Prompt the user for args and return the values they submitted.
    /// </summary>
    /// <param name="argDefinitions">Definitions for the args to display to the users.</param>
    private string[] PromptUserForArgs(string[] argDefinitions)
    {
        var args = new string[argDefinitions.Length];
        for (var i = 0; i < argDefinitions.Length; i++)
        {
            while (true)
            {
                System.Console.Write($"{argDefinitions[i]}: ");
                var userInput = System.Console.ReadLine();
                if (userInput is { Length: <= 0 }) continue;
                Debug.Assert(userInput != null, nameof(userInput) + " != null");
                args[i] = userInput;
                break;
            }
        }
        System.Console.WriteLine();
        return args;
    }
}