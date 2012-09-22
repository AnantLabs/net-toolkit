using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.CommandLine
{
    public class ArgumentCheckResult
    {
        #region Static

        public static ArgumentCheckResult OK()
        {
            return new ArgumentCheckResult(null, CheckResult.OK, "");
        }

        public static ArgumentCheckResult Failed(IArgument arg, CheckResult res, String msg)
        {
            return new ArgumentCheckResult(arg, res, msg);
        }

        #endregion

        public CheckResult Result { get; private set; }
        public String Message { get; private set; }
        public IArgument Argument { get; private set; }

        private ArgumentCheckResult(IArgument arg, CheckResult res, String msg)
        {
            Result = res;
            Message = msg;
            Argument = arg;
        }

        public String GetError()
        {
            if (Argument == null)
                return Message;

            return Argument.ErrorText.Replace("%message%", Message);
        }

        public override string ToString()
        {
            return GetError();
        }
    }

    /// \addtogroup enums
    /// @{

    /// <summary>
    /// Represent the argument base type
    /// </summary>
    public enum ArgumentBaseType
    {
        /// <summary>
        /// Argument as String or a character
        /// </summary>
        String,
        /// <summary>
        /// Argument as Byte, Int16, Int32, Int64 or unsigned versions
        /// </summary>
        Integer,
        /// <summary>
        /// Argument as Decimal, Double, Float (Single)
        /// </summary>
        Decimal
    }

    /// <summary>
    /// Result type for the argument check method
    /// </summary>
    public enum CheckResult
    {
        /// <summary>
        /// Argument is ok (was accept)
        /// </summary>
        OK,
        /// <summary>
        /// Argument was already set in the past
        /// </summary>
        IsAlreadySet,
        /// <summary>
        /// Argument is wrong
        /// </summary>
        Wrong,
        /// <summary>
        /// Fatal error
        /// </summary>
        Fatal
    }

    /// <summary>
    /// Represent a switch character
    /// </summary>
    /// <see cref="SwitchArgument"/>
    /// <see cref="SwitchedContentArgument{T}"/>
    public enum SwitchCharacter
    {
        /// <summary>
        /// Minus (-xxx)
        /// </summary>
        Minus,
        /// <summary>
        /// Plud (+xxx)
        /// </summary>
        Plus,
        /// <summary>
        /// Slash (/xxx)
        /// </summary>
        Slash,
        /// <summary>
        /// Double minus (--xxx)
        /// </summary>
        DoubleMinus
    }

    /// <summary>
    /// Represent a separator character
    /// </summary>
    /// <see cref="SwitchedContentArgument{T}"/>
    public enum SeparatorCharacter
    {
        /// <summary>
        /// Colon (:)
        /// <example>
        /// program.exe -x:NO
        /// </example>
        /// </summary>
        Colon,
        /// <summary>
        /// Equal (=)
        /// <example>
        /// program.exe -x=NO
        /// </example>
        /// </summary>
        Equal
    }
    /// @}
}
