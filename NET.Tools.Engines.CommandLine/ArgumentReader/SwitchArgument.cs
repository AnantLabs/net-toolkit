using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Represent a switch argument
    /// <example>
    /// An example for a switch argument type is:
    /// - program.exe -D
    /// - program.exe +f
    /// - program.exe --help
    /// </example>
    /// </summary>
    public sealed class SwitchArgument : IArgument, ISwitchArgument
    {
        #region Static

        /// <summary>
        /// Create a default help argument with the given switch character. Text is always '?'
        /// </summary>
        /// <param name="character">Switch character</param>
        /// <returns>Default help argument</returns>
        public static SwitchArgument CreateHelpArgument(SwitchCharacter character)
        {
            return new SwitchArgument(character, "?", "Show this help page");
        }

        #endregion

        public SwitchArgument(SwitchCharacter character, String switchText,
            String help, String error, int level)
        {
            IsSet = false;

            SwitchCharacter = character;
            Switch = switchText;
            IsOptional = true;
            HelpText = help;
            Level = level;
            ErrorText = error;
        }

        public SwitchArgument(SwitchCharacter character, String switchText,
            String help, String error)
            : this(character, switchText, help, error, 0)
        {
        }

        public SwitchArgument(SwitchCharacter character, String switchText,
            String help)
            : this(character, switchText, help, "%message%")
        {
        }

        #region IArgument Member

        public bool IsSet
        {
            get;
            private set;
        }

        public bool IsOptional
        {
            get;
            private set;
        }

        public bool IsSeveralTimes
        {
            get { return false; }
        }

        public string HelpText
        {
            get;
            private set;
        }

        public int Level
        {
            get;
            private set;
        }

        public ArgumentCheckResult Check(string arg)
        {
            if (arg.Equals(SwitchToString() + Switch))
            {
                if (IsSet)
                    return ArgumentCheckResult.Failed(this, CheckResult.IsAlreadySet, "Is already set");

                IsSet = true;
                return ArgumentCheckResult.OK();
            }

            return ArgumentCheckResult.Failed(this, CheckResult.Wrong, "");
        }

        public String ErrorText { get; private set; }

        public void Reset()
        {
            IsSet = false;
        }

        #endregion

        #region ISwitchArgument Member

        public string Switch
        {
            get;
            private set;
        }

        public SwitchCharacter SwitchCharacter
        {
            get;
            private set;
        }

        #endregion

        private String SwitchToString()
        {
            switch (SwitchCharacter)
            {
                case SwitchCharacter.Minus:
                    return "-";
                case SwitchCharacter.Plus:
                    return "+";
                case SwitchCharacter.Slash:
                    return "/";
                case SwitchCharacter.DoubleMinus:
                    return "--";
                default:
                    throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            return SwitchToString() + Switch;
        }
    }
}
