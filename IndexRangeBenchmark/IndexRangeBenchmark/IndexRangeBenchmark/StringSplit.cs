using BenchmarkDotNet.Attributes;

namespace IndexRangeBenchmark;

[MemoryDiagnoser]
public class StringSplit{
    const int count = 10000;
    readonly string str = "Tokyo city";
    Range range;

    [GlobalSetup]
    public void Setup(){
        range = ..6;
    }

    [Benchmark]
    public void String(){
        for(var i = 0; i < count; i++){
            _ = str[range];
        }
    }
    
    [Benchmark]
    public void Span(){
        var span = str.AsSpan();
        
        for(var i = 0; i < count; i++){
            _ = span[range];
        }
    }
    
    [Benchmark]
    public void SpanToString(){
        var span = str.AsSpan();
        
        for(var i = 0; i < count; i++){
            _ = span[range].ToString();
        }
    }
}
