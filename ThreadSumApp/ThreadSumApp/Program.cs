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
   // TODO: Change array size after testing
    public static void Main()
    {
        int[] randomArray = new int[50]; // Change to 200,000,000
        randomArray = RandomNum();

        Console.WriteLine("\nFrom Main Method:");
        for (int i = 0; i < randomArray.Length; i++)
        {
            Console.Write(randomArray[i] + " ");
        }

        Console.WriteLine("\nThe sum is: " + ArraySum(randomArray));

        Parallel.Invoke(() =>
        {
            Console.WriteLine("Begin first task...");
            Thread1(randomArray);
        }, // Close first Action

        () =>
        {
            Console.WriteLine("Begin second task...");
            Thread2(randomArray);
        });
        
    }
    // TODO: change array size after testing
    /// <summary>
    /// A method to fill the array with random numbers.
    /// </summary>
    /// <returns></returns>
    public static int[] RandomNum()
    {
        int[] array = new int[50]; // Change to 200,000,000

        Console.WriteLine("From RandomNum Method:");

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = RandomNumGenerator();
            Console.Write(array[i] + " ");
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
    /// A mthod to caclulate and return the sum of the array.
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public static int ArraySum(int[] array)
    {
        int sum = 0;

        for (int i = 0; i < array.Length; i++)
        {
            sum = sum + array[i];
        }

        return sum;
    }

    // Compute the sum in parallel using multiple threads
    public static void Thread1(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Thread 1: " + array[i]);  
        }
        Console.WriteLine("Thread 1 sum: " + ArraySum(array)); 
    }

    public static void Thread2(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Thread 2: " + array[i]);
        }
        Console.WriteLine("Thread 2 sum: " + ArraySum(array));

    }

    // Compute the sum using only one thread

    // Display the sum and times for both cases



}
    
