/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information Service ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

 → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
   https://github.com/dotnet/WatsonWebserver

---------------------------------------------------------------------------------------------*/



using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using WatsonWebserver.Core;

namespace FluentSysInfo
{
    internal partial class Worker : BackgroundService
    {

        // Response for default or invalid requesets !!
        private async Task DefaultCallback(HttpContextBase ctx) => await ctx.Response.Send(WebServerAgent.Serializer.SerializeJson("FluentSysInfo Web Service is running !"));




    }




}

