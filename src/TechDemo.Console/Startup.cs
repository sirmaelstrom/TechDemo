using TechDemo.Console.Commands;
using TechDemo.Console.Interfaces;

namespace TechDemo.Console;

public class Startup
{
    public static void Start(string[] args)
    {
        List<ICommand> commands = new List<ICommand>();
        commands.Add(new HelpCommand());
        commands.Add(new ReversePalindromeCommand());
        commands.Add(new SubstringCommand());
        commands.Add(new StringEveryOtherCharacterCommand());
        commands.Add(new CharToNumericCommand());
        commands.Add(new NumberIsPrimeCommand());
        commands.Add(new SingletonCommand());
        commands.Add(new ObjectArrayCommand());
        commands.Add(new FibonacciClosureCommand());
        commands.Add(new PeanoIntegerCommand());
        commands.Add(new ApproximatePiConcurrentComputationCommand());

        // TODO: Support non-interactive mode (where user just supplies args and we do something)
        var ui = new InteractiveUserInterface(commands);
        ui.Start();
    }
}