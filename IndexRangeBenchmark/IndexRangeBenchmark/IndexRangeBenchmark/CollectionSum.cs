using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace IndexRangeBenchmark;

[MemoryDiagnoser]
public class CollectionSum{
    const int count = 1000000000;
    private long[] array;
    Range range;
    private (int start, int length) offSetAndLength;

    [GlobalSetup]
    public void Setup(){
        range = 1..^1;
        array = Enumerable
                    .Range(0, count)
                    .Select(x => (long)x)
                    .ToArray();
        offSetAndLength = range.GetOffsetAndLength(array.Length);
    }

    [Benchmark]
    public long Array_Foreach(){
        var sum = 0L;
        foreach(var t in array[range]){
            sum += t;
        }

        return sum;
    }
    
    [Benchmark]
    public long Array_For(){
        var sum = 0L;
        var arr = array[range];
        
        for(var i = 0; i < arr.Length; i++){
            sum += arr[i];
        }

        return sum;
    }
    
    [Benchmark]
    public long Span_Foreach(){
        var span = array.AsSpan();
        var sum = 0L;
        foreach(var t in span[range]){
            sum += t;
        }

        return sum;
    }
    
    [Benchmark]
    public long Span_For(){
        var span = array.AsSpan(range);
        var sum = 0L;
        for(var i = 0; i < span.Length; i++){
            sum += span[i];
        }

        return sum;
    }
    
    [Benchmark]
    public long Linq(){
        return array.Skip(offSetAndLength.start)
                    .Take(offSetAndLength.length)
                    .LongCount();
    }
}
