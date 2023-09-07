namespace TechDemo.Console.Libraries;

public static class IntegerLibrary
{
    public static bool IsPrime(int number)
    {
        // Prime numbers are greater than 1
        // 2 & 3 are special cases
        switch (number)
        {
            case <= 1:
                return false;
            case <= 3:
                return true;
        }

        // If number is divisible by 2 or 3, return false since prime numbers cannot be
        // divisible by 2 or 3; except for 2 & 3 themselves
        if (number % 2 == 0 || number % 3 == 0)
        {
            return false;
        }

        // Loop to check divisibility by numbers in form of 6k +- 1, where k is an integer.
        // This is an optimization to reduce the number of checks
        for (int i = 5; i * i <= number; i += 6)
        {
            if (number % i == 0 || number % (i + 2) == 0)
            {
                return false;
            }
        }

        // If the number is not divisible by any of the above conditions, then the number is prime
        return true;
    }
}

#region Unit Testing Wrapper

public interface IIntegerWrapper
{
    bool IsPrime(int number);
}

public class IntegerLibraryWrapper : IIntegerWrapper
{
    public bool IsPrime(int number)
    {
        return IntegerLibrary.IsPrime(number);
    }
}

#endregion