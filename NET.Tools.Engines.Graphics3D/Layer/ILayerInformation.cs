using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Graphics3D
{
    /// <summary>
    /// Entry Point for Plugin Searcher
    /// </summary>
    public interface ILayerInformation
    {
        String SystemName { get; }
        ILayerImplementor LayerImplementor { get; }
        Graphics3DDevice Device { get; }
    }
}
