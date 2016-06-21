using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ProcessMonitor.Core;
using ProcessMonitor.Recorder;

namespace ProcessMonitor.Data
{

    /// <summary>
    /// Data provider accessing information about running processes on the PC.
    /// </summary>
    public class ProcessInfoDataProvider : IProcessInfoDataProvider
    {
        /// <summary>
        /// PC processes recorder.
        /// </summary>
        private readonly IRecorder processRecorder;

        /// <summary>
        /// Class constructor.
        /// </summary>
        public ProcessInfoDataProvider()
        {
            processRecorder = Recorder.Recorder.Instance;
        }

        /// <summary>
        /// Adds handler triggering on Cpu or High load event.
        /// </summary>
        /// <param name="handler">Handler triggering on Cpu or High load event.</param>
        public void AddHighloadEventHandler(HighLoadEventHandler handler)
        {
            processRecorder.OnHighLoadEvent += (sender, args) => handler(this, args);
        }

        /// <summary>
        /// Returns current process list.
        /// </summary>
        /// <returns>Process list.</returns>
        public async Task<IEnumerable<IProcessInfo>> GetProcessesAsync()
        {
            var processList = await processRecorder.GetAllProcesses();
            return processList.Select(process => new ProcessInfo { Id = process.Id, Name = process.ProcessName });
        }
    }
}
