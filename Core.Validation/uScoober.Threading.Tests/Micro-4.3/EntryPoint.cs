﻿using System.Reflection;
using uScoober.TestFramework;

internal static class EntryPoint
{
    public static void Main() {
        new TestHarness(Assembly.GetExecutingAssembly()).ExecuteTests();
    }
}