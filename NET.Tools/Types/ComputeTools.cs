using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// <summary>
    /// Tools for computing
    /// </summary>
    public static class ComputeTools
    {
        /// <summary>
        /// Compute the time until the end of process
        /// </summary>
        /// <param name="max">Maximum value</param>
        /// <param name="val">Value now</param>
        /// <param name="tickFirst">First tick value</param>
        /// <param name="tickNow">Tick value now</param>
        /// <returns>Time until end</returns>
        public static TimeSpan ComputeTimeToEnd(
            double max, double val, long tickFirst, long tickNow)
        {
            return TimeSpan.FromMilliseconds(
                (tickNow - tickFirst) * (max - val) / val);
        }

        /// <summary>
        /// Compute the KBytes per Second rate
        /// </summary>
        /// <param name="val">Value of bytes now</param>
        /// <param name="tickFirst">First tick</param>
        /// <param name="tickNow">Tick now</param>
        /// <returns>KB/s</returns>
        public static double ComputeKBytesPerSecond(
            double val, long tickFirst, long tickNow)
        {
            return (val / (tickNow - tickFirst)) / 1024d;
        }
    }
}
