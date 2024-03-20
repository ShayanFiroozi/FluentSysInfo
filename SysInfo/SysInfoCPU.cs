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
    internal class SysInfoCPU
    {


        internal CPUModel GetCPUInfo()
        {
            try
            {
                ManagementObject cpuInfo = new ManagementObjectSearcher("select * from Win32_Processor")
                         .Get()
                         .Cast<ManagementObject>()
                         .First();

                return new CPUModel(cpuInfo["ProcessorId"].ToString(),
                                    cpuInfo["SocketDesignation"].ToString(),
                                    cpuInfo["Name"].ToString(),
                                    cpuInfo["Caption"].ToString(),
                                    cpuInfo["AddressWidth"].ToString(),
                                    cpuInfo["DataWidth"].ToString(),
                                    cpuInfo["Architecture"].ToString(),
                                    cpuInfo["MaxClockSpeed"].ToString(),
                                    cpuInfo["ExtClock"].ToString(),
                                    ((uint)cpuInfo["L2CacheSize"] * (ulong)1024).ToString(),
                                    ((uint)cpuInfo["L3CacheSize"] * (ulong)1024).ToString(),
                                    cpuInfo["NumberOfCores"].ToString(),
                                    cpuInfo["NumberOfLogicalProcessors"].ToString(),
                                    cpuInfo["Manufacturer"].ToString(),
                                    cpuInfo["LoadPercentage"].ToString(),
                                    cpuInfo["VirtualizationFirmwareEnabled"].ToString());

            }
            catch
            {
                // Return CPU Model with "N/A" values !
                return new CPUModel();
            }
        }


    }
}
