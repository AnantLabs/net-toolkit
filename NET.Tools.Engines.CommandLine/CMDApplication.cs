using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using NET.Tools.OS;

namespace NET.Tools.Engines.CommandLine
{
    /// <summary>
    /// Represent a console application
    /// </summary>
    public static class CMDApplication
    {
        /*private static bool refresh = false; 

        internal static CMDDesktop Desktop { get; private set; }
        internal static event MouseEventHandler MouseEvent;
        internal static BufferSizeInformation BufferSize { get; private set; }

        public static void Run(String title, CMDDesktop desktop, BufferSizeType size)
        {            
            Desktop = desktop;
            BufferSize = new BufferSizeInformation(size);

            switch (size)
            {
                case BufferSizeType.Buffer80x25:
                    Console.BufferWidth = 80;
                    Console.BufferHeight = 25;
                    break;
                case BufferSizeType.Buffer80x50:
                    Console.BufferWidth = 80;
                    Console.BufferHeight = 50;
                    break;
                default:
                    throw new NotImplementedException();
            }
            Console.SetWindowPosition(0, 0);
            Console.Title = title;
            Console.TreatControlCAsInput = true;

            Console.CursorVisible = false;
            refresh = true;

            new Thread(() =>
            {
                while (desktop.IsVisible)
                {
                    if (refresh)
                    {
                        desktop.Paint();
                        refresh = false;
                    }

                    IList<NativeInput> list = ConsoleTools.ReadConsoleInput();
                    foreach (NativeInput input in list)
                    {
                        if (input.EventType == EventType.Mouse)
                        {
                            if (MouseEvent != null)
                            {
                                MouseButtons btn = MouseButtons.None;
                                switch (input.MouseEvent.ButtonState)
                                {
                                    case NativeMouseButton.Left:
                                        btn = MouseButtons.Left;
                                        break;
                                    case NativeMouseButton.Middle:
                                        btn = MouseButtons.Middle;
                                        break;
                                    case NativeMouseButton.X1:
                                        btn = MouseButtons.XButton1;
                                        break;
                                    case NativeMouseButton.X2:
                                        btn = MouseButtons.XButton2;
                                        break;
                                    case NativeMouseButton.Right:
                                        btn = MouseButtons.Right;
                                        break;
                                    default:
                                        break;
                                }

                                MouseEvent(null, new MouseEventArgs(btn, 1, 
                                    input.MouseEvent.MousePosition.X, input.MouseEvent.MousePosition.Y, 0));
                            }
                        }
                    }

                    Thread.Sleep(10);
                }
            }).Start();

            //Thread.Sleep(100);
        }

        public static void Run(CMDDesktop desktop)
        {
            Run("Console GUI Demo", desktop, BufferSizeType.Buffer80x25);
        }

        internal static void Refresh()
        {
            refresh = true;
        }*/
    }
}
