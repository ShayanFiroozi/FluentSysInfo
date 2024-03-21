using System;
using System.Threading;

namespace FluentSysInfo
{
    internal static class RunningProcessesFastResponse
    {

        private static string result;
        public static string Result
        {
            get
            {
                try
                {

                    GainReadLock();
                    return result;
                }
                finally
                {
                    ReleaseReadLock();
                }
            }

            set
            {
                try
                {
                    GainWriteLock();
                    result = value;
                }
                finally
                {
                    ReleaseWriteLock();
                }
            }

        }

        private static FastResponseTimer timer = new FastResponseTimer(5_000, () => new SysInfoRunningProcesses().GetRunningProcessesInfo());

        public static void StartFastResponse()
        {
            timer.OnTimerExecution += Timer_OnTimerExecution;
            timer.StartTimer();
        }

        private static void Timer_OnTimerExecution(object sender, string e)
        {
            // Getting the Result data from the SysInfo functions.
            Result = e;
        }

        public static void StopFastResponse()
        {
            timer.StopTimer();
            timer.OnTimerExecution -= Timer_OnTimerExecution;
        }

        #region SlimLock Helpers
        private static readonly ReaderWriterLockSlim SlimLock = new ReaderWriterLockSlim();


        private static void GainReadLock() => SlimLock.EnterReadLock();
        private static void GainWriteLock() => SlimLock.EnterWriteLock();


        private static void ReleaseReadLock() => SlimLock.ExitReadLock();
        private static void ReleaseWriteLock() => SlimLock.ExitWriteLock();
        #endregion



    }
}
