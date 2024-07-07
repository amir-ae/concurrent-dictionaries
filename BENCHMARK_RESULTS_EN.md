# Benchmark Results and Analysis

## Introduction

This document provides detailed analysis and commentary on the memory and CPU consumption of two different dictionary implementations: `Concurrent Dictionary` and `Lock-based Dictionary`, under various levels of concurrency.

## Benchmark Results

### Memory Analysis:

| Method               | Concurrency Level | Gen0 Collections | Gen1 Collections | Allocated Memory |
|--------------------- |-----------------:|-----------------:|-----------------:|-----------------:|
| GetRateConcurrent    | 10               |          0.2213  |               -  |        1.81 KB  |
| GetRateLock          | 10               |          0.2213  |               -  |        1.82 KB  |
| GetRateConcurrent    | 100              |          1.9531  |               -  |       15.87 KB  |
| GetRateLock          | 100              |          1.9531  |               -  |       15.88 KB  |
| GetRateConcurrent    | 1000             |         19.5313  |          3.4180  |      156.53 KB  |
| GetRateLock          | 1000             |         19.5313  |          3.1738  |      156.54 KB  |
| GetRateConcurrent    | 10000            |        191.4063  |        105.4688  |    1562.82 KB  |
| GetRateLock          | 10000            |        191.4063  |        109.3750  |    1562.82 KB  |
| UpdateRateConcurrent | 10               |          0.2441  |               -  |        1.99 KB  |
| UpdateRateLock       | 10               |          0.1831  |               -  |        1.53 KB  |
| UpdateRateConcurrent | 100              |          2.1973  |               -  |       18.19 KB  |
| UpdateRateLock       | 100              |          1.6479  |               -  |       13.49 KB  |
| UpdateRateConcurrent | 1000             |         22.4609  |          3.4180  |      179.95 KB  |
| UpdateRateLock       | 1000             |         16.1133  |          2.9297  |      133.08 KB  |
| UpdateRateConcurrent | 10000            |        218.7500  |        109.3750  |    1797.14 KB  |
| UpdateRateLock       | 10000            |        156.2500  |        101.5625  |     1328.4 KB  |

### CPU Analysis:

| Method               | Concurrency Level | Mean Time (us) | StdDev (us) | Operations per Second (Op/s) | Completed Work Items | Lock Contentions |
|--------------------- |-----------------:|---------------:|------------:|-----------------------------:|---------------------:|-----------------:|
| GetRateConcurrent    | 10               |        2.930   |       0.0358|                     341,315.4|                10.0063|              0.0000|
| GetRateLock          | 10               |        3.228   |       0.0412|                     309,761.6|                10.0038|              0.0000|
| GetRateConcurrent    | 100              |       30.208   |       0.1434|                      33,104.1|               100.0001|              0.0005|
| GetRateLock          | 100              |       27.899   |       0.1218|                      35,842.9|               100.0001|              0.0027|
| GetRateConcurrent    | 1000             |      246.232   |       4.5886|                       4,061.2|              1000.0000|              0.0181|
| GetRateLock          | 1000             |      196.717   |       1.1826|                       5,083.5|              1000.0000|              0.0171|
| GetRateConcurrent    | 10000            |    2176.146    |       9.6669|                         459.5|             10000.0000|                   -|
| GetRateLock          | 10000            |    1827.250    |      16.5329|                         547.3|             10000.0000|                   -|
| UpdateRateConcurrent | 10               |        3.104   |       0.0455|                     322,193.9|                10.0263|              0.0001|
| UpdateRateLock       | 10               |        4.796   |       0.0814|                     208,498.6|                10.0037|              0.0002|
| UpdateRateConcurrent | 100              |       34.222   |       0.4387|                      29,220.9|               100.0046|              0.7422|
| UpdateRateLock       | 100              |       48.976   |       0.2207|                      20,418.1|               100.0001|              0.0031|
| UpdateRateConcurrent | 1000             |      279.727   |       3.5623|                       3,574.9|              1000.0000|              8.7139|
| UpdateRateLock       | 1000             |      429.681   |       2.2272|                       2,327.3|              1000.0000|              0.0464|
| UpdateRateConcurrent | 10000            |    2311.348    |      20.3081|                         432.6|             10000.0000|             22.6016|
| UpdateRateLock       | 10000            |    4076.800    |      21.1503|                         245.3|             10000.0000|              0.0859|

## Detailed Analysis

### Memory Consumption:
- **ConcurrentDictionary**:
   - Generally allocates slightly less memory than the lock-based dictionary at lower concurrency levels.
   - At higher concurrency levels (1000 and 10000), both dictionaries allocate a similar amount of memory.
   - Gen0 and Gen1 garbage collections are comparable between the two approaches, though `ConcurrentDictionary` tends to have a bit more Gen0 collections at higher concurrency levels, indicating slightly higher memory churn.

- **Lock-based Dictionary**:
   - Memory allocation is almost on par with `ConcurrentDictionary` at lower concurrency levels.
   - At higher concurrency levels, the memory consumption is similar, though slightly higher in terms of allocated bytes.
   - Slightly fewer Gen0 collections at higher concurrency levels, indicating more efficient memory usage.

### CPU Consumption:
- **ConcurrentDictionary**:
   - Performs better in terms of update operations at all concurrency levels.
   - At very high concurrency levels (1000 and 10000), `ConcurrentDictionary` handles updates much more efficiently.
   - For get operations, it performs well at lower concurrency levels but becomes less efficient at very high concurrency levels compared to the lock-based dictionary.

- **Lock-based Dictionary**:
   - Generally performs better in get operations at high concurrency levels (1000 and 10000).
   - For update operations, it is consistently slower across all concurrency levels compared to `ConcurrentDictionary`.
   - Lock contentions are minimal but do exist, especially noticeable at higher concurrency levels.

## Best Choice
- **Get Operations**:
   - At low to moderate concurrency levels, `ConcurrentDictionary` performs adequately.
   - For very high concurrency levels, the lock-based dictionary might be a better choice for get operations due to its lower mean time and higher throughput.

- **Update Operations**:
   - Across all concurrency levels, `ConcurrentDictionary` is the superior choice for update operations due to its consistently better performance.

## Conclusion
Based on the analysis of memory and CPU consumption, `ConcurrentDictionary` is generally the better choice, especially for applications with frequent updates. However, if your application is read-heavy and operates at very high concurrency levels, a `Lock-based dictionary` might be more efficient for get operations. The decision should be based on the specific usage pattern and concurrency requirements of application.

## Methodology

### Benchmark Setup:

- Benchmarks were conducted using the [BenchmarkDotNet](https://benchmarkdotnet.org/) library.
- Each benchmark was run under three levels of concurrency: 10, 100, 1000, and 10000.
- Measurements included memory allocations, CPU consumption, and operations per second.

### Environment:

- Benchmarks were run on a machine with the following specifications:
  - CPU: AMD Ryzen 9 5980HS
  - RAM: 32 GB
  - OS: Windows 11

For any further details or questions, feel free to open an issue or contact the repository maintainer.
