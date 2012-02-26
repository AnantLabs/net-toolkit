using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NET.Tools.Engines.CodeBuilder
{
    /// <summary>
    /// Represent the interface for a typical code builder
    /// </summary>
    public interface ICodeBuilder
    {
        /// <summary>
        /// Generate the code
        /// </summary>
        /// <param name="targetDir">
        /// The target directory to generate the code
        /// </param>
        /// <param name="folderForNameSpaces">
        /// TRUE to generate folders for each namespace (like packages in Java), otherwise FALSE
        /// </param>
        void generate(DirectoryInfo targetDir, bool folderForNameSpaces);
        /// <summary>
        /// Generate the code with the default folder creation settings for this code builder
        /// </summary>
        /// <param name="targetDir">
        /// The target directory to generate the code
        /// </param>
        void generate(DirectoryInfo targetDir);

        /// <summary>
        /// Gets or sets the basic name space for all code
        /// </summary>
        String BasicNameSpace { get; set; }

        /// <summary>
        /// Gets the list of all defined namespaces
        /// </summary>
        IList<INameSpace> NameSpaceList { get; }
        /// <summary>
        /// Gets the list of all basic elements without namespace information
        /// </summary>
        IList<IObjectDefinition> BasicElementList { get; }
    }
}
