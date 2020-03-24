using System;
using System.Collections.Generic;
using System.Linq;


namespace IterTools
{
    public static class EnumHelper
    {
        public static IEnumerable<int> Accumulated(this IEnumerable<int> arr, int start = 0)
        {
            var enumerable = arr.ToList();
            var total = 0;
            foreach (var t in enumerable)
            {
                total += t;
                yield return total;
            }
        }

        public static IEnumerable<T> GroupByUniq<T>(this IEnumerable<T> arr)
        {
            T start = default;
            var enumerator = arr.GetEnumerator();
            while (true)
            {
                enumerator.MoveNext();
                
                if (Equals(start, default(T)))
                {
                    start = enumerator.Current;
                    yield return start;
                }

                while (enumerator.MoveNext())
                {
                    if (Equals(start, enumerator.Current))
                        continue;
                    start = enumerator.Current;
                    yield return start;
                }

                break;
            }
        }

        public static IEnumerable<T> DropWhile<T>(IEnumerable<T> arr, Func<T,bool> func)
        {
            using var enumerator = arr.GetEnumerator();

            while (enumerator.MoveNext())
            {
                if (func(enumerator.Current))
                    continue;
                    
                yield return enumerator.Current;
                break;
            }

            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        public static IEnumerable<T> Cycle<T>(IEnumerable<T> arr)
        {
            var enumerable = arr.ToList();
            while (true)
            {
                foreach (var e in enumerable)
                {
                    yield return e;
                }
            }
        }
        
        public static IEnumerable<int> Range(int start, int stop, int step)
        {
            var current = start;
            yield return start;
            while (true)
            { 
                current += step;
                if (current >= stop  && step > 0)
                    yield break;
                if (current <= stop  && step < 0)
                    yield break;
                
                yield return current;
            }
        }
    }
}