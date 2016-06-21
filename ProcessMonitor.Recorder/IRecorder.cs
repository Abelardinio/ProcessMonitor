using System.Diagnostics;
using System.Threading.Tasks;

namespace ProcessMonitor.Recorder
{
    /// <summary>
    /// Interface of PC processes recorder.
    /// </summary>
    public interface IRecorder
    {
        /// <summary>
        /// Event triggers when PC is under high load.
        /// </summary>
        event HighLoadEventHandler OnHighLoadEvent;

        /// <summary>
        /// Returns all PC processes.
        /// </summary>
        /// <returns>PC processes.</returns>
        Task<Process[]> GetAllProcesses();
    }
}
