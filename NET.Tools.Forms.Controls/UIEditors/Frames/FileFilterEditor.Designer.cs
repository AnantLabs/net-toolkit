namespace NET.Tools.Forms
{
    partial class FileFilterEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileFilterEditor));
            this.lvFilters = new System.Windows.Forms.ListView();
            this.CHName = new System.Windows.Forms.ColumnHeader();
            this.CHFilter = new System.Windows.Forms.ColumnHeader();
            this.CHDefaultExt = new System.Windows.Forms.ColumnHeader();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvFilters
            // 
            this.lvFilters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CHName,
            this.CHFilter,
            this.CHDefaultExt});
            this.lvFilters.FullRowSelect = true;
            this.lvFilters.HideSelection = false;
            resources.ApplyResources(this.lvFilters, "lvFilters");
            this.lvFilters.MultiSelect = false;
            this.lvFilters.Name = "lvFilters";
            this.lvFilters.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvFilters.UseCompatibleStateImageBehavior = false;
            this.lvFilters.View = System.Windows.Forms.View.Details;
            this.lvFilters.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // CHName
            // 
            resources.ApplyResources(this.CHName, "CHName");
            // 
            // CHFilter
            // 
            resources.ApplyResources(this.CHFilter, "CHFilter");
            // 
            // CHDefaultExt
            // 
            resources.ApplyResources(this.CHDefaultExt, "CHDefaultExt");
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            resources.ApplyResources(this.btnRemove, "btnRemove");
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // FileFilterEditor
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lvFilters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FileFilterEditor";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ColumnHeader CHName;
        private System.Windows.Forms.ColumnHeader CHFilter;
        private System.Windows.Forms.ColumnHeader CHDefaultExt;
        private System.Windows.Forms.ListView lvFilters;
    }
}