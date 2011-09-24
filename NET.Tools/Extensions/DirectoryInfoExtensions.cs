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

        public static long GetDirectorySize(this DirectoryInfo di)
        {
            return GetDirectorySize(di, true);
        }

        public static int GetDirectoryFiles(this DirectoryInfo di, bool recurs, String filter)
        {
            if (!recurs)
            {
                return di.GetFiles(filter).Length;
            }
            else
            {
                int counter=0;
                DoDirectoryActionRecurs(di, null,
                    (s, e) =>
                    {
                        counter += di.GetFiles(filter).Length;
                    });
                return counter;
            }
        }

        public static int GetDirectoryFiles(this DirectoryInfo di, bool recurs)
        {
            return GetDirectoryFiles(di, recurs, "*.*");
        }

        public static int GetDirectoryFiles(this DirectoryInfo di)
        {
            return GetDirectoryFiles(di, false);
        }

        public static int GetDirectoryFolders(this DirectoryInfo di, bool recurs)
        {
            if (!recurs)
            {
                return di.GetDirectories().Length;
            }
            else
            {
                int counter = 0;
                DoDirectoryActionRecurs(di, null,
                    (s, e) =>
                    {
                        counter += di.GetDirectories().Length;
                    });
                return counter;
            }
        }

        public static int GetDirectoryFolders(this DirectoryInfo di)
        {
            return GetDirectoryFolders(di, false);
        }

        public static int GetDirectoryElements(this DirectoryInfo di, bool recurs, String filter)
        {
            return GetDirectoryFiles(di, recurs, filter) + GetDirectoryFolders(di, recurs);
        }

        public static int GetDirectoryElements(this DirectoryInfo di, bool recurs)
        {
            return GetDirectoryElements(di, recurs);
        }

        public static int GetDirectoryElements(this DirectoryInfo di)
        {
            return GetDirectoryElements(di, false);
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

        public static int GetDirectoryParentsCount(this DirectoryInfo di)
        {
            int counter = 0;
            DirectoryInfo parent = di.Parent;

            while (parent != null)
            {
                counter++;
                parent = parent.Parent;
            }

            return counter;
        }

        public static DriveInfo ToRootDriveInfo(this DirectoryInfo di)
        {
            return new DriveInfo(di.FullName[0] + "");
        }

        public static Icon GetIcon(this DirectoryInfo di)
        {
            return Resources.Folder;
        }

        public static DirectoryInfo[] GetDirectoryParents(this DirectoryInfo di)
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

        public static FileInfo[] GetFiles(this DirectoryInfo di, params String[] filters)
        {
            List<FileInfo> res = new List<FileInfo>();

            foreach (String filter in filters)
                res.AddRange(di.GetFiles(filter));

            return res.ToArray();
        }

        public static DirectoryInfo[] GetDirectories(this DirectoryInfo di, params String[] filters)
        {
            List<DirectoryInfo> res = new List<DirectoryInfo>();

            foreach (String filter in filters)
                res.AddRange(di.GetDirectories(filter));

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
