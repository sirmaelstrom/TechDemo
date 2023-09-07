using TechDemo.Console.Interfaces;
using TechDemo.Console.Libraries;

namespace TechDemo.Console.Commands;

public class CharToNumericCommand : ICommand
{
    public string CommandName => "CharToNumeric";
    public string Description => "Demonstrates multiple methods for converting a character to numeric value";
    public string[] ArgDefinitions => Array.Empty<string>();
    public void Execute(string[] args)
    {
        System.Console.WriteLine("Method 1:  CharToCustomValue, input 1: 'A', input 2: 'D' (undefined)");

        var customValue = CharToNumericLibrary.CharToCustomValue('A');
        var customValue2 = CharToNumericLibrary.CharToCustomValue('D');
        
        System.Console.WriteLine($"Input 'A' result: {customValue} type: {customValue.GetType()}");
        System.Console.WriteLine($"Input 'D' result: {customValue2} type: {customValue2.GetType()}");
        
        System.Console.WriteLine("Method 2: CharToUnicodeCodePoint, input 'A'");
        var codePoint = CharToNumericLibrary.CharToUnicodeCodePoint('A');
        System.Console.WriteLine($"Input 'A' result: {codePoint} type: {codePoint.GetType()}");
        
        System.Console.WriteLine("Method 3: DigitCharToNumericValue, input 1: '8', input 2: 'A'");
        var numericValue = CharToNumericLibrary.DigitCharToNumericValue('8');
        var numericValue2 = CharToNumericLibrary.DigitCharToNumericValue('A');
        
        System.Console.WriteLine($"Input '8' result: {numericValue} type: {numericValue.GetType()}");
        System.Console.WriteLine($"Input 'A' result: {numericValue2} type: {numericValue2.GetType()}");
    }
}