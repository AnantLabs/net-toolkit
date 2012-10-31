using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Resources;

namespace NET.Tools
{
    /// \addtogroup extensions
    /// @{

    /// <summary>
    /// Extensions for Window Forms
    /// </summary>
    public static class FormExtensions
    {
        public static void CloseActiveMdiChild(this Form form)
        {
            form.ActiveMdiChild.Close();
        }

        public static void CloseAllMdiChildren(this Form form)
        {
            foreach (Form child in form.MdiChildren)
                child.Close();
        }

        public static void CloseOtherMdiChildren(this Form form)
        {
            Form activeMdi = form.ActiveMdiChild;

            foreach (Form child in form.MdiChildren)
                if (!child.Equals(activeMdi))
                    child.Close();
        }

        /// <summary>
        /// Checks automatically the possibility of closing a child window
        /// </summary>
        /// <param name="form"></param>
        /// <param name="mi"></param>
        public static void SetMdiCloseActiveEvent(this Form form, ToolStripMenuItem mi)
        {
            Thread thread = new Thread(() =>
            {
                while (form.Created)
                {
                    if (form.Visible)
                        try
                        {
                            form.Invoke(new Action(() => { mi.Enabled = form.ActiveMdiChild != null; }));
                        }
                        catch (Exception) { }
                    Thread.Sleep(100);
                }
            });
            form.Load += (s, e) => { thread.Start(); };
        }

        /// <summary>
        /// Checks automatically the possibility of closing all child windows
        /// </summary>
        /// <param name="form"></param>
        /// <param name="mi"></param>
        public static void SetMdiCloseAllEvent(this Form form, ToolStripMenuItem mi)
        {
            Thread thread = new Thread(() =>
            {
                while (form.Created)
                {
                    if (form.Visible)
                        try
                        {
                            form.Invoke(new Action(() => { mi.Enabled = form.MdiChildren.Length > 0; }));
                        }
                        catch (Exception) { }
                    Thread.Sleep(100);
                }
            });
            form.Load += (s, e) => { thread.Start(); };
        }

        /// <summary>
        /// Checks automatically the possibility of closing the others child windows
        /// </summary>
        /// <param name="form"></param>
        /// <param name="mi"></param>
        public static void SetMdiCloseOthersEvent(this Form form, ToolStripMenuItem mi)
        {
            Thread thread = new Thread(() =>
            {
                while (form.Created)
                {
                    if (form.Visible)
                        try
                        {
                            form.Invoke(new Action(() => { mi.Enabled = form.MdiChildren.Length > 1; }));
                        }
                        catch (Exception) { }
                    Thread.Sleep(100);
                }
            });
            form.Load += (s, e) => { thread.Start(); };
        }

        public static void SetMdiCloseActiveEvent(this Form form, ToolStripButton btn)
        {
            Thread thread = new Thread(() =>
            {
                while (form.Created)
                {
                    if (form.Visible)
                        try
                        {
                            form.Invoke(new Action(() => { btn.Enabled = form.ActiveMdiChild != null; }));
                        }
                        catch (Exception) { }
                    Thread.Sleep(100);
                }
            });
            form.Load += (s, e) => { thread.Start(); };
        }

        public static void SetMdiCloseAllEvent(this Form form, ToolStripButton btn)
        {
            Thread thread = new Thread(() =>
            {
                while (form.Created)
                {
                    if (form.Visible)
                        try
                        {
                            form.Invoke(new Action(() => { btn.Enabled = form.MdiChildren.Length > 0; }));
                        }
                        catch (Exception) { }
                    Thread.Sleep(100);
                }
            });
            form.Load += (s, e) => { thread.Start(); };
        }

        public static void SetMdiCloseOthersEvent(this Form form, ToolStripButton btn)
        {
            Thread thread = new Thread(() =>
            {
                while (form.Created)
                {
                    if (form.Visible)
                        try
                        {
                            form.Invoke(new Action(() => { btn.Enabled = form.MdiChildren.Length > 1; }));
                        }
                        catch (Exception) { }
                    Thread.Sleep(100);
                }
            });
            form.Load += (s, e) => { thread.Start(); };
        }

        /// <summary>
        /// Insert a menu item in the given menu strip for mdi controlling
        /// 
        /// <remarks>
        /// Support this languages (in dependency of the CurrentUICulture):
        /// - English (Default)
        /// - German
        /// - French
        /// </remarks>
        /// </summary>
        /// <param name="form"></param>
        /// <param name="menu">menu strip to insert the window menu</param>
        /// <param name="index">index of position to insert the windows menu</param>
        /// <param name="showCloseAll">shows "Close All"</param>
        /// <param name="showCloseOthers">shows "Close Others"</param>
        /// <param name="showLayout">shows "Layout"</param>
        /// <param name="showWindowList">shows the list of all mdi children</param>
        public static void InsertMdiControlMenu(this Form form, MenuStrip menu, int index, bool showCloseAll, bool showCloseOthers, bool showLayout, bool showWindowList)
        {
            ToolStripMenuItem root = new ToolStripMenuItem(TextManager.MDI.Window);
            {
                ToolStripMenuItem close = new ToolStripMenuItem(TextManager.MDI.Close);
                close.Click += (s, e) => { form.CloseActiveMdiChild(); };
                form.SetMdiCloseActiveEvent(close);
                root.DropDownItems.Add(close);

                if (showCloseAll)
                {
                    ToolStripMenuItem closeAll = new ToolStripMenuItem(TextManager.MDI.CloseAll);
                    closeAll.Click += (s, e) => { form.CloseAllMdiChildren(); };
                    form.SetMdiCloseAllEvent(closeAll);
                    root.DropDownItems.Add(closeAll);
                }

                if (showCloseOthers)
                {
                    ToolStripMenuItem closeOthers = new ToolStripMenuItem(TextManager.MDI.CloseOthers);
                    closeOthers.Click += (s, e) => { form.CloseOtherMdiChildren(); };
                    form.SetMdiCloseOthersEvent(closeOthers);
                    root.DropDownItems.Add(closeOthers);
                }

                if (showLayout)
                {
                    root.DropDownItems.Add(new ToolStripSeparator());

                    ToolStripMenuItem layout = new ToolStripMenuItem(TextManager.MDI.LayoutText);
                    {
                        ToolStripMenuItem tileHor = new ToolStripMenuItem(TextManager.MDI.Layout.TileHorizontal);
                        tileHor.Click += (s, e) => { form.LayoutMdi(MdiLayout.TileHorizontal); };
                        layout.DropDownItems.Add(tileHor);

                        ToolStripMenuItem tileVert = new ToolStripMenuItem(TextManager.MDI.Layout.TileVertical);
                        tileVert.Click += (s, e) => { form.LayoutMdi(MdiLayout.TileVertical); };
                        layout.DropDownItems.Add(tileVert);

                        ToolStripMenuItem overlapping = new ToolStripMenuItem(TextManager.MDI.Layout.Overlapping);
                        overlapping.Click += (s, e) => { form.LayoutMdi(MdiLayout.Cascade); };
                        layout.DropDownItems.Add(overlapping);
                    }
                    root.DropDownItems.Add(layout);
                }
            }

            menu.Items.Insert(index, root);
            if (showWindowList)
                menu.MdiWindowListItem = root;
        }


        /// <summary>
        /// Insert a menu item in the main menu strip of this form for mdi controlling
        /// 
        /// <remarks>
        /// Support this languages (in dependency of the CurrentUICulture):
        /// - English (Default)
        /// - German
        /// - French
        /// </remarks>
        /// </summary>
        /// <param name="form"></param>
        /// <param name="index">index of position to insert the windows menu</param>
        /// <param name="showCloseAll">shows "Close All"</param>
        /// <param name="showCloseOthers">shows "Close Others"</param>
        /// <param name="showLayout">shows "Layout"</param>
        /// <param name="showWindowList">shows the list of all mdi children</param>
        public static void InsertMdiControlMenu(this Form form, int index, bool showCloseAll, bool showCloseOthers, bool showLayout, bool showWindowList)
        {
            InsertMdiControlMenu(form, form.MainMenuStrip, index, showCloseAll, showCloseOthers, showLayout, showWindowList);
        }

        /// <summary>
        /// Insert a menu item in the given menu strip for <b>full</b> mdi controlling
        /// 
        /// <remarks>
        /// Support this languages (in dependency of the CurrentUICulture):
        /// - English (Default)
        /// - German
        /// - French
        /// </remarks>
        /// </summary>
        /// <param name="form"></param>
        /// <param name="menu">menu strip to insert the window menu</param>
        /// <param name="index">index of position to insert the windows menu</param>
        public static void InsertMdiControlMenu(this Form form, MenuStrip menu, int index)
        {
            InsertMdiControlMenu(form, menu, index, true, true, true, true);
        }

        /// <summary>
        /// Insert a menu item in the main menu strip of this form for <b>full</b> mdi controlling
        /// 
        /// <remarks>
        /// Support this languages (in dependency of the CurrentUICulture):
        /// - English (Default)
        /// - German
        /// - French
        /// </remarks>
        /// </summary>
        /// <param name="form"></param>
        /// <param name="index">index of position to insert the windows menu</param>
        public static void InsertMdiControlMenu(this Form form, int index)
        {
            InsertMdiControlMenu(form, form.MainMenuStrip, index);
        }
    }

    /// @}
}
