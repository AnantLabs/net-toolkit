using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using NET.Tools.Properties;

namespace NET.Tools
{
    /// <summary>
    /// \addtogroup extensions
    /// @{
    /// </summary>
    public static class DirectoryInfoExtensions
    {
        /// <summary>
        /// Returns the complete size of this directory
        /// </summary>
        /// <param name="di"></param>
        /// <param name="recurs">TRUE to search recursive all sub directories</param>
        /// <param name="filter">An optional file filter</param>
        /// <returns></returns>
        public static long GetDirectorySize(this DirectoryInfo di, bool recurs, String filter)
        {
            if (!recurs)
            {
                long length = 0;
                foreach (FileInfo fi in di.GetFiles(filter))
                {
                    length += fi.Length;
                }
                return length;
            }
            else
            {
                long length = 0;
                DoDirectoryActionRecurs(di,
                    null, (s, e) =>
                    {
                        foreach (FileInfo fi in e.Directory.GetFiles(filter))
                            length += fi.Length;
                    });
                return length;
            }
        }

        public static long GetDirectorySize(this DirectoryInfo di, bool recurs)
        {
            return GetDirectorySize(di, recurs, "*.*");
        }

        /// <summary>
        /// Returns the complete size of the directory, inclusive all files and sub directories
        /// </summary>
        /// <param name="di"></param>
        /// <returns></returns>
        public static long GetDirectorySize(this DirectoryInfo di)
        {
            return GetDirectorySize(di, true);
        }

        /// <summary>
        /// Returns all files in this directory
        /// </summary>
        /// <param name="di"></param>
        /// <param name="recurs">TRUE to search recursive</param>
        /// <param name="filter">An optional file filter</param>
        /// <returns></returns>
        public static FileInfo[] GetAllFiles(this DirectoryInfo di, bool recurs, String filter)
        {
            if (!recurs)
            {
                return di.GetFiles(filter);
            }
            else
            {
                List<FileInfo> lst = new List<FileInfo>();

                DoDirectoryActionRecurs(di, null,
                                        (s, e) => lst.AddRange(di.GetFiles(filter)));

                return lst.ToArray();
            }
        }

        public static FileInfo[] GetAllFiles(this DirectoryInfo di, bool recurs)
        {
            return GetAllFiles(di, recurs, "*.*");
        }

        /// <summary>
        /// Returns all files fromk this directory and all sub directories
        /// </summary>
        /// <param name="di"></param>
        /// <returns></returns>
        public static FileInfo[] GetAllFiles(this DirectoryInfo di)
        {
            return GetAllFiles(di, true);
        }

        public static DirectoryInfo[] GetAllDirectories(this DirectoryInfo di, bool recurs, string filter)
        {
            if (!recurs)
            {
                return di.GetDirectories();
            }
            else
            {
                List<DirectoryInfo> lst = new List<DirectoryInfo>();

                DoDirectoryActionRecurs(di, null,
                                        (s, e) => lst.AddRange(di.GetDirectories(filter)));

                return lst.ToArray();
            }
        }

        public static DirectoryInfo[] GetAllDirectories(this DirectoryInfo di, bool recurs)
        {
            return GetAllDirectories(di, recurs, "*");
        }

        /// <summary>
        /// Returns all directories in this directory and all sub directories
        /// </summary>
        /// <param name="di"></param>
        /// <returns></returns>
        public static DirectoryInfo[] GetAllDirectories(this DirectoryInfo di)
        {
            return GetAllDirectories(di, true);
        }

        /// <summary>
        /// Returns the number of sub elements
        /// </summary>
        /// <param name="di"></param>
        /// <param name="recurs">TRUE to search recursive in sub directories</param>
        /// <param name="filter">An optional file filter</param>
        /// <returns></returns>
        public static int GetAllElements(this DirectoryInfo di, bool recurs, String filter)
        {
            return GetAllFiles(di, recurs, filter).Length + GetAllDirectories(di, recurs).Length;
        }

        public static int GetAllElements(this DirectoryInfo di, bool recurs)
        {
            return GetAllElements(di, recurs, "*.*");
        }

        /// <summary>
        /// Returns all sub elements in this directory and all sub directories
        /// </summary>
        /// <param name="di"></param>
        /// <returns></returns>
        public static int GetAllElements(this DirectoryInfo di)
        {
            return GetAllElements(di, true);
        }

        public static bool CanAccess(this DirectoryInfo di)
        {
            try
            {
                di.GetFiles();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get the root driver information from directory
        /// </summary>
        /// <param name="di"></param>
        /// <returns></returns>
        public static DriveInfo ToRootDriveInfo(this DirectoryInfo di)
        {
            return new DriveInfo(di.FullName[0] + "");
        }

        /// <summary>
        /// Returns the icon for this directory
        /// </summary>
        /// <param name="di"></param>
        /// <returns></returns>
        public static Icon GetIcon(this DirectoryInfo di)
        {
            return Icon.ExtractAssociatedIcon(di.FullName) ?? Resources.Folder;
        }

        /// <summary>
        /// Get all directory parents
        /// </summary>
        /// <param name="di"></param>
        /// <returns></returns>
        public static DirectoryInfo[] GetParents(this DirectoryInfo di)
        {
            List<DirectoryInfo> res = new List<DirectoryInfo>();
            DirectoryInfo parent = di.Parent;

            while (parent != null)
            {
                res.Insert(0, parent);
                parent = parent.Parent;
            }

            return res.ToArray();
        }

        /// <summary>
        /// Get all files in directory that matches with one of the given file filter
        /// </summary>
        /// <param name="di"></param>
        /// <param name="filters">File filter to match</param>
        /// <returns></returns>
        public static FileInfo[] GetFilesMultiFilter(this DirectoryInfo di, params String[] filters)
        {
            List<FileInfo> res = new List<FileInfo>();

            foreach (String filter in filters)
                res.AddRange(di.GetFiles(filter));

            return res.ToArray();
        }

        /// <summary>
        /// Get all files in directory and sub directories that matches with one of the given file filter
        /// </summary>
        /// <param name="di"></param>
        /// <param name="filters">File filter to match</param>
        /// <returns></returns>
        public static FileInfo[] GetAllFilesMultiFilter(this DirectoryInfo di, params String[] filters)
        {
            List<FileInfo> res = new List<FileInfo>();

            foreach (String filter in filters)
                res.AddRange(di.GetAllFiles(true, filter));

            return res.ToArray();
        }

        /// <summary>
        /// Get all directories in directory that matches with one of the given file filter
        /// </summary>
        /// <param name="di"></param>
        /// <param name="filters">File filter to match</param>
        /// <returns></returns>
        public static DirectoryInfo[] GetDirectoriesMultiFilter(this DirectoryInfo di, params String[] filters)
        {
            List<DirectoryInfo> res = new List<DirectoryInfo>();

            foreach (String filter in filters)
                res.AddRange(di.GetDirectories(filter));

            return res.ToArray();
        }

        /// <summary>
        /// Get all directories and sub directories in directory that matches with one of the given file filter
        /// </summary>
        /// <param name="di"></param>
        /// <param name="filters">File filter to match</param>
        /// <returns></returns>
        public static DirectoryInfo[] GetAllDirectoriesMultiFilter(this DirectoryInfo di, params String[] filters)
        {
            List<DirectoryInfo> res = new List<DirectoryInfo>();

            foreach (String filter in filters)
                res.AddRange(di.GetAllDirectories(true, filter));

            return res.ToArray();
        }

        #region Private

        private static void DoDirectoryActionRecurs(DirectoryInfo di, 
            PutInDirectoryEventHandler evtDir, PutInDirectoryEventHandler evtFile)
        {
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                try
                {
                    if (evtDir != null)
                        evtDir(null, new PutInDirectoryEventArgs(dir));
                    DoDirectoryActionRecurs(di, evtDir, evtFile);
                }
                catch (Exception)
                {
                }
            }

            if (evtFile != null)
                evtFile(null, new PutInDirectoryEventArgs(di));
        }

        #endregion
    }
    /// @}

    public class PutInDirectoryEventArgs : EventArgs
    {
        public DirectoryInfo Directory { get; private set; }

        public PutInDirectoryEventArgs(DirectoryInfo di)
        {
            Directory = di;
        }
    }

    public delegate void PutInDirectoryEventHandler(object sender, PutInDirectoryEventArgs e);
}
