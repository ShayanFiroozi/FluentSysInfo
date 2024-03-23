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
using System.Collections.Generic;
using System.IO;

namespace FluentSysInfo
{
    internal static class Settings
    {

        internal static string IPAddress { get; private set; }
        internal static int ServicePort { get; private set; }
        internal static string ServiceSecretKey { get; private set; }
        internal static bool UseAuthentication { get; private set; }
        internal static bool FastResponse { get; private set; }
        internal static List<(string AgentName, int FastResponseInterval)> EnabledFastResponseAgents { get; private set; }



        private static IConfiguration ServiceSettings = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "Settings", "ServiceSettings.json"), true, true)
                .Build();



        internal static void LoadServiceSettings()
        {
            IPAddress = ServiceSettings.GetValue("IPAddress", "*");
            ServicePort = ServiceSettings.GetValue("ServicePort", 54800);
            ServiceSecretKey = ServiceSettings.GetValue("ServiceSecretKey", "FluentSysInfoSecretKeyXXX");
            UseAuthentication = ServiceSettings.GetValue("UseAuthentication", "yes") == "yes";
            FastResponse = ServiceSettings.GetValue("FastResponse", "yes") == "yes";

            EnabledFastResponseAgents = GetEnabledFastResponseAgents();
        }

        private static List<(string AgentName, int FastResponseInterval)> GetEnabledFastResponseAgents()
        {
            List<(string AgentName, int FastResponseInterval)> agents = new List<(string AgentName, int FastResponseInterval)>();

            agents.Clear();

            foreach (IConfigurationSection FastResonseAgent in ServiceSettings.GetSection("FastResponseAgents").GetChildren())
            {
                if (FastResonseAgent.GetValue<string>("IsActive") == "yes")
                {
                    int refreshInterval = Convert.ToInt32(FastResonseAgent.GetValue("RefreshInterval", "0").ToLower().Replace("seconds", string.Empty));
                    if (refreshInterval > 0)
                    {
                        agents.Add((FastResonseAgent.Key, refreshInterval));
                    }
                }
            }

            return agents;

        }


    }
}
