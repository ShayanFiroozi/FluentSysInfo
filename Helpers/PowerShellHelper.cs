/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information Service ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

 → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
   https://github.com/dotnet/WatsonWebserver

---------------------------------------------------------------------------------------------*/

using System;
using System.Diagnostics;

namespace FluentSysInfo
{

    internal sealed class PowerShellHelper
    {

        internal string ExecutePowerShellCommandAndGetTheResult(string command, bool AsJSON)
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.FileName = "powershell.exe";
                processStartInfo.Arguments = $"-Command \"{command}\"";
                processStartInfo.UseShellExecute = false;
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processStartInfo.ErrorDialog = false;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.Verb = "runas"; // run as administrator



                using (Process process = new Process())
                {
                    process.StartInfo = processStartInfo;
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();

                    if (!string.IsNullOrWhiteSpace(output))
                    {
                        return AsJSON ? new JsonHelper().ConvertPowerShellResultToJSON(output) : output;
                    }
                    else
                    {
                        return string.Empty;
                    }

                }
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }




    }


}
