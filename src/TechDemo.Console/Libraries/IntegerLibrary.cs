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
        // This is an optimization to reduce the number of checks:
        // After excluding numbers divisible by 2 or 3, we enter a loop that iterates over numbers of the form 6k ± 1,
        // where k is incremented in each iteration. The loop continues until k squared is greater than or equal to
        // number.
        //  In each iteration, we check whether number is divisible by 6k - 1 and 6k + 1. If number is divisible by
        //  either of these numbers, we return false because it's not prime.
        //  The loop only considers numbers of the form 6k ± 1 because any integer that's not divisible by 2 or 3 and
        //  greater than 3 can be expressed as 6k ± 1 for some positive integer k. Therefore, we only need to check
        //  these numbers.
        //  By incrementing k in each iteration, we efficiently check divisibility by a subset of potential divisors,
        //  reducing the number of checks compared to a full brute-force approach.
        for (var i = 5; i * i <= number; i += 6)
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