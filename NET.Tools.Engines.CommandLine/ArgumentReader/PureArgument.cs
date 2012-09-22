using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Represent a pure argument
    /// <example>
    /// An example for a pure argument is:
    /// - program.exe C:\test.txt
    /// - program.exe 1234
    /// </example>
    /// </summary>
    public sealed class PureArgument<T> : IArgument, ITextArgument, IMultiArgument<T> where T : IConvertible
    {
        private List<T> valueList;

        public PureArgument(String name, bool optional, bool multi, String help,
            String error, int level, Regex regex)
        {
            IsSet = false;
            valueList = new List<T>();

            IsOptional = optional;
            IsSeveralTimes = multi;
            HelpText = help;
            Level = level;
            ErrorText = error;
            RegularExpression = regex;
            Name = name;
        }

        public PureArgument(String name, bool optional, bool multi, String help,
            String error, int level)
            : this(name, optional, multi, help, error, level, null)
        {
        }

        public PureArgument(String name, bool optional, bool multi, String help,
            String error) :
            this(name, optional, multi, help, error, 0)
        {
        }

        public PureArgument(String name, bool optional, bool multi, String help) :
            this(name, optional, multi, help, "%message%")
        {
        }

        public PureArgument(String name, bool optional, String help) :
            this(name, optional, false, help)
        {
        }

        public PureArgument(String name, String help) :
            this(name, false, help)
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

        public ArgumentCheckResult Check(string arg)
        {
            //Safe the switch(ed content) arguments
            if (arg.StartsWith("-") || arg.StartsWith("+") ||
                arg.StartsWith("/") || arg.StartsWith("--"))
                return ArgumentCheckResult.Failed(this, CheckResult.Wrong, "");

            if (RegularExpression != null)
                if (!RegularExpression.Match(arg).Success)
                    return ArgumentCheckResult.Failed(this, CheckResult.Fatal, "The arguments structure is wrong (Regular Expression)!");

            if (IsSet)
                if (!IsSeveralTimes)
                    return ArgumentCheckResult.Failed(this, CheckResult.IsAlreadySet, "Is already set");

            valueList.Add((T)(arg as IConvertible).ToType(typeof(T), null));
            IsSet = true;
            return ArgumentCheckResult.OK();

            //switch (BaseType)
            //{
            //    case ArgumentBaseType.String:
            //        if (IsSet)
            //            if (!IsSeveralTimes)
            //                return ArgumentCheckResult.Failed(this, CheckResult.IsAlreadySet, "Is already set");

            //        valueList.Add(arg);
            //        IsSet = true;
            //        return ArgumentCheckResult.OK();
            //    case ArgumentBaseType.Integer:
            //        int i;
            //        if (!Int32.TryParse(arg, out i))
            //            return ArgumentCheckResult.Failed(this, CheckResult.Fatal, "No integer (e. g. 1234)");

            //        if (IsSet)
            //            if (!IsSeveralTimes)
            //                return ArgumentCheckResult.Failed(this, CheckResult.IsAlreadySet, "Is already set");

            //        valueList.Add(i);
            //        IsSet = true;
            //        return ArgumentCheckResult.OK();
            //    case ArgumentBaseType.Decimal:
            //        double d;
            //        if (!Double.TryParse(arg, out d))
            //            return ArgumentCheckResult.Failed(this, CheckResult.Fatal, "No double (e. g. 1.234)");

            //        if (IsSet)
            //            if (!IsSeveralTimes)
            //                return ArgumentCheckResult.Failed(this, CheckResult.IsAlreadySet, "Is already set");

            //        valueList.Add(d);
            //        IsSet = true;
            //        return ArgumentCheckResult.OK();
            //    default:
            //        throw new NotImplementedException();
            //}
        }

        public int Level
        {
            get;
            private set;
        }

        public void Reset()
        {
            IsSet = false;
            valueList.Clear();
        }

        public String ErrorText { get; private set; }

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

        public override string ToString()
        {
            return "<" + Name + ">";
        }
    }
}
