/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information Service ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

 → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
   https://github.com/dotnet/WatsonWebserver

---------------------------------------------------------------------------------------------*/

using System;
using System.Threading;

namespace FluentSysInfo
{
    internal sealed partial class FastResponseInfo<T> where T : ISysInfo, new()
    {

        private readonly ReaderWriterLockSlim SlimLock = new ReaderWriterLockSlim();

        private string result;
        public string Result
        {
            get
            {
                try
                {

                    SlimLock.EnterReadLock();
                    return result;
                }
                finally
                {
                    SlimLock.ExitReadLock();
                }
            }

            set
            {
                try
                {
                    SlimLock.EnterWriteLock();
                    result = value;
                }
                finally
                {
                    SlimLock.ExitWriteLock();
                }
            }

        }


        private FastResponseTimer timer;

        public FastResponseInfo(TimeSpan interval)
        {
            timer = new FastResponseTimer(interval);
        }

        public void StartFastResponse()
        {
            timer.OnTimerExecution += Timer_OnTimerExecution;
            timer.StartTimer();
        }

        private void Timer_OnTimerExecution(object sender, string e)
        {
            // Getting the Result data from the SysInfo functions.
            Result = e;
        }

        public void StopFastResponse()
        {
            timer.StopTimer();
            timer.OnTimerExecution -= Timer_OnTimerExecution;
        }






    }
}
