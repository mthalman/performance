﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using BenchmarkDotNet.Attributes;

namespace System.MathBenchmarks
{
    public partial class Double
    {
        // Tests Math.Sinh(double) over 5000 iterations for the domain -1, +1

        private const double sinhDelta = 0.0004;
        private const double sinhExpectedResult = 1.17520119337903;

        [Benchmark]
        public void Sinh() => SinhTest();

        public static void SinhTest()
        {
            var result = 0.0; var value = -1.0;

            for (var iteration = 0; iteration < MathTests.Iterations; iteration++)
            {
                value += sinhDelta;
                result += Math.Sinh(value);
            }

            var diff = Math.Abs(sinhExpectedResult - result);

            if (diff > MathTests.DoubleEpsilon)
            {
                throw new Exception($"Expected Result {sinhExpectedResult,20:g17}; Actual Result {result,20:g17}");
            }
        }
    }
}