using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace CollectionsSearchPerf
{
    public class CollectionsBench
    {
        private readonly List<Guid> list = new List<Guid>();
        private readonly HashSet<Guid> hashset = new HashSet<Guid>();
        private readonly Dictionary<Guid, Guid> dictionary = new Dictionary<Guid, Guid>();
        private readonly ConcurrentDictionary<Guid, Guid> dictionaryConcurrent = new ConcurrentDictionary<Guid, Guid>();

        private Guid guidToFind;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var random = new Random(DateTime.Now.Millisecond).Next(0, 10000);
            
            for (int i = 1; i <= 10000; i++)
            {
                var guid = Guid.NewGuid();
                if (random == i)
                    guidToFind = guid;
                list.Add(guid);
                hashset.Add(guid);
                dictionary.Add(guid, guid);
                dictionaryConcurrent.TryAdd(guid, guid);
            }
        }


        [Benchmark(OperationsPerInvoke = 5)]
        public bool ContainsInList()
        {
            return list.Contains(guidToFind);
        }

        [Benchmark(OperationsPerInvoke = 5)]
        public bool ContainsListBinary()
        {
            var index = list.BinarySearch(guidToFind);
            return index >= 0;
        }

        [Benchmark(OperationsPerInvoke = 5)]
        public bool ContainsInHash()
        {
            return hashset.Contains(guidToFind);
        }

        [Benchmark(OperationsPerInvoke = 5)]
        public bool ContainsInDictionary()
        {
            return dictionary.ContainsKey(guidToFind);
        }
        [Benchmark(OperationsPerInvoke = 5)]
        public bool ContainsInConcurrentDictionary()
        {
            return dictionaryConcurrent.ContainsKey(guidToFind);
        }
    }
}