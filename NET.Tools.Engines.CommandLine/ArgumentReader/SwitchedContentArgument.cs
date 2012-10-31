using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Represent a switched content argument
    /// <example>
    /// An example for a switched content argument is:
    /// - program.exe -path=C:\
    /// - program.exe -detect:ON
    /// </example>
    /// </summary>
    public sealed class SwitchedContentArgument<T> : IArgument, ITextArgument, ISwitchArgument, IMultiArgument<T> where T : IConvertible
    {
        private List<T> valueList = new List<T>();

        /// <summary>
        /// Represent the seperator between the switch and the argument text
        /// </summary>
        public SeparatorCharacter SeparatorCharacter { get; private set; }

        public SwitchedContentArgument(String name, SwitchCharacter switchChar,
            String switchText, SeparatorCharacter sepChar, bool optional, bool multi, 
            String help, String error, int level, Regex regex)
        {
            IsSet = false;
            valueList = new List<T>();

            SwitchCharacter = switchChar;
            Switch = switchText;
            SeparatorCharacter = sepChar;
            IsOptional = optional;
            IsSeveralTimes = multi;
            HelpText = help;
            Level = level;
            ErrorText = error;
            RegularExpression = regex;
            Name = name;
        }

        public SwitchedContentArgument(String name, SwitchCharacter switchChar,
            String switchText, SeparatorCharacter sepChar, bool optional, bool multi,
            String help, String error, int level)
            : this(name, switchChar, switchText, sepChar, optional, multi, help, error, level, null)
        {
        }

        public SwitchedContentArgument(String name, SwitchCharacter switchChar,
            String switchText, SeparatorCharacter sepChar, bool optional, bool multi, 
            String help, String error)
            : this(name, switchChar, switchText, sepChar, optional, multi, help, error, 0)
        {
        }

        public SwitchedContentArgument(String name, SwitchCharacter switchChar,
            String switchText, SeparatorCharacter sepChar, bool optional, bool multi,
            String help)
            : this(name, switchChar, switchText, sepChar, optional, multi, help, "%message%")
        {
        }

        public SwitchedContentArgument(String name, SwitchCharacter switchChar,
            String switchText, SeparatorCharacter sepChar, bool optional, String help)
            : this(name, switchChar, switchText, sepChar, optional, false, help)
        {
        }

        public SwitchedContentArgument(String name, SwitchCharacter switchChar,
            String switchText, SeparatorCharacter sepChar, String help)
            : this(name, switchChar, switchText, sepChar, false, help)
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
            get;
            private set;
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
            if (!arg.StartsWith(SwitchToString() + Switch + SeparatorToString()))
                return ArgumentCheckResult.Failed(this, CheckResult.Wrong, "");

            if (IsSet)
                if (!IsSeveralTimes)
                    return ArgumentCheckResult.Failed(this, CheckResult.IsAlreadySet, "Is already set");

            String sub = arg.Substring(arg.IndexOf(SeparatorToString())+1);
            if (RegularExpression != null)
                if (!RegularExpression.Match(sub).Success)
                    return ArgumentCheckResult.Failed(this, CheckResult.Fatal, "The arguments structure is wrong (Regular Expression)!");

            IsSet = true;
            valueList.Add((T)(sub as IConvertible).ToType(typeof(T), null));
            return ArgumentCheckResult.OK();
            //switch (BaseType)
            //{
            //    case ArgumentBaseType.String:
            //        IsSet = true;
            //        valueList.Add(sub);
            //        return ArgumentCheckResult.OK();
            //    case ArgumentBaseType.Integer:
            //        int i = 0;
            //        if (!Int32.TryParse(sub, out i))
            //            return ArgumentCheckResult.Failed(this, CheckResult.Fatal, "No integer (e. g. 1234)");
            //        valueList.Add(i);
            //        IsSet = true;
            //        return ArgumentCheckResult.OK();
            //    case ArgumentBaseType.Decimal:
            //        double d = 0;
            //        if (!Double.TryParse(sub, out d))
            //            return ArgumentCheckResult.Failed(this, CheckResult.Fatal, "No double (e. g. 1.234)");
            //        valueList.Add(d);
            //        IsSet = true;
            //        return ArgumentCheckResult.OK();
            //    default:
            //        throw new NotImplementedException();
            //}
        }

        public String ErrorText { get; private set; }

        public void Reset()
        {
            IsSet = false;
            valueList.Clear();
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

        #region ITextArgument Member

        public Regex RegularExpression
        {
            get;
            private set;
        }

        public String Name
        {
            get;
            private set;
        }

        #endregion

        #region IMultiArgument Member

        public ReadOnlyCollection<T> ValueList
        {
            get { return new ReadOnlyCollection<T>(valueList); }
        }

        public T Value
        {
            get { return valueList[0]; }
        }

        #endregion

        private String SeparatorToString()
        {
            switch (SeparatorCharacter)
            {
                case SeparatorCharacter.Colon:
                    return ":";
                case SeparatorCharacter.Equal:
                    return "=";
                default:
                    throw new NotImplementedException();
            }
        }

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
            return SwitchToString() + Switch + SeparatorToString() + "<" + Name + ">";
        }
    }
}
