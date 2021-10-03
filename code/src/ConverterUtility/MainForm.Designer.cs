/*
 * MIT License
 * 
 * Copyright (c) 2021 plexdata.de
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

namespace Plexdata.ConverterUtility
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabZipView = new System.Windows.Forms.TabPage();
            this.panZipView = new Plexdata.ConverterUtility.Controls.ZipPanel();
            this.tabPdfView = new System.Windows.Forms.TabPage();
            this.panPdfView = new Plexdata.ConverterUtility.Controls.PdfPanel();
            this.tabBinView = new System.Windows.Forms.TabPage();
            this.panBinView = new Plexdata.ConverterUtility.Controls.BinPanel();
            this.tbsButtons = new System.Windows.Forms.ToolStrip();
            this.tbbExit = new System.Windows.Forms.ToolStripButton();
            this.tbbInfo = new System.Windows.Forms.ToolStripButton();
            this.stsStatus = new System.Windows.Forms.StatusStrip();
            this.tabControl.SuspendLayout();
            this.tabZipView.SuspendLayout();
            this.tabPdfView.SuspendLayout();
            this.tabBinView.SuspendLayout();
            this.tbsButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabZipView);
            this.tabControl.Controls.Add(this.tabPdfView);
            this.tabControl.Controls.Add(this.tabBinView);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(784, 514);
            this.tabControl.TabIndex = 0;
            // 
            // tabZipView
            // 
            this.tabZipView.Controls.Add(this.panZipView);
            this.tabZipView.Location = new System.Drawing.Point(4, 22);
            this.tabZipView.Name = "tabZipView";
            this.tabZipView.Padding = new System.Windows.Forms.Padding(3);
            this.tabZipView.Size = new System.Drawing.Size(776, 488);
            this.tabZipView.TabIndex = 0;
            this.tabZipView.Text = "ZIP";
            this.tabZipView.UseVisualStyleBackColor = true;
            // 
            // panZipView
            // 
            this.panZipView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panZipView.Location = new System.Drawing.Point(3, 3);
            this.panZipView.Name = "panZipView";
            this.panZipView.Size = new System.Drawing.Size(770, 482);
            this.panZipView.TabIndex = 0;
            // 
            // tabPdfView
            // 
            this.tabPdfView.Controls.Add(this.panPdfView);
            this.tabPdfView.Location = new System.Drawing.Point(4, 22);
            this.tabPdfView.Name = "tabPdfView";
            this.tabPdfView.Padding = new System.Windows.Forms.Padding(3);
            this.tabPdfView.Size = new System.Drawing.Size(776, 488);
            this.tabPdfView.TabIndex = 2;
            this.tabPdfView.Text = "PDF";
            this.tabPdfView.UseVisualStyleBackColor = true;
            // 
            // panPdfView
            // 
            this.panPdfView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPdfView.Location = new System.Drawing.Point(3, 3);
            this.panPdfView.Name = "panPdfView";
            this.panPdfView.Size = new System.Drawing.Size(770, 482);
            this.panPdfView.TabIndex = 0;
            // 
            // tabBinView
            // 
            this.tabBinView.Controls.Add(this.panBinView);
            this.tabBinView.Location = new System.Drawing.Point(4, 22);
            this.tabBinView.Name = "tabBinView";
            this.tabBinView.Padding = new System.Windows.Forms.Padding(3);
            this.tabBinView.Size = new System.Drawing.Size(776, 488);
            this.tabBinView.TabIndex = 1;
            this.tabBinView.Text = "BIN";
            this.tabBinView.UseVisualStyleBackColor = true;
            // 
            // panBinView
            // 
            this.panBinView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panBinView.Location = new System.Drawing.Point(3, 3);
            this.panBinView.Name = "panBinView";
            this.panBinView.Size = new System.Drawing.Size(770, 482);
            this.panBinView.TabIndex = 0;
            // 
            // tbsButtons
            // 
            this.tbsButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbExit,
            this.tbbInfo});
            this.tbsButtons.Location = new System.Drawing.Point(0, 0);
            this.tbsButtons.Name = "tbsButtons";
            this.tbsButtons.Size = new System.Drawing.Size(784, 25);
            this.tbsButtons.TabIndex = 1;
            // 
            // tbbExit
            // 
            this.tbbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbExit.Image = global::Plexdata.ConverterUtility.Properties.Resources.ExitSmall;
            this.tbbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbExit.Name = "tbbExit";
            this.tbbExit.Size = new System.Drawing.Size(23, 22);
            this.tbbExit.Text = "Exit";
            this.tbbExit.ToolTipText = "Close window and exit application.";
            this.tbbExit.Click += new System.EventHandler(this.OnButtonExitClick);
            // 
            // tbbInfo
            // 
            this.tbbInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbInfo.Image = global::Plexdata.ConverterUtility.Properties.Resources.InfoSmall;
            this.tbbInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbInfo.Name = "tbbInfo";
            this.tbbInfo.Size = new System.Drawing.Size(23, 22);
            this.tbbInfo.Text = "Info";
            this.tbbInfo.ToolTipText = "Show application information.";
            this.tbbInfo.Click += new System.EventHandler(this.OnButtonInfoClick);
            // 
            // stsStatus
            // 
            this.stsStatus.Location = new System.Drawing.Point(0, 539);
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Size = new System.Drawing.Size(784, 22);
            this.stsStatus.TabIndex = 2;
            this.stsStatus.Text = "statusStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.stsStatus);
            this.Controls.Add(this.tbsButtons);
            this.Icon = global::Plexdata.ConverterUtility.Properties.Resources.MainIcon;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Converter Utility";
            this.tabControl.ResumeLayout(false);
            this.tabZipView.ResumeLayout(false);
            this.tabPdfView.ResumeLayout(false);
            this.tabBinView.ResumeLayout(false);
            this.tbsButtons.ResumeLayout(false);
            this.tbsButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabZipView;
        private System.Windows.Forms.TabPage tabBinView;
        private Controls.ZipPanel panZipView;
        private System.Windows.Forms.TabPage tabPdfView;
        private Controls.BinPanel panBinView;
        private Controls.PdfPanel panPdfView;
        private System.Windows.Forms.ToolStrip tbsButtons;
        private System.Windows.Forms.StatusStrip stsStatus;
        private System.Windows.Forms.ToolStripButton tbbExit;
        private System.Windows.Forms.ToolStripButton tbbInfo;
    }
}

