using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace NET.Tools
{
    /// <summary>
    /// Represent a special stream from the FileAppenderStream that appends data to the main executed file or other assemblies
    /// 
    /// <remarks>
    /// This stream cannot be write chaches back to assembly file! Remember that all known assemblies in
    /// the program are opened at runtime.
    /// </remarks>
    /// </summary>
    public class AssemblyAppenderStream : FileAppenderStream
    {
        public Assembly Assembly {get; private set;}

        /// <summary>
        /// Create the stream object
        /// </summary>
        /// <param name="asm">Assembly to open</param>
        public AssemblyAppenderStream(Assembly asm)
            : base(asm.Location)
        {
        }

        public AssemblyAppenderStream()
            : this(Assembly.GetEntryAssembly())
        {
        }

        /// <summary>
        /// Close the file. WriteBack must be false! See remarks of this class for informations
        /// </summary>
        /// <param name="writeBack">Must be false</param>
        /// <exception cref="NotSupportedException">
        /// Is thrown if the writeBack parameter is true
        /// </exception>
        public override void Close(bool writeBack)
        {
            if (writeBack)
                throw new NotSupportedException("Cannot write back to file!");

            base.Close(writeBack);
        }

        public override void Close()
        {
            base.Close(false);
        }
    }
}
