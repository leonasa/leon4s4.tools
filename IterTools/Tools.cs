using System;
using System.Collections.Generic;
using System.Linq;

namespace IterTools
{
    public static class Tools
    {
        public static IEnumerable<T> Repeat<T>(T toRepeat, int? times = null)
        {
            if (times == null)
                while (true)
                    yield return toRepeat;

            for (int i = 0; i < times; i++)
                yield return toRepeat;
        }

    //def imap(function, * iterables):
    //# imap(pow, (2,3,10), (5,2,3)) --> 32 9 1000
    //iterables = map(iter, iterables)
    //while True:
    //    args = [next(it) for it in iterables]
    //    if function is None:
    //        yield tuple(args)
    //    else:
    //        yield function(*args)

        public static IEnumerable<T> IMap<T>(Func<T, T> func, params IEnumerable<T>[] it)
        {
            foreach (var enumerable in it)
            foreach (var item in enumerable)
                yield return item;
        }

        public static IEnumerable<T> Chain<T>(params IEnumerable<T>[] it)
        {
            foreach (var enumerable in it)
            foreach (var item in enumerable)
                yield return item;
        }
        
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
}