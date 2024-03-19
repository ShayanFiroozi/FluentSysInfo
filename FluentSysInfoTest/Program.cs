using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FluentSysInfoTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {



            string ServerSecteyKey = "FluentSysInfoSecretKeyXXX";
            string TargetUrl = $"http://localhost:54800/api/SysInfo/GetDateTimeInfo/{ServerSecteyKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(TargetUrl);

                string result = await response.Content.ReadAsStringAsync();

                Console.WriteLine(result);

            }

            Console.ReadLine();

        }



    }
}
