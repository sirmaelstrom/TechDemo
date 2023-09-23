using System.Collections;
using TechDemo.Console.Interfaces;

namespace TechDemo.Console.Commands;

public class ObjectArrayCommand : ICommand
{
    public string CommandName => "ObjectArray";
    public string Description => "Demonstrates storing multiple types in an object array and printing their values.  Provides explanation of reference and value types.";
    public string[] ArgDefinitions => Array.Empty<string>();
    public void Execute(string[] args)
    {
        System.Console.WriteLine("Using object[]:");
        object[] objectArray = new object[3];
        objectArray[0] = 42; // int (value type)
        objectArray[1] = "Hello, world!"; // string (reference type)

        var person = new Person() { Id = 1, Name = "Sirmaelstrom" };
        objectArray[2] = person; // Complex type (reference type)

        foreach (object obj in objectArray)
        {
            System.Console.WriteLine(obj);
        }
        
        System.Console.WriteLine("Using ArrayList (from System.Collections)");
        ArrayList array = new ArrayList();
        array.Add(420);
        array.Add("Hello, world 2!");
        array.Add(person);

        foreach (object obj in array)
        {
            System.Console.WriteLine(obj);
        }
        
        System.Console.WriteLine("--------------------------------");
        System.Console.WriteLine("Value Types:  data stored directly in memory and variables of value types hold the actual data");
        System.Console.WriteLine("They store their data directly on the stack or inline within other data structures.");
        System.Console.WriteLine("When you assign a value type to another variable or pass it as a method argument, a copy of the data is made.  Changes to the copy do not affect the original value.");
        System.Console.WriteLine("Value types are typically small in size and have a predictable memory footprint");
        System.Console.WriteLine("--------------------------------");
        System.Console.WriteLine("Reference Types: represent data stored in memory and variables of reference types hold references (memory addresses) to the actual data.  Class, string an arrays (except for value type arrays like int[]) are reference types");
        System.Console.WriteLine("They store their data on the heap, variable holds references to data on the heap");
        System.Console.WriteLine("When you assign a reference type to another variable or pass it as a method argument, you are passing a reference to the same data.  Changes to the data are reflected in all references to that data");
        System.Console.WriteLine("Reference types can vary in size and have more flexible memory usage compared to value types");
        System.Console.WriteLine("--------------------------------");
        System.Console.WriteLine("42 is an integer (value type)");
        System.Console.WriteLine("Hello, world! is a string (reference type)");
        System.Console.WriteLine("[Name - printed] is the output of the 'ToString' override in the complex type 'Person' (reference type)");
        
    }

    private class Person
    {
        public int Id { get; init; }
        public string? Name { get; init; }

        public override string ToString()
        {
            return $"Person {Id}: {Name}";
        }
    }
}