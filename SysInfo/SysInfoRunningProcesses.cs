﻿/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information Service ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

 → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
   https://github.com/dotnet/WatsonWebserver

---------------------------------------------------------------------------------------------*/

namespace FluentSysInfo
{
    internal class SysInfoRunningProcesses
    {


        internal string GetRunningProcessesInfo(bool WithDetails = false)
        {
            if (WithDetails)
            {
                return new PowerShellHelper()
                .ExecutePowerShellCommandAndGetTheResult("Get-CimInstance -Class CIM_Process -ErrorAction Stop | Select-Object *", true);
            }
            else
            {
                return new PowerShellHelper()
                .ExecutePowerShellCommandAndGetTheResult("Get-CimInstance -Class CIM_Process -ErrorAction Stop", true);
            }
        }


    }
}
