using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for AppDomain
    /// </summary>
    public static class AppDomainExtensions
    {
        /// <summary>
        /// Gets the current filename of the application
        /// </summary>
        /// <param name="dom"></param>
        /// <returns>Filename of application as FileInfo</returns>
        public static FileInfo GetApplicationFilename(this AppDomain dom)
        {
            return new FileInfo(Assembly.GetEntryAssembly().Location);
        }

        /// <summary>
        /// List important information of application domain for logging
        /// </summary>
        /// <param name="dom"></param>
        /// <returns>The string with the AppDomain-Informations</returns>
        public static string ListApplicationInformation(this AppDomain dom)
        {
            StringBuilder str = new StringBuilder();

            str.Append("Running Application: " + dom.GetApplicationFilename() + "\r\n");
            str.Append("Default App-Domain: " + dom.IsDefaultAppDomain() + "\r\n");
            str.Append("Loaded Assemblies:\r\n");
            foreach(Assembly asm in dom.GetAssemblies())
                str.Append("\t" + asm.GetFileName().Name + "\r\n");

            return str.ToString();
        }
    }
    /// @}
}
