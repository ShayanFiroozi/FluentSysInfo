
//                         ► Fluent System Information Service ◄


// → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

// → Contact : <shayan.firoozi@gmail.com>

// → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

// → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
//   https://github.com/dotnet/WatsonWebserver

//---------------------------------------------------------------------------------------------*/


using FastLog.Interfaces;
using FluentConsoleNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

///*---------------------------------------------------------------------------------------------
namespace FluentSysInfo
{
    internal static class FastResponseHelper
    {
        private static readonly List<(string AgentName, dynamic FastResponseAgent)> activeAgents = new List<(string AgentName, dynamic FastResponseAgent)>();
        internal static List<(string AgentName, dynamic FastResponseAgent)> ActiveAgents = activeAgents;

        internal static string GetAgentResult(string AgenName)
        {
            if (!ActiveAgents.Exists(a => a.AgentName == AgenName)) return string.Empty;

            return ActiveAgents.Single(a => a.AgentName == AgenName).FastResponseAgent.Result;
        }

        internal static void StartAllFastResponseAgents()
        {

            _ = (FastLogger.logger?.LogInfo("Initializing Fast Response Agents..."));

            foreach ((string AgentName, int FastResponseInterval) Agent in Settings.EnabledFastResponseAgents)
            {
                if (Agent.FastResponseInterval > 0)
                {
                    StartFastResponseAgent(Agent.AgentName, Agent.FastResponseInterval);
                }
            }

            _ = (FastLogger.logger?.LogInfo("Fast Response initialization finished..."));

        }


        private static void StartFastResponseAgent(string AgentName, int FastResponseInterval)
        {
            // Activate the FastRespone agent with Agent Name got from the Setting file

            // Using Reflection with generic methods and types..👇


            Type sysInfoType = Type.GetType($"{Assembly.GetExecutingAssembly().GetName().Name}.{AgentName}");

            Type fastResponseType = typeof(FastResponseInfo<>).MakeGenericType(sysInfoType);

            dynamic AgentInstance = Activator.CreateInstance(fastResponseType, TimeSpan.FromSeconds(FastResponseInterval));


            AgentInstance.StartFastResponse();

            ActiveAgents.Add((AgentName, AgentInstance));

            _ = (FastLogger.logger?.LogSystem($"FastResponse agent {AgentName} has been started with interval of {FastResponseInterval:N0} second(s)."));


        }



    }
}

