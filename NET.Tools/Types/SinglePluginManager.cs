using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace NET.Tools
{
    /// <summary>
    /// Represent a plugin manager for single types
    /// </summary>
    /// <typeparam name="T">The plugin type to search in external DLLs</typeparam>
    /// 
    /// <example>
    /// This example shows you to get a plugin from dll:
    /// <code>
    /// SinglePluginManager&lt;IMyType&gt; manager = new SinglePluginManager&lt;IMyType&gt;();
    /// manager.AssemblyList.Add(Assembly.LoadFrom("MyPlugins.dll"));
    /// IMyType[] instances = manager.GetInstances();
    /// </code>
    /// Here you can see that the type IMyType will be searched in all assemblies (here in MyPlugins.dll) and
    /// it will be create for each found type a instance.
    /// </example>
    public sealed class SinglePluginManager<T> : PluginManager
    {
        public SinglePluginManager(SearchType type)
            : base(type)
        {
        }

        public SinglePluginManager(string path, SearchType type)
            : base(path, type)
        {
        }

        public T[] GetInstances(params object[] parameters)
        {
            return this.GetInstances<T>(parameters);
        }
    }
}
