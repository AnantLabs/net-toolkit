using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Network
{
    public interface IFileLoader : IDisposable
    {
        void SendBytes(byte[] bytes);
        double Percent { get; set; }
    }
}
