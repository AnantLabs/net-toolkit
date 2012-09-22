using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Represent the buffer size type
    /// </summary>
    public enum BufferSizeType
    {
        /// <summary>
        /// 80 Columns, 25 Rows
        /// </summary>
        Buffer80x25,
        /// <summary>
        /// 80 Columns, 50 Rows
        /// </summary>
        Buffer80x50
    }

    internal class BufferSizeInformation
    {
        private const int CHARWIDTH = 8;
        private const int CHARHEIGHT25 = 12;
        private const int CHARHEIGHT50 = 6;

        public int Columns { get; private set; }
        public int Rows { get; private set; }
        public int CharWidth { get; private set; }
        public int CharHeight { get; private set; }
        public BufferSizeType BufferSizeType { get; private set; }

        public BufferSizeInformation(BufferSizeType type)
        {
            switch (type)
            {
                case BufferSizeType.Buffer80x25:
                    Columns = 80;
                    Rows = 25;
                    CharWidth = CHARWIDTH;
                    CharHeight = CHARHEIGHT25;
                    break;
                case BufferSizeType.Buffer80x50:
                    Columns = 80;
                    Rows = 50;
                    CharWidth = CHARWIDTH;
                    CharHeight = CHARHEIGHT50;
                    break;
                default:
                    throw new NotImplementedException();
            }

            BufferSizeType = type;
        }
    }
}
