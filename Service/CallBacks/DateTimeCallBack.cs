/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information Service ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

 → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
   https://github.com/dotnet/WatsonWebserver

---------------------------------------------------------------------------------------------*/



using Microsoft.Extensions.Hosting;
using System;
using System.Text;
using System.Threading.Tasks;
using WatsonWebserver.Core;

namespace FluentSysInfo
{
    internal partial class Worker : BackgroundService
    {


        private async Task GetDateTimeInfoCallBack(HttpContextBase ctx)
        {

            SysInfoDateTime GetDateTimeInfo = new SysInfoDateTime();


            await new HttpHelper().HttpAuthenticateThenSendData(ctx,
                                                                ConvertDateTimeResultToJsonFormat(GetDateTimeInfo.GetInfo(),
                                                                GetDateTimeInfo.NumberOfProperties));




        }


        private string ConvertDateTimeResultToJsonFormat(string DateTimeResult, int NumberOfProperties)
        {
            StringBuilder result = new StringBuilder();

            try
            {

                // Add the first Json format '{' character
                _ = result.Append('{').Append('\n');

                string[] DateTimeItem = DateTimeResult.Split(new char[] { ',' }, NumberOfProperties);


                result.Append($" \"Date Time\": \"{DateTimeItem[0]}\"")
                      .Append(',').Append('\n');


                result.Append($" \"Date Time UTC\": \"{DateTimeItem[1]}\"")
                      .Append(',').Append('\n');


                result.Append($" \"Date\": \"{DateTimeItem[2]}\"")
                      .Append(',').Append('\n');


                result.Append($" \"Time\": \"{DateTimeItem[3]}\"")
                      .Append(',').Append('\n');


                result.Append($" \"Long Date\": \"{DateTimeItem[4]}\"")
                      .Append(',').Append('\n');



                result.Append($" \"Day Of Week\": \"{DateTimeItem[5]}\"")
                      .Append(',').Append('\n');


                result.Append($" \"Full Date Time\": \"{DateTimeItem[6]}\"")
                      .Append('\n');


                // Add the last '}' Json bracket ;)
                _ = result.Append('}');


                return result.ToString();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



    }
}




