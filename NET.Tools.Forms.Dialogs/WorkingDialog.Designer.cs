namespace NET.Tools.Forms
{
    partial class WorkingDialog
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
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lblAction = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(12, 43);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(385, 23);
            this.pbProgress.TabIndex = 0;
            // 
            // lblAction
            // 
            this.lblAction.Location = new System.Drawing.Point(12, 9);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(385, 31);
            this.lblAction.TabIndex = 1;
            this.lblAction.Text = "Action";
            // 
            // lblTime
            // 
            this.lblTime.Location = new System.Drawing.Point(239, 69);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(158, 23);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "Time";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSpeed
            // 
            this.lblSpeed.Location = new System.Drawing.Point(12, 69);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(151, 23);
            this.lblSpeed.TabIndex = 3;
            this.lblSpeed.Text = "KB/s";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 97);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // WorkingDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(409, 132);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.pbProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkingDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please wait...";
            this.Shown += new System.EventHandler(this.WorkingDialog_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Button btnCancel;
    }
}