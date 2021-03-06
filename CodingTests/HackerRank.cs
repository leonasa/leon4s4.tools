using System;
using System.Linq;

namespace CodingTests
{
    public class HackerRank
    {
        public static long RepeatedStringTooLongToRun(string s, long n)
        {
            var sLength = s.Length;
            long count = 0;
            long countTotalOfA = 0;
            var index = 0;
            while (count < n)
            {
                countTotalOfA += s[index] == 'a' ? 1 : 0;
                index = index >= sLength - 1 ? 0 : index + 1;
                count++;
            }
            
            return countTotalOfA;
        }

        public static long RepeatedString(string s, long n)
        {
            var countA = s.Count(a => a == 'a');
            
            if (countA == s.Length)
                return n;
            
            return countA;
        }
    }

    public class Mixing
    {
        public int function(int[] arr, int @int)
        {
            return arr.Count(i => i == @int);
        }

        public int MostPopularNumber(int[] arr, int size)
        {
            var groupedAndOrdered = arr.GroupBy(i => i).OrderBy(g => g.Count()).ToList();
            var max = groupedAndOrdered.Max(k => k.Count());
            var mostPopularNumber = groupedAndOrdered.Where(k => k.Count() == max).OrderByDescending(k => k.Key);
            return mostPopularNumber.First().Key;
        }

        public bool IsPalindrome(string word)
        {
            return word.SequenceEqual(word.Reverse());
        }

        public bool IsAlmostPalindromeRecursive(string word)
        {
            if (word.Length < 2)
                return true;

            if (word[0] != word[^1])
                return word.Length > 2 && word[1] == word[^2];

            // ReSharper disable once TailRecursiveCall -- Sample Version
            return IsAlmostPalindromeRecursive(word[1..^1]);
        }

        public bool IsAlmostPalindrome(string word)
        {
            while (true)
            {
                if (word.Length < 2) 
                    return true;

                if (word[0] != word[^1]) 
                    return word.Length > 2 && word[1] == word[^2];

                word = word[1..^1];
            }
        }

        public double CalculateDistance(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            var distance1 = Math.Sqrt(x1 * y1 + x2 * y2);
            var distance2 = Math.Sqrt(x2 * y2 + x3 * y3);
            var distance3 = Math.Sqrt(x3 * y3 + x1 * y1);
            return (distance1 + distance2 + distance3) / 3;
        }

        /// <summary>
        /// How many times a digit appears in a sequence
        /// </summary>
        /// <param name="n"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int FrequencyDigits(int n, int d)
        {
            var s1 = d.ToString();

            return Enumerable.Range(0, n).Select(i => i.ToString()).Sum(item => item.Count(s => s.ToString() == s1));
        }
    }
}