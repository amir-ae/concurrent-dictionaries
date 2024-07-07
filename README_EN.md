# Concurrent Dictionaries

## Overview

The purpose of this benchmarking task is to compare the performance of `Concurrent Dictionary` and a `Lock-based Dictionary` implementation in .NET under various levels of concurrency. Understanding the performance characteristics of these data structures is crucial for optimizing concurrent applications.

## Repository Structure

- **Library**: This project contains the implementation of the concurrent and lock-based dictionaries.
  - `ConcurrentRateDictionary.cs`: Implementation of a dictionary optimized for concurrent operations.
  - `LockBasedRateDictionary.cs`: Implementation of a dictionary using traditional locking mechanisms.

- **Benchmarks**: This project contains the benchmarks for evaluating the performance of the dictionaries.
  - `Benchmarks.cs`: Benchmarks for the dictionaries' get and update operations under various levels of concurrency.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [BenchmarkDotNet](https://benchmarkdotnet.org/) library

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/amir-ae/concurrent-dictionaries.git
    cd concurrent-dictionaries
    ```

2. Restore the dependencies:
    ```sh
    dotnet restore
    ```

### Running the Benchmarks

To run the benchmarks, navigate to the `Benchmarks` project folder and use the following command:
```sh
cd Benchmarks
dotnet run -c Release
```

## Benchmark Results
For detailed benchmark results and analysis, refer to the [BENCHMARK_RESULTS](BENCHMARK_RESULTS_EN.md).
