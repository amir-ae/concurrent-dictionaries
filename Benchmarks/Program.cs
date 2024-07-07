using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;

namespace Benchmarks;

public class Program
{
    static void Main(string[] args)
    {
        var config = ManualConfig.Create(DefaultConfig.Instance)
            .AddDiagnoser(MemoryDiagnoser.Default)
            .AddDiagnoser(ThreadingDiagnoser.Default)
            .AddColumn(StatisticColumn.P95)
            .AddColumn(StatisticColumn.P90)
            .AddColumn(StatisticColumn.P85)
            .AddColumn(StatisticColumn.OperationsPerSecond);

        BenchmarkRunner.Run<Benchmarks>(config);
    }
}