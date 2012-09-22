using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace NET.Tools
{
    /// <summary>
    /// Represent a class to read the assembly informations about a dll or exe
    /// </summary>
    public sealed class AssemblyInfo
    {
        private Assembly asm;

        /// <summary>
        /// Create a object instance
        /// </summary>
        /// <param name="asm">The assembly to read</param>
        public AssemblyInfo(Assembly asm)
        {
            this.asm = asm;
        }

        #region Assemblyattributaccessoren

        /// <summary>
        /// Title of assembly
        /// </summary>
        public string AssemblyTitle
        {
            get
            {
                object[] attributes = asm.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(asm.CodeBase);
            }
        }

        /// <summary>
        /// Version of Assembly
        /// </summary>
        public string AssemblyVersion
        {
            get
            {
                return asm.GetName().Version.ToString();
            }
        }

        /// <summary>
        /// Description of assembly
        /// </summary>
        public string AssemblyDescription
        {
            get
            {
                object[] attributes = asm.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        /// <summary>
        /// Product-Name of assemby
        /// </summary>
        public string AssemblyProduct
        {
            get
            {
                object[] attributes = asm.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        /// <summary>
        /// Copyright of assembly
        /// </summary>
        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = asm.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        /// <summary>
        /// Company of assembly
        /// </summary>
        public string AssemblyCompany
        {
            get
            {
                object[] attributes = asm.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        public string ToString(AssemblyInfoString str)
        {
            switch (str)
            {
                case AssemblyInfoString.Full:
                    return "[" +
                        "Product: " + this.AssemblyProduct + "; " +
                        "Title: " + this.AssemblyTitle + "; " +
                        "Version: " + this.AssemblyVersion + "; " +
                        "Description: " + this.AssemblyDescription + "; " +
                        "Company: " + this.AssemblyCompany + "; " +
                        "Copyright: " + this.AssemblyCopyright +
                        "]";
                case AssemblyInfoString.Normal:
                    return "[" +
                        "Title: " + this.AssemblyTitle + "; " +
                        "Version: " + this.AssemblyVersion + "; " +
                        "Description: " + this.AssemblyDescription + "; " +
                        "Copyright: " + this.AssemblyCopyright +
                        "]";
                case AssemblyInfoString.Easy:
                    return "Title: " + this.AssemblyTitle;
                case AssemblyInfoString.CommandLineStyle:
                    return
                        this.AssemblyTitle + "\t" +
                        this.AssemblyCopyright + " (" +
                        this.AssemblyVersion + ")\n" +
                        this.AssemblyDescription + "\n";
                default:
                    throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            return this.ToString(AssemblyInfoString.Normal);
        }
    }

    /// \addtogroup enums
    /// @{

    public enum AssemblyInfoString
    {
        /// <summary>
        /// All informations in a list
        /// </summary>
        Full,
        /// <summary>
        /// Important informations in a list
        /// </summary>
        Normal,
        /// <summary>
        /// Only title in list
        /// </summary>
        Easy,
        /// <summary>
        /// Style for command line:
        /// Title Copyright (Version)
        /// Description
        /// </summary>
        CommandLineStyle
    }
    /// @}
}
