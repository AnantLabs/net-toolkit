using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    public abstract class Creator<T>
    {
        internal abstract T Create();
    }
}
