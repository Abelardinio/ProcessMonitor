using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Threading;

namespace ProcessMonitor.Recorder
{
    /// <summary>
    /// PC processes recorder.
    /// </summary>
    public class Recorder : IRecorder
    {
        private static readonly Lazy<Recorder> RecorderLazy = new Lazy<Recorder>(() => new Recorder());

        /// <summary>
        /// Gets installed RAM size in KB.
        /// </summary>
        /// <param name="totalMemoryInKilobytes"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out long totalMemoryInKilobytes);

        /// <summary>
        /// High load value.
        /// </summary>
        private const float HighLoadValue = 0;

        /// <summary>
        /// Installed RAM amount.
        /// </summary>
        private readonly long totalRamAmount;

        /// <summary>
        /// Perfomance counter component for CPU.
        /// </summary>
        private readonly PerformanceCounter cpuCounter;

        /// <summary>
        /// Perfomance counter component for RAM.
        /// </summary>
        private readonly PerformanceCounter ramCounter;

        /// <summary>
        /// Private class constructor.
        /// </summary>
        private Recorder()
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            long totalRam;
            GetPhysicallyInstalledSystemMemory(out totalRam);
            var totalRamInMbs = totalRam / 1024;
            totalRamAmount = totalRamInMbs;

            Task.Factory.StartNew(HighLoadCheckerTask);
        }

        public static Recorder Instance => RecorderLazy.Value;

        /// <summary>
        /// Event triggers when PC is under high load.
        /// </summary>
        public event HighLoadEventHandler OnHighLoadEvent;

        /// <summary>
        /// Returns all PC processes.
        /// </summary>
        /// <returns>PC processes.</returns>
        public Task<Process[]> GetAllProcesses()
        {
            return Task.Run(() => Process.GetProcesses());
        }


        /// <summary>
        /// Checks CPU and RAM load every half a second and triggers HighLoadEvent if it's above 90%.
        /// </summary>
        private void HighLoadCheckerTask()
        {
            while (true)
            {
                Thread.Sleep(10000);
                var cpuLoadValue = cpuCounter.NextValue();
                var ramLoadValue = GetRamLoadValue();
                var isCpuHighLoad = cpuLoadValue > HighLoadValue;
                var isRamHighLOad = ramLoadValue > HighLoadValue;

                if (isCpuHighLoad)
                {
                    OnHighLoadEvent?.Invoke(this, new HighLoadEventArgs(HighLoadType.Cpu, cpuLoadValue));
                }

                if (isRamHighLOad)
                {
                    OnHighLoadEvent?.Invoke(this, new HighLoadEventArgs(HighLoadType.Cpu, cpuLoadValue));
                }

                Thread.Sleep((isRamHighLOad || isCpuHighLoad) ? 600 : 500);
            }
        }

        /// <summary>
        /// Gets RAM load.
        /// </summary>
        private float GetRamLoadValue()
        {
            var ramLoadValue = ramCounter.NextValue();

            return (ramLoadValue / totalRamAmount) * 100;
        }
    }
}
