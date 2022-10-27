using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
/// <summary>
/// Prompt: 
///     Make an array of 200 million random numbers between 1 and 10. 
///     Compute the sum in parallel using multiple threads.
///     Then compute the sum with only one thread, and display the sum and times for both cases.
/// </summary>
/// 


public class Concurrency
{
   
    public static void Main()
    {
        int[] randomArray = new int[10000];
        randomArray = RandomNum();

        // run the threads in parallel.
        Parallel.Invoke(() =>
        {
            Console.WriteLine("Begin first thread...");
            Thread1(randomArray);
        },

        () =>
        {
            Console.WriteLine("Begin second thread...");
            Thread2(randomArray);
        }//,

        //() =>
        //{
        //    Console.WriteLine("Begin third thread...");
        //    Thread3(randomArray);
        //},

        //() =>
        //{
        //    Console.WriteLine("Begin fourth thread..");
        //    Thread4(randomArray);
        //}
        );

        Console.WriteLine("Begin single thread...");
        LoneThread(randomArray);
    }

    /// <summary>
    /// A method to fill the array with random numbers.
    /// </summary>
    /// <returns></returns>
    public static int[] RandomNum()
    {
        int[] array = new int[10000];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = RandomNumGenerator();
        }

        return array;
    }

    /// <summary>
    /// A method to pass back to RandomNum() only values between 1 and 10
    /// </summary>
    /// <returns></returns>
    public static int RandomNumGenerator()
    {
        int min = 1;
        int max = 10;

        Random random = new Random();
        int number = random.Next(min, max);

        return number;
    }

    /// <summary>
    /// A method to caclulate and return the sum of the array.
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public static int ArraySum(int[] array)
    {
        int sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }

        return sum;
    }

    // Compute the sum in parallel using multiple threads
    public static void Thread1(int[] array)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        stopwatch.Stop();
        TimeSpan timeSpan = stopwatch.Elapsed;
        Console.WriteLine("Thread 1 sum: " + ArraySum(array) + ". It took " + timeSpan.Milliseconds + " milliseconds to calculate the sum."); 
    }

    public static void Thread2(int[] array)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        stopwatch.Stop();
        TimeSpan timeSpan = stopwatch.Elapsed;
        Console.WriteLine("Thread 2 sum: " + ArraySum(array) + ". It took " + timeSpan.Milliseconds + " milliseconds to calculate the sum.");
    }

    public static void Thread3(int[] array)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        stopwatch.Stop();
        TimeSpan timeSpan = stopwatch.Elapsed;
        Console.WriteLine("Thread 3 sum: " + ArraySum(array) + ". It took " + timeSpan.Milliseconds + " milliseconds to calculate the sum.");
    }

    public static void Thread4(int[] array)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        stopwatch.Stop();
        TimeSpan timeSpan = stopwatch.Elapsed;
        Console.WriteLine("Thread 4 sum: " + ArraySum(array) + ". It took " + timeSpan.Milliseconds + " milliseconds to calculate the sum.");
    }

    /// <summary>
    /// A method to find the sum of the array using a single thread
    /// </summary>
    /// <param name="array"></param>
    public static void LoneThread(int[] array)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        stopwatch.Stop();
        TimeSpan timeSpan = stopwatch.Elapsed;
        Console.WriteLine("Single thread sum: " + ArraySum(array) + ". It took " + timeSpan.Milliseconds + " milliseconds to calculate the sum.");
    }

}
    
