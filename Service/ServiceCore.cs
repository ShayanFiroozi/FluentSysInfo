﻿/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information Service ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

 → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
   https://github.com/dotnet/WatsonWebserver

---------------------------------------------------------------------------------------------*/


using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using WatsonWebserver;
using WatsonWebserver.Core;

namespace FluentSysInfo
{
    internal partial class Worker : BackgroundService
    {

        private Webserver WebServerAgent;

        public Worker()
        {
            FastLogger.logger?.LogSystem("FluentSysInfo service has been initialized.");


            // Load Service Settings
            Settings.LoadServiceSettings();


            // Start FastResponse Agents
           FastResponseHelper.StartAllFastResponseAgents();

        }

        private void StartWebServer()
        {
            WebServerAgent = new WatsonWebserver.Extensions.HostBuilderExtension.HostBuilder(Settings.IPAddress,
                                                                                             Settings.ServicePort,
                                                                                             false,
                                                                                             DefaultCallback)
                // Map the Callbacks

                .MapParameteRoute(HttpMethod.GET, "/api/SysInfo/GetDateTimeInfo/secret={secret}", GetDateTimeInfoCallBack)
                .MapParameteRoute(HttpMethod.GET, "/api/SysInfo/GetOsInfo/secret={secret}", OSInfoCallBack)
                .MapParameteRoute(HttpMethod.GET, "/api/SysInfo/GetCpuInfo/secret={secret}", CPUInfoCallBack)
                .MapParameteRoute(HttpMethod.GET, "/api/SysInfo/GetMotherBoardInfo/secret={secret}", CPUMotherBoardCallBack)
                .MapParameteRoute(HttpMethod.GET, "/api/SysInfo/GetBiosInfo/secret={secret}", BIOSInfoCallBack)
                .MapParameteRoute(HttpMethod.GET, "/api/SysInfo/GetPhysicalMemoryInfo/secret={secret}", PhysicalMemoryInfoCallBack)
                .MapParameteRoute(HttpMethod.GET, "/api/SysInfo/GetRunningProcessesInfo/secret={secret}", RunningProcessesInfoCallBack)
                .MapParameteRoute(HttpMethod.GET, "/api/SysInfo/GetWindowsServicesInfo/secret={secret}", WindowsServicesInfoCallBack)
                .MapParameteRoute(HttpMethod.GET, "/api/SysInfo/GetGraphicCardInfo/secret={secret}", GraphicCardInfoCallBack)
                .MapParameteRoute(HttpMethod.GET, "/api/SysInfo/GetNetworkInterfaceInfo/secret={secret}", NetworkInterfaceInfoCallBack)
                .MapParameteRoute(HttpMethod.GET, "/api/SysInfo/GetDiskInfo/secret={secret}", DiskInfoCallBack)
                .MapParameteRoute(HttpMethod.GET, "/api/SysInfo/GetPartitionInfo/secret={secret}", PartitionInfoCallBack)
                .MapParameteRoute(HttpMethod.GET, "/api/SysInfo/GetDriveInfo/secret={secret}", DriveInfoCallBack)



                // Build the watson web server
                .Build();


            // Permit all IP address
            WebServerAgent.Settings.AccessControl.Mode = AccessControlMode.DefaultPermit;


            // Subscrive to Watson Web Server events
            WebServerAgent.Events.ExceptionEncountered += (object sender, ExceptionEventArgs e) => ExceptionHandler.HandleException(e.Exception);
            WebServerAgent.Events.ServerStarted += (object sender, EventArgs e) => FastLogger.logger?.LogSystem("The Watson Web Service has been started.");
            WebServerAgent.Events.ServerStopped += (object sender, EventArgs e) => FastLogger.logger?.LogSystem("The Watson Web Service has been stopped.");
            WebServerAgent.Events.Logger = (string log) => FastLogger.logger?.LogDebug(log, "Via Watson Internal Logger", 100);


            // Start The Watson Web Server
            WebServerAgent.Start();

        }


        private void StopWebServer()
        {
            WebServerAgent?.Stop();
            WebServerAgent?.Dispose();
        }


        public override Task StartAsync(CancellationToken cancellationToken)
        {

            try
            {
                StartWebServer();
            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex);
            }


            FastLogger.logger?.LogSystem("FluentSysInfo service has been started.");

            return base.StartAsync(cancellationToken);
        }


        public override Task StopAsync(CancellationToken cancellationToken)
        {

            try
            {
                StopWebServer();
            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex);
            }

            FastLogger.logger?.LogSystem("FluentSysInfo service has been stopped.");


            FastLogger.StopLogger();

            return base.StopAsync(cancellationToken);
        }




        // We do not need this method but we have to override it !
        protected override Task ExecuteAsync(CancellationToken stoppingToken) => Task.CompletedTask;

    }
}
