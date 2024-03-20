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


        private async Task GetDateTimeInfoCallBack(HttpContextBase ctx)
        {

            SysInfoDateTime GetDateTimeInfo = new SysInfoDateTime();


            string DateTimeInfoJSON = WebServerAgent.Serializer.SerializeJson(new DateTimeModel(GetDateTimeInfo.GetDateTime(),
                GetDateTimeInfo.GetDateTimeUTC(),
                GetDateTimeInfo.GetDate(),
                GetDateTimeInfo.GetTime(),
                GetDateTimeInfo.GetLongDate(),
                $"{GetDateTimeInfo.GetLongDate()}  {GetDateTimeInfo.GetTime()}",
                GetDateTimeInfo.GetDayOfWeek()));


            await new HttpHelper().HttpAuthenticateThenSendData(ctx, DateTimeInfoJSON);


        }






    }
}




