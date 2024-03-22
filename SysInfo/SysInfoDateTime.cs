/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information Service ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

 → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
   https://github.com/dotnet/WatsonWebserver

---------------------------------------------------------------------------------------------*/


using FluentSysInfo.Interfaces;
using System;

namespace FluentSysInfo
{
    internal class SysInfoDateTime : ISysInfo
    {

        public int NumberOfProperties => 7;

        public string GetInfo()
        {
            return $"{GetDateTime()},{GetDateTimeUTC()},{GetDate()},{GetTime()},{GetLongDate()},{GetDayOfWeek()},{GetFullDateTime()}";
        }


        private string GetDateTime() => DateTime.Now.ToString().Replace(',', ' ');

        private string GetDateTimeUTC() => DateTime.UtcNow.ToString().Replace(',', ' ');



        private string GetDate() => DateTime.Now.ToShortDateString().Replace(',', ' ');
        private string GetLongDate() => DateTime.Now.ToLongDateString().Replace(',', ' ');



        private string GetTime() => DateTime.Now.ToLongTimeString().Replace(',', ' ');

        private string GetDayOfWeek() => DateTime.Now.DayOfWeek.ToString().Replace(',', ' ');


        private string GetFullDateTime() => $"{GetLongDate().Replace(',', ' ')}  {GetTime().Replace(',', ' ')}";


    }
}
