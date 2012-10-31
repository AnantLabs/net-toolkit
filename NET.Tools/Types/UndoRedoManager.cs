using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools
{
    /// <summary>
    /// Represent a manager for handling the undo-redo-system
    /// </summary>
    /// <typeparam name="T">Type of the controlled object</typeparam>
    /// 
    /// <example>
    /// This example show you to create an undo-redo-manager for an image:
    /// <code>
    /// UndoRedoManager{Image} manager = new UndoRedoManager{Image}();
    /// ...
    /// public void Init()
    /// {
    ///     manager.UndoListChanged += (sender, e) => { btnUndo.Enabled = manager.CanUndo; };
    ///     manager.RedoListChanged += (sender, e) => { btnRedo.Enabled = manager.CanRedo; };
    /// }
    /// ...
    /// public void DoAction()
    /// {
    ///     manager.AddAction(currentImage);
    ///     ...
    /// }
    /// ...
    /// public void Undo()
    /// {
    ///     currentImage = manager.Undo(currentImage);
    /// }
    /// ...
    /// public void Redo()
    /// {
    ///     currentImage = manager.Redo(currentImage);
    /// }
    /// </code>
    /// </example>
    public sealed class UndoRedoManager<T>
    {
        #region Inner Classes

        private class ListItem<Item>
        {
            public String ActionName { get; private set; }
            public Item ActionObject { get; private set; }

            public ListItem(String actionName, Item actionObject)
            {
                ActionName = actionName;
                ActionObject = actionObject;
            }
        }

        #endregion

        private IList<ListItem<T>> undoList, redoList;

        /// <summary>
        /// Is called if the undo list is changed
        /// </summary>
        public event EventHandler UndoListChanged;
        /// <summary>
        /// Is called if the redo list is changed
        /// </summary>
        public event EventHandler RedoListChanged;

        #region Properties

        /// <summary>
        /// The last action name in undo list
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Is thrown if the undo list is empty
        /// </exception>
        public String LastUndoActionName
        {
            get
            {
                if (undoList.Count > 0)
                    return undoList[undoList.Count - 1].ActionName;

                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// The last action name in redo list
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Is thrown if the redo list is empty
        /// </exception>
        public String LastRedoActionName
        {
            get
            {
                if (redoList.Count > 0)
                    return redoList[redoList.Count - 1].ActionName;

                throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Is an undo able?
        /// </summary>
        public bool CanUndo
        {
            get { return undoList.Count > 0; }
        }

        /// <summary>
        /// Is a redo able?
        /// </summary>
        public bool CanRedo
        {
            get { return redoList.Count > 0; }
        }

        /// <summary>
        /// The maximum length of undo and redo list. If the end is open then use all values under 1
        /// </summary>
        public int MaxLength
        {
            get;
            set;
        }

        /// <summary>
        /// Gets an array of strings with all redo action names
        /// </summary>
        public String[] RedoActionNameList
        {
            get
            {
                List<String> res = new List<String>();
                foreach (ListItem<T> item in redoList)
                    res.Add(item.ActionName);
                return res.ToArray();
            }
        }

        /// <summary>
        /// Gets an array of strings with all undo action names
        /// </summary>
        public String[] UndoActionNameList
        {
            get
            {
                List<String> res = new List<String>();
                foreach (ListItem<T> item in undoList)
                    res.Add(item.ActionName);
                return res.ToArray();
            }
        }

        #endregion

        /// <summary>
        /// Create the manager
        /// </summary>
        /// <param name="maxLength">Maximum length of undo and redo list or a value under 1 if the end is open</param>
        public UndoRedoManager(int maxLength)
        {
            undoList = new List<ListItem<T>>();
            redoList = new List<ListItem<T>>();
            MaxLength = maxLength;
        }

        public UndoRedoManager()
            : this(-1)
        {
        }

        /// <summary>
        /// Add a action that changed the old object value
        /// </summary>
        /// <param name="name">The name of the action that is use on this object now</param>
        /// <param name="oldObj">The object before the action change it</param>
        public void AddAction(String name, T oldObj)
        {
            AddUndo(new ListItem<T>(name, oldObj));
            DoUndoListChanged();
            redoList.Clear();
            DoRedoListChanged();
        }

        /// <summary>
        /// Add a action that changed the old object value
        /// </summary>
        /// <param name="oldObj">The object before the action change it</param>
        public void AddAction(T oldObj)
        {
            AddAction("", oldObj);
        }

        /// <summary>
        /// Make a change undo
        /// </summary>
        /// <param name="activeObj">The active object value (To add to the redo list)</param>
        /// <returns>The object value before the active object value</returns>
        public T Undo(T activeObj)
        {
            ListItem<T> item = undoList.Last<ListItem<T>>();
            undoList.Remove(item);
            DoUndoListChanged();

            AddRedo(new ListItem<T>(item.ActionName, activeObj));
            DoRedoListChanged();
            return item.ActionObject;
        }

        /// <summary>
        /// Make a change redo
        /// </summary>
        /// <param name="activeObj">The active object value (To add to the undo list)</param>
        /// <returns>The object value after the active object value</returns>
        public T Redo(T activeObj)
        {
            ListItem<T> item = redoList.Last<ListItem<T>>();
            redoList.Remove(item);
            DoRedoListChanged();

            AddUndo(new ListItem<T>(item.ActionName, activeObj));
            DoUndoListChanged();
            return item.ActionObject;
        }

        /// <summary>
        /// Clear the undo list
        /// </summary>
        public void ClearUndoList()
        {
            undoList.Clear();
            DoUndoListChanged();
        }

        /// <summary>
        /// Clear the redo list
        /// </summary>
        public void ClearRedoList()
        {
            redoList.Clear();
            DoRedoListChanged();
        }

        /// <summary>
        /// Clear all lists
        /// </summary>
        public void ClearLists()
        {
            ClearRedoList();
            ClearUndoList();
        }

        private void DoUndoListChanged()
        {
            if (UndoListChanged != null)
                UndoListChanged(this, new EventArgs());
        }

        private void DoRedoListChanged()
        {
            if (RedoListChanged != null)
                RedoListChanged(this, new EventArgs());
        }

        private void AddUndo(ListItem<T> item)
        {
            undoList.Add(item);

            if (MaxLength > 0)
                if (undoList.Count > MaxLength)
                    while (undoList.Count > MaxLength)
                        undoList.RemoveAt(undoList.Count - 1);
        }

        private void AddRedo(ListItem<T> item)
        {
            redoList.Add(item);

            if (MaxLength > 0)
                if (redoList.Count > MaxLength)
                    while (redoList.Count > MaxLength)
                        redoList.RemoveAt(redoList.Count - 1);
        }
    }
}
