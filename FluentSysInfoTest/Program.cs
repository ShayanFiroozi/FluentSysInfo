using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FluentSysInfoTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {



            using (HttpClient client = new HttpClient())
            {
                string serverSecteyKey = "FluentSysInfoSecretKeyXXX";

                string url = $"http://localhost:54800/api/SysInfo/GetDateTimeInfo/{serverSecteyKey}";

                HttpResponseMessage response = await client.GetAsync(url);


                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);



            }

              Console.ReadLine();



        }



    }
}
