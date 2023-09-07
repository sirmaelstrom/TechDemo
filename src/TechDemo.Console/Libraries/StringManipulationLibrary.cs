using System.Text;

namespace TechDemo.Console.Libraries;

public class StringManipulationLibrary
{
    public string EveryOther(string s)
    {
        var output = "";
        
        for (var i = 0; i < s.Length; i += 2)
        {
            output += s[i];
        }

        return output;
    }
    
    public string EveryOtherReverse(string s)
    {
        var output = "";
        
        for (int i = s.Length - 1; i >= 0; i -= 2)
        {
            output += s[i];
        }

        return output;
    }

    public string GenerateSubstrings(string s)
    {
        var length = s.Length;
        
        var sb = new StringBuilder();
        for (int start = 0; start < length; start++)
        {
            for (int end = start + 1; end <= length; end++)
            {
                var substring = s.Substring(start, end - start);
                sb.Append(substring + " ");
            }
        }

        return sb.ToString().Trim();
    }

    public string GenerateSubstringsManualPreIncrement(string s)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < s.Length; ++i)
        {
            var subString = new StringBuilder(s.Length - i);

            for (var j = i; j < s.Length; ++j)
            {
                subString.Append(s[j]);
                sb.Append(subString + " ");
            }
        }

        return sb.ToString().Trim();
    }
    
    public string ReverseString(string s)
    {
        var reverse = "";
    
        for (var i = s.Length - 1; i >= 0; i--)
        {
            reverse += s[i].ToString();
        }

        return reverse;
    }

    public string ReverseStringWithStringBuilder(string s)
    {
        var reversed = new StringBuilder(s.Length);
        for (int i = s.Length - 1; i >= 0; i--)
        {
            reversed.Append(s[i]);
        }

        return reversed.ToString();
    }

    public string ReverseStringLinq(string s)
    {
        return new string(s.Reverse().ToArray());
    }
    
}