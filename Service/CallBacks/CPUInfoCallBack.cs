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


        private async Task CPUInfoCallBack(HttpContextBase ctx)
        {

            if (await CheckAuthentication(ctx))
            {

                SysInfoCPU GetCPUInfo = new SysInfoCPU();

                // Create an CPUModel instance
                string CPUInfoJSON = WebServerAgent.Serializer.SerializeJson(GetCPUInfo.GetCPUInfo());


                ctx.Response.StatusCode = 200;
                ctx.Response.ContentType = "text/plain";

                if (!string.IsNullOrEmpty(CPUInfoJSON))
                {
                    await ctx.Response.Send(CPUInfoJSON);
                }
                else
                {
                    await ctx.Response.Send(WebServerAgent.Serializer.SerializeJson("Invalid data !"));
                }


            }

        }



    }


}

