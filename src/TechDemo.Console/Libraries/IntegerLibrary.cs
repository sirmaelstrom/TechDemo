using System.Collections.Concurrent;

namespace TechDemo.Console.Libraries;

public static class IntegerLibrary
{
    /// <summary>
    /// Method to generate prime numbers using concurrent prime sieve approach
    /// Note:  this is presently not working as expected
    /// </summary>
    /// <param name="numberOfPrimes"></param>
    /// <param name="timeoutMilliseconds"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static IEnumerable<int> GeneratePrimes(int numberOfPrimes, int timeoutMilliseconds)
    {
        if (numberOfPrimes < 1)
        {
            throw new ArgumentException("Number of primes must be greater than or equal to 1.");
        }

        var primes = new List<int>();
        var ch = new BlockingCollection<int>();

        // Launch a task to Generate Prime Numbers concurrently
        var generateTask = Task.Run(() =>
        {
            Generate(ch, timeoutMilliseconds);
        });

        try
        {
            for (int i = 0; i < numberOfPrimes; i++)
            {
                int prime = ch.Take(); // Take the next prime number from the channel
                primes.Add(prime); // Add the prime number to the list

                var ch1 = new BlockingCollection<int>();
                var primeToFilter = prime; // Local variable to capture the current prime
                var filterTask = Task.Run(() =>
                {
                    Filter(ch, ch1, primeToFilter); // Launch a task to Filter out multiples of the current prime
                });

                ch = ch1; // Update the channel for the next iteration
                filterTask.Wait(); // Wait for the Filter task to complete
            }
        }
        finally
        {
            ch.CompleteAdding(); // Signal the end of the channel
            generateTask.Wait(); // Wait for the Generate task to complete
        }

        return primes; // Return the list of generated prime numbers
    }
    
    // Generate Method: Generates an Infinite Sequence of Integers (2, 3, 4, ...) with timeout for testing purposes
    private static void Generate(BlockingCollection<int> ch, int timeoutMilliseconds)
    {
        DateTime startTime = DateTime.Now;

        for (int i = 2; ; i++)
        {
            ch.Add(i); // Add the next integer to the channel

            // Check if the specified timeout has been reached
            if ((DateTime.Now - startTime).TotalMilliseconds > timeoutMilliseconds)
            {
                ch.CompleteAdding(); // Signal the end of the channel if the timeout is exceeded
                break;
            }
        }
    }


    // Filter Method: Removes Multiples of the Current Prime from the Input Channel
    private static void Filter(BlockingCollection<int> input, BlockingCollection<int> output, int prime)
    {
        foreach (var number in input.GetConsumingEnumerable())
        {
            if (number % prime != 0)
            {
                output.Add(number); // Add non-multiples to the output channel
            }
        }

        output.CompleteAdding(); // Signal the end of the output channel
    }
    
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