using TechDemo.Console.Interfaces;
using TechDemo.Console.Libraries;

namespace TechDemo.Console.Commands;

public class SingletonCommand : ICommand
{
    public string CommandName => "Singleton";

    public string Description =>
        "Demonstrates implementation of a singleton class and how retriving the instance will always return the same instance (hence, singleton)";

    public string[] ArgDefinitions => Array.Empty<string>();
    public void Execute(string[] args)
    {
        // Get an instance of the Singleton.
        SingletonLibrary singleton1 = SingletonLibrary.Instance;

        // Call a method on the Singleton instance.
        System.Console.WriteLine($"singleton1 Guid: {singleton1.GetGuid().ToString()}");

        // Try to get another instance; it will be the same as the first one.
        SingletonLibrary singleton2 = SingletonLibrary.Instance;
        
        System.Console.WriteLine($"singleton2 Guid: {singleton2.GetGuid().ToString()}");

        // Check if both instances are the same.
        if (singleton1 == singleton2)
        {
            System.Console.WriteLine("Both instances are the same.");
        }
    }
}