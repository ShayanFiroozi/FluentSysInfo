//namespace FluentSysInfo
//{
//    internal class CPUModel
//    {

//        public string ID { get; set; } = "N/A";

//        public string Scoket { get; set; } = "N/A";

//        public string Name { get; set; } = "N/A";

//        public string Description { get; set; } = "N/A";

//        public string AddressWidth { get; set; } = "N/A";

//        public string DataWidth { get; set; } = "N/A";

//        public string Architecture { get; set; } = "N/A";

//        public string SpeedMHz { get; set; } = "N/A";

//        public string BusSpeedMHz { get; set; } = "N/A";

//        public string L2Cache { get; set; } = "N/A";

//        public string L3Cache { get; set; } = "N/A";

//        public string Cores { get; set; } = "N/A";

//        public string Threads { get; set; } = "N/A";

//        public string Manufacturer { get; set; } = "N/A";

//        public string LoadPercentage { get; set; } = "N/A";

//        public string VirtualizationEnabled { get; set; } = "N/A";


//        public CPUModel()
//        {
//            // Use for default "N/A" value return !
//        }

//        public CPUModel(string iD,
//                        string scoket,
//                        string name,
//                        string description,
//                        string addressWidth,
//                        string dataWidth,
//                        string architecture,
//                        string speedMHz,
//                        string busSpeedMHz,
//                        string l2Cache,
//                        string l3Cache,
//                        string cores,
//                        string threads,
//                        string manufacturer,
//                        string loadPercentage,
//                        string virtualizationEnabled)
//        {
//            ID = iD;
//            Scoket = scoket;
//            Name = BeutifyCPUName(name);
//            Description = description;
//            AddressWidth = addressWidth;
//            DataWidth = dataWidth;
//            Architecture = architecture;
//            SpeedMHz = speedMHz;
//            BusSpeedMHz = busSpeedMHz;
//            L2Cache = l2Cache;
//            L3Cache = l3Cache;
//            Cores = cores;
//            Threads = threads;
//            Manufacturer = manufacturer;
//            LoadPercentage = loadPercentage;
//            VirtualizationEnabled = virtualizationEnabled;
//        }

//        private string BeutifyCPUName(string CPUName) => CPUName
//                   .Replace("(TM)", string.Empty)
//                   .Replace("(tm)", string.Empty)
//                   .Replace("(R)", string.Empty)
//                   .Replace("(r)", string.Empty)
//                   .Replace("(C)", string.Empty)
//                   .Replace("(c)", string.Empty)
//                   .Replace("    ", string.Empty)
//                   .Replace("  ", string.Empty);



//    }


//}
