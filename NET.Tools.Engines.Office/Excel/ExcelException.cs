﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NET.Tools.Engines.Office.Excel
{
    /// \addtogroup office_excel
    /// @{

    [Serializable]
    public class ExcelException : OfficeException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ExcelException()
        {
        }

        public ExcelException(string message) : base(message)
        {
        }

        public ExcelException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ExcelException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

    /// @}
}
