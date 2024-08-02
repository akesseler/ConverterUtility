/*
 * MIT License
 * 
 * Copyright (c) 2024 plexdata.de
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

namespace Plexdata.ConverterUtility.Controls
{
    partial class PdfResultPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbsButtons = new System.Windows.Forms.ToolStrip();
            this.tbbFolder = new System.Windows.Forms.ToolStripButton();
            this.tbbView = new System.Windows.Forms.ToolStripButton();
            this.tbbClear = new System.Windows.Forms.ToolStripButton();
            this.lstResults = new System.Windows.Forms.ListView();
            this.colFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFilePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbsButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbsButtons
            // 
            this.tbsButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbFolder,
            this.tbbView,
            this.tbbClear});
            this.tbsButtons.Location = new System.Drawing.Point(0, 0);
            this.tbsButtons.Name = "tbsButtons";
            this.tbsButtons.Size = new System.Drawing.Size(615, 25);
            this.tbsButtons.TabIndex = 0;
            // 
            // tbbFolder
            // 
            this.tbbFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbFolder.Image = global::Plexdata.ConverterUtility.Properties.Resources.OpenSmall;
            this.tbbFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbFolder.Name = "tbbFolder";
            this.tbbFolder.Size = new System.Drawing.Size(23, 22);
            this.tbbFolder.Text = "Folder";
            this.tbbFolder.ToolTipText = "Choose a folder to save the files to.";
            this.tbbFolder.Click += new System.EventHandler(this.OnButtonFolderClick);
            // 
            // tbbView
            // 
            this.tbbView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbView.Image = global::Plexdata.ConverterUtility.Properties.Resources.ViewSmall;
            this.tbbView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbView.Name = "tbbView";
            this.tbbView.Size = new System.Drawing.Size(23, 22);
            this.tbbView.Text = "View";
            this.tbbView.ToolTipText = "Open selected files for viewing.";
            this.tbbView.Click += new System.EventHandler(this.OnButtonViewClick);
            // 
            // tbbClear
            // 
            this.tbbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbClear.Image = global::Plexdata.ConverterUtility.Properties.Resources.ClearSmall;
            this.tbbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbClear.Name = "tbbClear";
            this.tbbClear.Size = new System.Drawing.Size(23, 22);
            this.tbbClear.Text = "Clear";
            this.tbbClear.ToolTipText = "Clear content.";
            this.tbbClear.Click += new System.EventHandler(this.OnButtonClearClick);
            // 
            // lstResults
            // 
            this.lstResults.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFileName,
            this.colFilePath,
            this.colFileSize});
            this.lstResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstResults.FullRowSelect = true;
            this.lstResults.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstResults.HideSelection = false;
            this.lstResults.Location = new System.Drawing.Point(0, 25);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(615, 444);
            this.lstResults.TabIndex = 1;
            this.lstResults.UseCompatibleStateImageBehavior = false;
            this.lstResults.View = System.Windows.Forms.View.Details;
            this.lstResults.DoubleClick += new System.EventHandler(this.OnResultsListDoubleClick);
            // 
            // colFileName
            // 
            this.colFileName.Text = "Name";
            // 
            // colFilePath
            // 
            this.colFilePath.Text = "Path";
            // 
            // colFileSize
            // 
            this.colFileSize.Text = "Size";
            // 
            // PdfResultPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.tbsButtons);
            this.Name = "PdfResultPanel";
            this.Size = new System.Drawing.Size(615, 469);
            this.tbsButtons.ResumeLayout(false);
            this.tbsButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tbsButtons;
        private System.Windows.Forms.ListView lstResults;
        private System.Windows.Forms.ColumnHeader colFileName;
        private System.Windows.Forms.ColumnHeader colFilePath;
        private System.Windows.Forms.ColumnHeader colFileSize;
        private System.Windows.Forms.ToolStripButton tbbFolder;
        private System.Windows.Forms.ToolStripButton tbbClear;
        private System.Windows.Forms.ToolStripButton tbbView;
    }
}
