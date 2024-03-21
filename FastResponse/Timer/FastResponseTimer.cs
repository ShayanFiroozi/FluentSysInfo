using System;
using System.Timers;

namespace FluentSysInfo
{
    internal class FastResponseTimer
    {
        private Timer Timer;

        private readonly int Interval = 5_000; // Millisecond(s)

        private readonly Func<string> CallbackFunction;

        internal event EventHandler<string> OnTimerExecution;

        internal bool? IsRunning => Timer?.Enabled;

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
            OnTimerExecution?.Invoke(null, CallbackFunction());
        }

        internal void StopTimer()
        {
            Timer.Enabled = false;
            Timer.Stop();
        }


    }
}
