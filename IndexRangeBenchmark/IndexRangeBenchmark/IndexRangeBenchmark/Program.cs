// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using IndexRangeBenchmark;

// BenchmarkRunner.Run<CollectionSum>();
// var r = new CollectionSum();

var switcher = new BenchmarkSwitcher(new[]
{
    typeof(CollectionSum),
    typeof(RangeAccess),
});

args = new[] { "0" };
switcher.Run(args);