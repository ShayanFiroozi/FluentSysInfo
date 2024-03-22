/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information Service ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

 → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
   https://github.com/dotnet/WatsonWebserver

---------------------------------------------------------------------------------------------*/

using System;
using System.Timers;

namespace FluentSysInfo
{
    internal sealed class FastResponseTimer
    {
        private Timer Timer;

        private readonly int Interval;

        private readonly Func<string> CallbackFunction;

        internal event EventHandler<string> OnTimerExecution;

    
        internal FastResponseTimer(int Interval, Func<string> CallbackFunction)
        {
            this.Interval = Interval;
            this.CallbackFunction = CallbackFunction;
        }

        internal void StartTimer()
        {
            Timer = new Timer(Interval);


            Timer.Elapsed += Timer_Elapsed;
            Timer.Enabled = true;
            Timer.AutoReset = true;
            Timer.Start();

            // Call the CallBackFunction for the first time
            Timer_Elapsed(null, null);
        }


        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnTimerExecution?.Invoke(sender, CallbackFunction());
        }

        internal void StopTimer()
        {
            Timer.Enabled = false;
            Timer.Stop();
        }


    }
}
