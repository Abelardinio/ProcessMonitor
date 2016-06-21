using System.Collections.Generic;
using System.Threading.Tasks;

using ProcessMonitor.Core;
using ProcessMonitor.Recorder;

namespace ProcessMonitor.Data
{

    /// <summary>
    /// Data provider accessing information about running processes on the PC.
    /// </summary>
    public interface IProcessInfoDataProvider
    {
        /// <summary>
        /// Adds handler triggering on Cpu or High load event.
        /// </summary>
        /// <param name="handler">Handler triggering on Cpu or High load event.</param>
        void AddHighloadEventHandler(HighLoadEventHandler handler);

        /// <summary>
        /// Returns current process list.
        /// </summary>
        /// <returns>Process list.</returns>
        Task<IEnumerable<IProcessInfo>> GetProcessesAsync();
    }
}
