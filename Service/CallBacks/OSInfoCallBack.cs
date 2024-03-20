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


        private async Task OSInfoCallBack(HttpContextBase ctx)
        {

            if (await CheckAuthentication(ctx))
            {

                SysInfoOS GetOSInfo = new SysInfoOS();

                // Create an OSModel instance
                string OSInfoJSON = WebServerAgent.Serializer.SerializeJson(new OSModel(GetOSInfo.GetMachineName(),
                                                                                        GetOSInfo.GetCurrentUserName(),
                                                                                        GetOSInfo.GetOSInfo(),
                                                                                        GetOSInfo.GetOSSerialNumber()));


                ctx.Response.StatusCode = 200;
                ctx.Response.ContentType = "text/plain";

                if (!string.IsNullOrEmpty(OSInfoJSON))
                {
                    await ctx.Response.Send(OSInfoJSON);
                }
                else
                {
                    await ctx.Response.Send(WebServerAgent.Serializer.SerializeJson("Invalid data !"));
                }


            }

        }



    }


}

