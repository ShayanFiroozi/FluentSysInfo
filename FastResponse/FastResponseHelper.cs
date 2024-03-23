
//                         ► Fluent System Information Service ◄


// → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

// → Contact : <shayan.firoozi@gmail.com>

// → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

// → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
//   https://github.com/dotnet/WatsonWebserver

//---------------------------------------------------------------------------------------------*/


using FluentConsoleNet;
using System;
using System.Collections.Generic;
using System.Linq;

///*---------------------------------------------------------------------------------------------
namespace FluentSysInfo
{
    internal static class FastResponseHelper
    {

        internal static List<(string AgentName, dynamic FastResponseAgent)> ActiveAgents = new List<(string AgentName, dynamic FastResponseAgent)>();

        internal static string GetAgentResult(string AgenName)
        {
            if (!ActiveAgents.Any(a => a.AgentName == AgenName)) return string.Empty;

            return ActiveAgents.Single(a => a.AgentName == AgenName).FastResponseAgent.Result;
        }

        internal static void StartAllFastResponseAgents()
        {

            foreach ((string AgentName, int FastResponseInterval) agent in Settings.EnabledFastResponseAgents)
            {
                if (agent.FastResponseInterval > 0)
                {
                    // Activate the FastRespone agent with Agent Name got from the Setting file

                    // Using Reflection with generic methods and types..👇


                    Type sysInfoType = Type.GetType($"FluentSysInfo.{agent.AgentName}");

                    Type fastResponseType = typeof(FastResponseInfo<>).MakeGenericType(new Type[] { sysInfoType });

                    dynamic AgentInstance = Activator.CreateInstance(fastResponseType, TimeSpan.FromSeconds(agent.FastResponseInterval));


                    AgentInstance.StartFastResponse();

                    ActiveAgents.Add((agent.AgentName, AgentInstance));

                    _ = (FastLogger.logger?.LogSystem(
                              $"FastResponse agent {agent.AgentName} has been started with interval of {agent.FastResponseInterval:N0} second(s)."));


                }
            }

        }




    }
}

