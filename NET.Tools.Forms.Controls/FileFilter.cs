using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;


namespace NET.Tools.Forms
{
    public sealed class FileFilter
    {
        private String name, filter, defaultExt;

        [Category("Design")]
        public String Name { get { return name; } set { name = value; } }
        [Category("Behavior")]
        public String Filter { get { return filter; } set { filter = value; } }
        [Category("Behavior")]
        public String DefaultExt { get { return defaultExt; } set { defaultExt = value; } }

        public FileFilter()
        {
        }

        public FileFilter(String name, String filter, String defaultExt)
        {
            this.name = name;
            this.filter = filter;
            this.defaultExt = defaultExt;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            else if (!(obj is FileFilter))
                return false;
            else if (Object.ReferenceEquals(this, obj))
                return true;

            return filter.Equals((obj as FileFilter).filter);
        }

        public override int GetHashCode()
        {
            return filter.GetHashCode();
        }
    }

    /// <summary>
    /// \addtogroup enums
    /// @{
    /// </summary>
    public enum PictureFilterIndex
    {
        BMP = 0,
        JPEG = 1,
        PNG = 2
    }
    /// @}
}
