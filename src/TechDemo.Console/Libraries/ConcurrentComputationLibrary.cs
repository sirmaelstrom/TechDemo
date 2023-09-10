namespace TechDemo.Console.Libraries;

public class ConcurrentComputationLibrary
{
    /// <summary>
    /// Compute approximation of pi using the Nilakantha Series with parallel processing
    /// </summary>
    /// <param name="n">Number of terms to calculate in the series</param>
    /// <returns></returns>
    public static double CalculatePi(int n)
    {
        double result = 3.0; // initial approximation of pi
        object lockObject = new object(); // lock object used for thread synchronization
        double[] partialSums = new double[n]; // array to store the partial sums for each term

        // Dived work into multiple tasks, each computing a term in the parallel
        // Iterate from 0 to n-1 with a loop variable of k
        // For each value of k, calculate the corresponding term in the Nilakantha Series and store in partial sums array
        Parallel.For(0, n, k =>
        {
            var term = 4 * Math.Pow(-1, k) / ((2 * k + 2) * (2 * k + 3) * (2 * k + 4));
            partialSums[k] = term;
        });

        // Once all parallel tasks have finished computations, accumulate partial sums into result
        // inside the lock add partial sum to result ensuring only one thread can modify the result at a time
        foreach (var partialSum in partialSums)
        {
            lock (lockObject)
            {
                result += partialSum;
            }
        }

        return result;
    }
}