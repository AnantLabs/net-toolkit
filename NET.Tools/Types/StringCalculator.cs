using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NET.Tools
{
    /// <summary>
    /// Compute string calculations
    /// 
    /// <example>
    /// This example shows you to use this tools class:
    /// <code>
    /// String calc = "21*x/3";
    /// double result = 0d;
    /// 
    /// for(double i = -1.0d; i &lt;= 1.0d; i += 0.01d)
    /// {
    ///     Dictionary{String, double} dic = new Dictionary{String, double}();
    ///     dic.Add("x", i);
    /// 
    ///     result += StringCalculator.ParseCalculationString(calc, dic);
    /// }
    /// </code>
    /// This example shows you a complex operation:
    /// <code>
    /// String calc = "-(4 * 5.23) * sin(cos(-3.45)/1.2) + 0.567";
    /// double value = StringCalculator.ParseCalculationString(calc);
    /// </code>
    /// </example>
    /// 
    /// <remarks>
    /// Supported:
    /// - Number format:
    ///     - Negative numbers
    ///     - Decimal numbers with [.] and [,]
    ///     - Variable number of digits (default 6)
    /// - Operations (Pow first, Point second, Line third):
    ///     - Add +
    ///     - Sub -
    ///     - Div /
    ///     - Mul *
    ///     - Mod %
    ///     - Pow ^
    /// - Breaks
    /// - Functions:
    ///     - Sin
    ///     - Cos
    ///     - Tan
    ///     - SinA
    ///     - CosA
    ///     - TanA
    ///     - Sinh
    ///     - Cosh
    ///     - Tanh
    ///     - Abs
    ///     - Round
    ///     - Trunc
    ///     - Sqrt
    /// </remarks>
    /// </summary>
    public static class StringCalculator
    {
        private static int decimals = 6;

        #region Calculator

        private static String NumberRegex { get { return "([\\-]?[0-9]+(\\,[0-9]+)?)"; } }

        private static String SubRegex { get { return "(\\-)"; } }
        private static String AddRegex { get { return "(\\+)"; } }
        private static String DivRegex { get { return "(\\/)"; } }
        private static String MulRegex { get { return "(\\*)"; } }
        private static String PowRegex { get { return "(\\^)"; } }
        private static String ModRegex { get { return "(\\%)"; } }

        private static String SinRegex { get { return "(sin)"; } }
        private static String CosRegex { get { return "(cos)"; } }
        private static String TanRegex { get { return "(tan)"; } }
        private static String SinhRegex { get { return "(sinh)"; } }
        private static String CoshRegex { get { return "(cosh)"; } }
        private static String TanhRegex { get { return "(tanh)"; } }
        private static String ASinRegex { get { return "(sina)"; } }
        private static String ACosRegex { get { return "(cosa)"; } }
        private static String ATanRegex { get { return "(tana)"; } }
        private static String AbsRegex { get { return "(abs)"; } }
        private static String TruncRegex { get { return "(trunc)"; } }
        private static String RoundRegex { get { return "(round)"; } }
        private static String SqrtRegex { get { return "(sqrt)"; } }

        private static Regex Pow
        {
            get { return new Regex(NumberRegex + PowRegex + NumberRegex, RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex Add
        {
            get { return new Regex(NumberRegex + AddRegex + NumberRegex, RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex Sub
        {
            get { return new Regex(NumberRegex + SubRegex + NumberRegex, RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex Mul
        {
            get { return new Regex(NumberRegex + MulRegex + NumberRegex, RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex Div
        {
            get { return new Regex(NumberRegex + DivRegex + NumberRegex, RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex Mod
        {
            get { return new Regex(NumberRegex + ModRegex + NumberRegex, RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex Breaks
        {
            get { return new Regex("[\\(][^\\(\\)]+[\\)]", RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex Sin
        {
            get { return new Regex(SinRegex + NumberRegex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex Cos
        {
            get { return new Regex(CosRegex + NumberRegex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex Tan
        {
            get { return new Regex(TanRegex + NumberRegex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex Sinh
        {
            get { return new Regex(SinhRegex + NumberRegex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex Cosh
        {
            get { return new Regex(CoshRegex + NumberRegex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex Tanh
        {
            get { return new Regex(TanhRegex + NumberRegex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex ASin
        {
            get { return new Regex(ASinRegex + NumberRegex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex ACos
        {
            get { return new Regex(ACosRegex + NumberRegex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex ATan
        {
            get { return new Regex(ATanRegex + NumberRegex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex Abs
        {
            get { return new Regex(AbsRegex + NumberRegex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex Round
        {
            get { return new Regex(RoundRegex + NumberRegex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex Trunc
        {
            get { return new Regex(TruncRegex + NumberRegex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace); }
        }

        private static Regex Sqrt
        {
            get { return new Regex(SqrtRegex + NumberRegex, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace); }
        }

        #endregion

        /// <summary>
        /// Parse an as string given calculation
        /// </summary>
        /// <param name="str"></param>
        /// <param name="valueList">An optional list to replace characters with the given numbers</param>
        /// <param name="decimals">Count of digits</param>
        /// <returns>The calculation result</returns>
        /// <exception cref="ParserException">
        /// Is thrown if the parser cannot parse the string
        /// </exception>
        /// <exception cref="NumberParserException">
        /// Is thrown if an number cannot be parsed
        /// </exception>
        public static double ParseCalculationString(String str, Dictionary<String, double> valueList, int decimals)
        {
            StringCalculator.decimals = decimals;

            Log.Info("Parse calculation string...");
            Log.Debug("Incomming: " + str);
            foreach (String key in valueList.Keys)
                str = str.Replace(key, valueList[key].ToString(CreateForToStringZeros()));
            Log.Debug("Replace values: " + str);

            //Replace all points with comma for decimal numbers
            str = str.Replace('.', ',');
            Log.Debug("Replace '.': " + str);
            //Remove all spaces
            str = str.RemoveAllSpaces();
            Log.Debug("Remove all spaces: " + str);

            str = CheckForBreaks(str); //Clean up from breaks (compute all breaks)
            double value = CheckForOperatorsAndFunctions(str); //Last step: Compute all operations

            Log.Info("Finished parsing, result: " + value);
            return value;
        }

        public static double ParseCalculationString(String str, Dictionary<String, double> valueList)
        {
            return ParseCalculationString(str, valueList, 6);
        }

        public static double ParseCalculationString(String str, int decimals)
        {
            return ParseCalculationString(str, new Dictionary<string, double>(), decimals);
        }

        public static double ParseCalculationString(String str)
        {
            return ParseCalculationString(str, new Dictionary<string,double>());
        }

        #region Private

        private static String CheckForBreaks(String str)
        {
            Log.Debug("Check for breaks...");

            StringBuilder calc = new StringBuilder(str);
            Match match = null;

            do
            {
                Log.Debug("Current: " + calc.ToString());

                match = Breaks.Match(calc.ToString());
                if (match.Success)
                {
                    Log.Debug("Found match: " + match.Value);

                    //Get part
                    String part = match.Value.Substring(1, match.Value.Length - 2);
                    //Compute all operations to one double number
                    double value = CheckForOperatorsAndFunctions(part);

                    //Remove position included breaks
                    calc.Remove(match.Index, match.Length);
                    //Insert double number value on this place
                    calc.Insert(match.Index, value.ToString(CreateForToStringZeros()));

                    Log.Debug("New string: " + calc.ToString());
                }
            } while (match.Success);

            Log.Debug("Breaks result: " + str);
            return calc.ToString();
        }

        private static double CheckForOperatorsAndFunctions(String str)
        {
            // I: Functions
            str = CheckFor(str, Sin, "sin");
            str = CheckFor(str, Cos, "cos");
            str = CheckFor(str, Tan, "tan");
            str = CheckFor(str, ASin, "sina");
            str = CheckFor(str, ACos, "cosa");
            str = CheckFor(str, ATan, "tana");
            str = CheckFor(str, Sinh, "sinh");
            str = CheckFor(str, Cosh, "cosh");
            str = CheckFor(str, Tanh, "tanh");
            str = CheckFor(str, Abs, "abs");
            str = CheckFor(str, Round, "round");
            str = CheckFor(str, Trunc, "trunc");
            str = CheckFor(str, Sqrt, "sqrt");

            // II: Operations
            //Step 1: Pow
            str = CheckFor(str, Pow, '^');
            //Step 2: Mul / Div
            str = CheckFor(str, Mod, '%');
            str = CheckFor(str, Mul, '*');
            str = CheckFor(str, Div, '/');
            //Step 3: Add / Sub
            str = CheckFor(str, Add, '+');
            str = CheckFor(str, Sub, '-');

            double value = 0d;
            if (!Double.TryParse(str, out value))
                throw new NumberParserException("Number cannot be parsed (" + str + ")");

            return value;
        }

        private static String CheckFor(String str, Regex reg, string func)
        {
            Log.Debug("Check for function: " + func);

            StringBuilder calc = new StringBuilder(str);
            Match match = null;

            do
            {
                Log.Debug("Current: " + str);

                match = reg.Match(calc.ToString());
                if (match.Success)
                {
                    Log.Debug("Found match: " + match.Value);

                    String part = match.Value;
                    double value = ComputeCalculationForFunctions(part, func);

                    calc.Remove(match.Index, match.Length);
                    calc.Insert(match.Index, value.ToString(CreateForToStringZeros()));

                    Log.Debug("New string: " + str);
                }
            }
            while (match.Success);

            Log.Debug("Functions result: " + str);
            return calc.ToString();
        }

        private static String CheckFor(String str, Regex reg, char operation)
        {
            Log.Debug("Check for operators: " + operation);

            StringBuilder calc = new StringBuilder(str);
            Match match = null;

            do
            {
                Log.Debug("Current: " + str);

                match = reg.Match(calc.ToString());
                if (match.Success)
                {
                    Log.Debug("Found match: " + match.Value);

                    String part = match.Value;
                    double value = ComputeCalculationForOperators(part, operation);

                    calc.Remove(match.Index, match.Length);
                    calc.Insert(match.Index, value.ToString(CreateForToStringZeros()));

                    Log.Debug("New string: " + str);
                }
            }
            while (match.Success);

            Log.Debug("Operation result: " + str);
            return calc.ToString();
        }

        private static double ComputeCalculationForFunctions(String str, string func)
        {
            double value = 0;
            if (!Double.TryParse(str.Substring(func.Length), out value))
                throw new NumberParserException("Cannot parse number for function " + func + "!");

            switch (func.ToLower())
            {
                case "sin":
                    return Math.Sin(value);
                case "cos":
                    return Math.Cos(value);
                case "tan":
                    return Math.Tan(value);
                case "sinh":
                    return Math.Sinh(value);
                case "cosh":
                    return Math.Cosh(value);
                case "tanh":
                    return Math.Tanh(value);
                case "trunc":
                    return Math.Truncate(value);
                case "abs":
                    return Math.Abs(value);
                case "sqrt":
                    return Math.Sqrt(value);
                case "sina":
                    return Math.Asin(value);
                case "cosa":
                    return Math.Acos(value);
                case "tana":
                    return Math.Atan(value);
                case "round":
                    return Math.Round(value);
                default:
                    throw new ParserException("Unknown function: " + func);
            }
        }

        private static double ComputeCalculationForOperators(String str, char operation)
        {
            MatchCollection matches = new Regex(NumberRegex).Matches(str);
            if (matches.Count != 2)
                throw new ParserException("Match error!");

            //Search first match in string
            Match match = null;
            if (matches[0].Index == 0)
                match = matches[0];
            else if (matches[1].Index == 0)
                match = matches[1];

            //Check operator
            int opIndex = match.Length;
            if (str[opIndex] != operation)
                throw new ParserException("Operation failed: " + str[opIndex]);
            //Split on index
            String[] parts = new String[] { str.Substring(0, match.Length), str.Substring(opIndex + 1) };

            try
            {
                double first = Double.Parse(parts[0]);
                double second = Double.Parse(parts[1]);

                switch (operation)
                {
                    case '^':
                        return Math.Pow(first, second);
                    case '+':
                        return first + second;
                    case '-':
                        return first - second;
                    case '*':
                        return first * second;
                    case '/':
                        return first / second;
                    case '%':
                        return first % second;
                    default:
                        throw new ParserException("Unknown operator: " + operation);
                }
            }
            catch (Exception e)
            {
                throw new NumberParserException("Cannot parse the number!", e);
            }
        }

        private static String CreateForToStringZeros()
        {
            StringBuilder str = new StringBuilder();
            str.Append("0.");

            for (int i = 0; i < decimals; i++)
                str.Append("0");

            return str.ToString();
        }

        #endregion
    }
}
