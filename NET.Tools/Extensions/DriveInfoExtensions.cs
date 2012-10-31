using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using NET.Tools.Properties;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class DriveInfoExtensions
    {
        public static Icon GetIcon(this DriveInfo di)
        {
            switch (di.DriveType)
            {
                case DriveType.CDRom:
                    return Resources.CDDVD;
                    
                case DriveType.Fixed:
                    return Resources.HDD;
                    
                case DriveType.Network:
                    return Resources.Network;
                    
                case DriveType.NoRootDirectory:
                    return Resources.HDD;
                    
                case DriveType.Ram:
                    return Resources.HDD;
                    
                case DriveType.Removable:
                    return Resources.Stick;
                    
                case DriveType.Unknown:
                    return Resources.HDD;
                    
                default:
                    throw new NotImplementedException();
            }
        }
    }
    /// @}
}
