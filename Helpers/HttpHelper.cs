/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information Service ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

 → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
   https://github.com/dotnet/WatsonWebserver

---------------------------------------------------------------------------------------------*/

using System.Threading.Tasks;
using WatsonWebserver.Core;

namespace FluentSysInfo
{

    internal class HttpHelper
    {

        internal async Task HttpAuthenticateThenSendData(HttpContextBase ctx, string DataToSend)
        {

            if (await CheckAuthentication(ctx))
            {

                ctx.Response.StatusCode = 200;
                ctx.Response.ContentType = "text/plain";

                if (!string.IsNullOrEmpty(DataToSend))
                {
                    await ctx.Response.Send(DataToSend);
                }
                else
                {
                    await ctx.Response.Send("Invalid data !");
                }


            }

        }



        private async Task<bool> CheckAuthentication(HttpContextBase ctx)
        {
            try
            {

                if (!Settings.UseAuthentication) return true;


                // Parse the secret sent by the request
                string sentSecret = ctx.Request.Url.Parameters["secret"].Replace("secret=", string.Empty);

                if (sentSecret != Settings.ServiceSecretKey)
                {
                    ctx.Response.StatusCode = 401;
                    ctx.Response.ContentType = "text/plain";

                    await ctx.Response.Send("Authentication failed !");

                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }


    }


}
