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


        private async Task BIOSInfoCallBack(HttpContextBase ctx)
        {

            await GetSysInfoResult(ctx, new SysInfoBios());

            

        }

    }



}




