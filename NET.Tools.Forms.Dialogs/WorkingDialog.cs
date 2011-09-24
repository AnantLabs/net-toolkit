using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;


namespace NET.Tools.Forms
{
    /// \addtogroup dialogGroup
    /// @{

    /// <summary>
    /// Represent a dialog for show the working state with a progress bar
    /// 
    /// <example>
    /// Here you can see a default call of this dialog while copying a file
    /// <code>
    /// WorkingDialog.ShowDialog("Copy...", (sender, e) => 
    /// {
    ///     e.HideKBS();
    ///     e.HideTime();   
    ///     e.Maximum = stream.Length;
    ///     
    ///     byte[] buffer = new byte[0xffff];
    ///     int bytes = 0;
    ///     
    ///     int tickFirst = Environment.GetTickCount();
    ///     
    ///     while(bytes &lt; stream.Length)
    ///     {
    ///         int read = stream.Read(buffer, 0, 0xffff);
    ///         if (read == 0)
    ///             break;         
    ///             
    ///         out.Write(buffer, 0, read);
    ///         
    ///         bytes += read;
    ///         
    ///         e.Value = bytes;
    ///         e.ShowTime(stream.Length, bytes, tickFirst, Environment.GetTickCount());
    ///         e.ShowKBS(bytes, tickFirst, Environment.GetTickCount());
    ///     }
    /// });
    /// </code>
    /// </example>
    /// </summary>
    public partial class WorkingDialog : Form
    {
        #region Inner classes

        public delegate void WorkingEventHandler(object sender, WorkingEventArgs e);

        public class WorkingEventArgs : EventArgs
        {
            internal WorkingDialog Form { get; private set; }
            internal long FirstTick { get; private set; }

            internal WorkingEventArgs(WorkingDialog dlg)
            {
                Form = dlg;
                FirstTick = Environment.TickCount;
            }

            public String Info
            {
                get { return Form.Invoke<String>(new Func<String>(() => { return Form.lblAction.Text; })); }
                set { Form.Invoke(new Action(() => { Form.lblAction.Text = value; })); }
            }

            /// <summary>
            /// Set the time to end
            /// </summary>
            /// <param name="max">Maximum value</param>
            /// <param name="val">Value now (must be greater than 0)</param>
            /// <param name="type">Output of time</param>
            public void ShowTime(double max, double val, TimeSpanStringType type)
            {                
                Form.Invoke(new Action(() =>
                {
                    if (val == 0)
                        throw new ArgumentException("Division by zero! Value cannot be 0!");                

                    Form.lblTime.Text = ComputeTools.ComputeTimeToEnd(max, val,
                        FirstTick, Environment.TickCount).ToString(type);
                }));
            }

            /// <summary>
            /// Set the time to end and shows it with type "TimeSpanStringType.OnlyLast"
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
                Form.Invoke(new Action(() =>
                {
                    Form.lblTime.Text = "";
                }));
            }

            /// <summary>
            /// Set the kb/s value
            /// </summary>
            /// <param name="val">Value now</param>
            public void ShowKBS(double val)
            {
                Form.Invoke(new Action(() =>
                {
                    Form.lblSpeed.Text = ComputeTools.ComputeKBytesPerSecond(val, 
                        FirstTick, Environment.TickCount).ToByteSizeString();
                }));
            }

            /// <summary>
            /// Hide the KBS
            /// </summary>
            public void HideKBS()
            {
                Form.Invoke(new Action(() =>
                {
                    Form.lblSpeed.Text = "";
                }));
            }

            /// <summary>
            /// Maximum for the progress bar
            /// </summary>
            public int Maximum
            {
                get { return Form.Invoke<int>(new Func<int>(() => { return Form.pbProgress.Maximum; })); }
                set { Form.Invoke(new Action(() => { Form.pbProgress.Maximum = value; })); }
            }

            /// <summary>
            /// Value now for the progress bar
            /// </summary>
            public int Value
            {
                get { return Form.Invoke<int>(new Func<int>(() => { return Form.pbProgress.Value; })); }
                set { Form.Invoke(new Action(() => { Form.pbProgress.Value = value; })); }
            }
        }

        #endregion

        #region Static

        public static bool ShowDialog(String title, WorkingEventHandler handler)
        {
            WorkingDialog dlg = new WorkingDialog(handler);
            dlg.Text = title;

            return dlg.ShowDialog() == DialogResult.OK;
        }

        #endregion

        private Thread thread;
        private WorkingEventHandler handler;

        public WorkingDialog(WorkingEventHandler handler)
        {
            InitializeComponent();
            DialogResult = DialogResult.OK;

            this.handler = handler;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            thread.Abort();
            Close();
        }

        private void WorkingDialog_Shown(object sender, EventArgs e)
        {
            thread = new Thread(() =>
            {
                if (handler != null)
                    handler(this, new WorkingEventArgs(this));
                this.Invoke(new Action(() =>
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }));
            });
            thread.Priority = ThreadPriority.Normal;
            thread.Start();
        }
    }
    /// @}
}
