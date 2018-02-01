# CollectionsSearchPerf
Perfomance becnh for collections and contains search

## Results

```
// * Summary *

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.192)
Intel Core i5-3337U CPU 1.80GHz (Ivy Bridge), 1 CPU, 4 logical cores and 2 physical cores
Frequency=1753823 Hz, Resolution=570.1830 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2600.0  [AttachedDebugger]
  DefaultJob : .NET Framework 4.7 (CLR 4.0.30319.42000), 32bit LegacyJIT-v4.7.2600.0


                         Method |         Mean |       Error |        StdDev |        Median |
------------------------------- |-------------:|------------:|--------------:|--------------:|
                 ContainsInList | 27,114.67 ns | 862.5803 ns | 2,502.5018 ns | 26,454.518 ns |
             ContainsListBinary |     36.40 ns |   1.9860 ns |     5.8557 ns |     35.308 ns |
                 ContainsInHash |     13.15 ns |   0.2764 ns |     0.4617 ns |     13.150 ns |
           ContainsInDictionary |     10.59 ns |   0.6305 ns |     1.8590 ns |      9.949 ns |
 ContainsInConcurrentDictionary |     11.63 ns |   0.4413 ns |     1.2733 ns |     11.162 ns |

```
