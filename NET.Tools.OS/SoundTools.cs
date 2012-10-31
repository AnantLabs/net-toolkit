using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.OS
{
    /// \addtogroup dlltools
    /// @{

    ///<summary>
    ///Tools for sound playing
    ///</summary>
    public static class SoundTools
    {
        public static bool PlaySound(string filename, bool syncron, bool loop)
        {
            SoundFlags flags = SoundFlags.Filename;
            if (syncron)
                flags |= SoundFlags.Syncron;
            else
                flags |= SoundFlags.Asyncron;
            if (loop)
                flags |= SoundFlags.Loop;

            return WinMM.PlaySound(filename, UIntPtr.Zero, (uint)flags);
        }

        public static bool PlaySound(byte[] data, bool syncron, bool loop)
        {
            SoundFlags flags = SoundFlags.Resource;
            if (syncron)
                flags |= SoundFlags.Syncron;
            else
                flags |= SoundFlags.Asyncron;
            if (loop)
                flags |= SoundFlags.Loop;

            return WinMM.PlaySound(data, UIntPtr.Zero, (uint)flags);
        }

        public static bool PlaySound(string filename, SoundFlags flags)
        {
            return WinMM.PlaySound(filename, UIntPtr.Zero, 
                (uint)(flags | SoundFlags.Filename));
        }

        public static bool PlaySound(byte[] data, SoundFlags flags)
        {
            return WinMM.PlaySound(data, UIntPtr.Zero, 
                (uint)(flags | SoundFlags.Resource));
        }
    }

    /// @}

    /// \addtogroup enums
    /// @{

    [Flags]
    public enum SoundFlags : uint
    {
        Syncron = 0x00,
        Asyncron = 0x01,
        NodeDefault = 0x02,
        Memory = 0x04,
        Loop = 0x08,
        NoStop = 0x10,
        Purge = 0x40,
        NoWait = 0x2000,
        Alias = 0x10000,
        AliasID = 0x110000,
        Filename = 0x20000,
        Resource = 0x40004
    }

    /// @}
}
