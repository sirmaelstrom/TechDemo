namespace TechDemo.Console.Libraries;

public class FibonacciLibrary
{
    public static Func<int> CreateFibonacciClosure()
    {
        int prev = 0;
        int current = 1;

        // Define a lambda function that calculates the next Fibonacci number
        Func<int> getNextFibonacci = () =>
        {
            int temp = current;
            current = prev + current;
            prev = temp;
            return prev;
        };

        // Return the lambda function as a closure
        return getNextFibonacci;
    }
}