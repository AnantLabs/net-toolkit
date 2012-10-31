using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.Threading;

namespace NET.Tools.Forms
{
    internal static class TextManager
    {
        private static ResourceManager rm = new ResourceManager(
            typeof(TextManager).Namespace + ".Text", typeof(TextManager).Assembly);

        private static String GetString(String key)
        {
            return rm.GetString(key, Thread.CurrentThread.CurrentUICulture);
        }

        public static class Dialog
        {
            public static class Message
            {
                public static class Error
                {
                    public static class Regex
                    {
                        public static String Message { get { return GetString("Dialog.Message.Error.Regex.Message"); } }
                        public static String Title { get { return GetString("Dialog.Message.Error.Regex.Title"); } }
                    }

                    public static class Login
                    {
                        public static String Message { get { return GetString("Dialog.Message.Error.Login.Message"); } }
                        public static String Title { get { return GetString("Dialog.Message.Error.Login.Title"); } }
                    }
                }
            }

            public static class Question
            {
                public static class Overwrite
                {
                    public static String Message { get { return GetString("Dialog.Question.Overwrite.Message"); } }
                    public static String MessageFile(String file)
                    {
                        return Message.Replace("%file%", file);
                    }
                    public static String Title { get { return GetString("Dialog.Question.Overwrite.Title"); } }
                    
                }
                public static class Delete
                {
                    public static String Message { get { return GetString("Dialog.Question.Delete.Message"); } }
                    public static String Title { get { return GetString("Dialog.Question.Delete.Title"); } }
                }
            }

            public static class Input
            {
                public static class Path
                {
                    public static String Message { get { return GetString("Dialog.Input.Path.Message"); } }
                }
            }

            public static class Image
            {
                public static String Open { get { return GetString("Dialog.Image.Open"); } }
                public static String Save { get { return GetString("Dialog.Image.Save"); } }
            }
        }

        public static class Button
        {
            public static String Open { get { return GetString("Button.Open"); } }
            public static String Save { get { return GetString("Button.Save"); } }
        }
    }
}
