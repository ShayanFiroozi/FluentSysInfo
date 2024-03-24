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


        private async Task GetSysInfoResult(HttpContextBase ctx, ISysInfo sysInfoClass)
        {
            if (Settings.IsFastResponseEnabled(sysInfoClass.GetType().Name))
            {
                // Get the result from the Fast Response Agents ( Faster )
                await new HttpHelper().HttpAuthenticateThenSendData(ctx, FastResponseHelper.GetAgentResult(sysInfoClass.GetType().Name));
            }
            else
            {
                // Get the result from executing the PowerShell commands directly (slower)
                await new HttpHelper().HttpAuthenticateThenSendData(ctx, sysInfoClass.GetInfo());
            }

        }



    }



}




