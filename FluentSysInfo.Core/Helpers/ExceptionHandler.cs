/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information Service ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

 → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
   https://github.com/dotnet/WatsonWebserver

---------------------------------------------------------------------------------------------*/

using FluentConsoleNet;
using System;
using System.Threading.Tasks;

namespace FluentSysInfo.Core
{

    internal static class ExceptionHandler
    {
        internal static void HandleException(Exception exception, int EventId = 0, int WaitForSeconds = 5)
        {
            if (exception == null)
            {
                return;
            }

            if (FastLogger.logger != null)
            {
                _ = FastLogger.logger.LogException(exception, EventId);
            }


            FastConsole.PrintException(exception);

            FastLogger.logger?.ProcessAllEventsInQueue().GetAwaiter().GetResult();

            Task.Delay(WaitForSeconds * 1_000).GetAwaiter().GetResult();


        }
    }


}
