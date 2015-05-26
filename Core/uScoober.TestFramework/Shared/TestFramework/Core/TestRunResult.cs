using System;
using System.Diagnostics;
using System.Text;
using uScoober.DataStructures;

namespace uScoober.TestFramework.Core
{
    public class TestRunResult : DisposableBase
    {
        private readonly List _failures = new List();

        public TestRunResult() {
            RunStarted = DateTime.Now;
        }

        public double DurationOfExecution { get; private set; }

        public double DurationOfSetup { get; private set; }

        public double DurationOfTeardown { get; private set; }

        public string DurationSummary {
            get {
                var builder = new StringBuilder(10);
                double executionTime = DurationOfSetup + DurationOfExecution + DurationOfTeardown;
                if (executionTime < 60) {
                    builder.Append("0:");
                }
                else {
                    var minutes = (int)(executionTime / 60);
                    builder.Append(minutes);
                    builder.Append(":");
                    executionTime -= (minutes * 60);
                }

                if (executionTime < 10) {
                    builder.Append("0");
                }
                builder.Append(executionTime.ToString("F4"));
                return builder.ToString();
            }
        }

        public int FailedCount { get; private set; }

        public List Failures {
            get { return _failures; }
        }

        public bool IsComplete { get; private set; }

        public int PassedCount { get; private set; }

        public DateTime RunFinished { get; private set; }

        public DateTime RunStarted { get; private set; }

        [DebuggerStepThrough]
        public void Record(TestCaseResult result) {
            if (result.Passed) {
                PassedCount++;
            }
            else {
                FailedCount++;
                _failures.Add(result);
            }
            DurationOfSetup += result.DurationOfSetup;
            DurationOfExecution += result.DurationOfTest;
            DurationOfTeardown += result.DurationOfTeardown;
        }

        public void TestingComplete() {
            RunFinished = DateTime.Now;
            IsComplete = true;
        }

        protected override void DisposeManagedResources() {
            _failures.Clear();
        }
    }
}