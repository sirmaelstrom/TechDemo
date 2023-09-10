using System.Diagnostics;
using TechDemo.Console.Interfaces;

namespace TechDemo.Console;

public class InteractiveUserInterface
{
    private const string GreetingMessage = @"Welcome to HeathDev Technical Interview Examples! Enter ""0"" to quit.";

    /// <summary>
    /// We are storing our commands in a dictionary for fast indexing later on.
    /// </summary>
    private readonly Dictionary<int, ICommand> _availableCommands;

    /// <summary>
    /// A class for showing messages to the user
    /// </summary>
    /// <param name="availableCommands">Commands available to the user.</param>
    public InteractiveUserInterface(List<ICommand> availableCommands)
    {
        _availableCommands = new Dictionary<int, ICommand>();
        var i = 1;
        availableCommands.ForEach(cmd => _availableCommands.Add(i++, cmd));
    }

    /// <summary>
    /// Display a friendly welcome message to the user and start up the interactive UI.
    /// </summary>
    public void Start()
    {
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
            var option = System.Console.ReadLine();

            int enteredOption;
            while (true)
            {
                if (int.TryParse(option, out var parsedInt))
                {
                    enteredOption = parsedInt;
                    break;
                }

                System.Console.WriteLine("Value not integer, please try again");
                option = System.Console.ReadLine();
            }
            
            if (enteredOption == 0) { return; }

            if (!_availableCommands.ContainsKey(enteredOption)) continue;
            
            var commandToExecute = _availableCommands[enteredOption];
            var args = PromptUserForArgs(commandToExecute.CommandName, commandToExecute.ArgDefinitions);
            commandToExecute.Execute(args);
            System.Console.WriteLine("Press any key to continue");
            System.Console.ReadKey(true);
            System.Console.Clear();
            DisplayAvailableCommands();
        }
    }

    /// <summary>
    /// Display a list of available commands
    /// </summary>
    private void DisplayAvailableCommands()
    {
        System.Console.Write(GreetingMessage);

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
    /// <param name="commandName">The currently executed command</param>
    /// <param name="argDefinitions">Definitions for the args to display to the users.</param>
    private string[] PromptUserForArgs(string commandName, string[] argDefinitions)
    {
        var args = new string[argDefinitions.Length];
        for (var i = 0; i < argDefinitions.Length; i++)
        {
            while (true)
            {
                System.Console.Write($"{commandName} - {argDefinitions[i]}: ");
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