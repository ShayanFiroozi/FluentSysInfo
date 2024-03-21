/*---------------------------------------------------------------------------------------------

                         ► Fluent System Information Service ◄


 → Copyright (c) 2024 Shayan Firoozi , Bandar Abbas , Iran , Under MIT License.

 → Contact : <shayan.firoozi@gmail.com>

 → GitHub repository : https://github.com/ShayanFiroozi/FluentSysInfo

 → FluentSysInfo uses "Watson Web Service" which is very lightweight and reliable.🙏🏻 
   https://github.com/dotnet/WatsonWebserver

---------------------------------------------------------------------------------------------*/

using System;
using System.Linq;

namespace FluentSysInfo
{

    internal class JSONHelper
    {

        internal string ConvertPowerShellResultToJSON(string PowerShellResult)
        {
            try
            {

                return string.Join(Environment.NewLine, ParseAndNormalizeThePowerShellResult(PowerShellResult));
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        internal string[] ParseAndNormalizeThePowerShellResult(string PowerShellRawResult)
        {
            string result = string.Empty;

            try
            {
                // Split each line
                string[] lines = PowerShellRawResult.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                // Process each line
                foreach (string line in lines)
                {
                    try
                    {
                        // Handle the empty lines !
                        if (line == string.Empty && result != string.Empty)
                        {
                            result += Environment.NewLine;
                            continue;
                        }


                        // Ignore the lines without ':' character ! ( may be it's an unwanted description , bad result or useless property !!)
                        if (!line.Contains(':')) continue;

                        // Split just first occurance of ':' character
                        string[] lineSections = line.Split(new char[] { ':' }, 2);

                        // Trim the line sections
                        lineSections[0] = lineSections[0].Trim();
                        lineSections[1] = lineSections[1].Trim();

                        // Ignore empty line sections !
                        if (string.IsNullOrWhiteSpace(lineSections[0]) || string.IsNullOrWhiteSpace(lineSections[1])) continue;

                        // Ignore some CIM/Win32 classes properties
                        if (lineSections[0] == "CreationClassName"
                            || lineSections[0] == "SystemCreationClassName"
                            || lineSections[0] == "CimClass"
                            || lineSections[0] == "CimInstanceProperties"
                            || lineSections[0] == "CimSystemProperties") continue;


                        if (result == string.Empty)
                        {
                            result += $"{lineSections[0]}:{lineSections[1]}";
                        }
                        else
                        {
                            result += $"{Environment.NewLine}{lineSections[0]}:{lineSections[1]}";
                        }


                    }

                    catch (Exception ex) { /*Ignore the lopp internal possible exception ...*/ }

                }

                return result.TrimEnd().Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            }
            catch (Exception ex)
            {
                // Pass the exception message to the caller function
                return new string[] { "Error Occured : ", ex.Message };
            }

        }



    }


}
