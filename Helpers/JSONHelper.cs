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
using System.Diagnostics;
using System.Threading.Tasks;

namespace FluentSysInfo
{

    internal class JSONHelper
    {

        internal string ConvertPowerShellResultToJSON(string Result, bool IgnoreEmptyResults = true)
        {
            try
            {
                return Result;
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }




    }


}
