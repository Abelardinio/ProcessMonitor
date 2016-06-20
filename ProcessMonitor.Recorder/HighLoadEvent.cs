using System;

namespace ProcessMonitor.Recorder
{
    /// <summary>
    /// High load event handler.
    /// </summary>
    /// <param name="sender">Instance of sender object.</param>
    /// <param name="e">Information about high load event.</param>
    public delegate void HighLoadEventHandler(object sender, HighLoadEventArgs e);

    /// <summary>
    /// Class with information about high load event.
    /// </summary>
    public class HighLoadEventArgs
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="highLoadType">Type of high load notification.</param>
        /// <param name="loadValue">Load value.</param>
        public HighLoadEventArgs(HighLoadType highLoadType, float loadValue)
        {
            HighLoadType = highLoadType;
            LoadValue = loadValue;
        }

        /// <summary>
        /// Type of high load notification.
        /// </summary>
        public HighLoadType HighLoadType { get; private set; }

        /// <summary>
        /// Load value.
        /// </summary>
        public float LoadValue { get; private set; }

        /// <summary>
        /// Returns high load message.
        /// </summary>
        /// <returns>High load message.</returns>
        public string GetMessage()
        {
            switch (HighLoadType)
            {
                case HighLoadType.Cpu:
                    return "PC CPU is under high load.";
                case HighLoadType.Ram:
                    return "PC RAM is under high usage.";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
