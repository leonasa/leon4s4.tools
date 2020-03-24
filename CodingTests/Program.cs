using System;
using System.Linq;
using IterTools;

namespace CodingTests
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {-1,1};
            var sum = arr.Sum();
            var result = arr.Accumulated().Take(arr.Length-1).Select(x => Math.Abs(2 * x - sum)).Min();
            
            var c = Convert.ToChar(1);
            Console.WriteLine(c == '1');
            // input number N 
            int n = 1536;

            // input digit D 
            int d = 6;

            Console.WriteLine(Mixing.FrequencyDigits(n, d));
        }
    }
}