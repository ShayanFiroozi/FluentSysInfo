using System;
using System.Collections.Generic;

namespace FluentSysInfo.Core
{

    public class FluentSysInfoSetting : IDisposable
    {

        #region Properties

        private bool _ActiveFastResponse;
        private bool disposedValue;
        private readonly List<FluentSysInfoTypes> _FastResponseAgents = new();

        public bool IsFastResponseActive() => _ActiveFastResponse;
        public IEnumerable<FluentSysInfoTypes> FastResponseAgents => _FastResponseAgents;

        #endregion



        #region Public Methods
        public void AddFastResponseAgent(FluentSysInfoTypes agent) => _FastResponseAgents.Add(agent);
        public void RemoveFastResponseAgent(FluentSysInfoTypes agent) => _FastResponseAgents.Remove(agent);

        public void EnableFastResponse() => _ActiveFastResponse = true;
        public void DisableFastResponse() => _ActiveFastResponse = false;
        #endregion



        #region Dispose Pattern
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _FastResponseAgents.Clear();

                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null

                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~FluentSysInfoSetting()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion


    }

}
