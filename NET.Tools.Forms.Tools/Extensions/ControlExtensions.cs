using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Threading;
using System.Globalization;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for controls
    /// </summary>
    public static class ControlExtensions
    {
        public static T Invoke<T>(this Control control, Delegate method)
        {
            return (T)control.Invoke(method);
        }

        /// <summary>
        /// Update the culture to the given culture and update the controls used UpdateByCurrentCulture
        /// 
        /// <example>
        /// This example shows you to change the culture:
        /// <code>
        /// private void btnEnglishClick(object sender, EventArgs e)
        /// {
        ///     this.UpdateCulture(new CultureInfo("en"));
        /// }
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="control"></param>
        /// <param name="culture">The culture used to update</param>
        public static void UpdateCulture(this Control control, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            control.UpdateByCurrentCulture();
        }

        /// <summary>
        /// Update the UI culture to the given culture and update the controls used UpdateByCurrentCulture
        /// 
        /// <example>
        /// This example shows you to change the culture:
        /// <code>
        /// private void btnEnglishClick(object sender, EventArgs e)
        /// {
        ///     this.UpdateUICulture(new CultureInfo("en"));
        /// }
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="control"></param>
        /// <param name="culture">The culture used to update</param>
        public static void UpdateUICulture(this Control control, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentUICulture = culture;
            control.UpdateByCurrentUICulture();
        }

        /// <summary>
        /// Update the properties of all components and controls in this control with the current UI culture
        /// 
        /// <remarks>
        /// Support:
        /// - Text (Property)
        /// </remarks>
        /// </summary>
        /// <param name="control"></param>
        public static void UpdateByCurrentUICulture(this Control control)
        {
            ResourceManager rm = new ResourceManager(control.GetType());
            UpdateContainer(control, rm, true);
            UpdateThis(control, rm, true);
        }

        /// <summary>
        /// Update the properties of all components and controls in this control with the current culture
        /// 
        /// <remarks>
        /// Support:
        /// - Text (Property)
        /// </remarks>
        /// </summary>
        /// <param name="control"></param>
        public static void UpdateByCurrentCulture(this Control control)
        {
            ResourceManager rm = new ResourceManager(control.GetType());
            UpdateContainer(control, rm, false);
            UpdateThis(control, rm, false);
        }

        private static void UpdateContainer(Control control, ResourceManager rm, bool uiCulture)
        {
            foreach (Control contr in control.Controls)
            {
                //Console.WriteLine("Control: " + contr.Name);

                if (contr.GetType().IsSubclassOf(typeof(ToolStrip)) || (contr is ToolStrip))
                {
                    UpdateToolStrip(contr as ToolStrip, rm, uiCulture);
                }
                else
                {
                    String text = null;
                    if (uiCulture)
                        text = rm.GetString(contr.Name + ".Text", Thread.CurrentThread.CurrentUICulture);
                    else
                        text = rm.GetString(contr.Name + ".Text", Thread.CurrentThread.CurrentCulture);

                    if (text != null)
                        contr.Text = text;                    
                }

                UpdateContainer(contr, rm, uiCulture);
            }
        }

        private static void UpdateThis(Control control, ResourceManager rm, bool uiCulture)
        {
            String text = null;
            if (uiCulture)
                text = rm.GetString("$this.Text", Thread.CurrentThread.CurrentUICulture);
            else
                text = rm.GetString("$this.Text", Thread.CurrentThread.CurrentCulture);

            if (text != null)
                control.Text = text;
        }

        private static void UpdateToolStrip(ToolStrip strip, ResourceManager rm, bool uiCulture)
        {
            foreach (ToolStripItem item in strip.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    UpdateToolStripMenuItem(item as ToolStripMenuItem, rm, uiCulture);
                }
                else
                {
                    String text = null;
                    if (uiCulture)
                        text = rm.GetString(item.Name + ".Text", Thread.CurrentThread.CurrentUICulture);
                    else
                        text = rm.GetString(item.Name + ".Text", Thread.CurrentThread.CurrentCulture);

                    if (text != null)
                        item.Text = text;
                }
            }
        }

        private static void UpdateToolStripMenuItem(ToolStripMenuItem item, ResourceManager rm, bool uiCulture)
        {
            foreach (ToolStripItem i in item.DropDownItems)
            {
                if (i is ToolStripMenuItem)
                    UpdateToolStripMenuItem(i as ToolStripMenuItem, rm, uiCulture);
            }

            String text = null;
            if (uiCulture)
                text = rm.GetString(item.Name + ".Text", Thread.CurrentThread.CurrentUICulture);
            else
                text = rm.GetString(item.Name + ".Text", Thread.CurrentThread.CurrentCulture);

            if (text != null)
                item.Text = text;
        }
    }
    /// @}
}
