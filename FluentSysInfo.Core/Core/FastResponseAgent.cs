using System;

namespace FluentSysInfo.Core
{
    public class FastResponseAgentModel
    {
        public FluentSysInfoTypes FastResponseAgent { get; set; }
        public TimeSpan ExecutionInterval { get; set; }

        public bool IsActive { get; set; }


        public FastResponseAgentModel(FluentSysInfoTypes fastResponseAgent,
                                      TimeSpan executionInterval)
        {
            FastResponseAgent = fastResponseAgent;
            ExecutionInterval = executionInterval;
        }

        public void DisableFastResponseAgent(FluentSysInfoTypes fastResponseAgent) => 

    }
}
