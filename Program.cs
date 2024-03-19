/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information Service ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

 → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
   https://github.com/dotnet/WatsonWebserver

---------------------------------------------------------------------------------------------*/


using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
using System.Threading;

namespace FluentSysInfo
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            // Catch global exceptions !
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;


            Console.Title = "FluentSysInfo Service";


            // Necessary to force the system to use "US Standard DateTime"
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");



            // Initialize the Fast Logger agent  
            try
            {
                FastLogger.InitializeLogger(AppContext.BaseDirectory);
            }
            catch
            {
                // Ignore the logger initialization and continue to run the service without logging meachanism !
            }


            // Build up and host the service

            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddHostedService<Worker>();

            IHost host = builder.Build();
            host.Run();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ExceptionHandler.HandleException((Exception)e.ExceptionObject);
        }


    }
}