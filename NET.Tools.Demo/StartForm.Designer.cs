namespace NET.Tools
{
    partial class StartForm
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
            this.btnControls = new System.Windows.Forms.Button();
            this.btnDialogs = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDrawing = new System.Windows.Forms.Button();
            this.btnGlobal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnControls
            // 
            this.btnControls.Location = new System.Drawing.Point(12, 12);
            this.btnControls.Name = "btnControls";
            this.btnControls.Size = new System.Drawing.Size(288, 23);
            this.btnControls.TabIndex = 0;
            this.btnControls.Text = "Controls";
            this.btnControls.UseVisualStyleBackColor = true;
            this.btnControls.Click += new System.EventHandler(this.btnControls_Click);
            // 
            // btnDialogs
            // 
            this.btnDialogs.Location = new System.Drawing.Point(12, 41);
            this.btnDialogs.Name = "btnDialogs";
            this.btnDialogs.Size = new System.Drawing.Size(288, 23);
            this.btnDialogs.TabIndex = 1;
            this.btnDialogs.Text = "Dialogs";
            this.btnDialogs.UseVisualStyleBackColor = true;
            this.btnDialogs.Click += new System.EventHandler(this.btnDialogs_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 157);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(288, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDrawing
            // 
            this.btnDrawing.Location = new System.Drawing.Point(12, 70);
            this.btnDrawing.Name = "btnDrawing";
            this.btnDrawing.Size = new System.Drawing.Size(288, 23);
            this.btnDrawing.TabIndex = 3;
            this.btnDrawing.Text = "Drawing";
            this.btnDrawing.UseVisualStyleBackColor = true;
            this.btnDrawing.Click += new System.EventHandler(this.btnDrawing_Click);
            // 
            // btnGlobal
            // 
            this.btnGlobal.Location = new System.Drawing.Point(12, 99);
            this.btnGlobal.Name = "btnGlobal";
            this.btnGlobal.Size = new System.Drawing.Size(288, 23);
            this.btnGlobal.TabIndex = 4;
            this.btnGlobal.Text = "Globalization";
            this.btnGlobal.UseVisualStyleBackColor = true;
            this.btnGlobal.Click += new System.EventHandler(this.btnGlobal_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 192);
            this.Controls.Add(this.btnGlobal);
            this.Controls.Add(this.btnDrawing);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDialogs);
            this.Controls.Add(this.btnControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start Forms";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnControls;
        private System.Windows.Forms.Button btnDialogs;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDrawing;
        private System.Windows.Forms.Button btnGlobal;
    }
}