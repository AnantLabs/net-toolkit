using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Represent a class to read arguments for the program
    /// 
    /// <example>
    /// This example shows you to read the arguments 'filename', '/D' and '/F=Number' from the command line. 
    /// The parameter '/D' must be optional, 'filename' is not optional and '/F=Number' is optional too and must be an Int32:
    /// <code>
    ///  argReader = new ArgumentReader(false, SwitchArgument.CreateHelpArgument(SwitchCharacter.Slash), "My Error Text", 
    ///            "Using: program.exe {filename} [/D] [/F=3]", "Example", "BlaBla", 
    ///            new PureArgument{String}("MyPureArgument", false, false, "Filename", "Pure Argument: %message%"), 
    ///            new SwitchArgument(SwitchCharacter.Slash, "D", "Switch D", "Switch D: %message%"),
    ///            new SwitchedContentArgument{Int32}("SwitchedArgument", SwitchCharacter.Slash, "F", SeparatorCharacter.Equal, true, true, "Switched Content F", "Switched Content F: %message%"));
    ///  if (!argReader.EvaluateArguments(args))
    ///     throw new Exception("Failed to read arguments!");
    /// </code>
    /// </example>
    /// </summary>
    /// <seealso cref="IArgument"/>
    /// <seealso cref="ISwitchArgument"/>
    /// <seealso cref="ITextArgument"/>
    /// <seealso cref="PureArgument{T}"/>
    /// <seealso cref="SwitchArgument"/>
    /// <seealso cref="SwitchedContentArgument{T}"/>
    public class ArgumentReader
    {
        private enum EvaluationResult
        {
            OK,
            Failed,
            Help
        }

        private const int LEFT = 25;

        private String lastError = "";

        /// <summary>
        /// List of arguments to read
        /// </summary>
        /// <see cref="PureArgument{T}"/>
        /// <see cref="SwitchArgument"/>
        /// <see cref="SwitchedContentArgument{T}"/>
        public List<IArgument> ArgumentList { get; private set; }
        /// <summary>
        /// TRUE, if the help page is shown if the argument list is wrong
        /// </summary>
        public bool ShowHelp { get; set; }
        /// <summary>
        /// A string to descripe the syntax using for the arguments
        /// </summary>
        public String SyntaxUsing { get; set; }
        /// <summary>
        /// A string to descripe the syntax using with (an) example(s)
        /// </summary>
        public String ExampleUsing { get; set; }
        /// <summary>
        /// A string to show hints for syntax using
        /// </summary>
        public String Hints { get; set; }
        /// <summary>
        /// A string to show an error text if the argument list is wrong
        /// </summary>
        public String ErrorUsing { get; set; }
        /// <summary>
        /// FALSE, if an error must thrown if the argument is unknown, otherwise it will be ignored
        /// </summary>
        public bool AllowUnknownArgs { get; set; }
        /// <summary>
        /// Represent the argument that shows the help page only. For example '/?'
        /// </summary>
        public SwitchArgument HelpArgument { get; set; }

        public ArgumentReader(bool showHelp, SwitchArgument helpArg, String error, String syntax, String example, 
            String hints, bool allowUnknownArgs, params IArgument[] args)
        {
            ArgumentList = new List<IArgument>();
            ArgumentList.AddRange(args);

            ShowHelp = showHelp;
            ErrorUsing = error;
            SyntaxUsing = syntax;
            ExampleUsing = example;
            Hints = hints;
            AllowUnknownArgs = allowUnknownArgs;
            HelpArgument = helpArg;
        }

        public ArgumentReader(bool showHelp, SwitchArgument helpArg, String error, String syntax, String example,
            String hints, params IArgument[] args)
            : this(showHelp, helpArg, error, syntax, example, hints, false, args)
        {
        }

        public ArgumentReader(bool showHelp, SwitchArgument helpArg, String error, String syntax, String example,
            params IArgument[] args)
            : this(showHelp, helpArg, error, syntax, example, "", args)
        {
        }

        public ArgumentReader(bool showHelp, SwitchArgument helpArg, String error, String syntax, params IArgument[] args)
            : this(showHelp, helpArg, error, syntax, "", args)
        {
        }

        public ArgumentReader(bool showHelp, SwitchArgument helpArg, String error, params IArgument[] args)
            : this(showHelp, helpArg, error, "", args)
        {
        }

        public ArgumentReader(bool showHelp, SwitchArgument helpArg, params IArgument[] args)
            : this(showHelp, helpArg, "", args)
        {
        }

        public ArgumentReader(SwitchArgument helpArg, params IArgument[] args)
            : this(true, helpArg, args)
        {
        }

        public ArgumentReader(params IArgument[] args)
            : this(SwitchArgument.CreateHelpArgument(SwitchCharacter.Slash), args)
        {
        }

        /// <summary>
        /// Evaluate all arguments
        /// </summary>
        /// <param name="args">The argument list</param>
        /// <returns>TRUE, if all is ok</returns>
        public bool EvaluateArguments(params String[] args)
        {
            return EvaluateArgumentsInternal(args) == EvaluationResult.OK;
        }

        private EvaluationResult EvaluateArgumentsInternal(params String[] args)
        {
            lastError = "";

            HelpArgument.Reset();
            //Reset all argument definitions
            foreach (IArgument defArg in ArgumentList)
            {
                defArg.Reset();
            }

            //Check each argument
            foreach (String arg in args)
            {
                if (HelpArgument.Check(arg).Result == CheckResult.OK)
                {
                    PrintHelpPage(false);
                    return EvaluationResult.Help; // Go out, no error, but cannot work
                }

                bool find = false;
                foreach (IArgument defArg in ArgumentList)
                {
                    ArgumentCheckResult result = defArg.Check(arg);
                    if ((result.Result == CheckResult.IsAlreadySet) ||
                        (result.Result == CheckResult.Fatal))
                    {
                        lastError = result.GetError();
                        return EvaluationResult.Failed;
                    }
                    if (result.Result == CheckResult.OK)
                    {
                        find = true;
                        break;
                    }
                }

                if (!AllowUnknownArgs)
                {
                    if (!find)
                    {
                        lastError = "Argument <" + arg + "> is unknown!";
                        return EvaluationResult.Failed;
                    }
                }
            }

            //Evaluate defined args
            int activeLevel = Int32.MinValue; //For argument order
            foreach (IArgument defArg in ArgumentList)
            {
                //False argument order
                if (defArg.Level < activeLevel)
                {
                    lastError = "False argument order";
                    return EvaluationResult.Failed;
                }
                activeLevel = defArg.Level;

                //Is not set?
                if (!defArg.IsSet)
                    //And is not optional?
                    if (!defArg.IsOptional)
                    {
                        lastError = "Arguments are missing";
                        return EvaluationResult.Failed;
                    }
            }

            return EvaluationResult.OK;
        }

        /// <summary>
        /// Evaluate all arguments
        /// </summary>
        /// <param name="autoPrint">TRUE if the method print text to console automaticly</param>
        /// <param name="args">The argument list</param>
        /// <returns>TRUE, if all is ok</returns>
        public bool EvaluateArguments(bool autoPrint, params String[] args)
        {
            EvaluationResult result = EvaluateArgumentsInternal(args);

            if (autoPrint)
            {
                if (result == EvaluationResult.Failed)
                    PrintHelpPage(true);
            }

            return result == EvaluationResult.OK;
        }

        public void PrintHelpPage(bool error)
        {
            if (error)
                if (ErrorUsing != "")
                    Console.WriteLine(ErrorUsing);
            Console.WriteLine();

            if (error)
                if (GetLastError() != "")
                    Console.WriteLine(GetLastError());

            if (error)
                if (!ShowHelp)
                    return;

            Console.WriteLine();
            if (SyntaxUsing != "")
                Console.WriteLine(SyntaxUsing);
            Console.WriteLine();

            List<IArgument> tmp = new List<IArgument>(ArgumentList);
            tmp.Insert(0, HelpArgument); //Add default help argument
            foreach (IArgument arg in tmp)
            {
                String key = "   " + arg.ToString();

                Console.Write(key);
                if (key.Length >= LEFT)
                    Console.WriteLine();

                Console.SetCursorPosition(LEFT, Console.CursorTop);
                Console.WriteLine(arg.HelpText);
            }

            Console.WriteLine();
            if (Hints != "")
                Console.WriteLine(Hints);
            Console.WriteLine();

            if (ExampleUsing != "")
                Console.WriteLine(ExampleUsing);
            Console.WriteLine();
        }

        public String GetLastError()
        {
            return lastError;
        }
    }
}
