// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using IndexRangeBenchmark;

var switcher = new BenchmarkSwitcher(new[]
{
    typeof(CollectionSum),
    typeof(RangeAccess),
    typeof(StringSplit),
});

args = new[] { "0" };
switcher.Run(args);

Range range = ..6;
string str = "Tokyo city";
var memory = new Memory<char>(str.ToCharArray());
Console.WriteLine(memory[range]);