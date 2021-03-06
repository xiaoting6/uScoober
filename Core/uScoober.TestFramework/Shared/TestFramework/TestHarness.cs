﻿using System;
using System.Reflection;
using System.Threading;
using Microsoft.SPOT;
using uScoober.TestFramework.Core;
using uScoober.TestFramework.Output;

namespace uScoober.TestFramework
{
    public static class TestHarness
    {
        public static void RunTests(Assembly assembly,
                                    IRunnerUserInput input = null,
                                    IRunnerResultProcessor output = null,
                                    string logDirectory = null,
                                    bool showGcMessages = false) {
            if (assembly == null) {
                throw new ArgumentNullException("assembly");
            }
            Debug.EnableGCMessages(showGcMessages);

            var dispatch = new FeedbackDispatcher();
            if (output != null) {
                dispatch.Add(output);
            }
            dispatch.Add(new FeedbackToDebug());
            if (BuildAutomation.InBuild) {
                dispatch.Add(new FeedbackToLogFiles());
            }
            else if (logDirectory != null) {
                dispatch.Add(new FeedbackToLogFiles(logDirectory));
            }

            TestRunner runner = new TestRunner(assembly, input, dispatch);
            runner.ExecuteTests()
                  .Wait();

            if (!BuildAutomation.InBuild) {
                Thread.Sleep(Timeout.Infinite);
            }
            else {
                Thread.CurrentThread.Abort();
                //TaskScheduler.UnusedThreadTimeoutMilliseconds = 10;
                //Task.Run(() => { });
            }

            //todo: handle shutting down of emulator!
        }
    }
}