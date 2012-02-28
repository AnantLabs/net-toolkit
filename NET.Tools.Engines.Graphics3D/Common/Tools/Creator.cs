using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D.Common.Tools
{
    public abstract class Creator<T>
    {
        internal abstract T Create();
    }
}
