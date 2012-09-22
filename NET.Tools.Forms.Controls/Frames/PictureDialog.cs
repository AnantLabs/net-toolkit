using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Resources;

namespace NET.Tools.Forms.Frames
{
    internal partial class PictureDialog : Form
    {
        public enum DialogType
        {
            Open,
            Save
        }

        private bool overwritePromt;

        public List<String> FileNames
        {
            get
            {
                return new List<String>(txtFileNames.Text.Split('|'));
            }
        }

        public PictureDialog(DialogType type, bool bmp, bool jpeg, bool png, PictureFilterIndex filterIndex,
            bool multiselect, bool overwritePromt, DirectoryInfo initialDirectory, 
            String fileName)
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;

            List<FileFilter> filterList = new List<FileFilter>();
            if (bmp) filterList.Add(new FileFilter("Bitmap (*.bmp)", "*.bmp", "bmp"));
            if (jpeg) filterList.Add(new FileFilter("JPEG (*.jpg)", "*.jpg", "jpg"));
            if (png) filterList.Add(new FileFilter("Portable Network Graphic (*.png)", "*.png", "png"));
            cmbFileFilter.FileFilterList = filterList.ToArray();
            switch (filterIndex)
            {
                case PictureFilterIndex.BMP:
                    cmbFileFilter.SelectedFilterString = "*.bmp";
                    break;
                case PictureFilterIndex.JPEG:
                    cmbFileFilter.SelectedFilterString = "*.jpg";
                    break;
                case PictureFilterIndex.PNG:
                    cmbFileFilter.SelectedFilterString = "*.png";
                    break;
                default:
                    throw new NotImplementedException();
            }

            lstFiles.MultiSelect = multiselect;
            this.overwritePromt = overwritePromt;
            lstFiles.Directory = initialDirectory;
            txtFileNames.Text = fileName;

            if (type == DialogType.Open)
            {
                this.Text = TextManager.Dialog.Image.Open;
                this.btnOK.Text = TextManager.Button.Open;
            }
            else if (type == DialogType.Save)
            {
                this.Text = TextManager.Dialog.Image.Save;
                this.btnOK.Text = TextManager.Button.Save;
            }
            else
                throw new NotImplementedException();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (overwritePromt)
                if (File.Exists(lstFiles.SelectedFiles[0].FullName))
                    if (MessageBox.Show(TextManager.Dialog.Question.Overwrite.MessageFile(lstFiles.SelectedFiles[0].FullName), 
                            TextManager.Dialog.Question.Overwrite.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void lstFiles_SelectedObjectChanged(object sender, EventArgs e)
        {
            txtFileNames.Text = "";

            if (lstFiles.SelectedFiles.Count != 1)
                pbPreview.Image = null;
            else
                pbPreview.Image = Image.FromFile(lstFiles.SelectedFiles[0].FullName);

            foreach (FileInfo fi in lstFiles.SelectedFiles)
                txtFileNames.Text += (fi.FullName + "|");
            if (txtFileNames.Text.Length > 0)
                txtFileNames.Text = txtFileNames.Text.Remove(txtFileNames.Text.Length - 1);
        }
    }
}
