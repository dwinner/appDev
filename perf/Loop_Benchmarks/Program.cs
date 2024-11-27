using BenchmarkDotNet.Running;

namespace Loop_Benchmarks;

public class Program
{
   public static void Main(string[] args)
   {
      // If arguments are available use BenchmarkSwitcher to run benchmarks
      if (args.Length > 0)
      {
         _ = BenchmarkSwitcher
            .FromAssembly(typeof(Program).Assembly)
            .Run(args, BenchmarkConfig.Get());
         return;
      }

      // Else, use BenchmarkRunner
      _ = BenchmarkRunner.Run<LoopBenchmarks>(BenchmarkConfig.Get());
   }
}