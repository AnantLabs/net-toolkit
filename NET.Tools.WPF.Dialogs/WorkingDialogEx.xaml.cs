using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;
using NET.Tools.WPF.Skins;





namespace NET.Tools.WPF
{
    /// \addtogroup dialogGroup
    /// @{

    /// <summary>
    /// Represent a Dialog for working processes with a progress bar
    /// 
    /// Change the skin about the bundle parameter
    /// </summary>
    public partial class WorkingDialogEx : Window
    {
        #region Inner Classes
        /// <summary>
        /// Action for the working thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void WorkingActionHandler(object sender, WorkingActionEventArgs e);

        /// <summary>
        /// Event-Arguments for the woring action
        /// </summary>
        public class WorkingActionEventArgs : EventArgs
        {
            private WorkingDialogEx win;
            private long firstTick;

            /// <summary>
            /// Gets or sets the info-text
            /// </summary>
            public String Info
            {
                get { return win.Invoke<String>(() => { return win.Info; }); }
                set { win.Invoke(() => { win.Info = value; }); }
            }

            /// <summary>
            /// Set the time to end
            /// </summary>
            /// <param name="max">Maximum value</param>
            /// <param name="val">Value now (must be greater than 0)</param>
            /// <param name="type">Output of time</param>
            public void ShowTime(double max, double val, TimeSpanStringType type)
            {
                win.Invoke(() =>
                {
                    if (val == 0)
                        throw new ArgumentException("Division by zero! Value cannot be 0!");

                    win.Time = ComputeTools.ComputeTimeToEnd(max, val, 
                        firstTick, Environment.TickCount).ToString(type);
                });
            }

            /// <summary>
            /// Set the time to end
            /// </summary>
            /// <param name="max">Maximum value</param>
            /// <param name="val">Value now (must be greater than 0)</param>
            public void ShowTime(double max, double val)
            {
                ShowTime(max, val, TimeSpanStringType.OnlyLast);
            }

            /// <summary>
            /// Hide the time
            /// </summary>
            public void HideTime()
            {
                win.Invoke(() =>
                {
                    win.Time = "";
                });
            }

            /// <summary>
            /// Set the kb/s value
            /// </summary>
            /// <param name="val">Value now</param>
            public void ShowKBS(double val)
            {
                win.Invoke(() =>
                {
                    win.KBS = ComputeTools.ComputeKBytesPerSecond(val, 
                        firstTick, Environment.TickCount).ToByteSizeString();
                });
            }

            /// <summary>
            /// Hide the KBS
            /// </summary>
            public void HideKBS()
            {
                win.Invoke(() =>
                {
                    win.KBS = "";
                });
            }

            /// <summary>
            /// Maximum for the progress bar
            /// </summary>
            public double Maximum
            {
                get { return win.Invoke<double>(() => { return win.Maximum; }); }
                set { win.Invoke(() => { win.Maximum = value; }); }
            }

            /// <summary>
            /// Value now for the progress bar
            /// </summary>
            public double Value
            {
                get { return win.Invoke<double>(() => { return win.Value; }); }
                set { win.Invoke(() => { win.Value = value; }); }
            }

            internal WorkingActionEventArgs(WorkingDialogEx win)
            {
                this.win = win;
                this.firstTick = Environment.TickCount;
            }
        }
        #endregion

        #region Static
        /// <summary>
        /// Show the dialog
        /// </summary>
        /// <param name="title">Dialogs title</param>
        /// <param name="info">Info-text</param>
        /// <param name="action">Working action</param>
        /// <param name="bundle">Skin-Bundle</param>
        /// <returns>TRUE, if the dialog was not canceled and there are no exceptions in action thread</returns>
        public static bool ShowDialog(String title, String info, WorkingActionHandler action, SkinBundle bundle)
        {
            WorkingDialogEx dlg = new WorkingDialogEx();
            dlg.Title = title;
            dlg.lblInfo.Content = info;
            dlg.action = action;

            if (bundle != null)
            {
                dlg.Resources.Source = bundle.XAMLSkinPath;
                dlg.Style = (Style)dlg.Resources[bundle.WindowTemplateKey];
            }

            return dlg.ShowDialog().GetValueOrDefault(false);
        }

        /// <summary>
        /// Show the dialog
        /// </summary>
        /// <param name="title">Dialogs title</param>
        /// <param name="info">Info-text</param>
        /// <param name="action">Working action</param>
        /// <returns>TRUE, if the dialog was not canceled and there are no exceptions in action thread</returns>
        public static bool ShowDialog(String title, String info, WorkingActionHandler action)
        {
            return ShowDialog(title, info, action, null);
        }
        #endregion

        private bool canClose = false;
        private WorkingActionHandler action;
        private Thread thread;

        internal String Info
        {
            get { return lblInfo.Content as String; }
            set { lblInfo.Content = value; }
        }
        internal String Time
        {
            get { return (String)lblTime.Content; }
            set
            {
                lblTime.Content = value;
            }
        }
        internal String KBS
        {
            get { return (String)lblKBS.Content; }
            set
            {
                lblKBS.Content = value;
            }
        }
        internal double Maximum
        {
            get { return pbProgress.Maximum; }
            set { pbProgress.Maximum = value; lblPercent.Content = ComputePercent().ToString("0.00") + "%"; }
        }
        internal double Value
        {
            get { return pbProgress.Value; }
            set { pbProgress.Value = value; lblPercent.Content = ComputePercent().ToString("0.00") + "%"; }
        }

        private WorkingDialogEx()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!canClose)
                e.Cancel = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            thread.Abort();
            canClose = true;
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            thread = new Thread(() =>
            {
                try
                {
                    action(this, new WorkingActionEventArgs(this));

                    canClose = true;
                    this.Dispatcher.Invoke(new Action(() => { DialogResult = true; }), null);
                }
                catch (Exception ex)
                {
                    if (ex is ThreadAbortException)
                        return;

                    Console.WriteLine(
                        ex.GetType().Name + ": " + ex.Message + "\n" + 
                        ex.StackTrace.ToString());

                    canClose = true;
                    this.Dispatcher.Invoke(new Action(() => { DialogResult = false; }), null);
                }
                finally
                {
                    this.Dispatcher.Invoke(new Action(() => { Close(); }), null);
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private double ComputePercent()
        {
            return pbProgress.Value * 100d / pbProgress.Maximum;
        }
    }
}
