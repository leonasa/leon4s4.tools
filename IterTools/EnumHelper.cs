using System;
using System.Collections.Generic;
using System.Linq;


namespace IterTools
{
    public static class EnumHelper
    {
        public static IEnumerable<int> Accumulated(IEnumerable<int> arr, int start = 0)
        {
            var enumerable = arr.ToList();
            var total = 0;
            foreach (var t in enumerable)
            {
                total += t;
                yield return total;
            }
        }  
        
        public static IEnumerable<T> DropWhile<T>(IEnumerable<T> arr, Func<T,bool> func)
        {
            using (var enumerator = arr.GetEnumerator())
            {
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

    public class Tools
    {
        public static IEnumerable<T> Repeat<T>(T toRepeat, int? times = null)
        {
            if (times == null)
                while (true)
                    yield return toRepeat;

            for (int i = 0; i < times; i++)
                yield return toRepeat;
        }

        public static IEnumerable<T> Chain<T>(params IEnumerable<T>[] it)
        {
            foreach (var enumerable in it)
            foreach (var item in enumerable)
                yield return item;
        }
        
//    def permutations(iterable, r=None):
//    pool = tuple(iterable)
//    n = len(pool)
//    r = n if r is None else r
//    for indices in product(range(n), repeat=r):
//        if len(set(indices)) == r:
//            yield tuple(pool[i] for i in indices)
        public static IEnumerable<IEnumerable<T>> Permutations<T>(IEnumerable<T> enumerable, int? numberOfItems)
        {
            var pool = enumerable.ToList();
            var n = pool.Count;
            var r = numberOfItems ?? n;

            foreach (var indices in Product(Enumerable.Range(0, n).ToList(), r).Select(id=>id.ToList()).ToList())
            {
                var hashedIndices = new HashSet<int>(indices);
                if (hashedIndices.Count == r)
                {
                    var permutations = indices.Select(i => pool[i]);
                    yield return permutations;
                }
            }
        }

        public static IEnumerable<IEnumerable<T>> Product<T>(params IEnumerable<T>[] pools)
        {
            var result = new List<List<T>> {new List<T>()};

            foreach (var pool in pools.Select(p=>p.ToList()))
            {
                var nResult = new List<List<T>>();
                
                foreach (var x in result)
                {
                    foreach (var y in pool)
                    {
                        var tt = new List<T>();
                        tt.AddRange(x);
                        tt.Add(y);
                        nResult.Add(tt);
                    }
                }

                result = nResult;
            }

            foreach (var res in result)
            {
                yield return res;
            }
        }


        public static IEnumerable<IEnumerable<T>> Product<T>(IEnumerable<T> it, int repeat)
        {
            var pools = Enumerable.Range(0, repeat).Select(i => it).ToArray();

            var enumerable = Product(pools);
            foreach (var p in enumerable)
                yield return p;
        }

//    def combinations(iterable, r):
//    pool = tuple(iterable)
//    n = len(pool)
//    for indices in permutations(range(n), r):
//        if sorted(indices) == list(indices):
//            yield tuple(pool[i] for i in indices)
        public static IEnumerable<IEnumerable<T>> Combination<T>(IEnumerable<T> it, int r)
        {
            var pool = it.ToList();
            var n = pool.Count;
            foreach (var indices in Permutations(Enumerable.Range(0, n), r).Select(i=>i.ToList()))
            {
                var sortedIndices = indices.OrderBy(c => c);
                if (sortedIndices.SequenceEqual(indices))
                {
                    yield return indices.Select(i => pool[i]);
                }
            }
        }
    }

    public static class ToolsStatics
    {
        public static IEnumerable<int> Accumulated(this IEnumerable<int> arr, int start = 0)
        {
            var enumerable = arr.ToList();
            var total = 0;
            for (var i = 0; i < enumerable.Count; i++)
            {
                total = enumerable[i] + total;
                yield return total;
            }
        }
    }
}