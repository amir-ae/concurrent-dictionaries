```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3737/23H2/2023Update/SunValley3)
AMD Ryzen 9 5980HS with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2


```
| Method               | ConcurrencyLevel | Mean         | Error      | StdDev     | P95          | P90          | P85          | Op/s      | Gen0     | Completed Work Items | Lock Contentions | Gen1     | Allocated  |
|--------------------- |----------------- |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|----------:|---------:|---------------------:|-----------------:|---------:|-----------:|
| **GetRateConcurrent**    | **10**               |     **2.930 μs** |  **0.0383 μs** |  **0.0358 μs** |     **2.986 μs** |     **2.974 μs** |     **2.958 μs** | **341,315.4** |   **0.2213** |              **10.0063** |           **0.0000** |        **-** |    **1.81 KB** |
| GetRateLock          | 10               |     3.228 μs |  0.0441 μs |  0.0412 μs |     3.300 μs |     3.288 μs |     3.275 μs | 309,761.6 |   0.2213 |              10.0038 |           0.0000 |        - |    1.82 KB |
| **GetRateConcurrent**    | **100**              |    **30.208 μs** |  **0.1533 μs** |  **0.1434 μs** |    **30.388 μs** |    **30.379 μs** |    **30.367 μs** |  **33,104.1** |   **1.9531** |             **100.0001** |           **0.0005** |        **-** |   **15.87 KB** |
| GetRateLock          | 100              |    27.899 μs |  0.1302 μs |  0.1218 μs |    28.072 μs |    28.061 μs |    28.045 μs |  35,842.9 |   1.9531 |             100.0001 |           0.0027 |        - |   15.88 KB |
| **GetRateConcurrent**    | **1000**             |   **246.232 μs** |  **4.6721 μs** |  **4.5886 μs** |   **251.411 μs** |   **251.015 μs** |   **250.629 μs** |   **4,061.2** |  **19.5313** |            **1000.0000** |           **0.0181** |   **3.4180** |  **156.53 KB** |
| GetRateLock          | 1000             |   196.717 μs |  1.2643 μs |  1.1826 μs |   198.209 μs |   198.135 μs |   198.043 μs |   5,083.5 |  19.5313 |            1000.0000 |           0.0171 |   3.1738 |  156.54 KB |
| **GetRateConcurrent**    | **10000**            | **2,176.146 μs** | **10.9049 μs** |  **9.6669 μs** | **2,188.787 μs** | **2,186.142 μs** | **2,185.036 μs** |     **459.5** | **191.4063** |           **10000.0000** |                **-** | **105.4688** | **1562.82 KB** |
| GetRateLock          | 10000            | 1,827.250 μs | 17.6747 μs | 16.5329 μs | 1,848.739 μs | 1,843.957 μs | 1,843.478 μs |     547.3 | 191.4063 |           10000.0000 |                - | 109.3750 | 1562.82 KB |
| **UpdateRateConcurrent** | **10**               |     **3.104 μs** |  **0.0486 μs** |  **0.0455 μs** |     **3.176 μs** |     **3.160 μs** |     **3.152 μs** | **322,193.9** |   **0.2441** |              **10.0263** |           **0.0001** |        **-** |    **1.99 KB** |
| UpdateRateLock       | 10               |     4.796 μs |  0.0870 μs |  0.0814 μs |     4.890 μs |     4.849 μs |     4.847 μs | 208,498.6 |   0.1831 |              10.0037 |           0.0002 |        - |    1.53 KB |
| **UpdateRateConcurrent** | **100**              |    **34.222 μs** |  **0.4689 μs** |  **0.4387 μs** |    **34.921 μs** |    **34.760 μs** |    **34.678 μs** |  **29,220.9** |   **2.1973** |             **100.0046** |           **0.7422** |        **-** |   **18.19 KB** |
| UpdateRateLock       | 100              |    48.976 μs |  0.2827 μs |  0.2207 μs |    49.212 μs |    49.186 μs |    49.183 μs |  20,418.1 |   1.6479 |             100.0001 |           0.0031 |        - |   13.49 KB |
| **UpdateRateConcurrent** | **1000**             |   **279.727 μs** |  **3.8084 μs** |  **3.5623 μs** |   **285.376 μs** |   **284.940 μs** |   **284.294 μs** |   **3,574.9** |  **22.4609** |            **1000.0000** |           **8.7139** |   **3.4180** |  **179.95 KB** |
| UpdateRateLock       | 1000             |   429.681 μs |  2.5125 μs |  2.2272 μs |   432.825 μs |   431.826 μs |   431.605 μs |   2,327.3 |  16.1133 |            1000.0000 |           0.0464 |   2.9297 |  133.08 KB |
| **UpdateRateConcurrent** | **10000**            | **2,311.348 μs** | **24.3197 μs** | **20.3081 μs** | **2,334.733 μs** | **2,334.274 μs** | **2,333.198 μs** |     **432.6** | **218.7500** |           **10000.0000** |          **22.6016** | **109.3750** | **1797.14 KB** |
| UpdateRateLock       | 10000            | 4,076.800 μs | 22.6109 μs | 21.1503 μs | 4,111.300 μs | 4,109.427 μs | 4,106.783 μs |     245.3 | 156.2500 |           10000.0000 |           0.0859 | 101.5625 |  1328.4 KB |
