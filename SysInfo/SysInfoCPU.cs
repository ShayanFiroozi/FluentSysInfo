﻿/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information Service ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

 → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
   https://github.com/dotnet/WatsonWebserver

---------------------------------------------------------------------------------------------*/

using FluentSysInfo.Interfaces;

namespace FluentSysInfo
{
    internal class SysInfoCpu : ISysInfo
    {


        public string GetInfo()
        {
            return new PowerShellHelper()
                         .ExecutePowerShellCommandAndGetTheResult("Get-CimInstance -Class CIM_Processor -ErrorAction Stop | Select-Object *", true);
        }


    }
}
