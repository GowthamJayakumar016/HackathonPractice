using System;

class Program
{
    static void Main(String[] args)
    {
        int[] arr = { 10, 45, 23, 89, 56 };

        int largest = int.MinValue;
        int secondLargest = int.MinValue;

        foreach (int num in arr)
        {
            if (num > largest)
            {
                secondLargest = largest;
                largest = num;
            }
            else if (num > secondLargest && num != largest)
            {
                secondLargest = num;
            }
        }

        Console.WriteLine("Second Largest: " + secondLargest);
    }
}
