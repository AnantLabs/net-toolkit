using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for character arrays
    /// </summary>
    public static class CharacterArrayExtensions
    {
        public static byte[] ToByteArray(this char[] array, Encoding encoding)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(ms, encoding))
                {
                    writer.Write(array);
                    writer.Flush();
                    ms.Seek(0, SeekOrigin.Begin);
                    return ms.ToArray();
                }
            }
        }
    }

    /// @}
}
