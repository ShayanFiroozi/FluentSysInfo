namespace FluentSysInfo
{
    internal class OSModel
    {


        public string MachineName { get; set; }

        public string UserName { get; set; }

        public string OSVersion { get; set; }


        public OSModel(string machineName,
                       string userName,
                       string oSVersion)
        {
            MachineName = machineName;
            UserName = userName;
            OSVersion = oSVersion;
        }





    }


}
