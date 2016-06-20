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
    }
}
