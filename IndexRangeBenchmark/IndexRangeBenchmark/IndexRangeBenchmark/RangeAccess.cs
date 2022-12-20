using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace IndexRangeBenchmark;

[MemoryDiagnoser]
public class RangeAccess{
    const int count = 10000;
    private long[] array;
    private Memory<long> memory;
    
    [GlobalSetup]
    public void Setup(){
        array = Enumerable
                .Range(0, count)
                .Select(x => (long)x)
                .ToArray();
        memory = array.AsMemory();
    }

    [Benchmark]
    public void Array(){
        for(var i = 0; i < count; i++){
            _ = array[i..].Length;
        }
    }
    
    [Benchmark]
    public void Span(){
        var span = memory.Span;
        for(var i = 0; i < count; i++){
            _ = span[i..];
        }
    }
}
