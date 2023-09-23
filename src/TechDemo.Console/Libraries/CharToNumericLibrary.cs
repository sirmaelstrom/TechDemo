namespace TechDemo.Console.Libraries;

public class CharToNumericLibrary
{
    public static int CharToCustomValue(char ch)
    {
        var charToValueMap = new Dictionary<char, int>
        {
            { 'A', 1 },
            { 'B', 2 },
            { 'C', 3 },
            // Add more mappings as needed
        };

        if (charToValueMap.TryGetValue(ch, out var value))
        {
            return value;
        }

        // Handle characters not in the mapping
        return -1; 
    }
    
    public static int CharToUnicodeCodePoint(char ch)
    {
        // note that the cast to (int) is redundant, but left for clarity
        return (int)ch;
    }

    public static int DigitCharToNumericValue(char ch)
    {
        if (char.IsDigit(ch))
        {
            // note that the cast to (int) is redundant, but left for clarity
            return (int)(ch - '0');
        }

        // Handle non-digit characters
        return -1;
    }
}

#region Unit Testing Wrapper

public interface ICharToNumeric
{
    int CharToCustomValue(char ch);
    int CharToUnicodeCodePoint(char ch);
    int DigitCharToNumericValue(char ch);
}

public class CharToNumeric : ICharToNumeric
{
    public int CharToCustomValue(char ch)
    {
        return CharToNumericLibrary.CharToCustomValue(ch);
    }

    public int CharToUnicodeCodePoint(char ch)
    {
        return CharToNumericLibrary.CharToUnicodeCodePoint(ch);
    }

    public int DigitCharToNumericValue(char ch)
    {
        return CharToNumericLibrary.DigitCharToNumericValue(ch);
    }
}

#endregion