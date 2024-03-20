/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information Service ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

 → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
   https://github.com/dotnet/WatsonWebserver

---------------------------------------------------------------------------------------------*/


using System;
using System.Linq;
using System.Management;
using System.Runtime.Versioning;

namespace FluentSysInfo
{
    internal class SysInfoOS
    {



        internal string GetMachineName()
        {
            try
            {
                return !string.IsNullOrWhiteSpace(Environment.MachineName)
                    ? Environment.MachineName
                    : "N/A";
            }
            catch
            {
                return "N/A";
            }
        }


        internal string GetCurrentUserName()
        {
            try
            {
                return !string.IsNullOrWhiteSpace(Environment.UserName)
                    ? Environment.UserName
                    : "N/A";
            }
            catch
            {
                return "N/A";
            }
        }


        internal string GetOSInfo()
        {
            try
            {
                return Environment.OSVersion != null
                ? $"{Environment.OSVersion?.ToString()} ({GetOSArchitecture()})"
                : "N/A";
            }
            catch
            {
                return "N/A";
            }
        }


        internal string GetOSSerialNumber()
        {
            ManagementObject wmi = null;
            try
            {
                wmi = new ManagementObjectSearcher("select * from Win32_OperatingSystem")
                   .Get()
                   .Cast<ManagementObject>()
                   .First();

                string serialNumber = (string)wmi["SerialNumber"];

                return !string.IsNullOrWhiteSpace(serialNumber) ? serialNumber : "N/A";
            }
            catch
            {
                return "N/A";
            }

            finally
            {
                wmi.Dispose();
            }

        }


        private string GetOSArchitecture() => Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit";

    }
}
