/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information Service ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

 → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
   https://github.com/dotnet/WatsonWebserver

---------------------------------------------------------------------------------------------*/

using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace FluentSysInfo
{
    internal static class Settings
    {

        internal static string IPAddress { get; private set; }
        internal static int ServicePort { get; private set; }
        internal static string ServiceSecretKey { get; private set; }
        internal static bool UseAuthentication { get; private set; }



        private static IConfiguration ServiceSettings = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "Settings", "ServiceSettings.json"), true, true)
                .AddUserSecrets<Program>()
                .Build();



        internal static void LoadServiceSettings()
        {
            IPAddress = ServiceSettings.GetValue("IPAddress", "*");
            ServicePort = ServiceSettings.GetValue("ServicePort", 54800);
            ServiceSecretKey = ServiceSettings.GetValue("ServiceSecretKey", "FluentSysInfoSecretKeyXXX");
            UseAuthentication = ServiceSettings.GetValue("UseAuthentication", true);
        }


    }
}
