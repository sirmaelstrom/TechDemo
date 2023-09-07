namespace TechDemo.Console.Interfaces;

public interface ICommand 
{
    string CommandName { get; }
    string Description { get; }
    string[] ArgDefinitions { get; }
    void Execute(string[] args);
}