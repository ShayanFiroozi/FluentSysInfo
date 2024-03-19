/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information Service ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

 → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
   https://github.com/dotnet/WatsonWebserver

---------------------------------------------------------------------------------------------*/


using System;

namespace FluentSysInfo
{
    internal class SysInfoDateTime
    {

    
        internal string GetDateTime() => DateTime.Now.ToString();

        internal string GetDateTimeUTC() => DateTime.UtcNow.ToString();


  
        internal string GetDate() => DateTime.Now.ToShortDateString();
        internal string GetLongDate() => DateTime.Now.ToLongDateString();


   
        internal string GetTime() => DateTime.Now.ToLongTimeString();
        internal string GetShortTime() => DateTime.Now.ToShortTimeString();


        internal string GetFullDateTime() => $"{GetLongDate()}  {GetTime()}";

    }
}
