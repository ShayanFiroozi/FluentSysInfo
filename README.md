<p align="center">
 <img src="https://github.com/ShayanFiroozi/FluentSysInfo/blob/master/Icon.ico"
</p>

# FluentSysInfo
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo&metric=bugs)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=ShayanFiroozi_FluentSysInfo&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=ShayanFiroozi_FluentSysInfo)
[![GitHub License](https://img.shields.io/github/license/ShayanFiroozi/FluentSysInfo)](https://github.com/ShayanFiroozi/FluentSysInfo/blob/master/LICENSE.md)
 
**FluentSysInfo** provides the accessibility to the various System Informations of a local or remote machine via WebAPI
  
✔ FluentSysInfo uses [Watson Web Server](https://github.com/dotnet/WatsonWebserver) , A great , lightweight and most reliable web server , special thanks to @jchristn 👍

✔ FluentSysInfo uses [FastLog.Net](https://github.com/ShayanFiroozi/FastLog.Net) , Ultra Fast and High performance logger for .NET 💯 

<br/>

## Features 💯
 **FluentSysInfo features :**
 * **Supported System Information :**  
    ✔ Date Time Info  
    ✔ OS Info  
    ✔ Main Board Info  
    ✔ BIOS Info  
    ✔ CPU Info  
    ✔ PhysicalMemory Info  
    ✔ Disk And Drive Info  
    ✔ Network Interfaces Info  
    ✔ Graphic Card Info  
    ✔ Running Processes Info  
    ✔ Windows Services Info  
    
 <br/>  

  
 
## Contributions 🤝
Since this is a new repository , there's no contributor yet! , But **FluentSysInfo** welcomes and appreciates any contribution , pull request or bug report.

 


<br/>
 
## How To Use ❔
   
 - It's really simple to call the **FluentSysInfo** WebAPI :
 
 ```csharp
            string ServerSecteyKey = "FluentSysInfoSecretKeyXXX";
            string TargetUrl = $"http://localhost:54800/api/SysInfo/GetDateTimeInfo/{ServerSecteyKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(TargetUrl);

                string result = await response.Content.ReadAsStringAsync();

                Console.WriteLine(result);

            }

            Console.ReadLine();

```   

And the result from the **FluentSysInfo** would be something like this : 

```json
{
  "DateTime": "3/19/2024 3:51:49 PM",
  "DateTimeUTC": "3/19/2024 12:21:49 PM",
  "DateOnly": "3/19/2024",
  "TimeOnly": "3:51:49 PM",
  "LongDate": "Tuesday, March 19, 2024",
  "FullDateTime": "Tuesday, March 19, 2024  3:51:49 PM"
}
```

> :information_source: 
**FluentSysInfo** settings can be easily changed via [Service Settings File](https://github.com/ShayanFiroozi/FluentSysInfo/blob/master/Settings/ServiceSettings.json).  
    
> :warning: 
It is recommended to keep the **UseAuthentication** setting enable to prevent unwanted access to the target machine information.

<br/>

    
### Available APIs : 
* **Date And Time Info -> /api/SysInfo/GetDateTimeInfo**
* **OS Info -> /api/SysInfo/GetOSInfo**
* **CPU Info -> /api/SysInfo/GetCPUInfo**
* **Mother Board Info -> /api/SysInfo/GetMotherBoardInfo**
* **BIOS Info -> /api/SysInfo/GetBIOSInfo**
* **Physical Memory Info -> /api/SysInfo/GetPhysicalMemoryInfo**
* **Running Processes Info -> /api/SysInfo/GetRunningProcessesInfo**
* **Windows Services Info -> /api/SysInfo/GetWindowsServicesInfo**
* **Graphic Card Info -> /api/SysInfo/GetGraphicCardInfo**
* **Network Interface(s) Info -> /api/SysInfo/GetNetworkInterfaceInfo**
* **Disk(s) Info -> /api/SysInfo/GetDiskInfo**
* **Disk Drive(s) Info -> /api/SysInfo/GetDrivesInfo**

  

<br/>  
  
> :warning:  If **UseAuthentication** settings is enable the secret key should be sent by each **Get** request.


> :information_source: **Example With Authentication** : http://localhost:54800/api/SysInfo/GetDateTimeInfo/FluentSysInfoSecretKeyXXX
<br/>


> :information_source: **Example Without Authentication** : http://localhost:54800/api/SysInfo/GetOSInfo
 <br/>
 
 
## Known Issues ‼ 
 **Not Reported Yet!** 😎

<br/>
 
 ## © License
**FluentSysInfo** is an open source software, licensed under the terms of MIT license.
See [**LICENSE**](LICENSE.md) for more details.

<br/>
 
## 🛠 How to build
Use **Visual Studio 2022** and open the solution 'FluentSysInfo.sln'.

**FluentSysInfo** solution is setup to support following .Net versions :

- .Net Core 8.0
- .Net Core 7.0
- .Net Core 6.0
- .Net Framework 4.8


> **Note**:  
Since the **FluentSysInfo** solution is supporting multi target frameworks , to build the solution successfully you should install all .Net versions above , otherwise you can easily exclude not interested framework(s) by editing **TargetFrameworks** tag in the [FluentSysInfo Project File](https://github.com/ShayanFiroozi/FluentSysInfo/blob/master/FluentSysInfo.csproj).

<br/>
 
## Donations 💲
If you would like to financially support **FluentSysInfo**, first of all, thank you! Please read [**DONATIONS**](DONATIONS.md) for my crypto wallets !

<br/>
 
## Version History 🕙
Please read [**CHANGELOG**](CHANGELOG.md) for more and track changing details.
