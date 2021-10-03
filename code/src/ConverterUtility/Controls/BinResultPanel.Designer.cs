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

namespace Plexdata.ConverterUtility.Controls
{
    partial class BinResultPanel
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
            this.tbcBytesPerLine = new System.Windows.Forms.ToolStripComboBox();
            this.tbcBlockWidth = new System.Windows.Forms.ToolStripComboBox();
            this.tbbUpperCase = new System.Windows.Forms.ToolStripButton();
            this.binView = new ConverterUtility.Controls.HexViewer();
            this.tbsButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbsButtons
            // 
            this.tbsButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbcBytesPerLine,
            this.tbcBlockWidth,
            this.tbbUpperCase});
            this.tbsButtons.Location = new System.Drawing.Point(0, 0);
            this.tbsButtons.Name = "tbsButtons";
            this.tbsButtons.Size = new System.Drawing.Size(701, 25);
            this.tbsButtons.TabIndex = 0;
            // 
            // tbcBytesPerLine
            // 
            this.tbcBytesPerLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbcBytesPerLine.Name = "tbcBytesPerLine";
            this.tbcBytesPerLine.Size = new System.Drawing.Size(75, 25);
            this.tbcBytesPerLine.ToolTipText = "Change bytes per line to be displayed.";
            this.tbcBytesPerLine.SelectedIndexChanged += new System.EventHandler(this.OnBytesPerLineSelectedIndexChanged);
            // 
            // tbcBlockWidth
            // 
            this.tbcBlockWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbcBlockWidth.Name = "tbcBlockWidth";
            this.tbcBlockWidth.Size = new System.Drawing.Size(75, 25);
            this.tbcBlockWidth.ToolTipText = "Change block width to be used.";
            this.tbcBlockWidth.SelectedIndexChanged += new System.EventHandler(this.OnBlockWidthSelectedIndexChanged);
            // 
            // tbbUpperCase
            // 
            this.tbbUpperCase.CheckOnClick = true;
            this.tbbUpperCase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbUpperCase.Image = global::Plexdata.ConverterUtility.Properties.Resources.UpperSmall;
            this.tbbUpperCase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbUpperCase.Name = "tbbUpperCase";
            this.tbbUpperCase.Size = new System.Drawing.Size(23, 22);
            this.tbbUpperCase.Text = "Upper";
            this.tbbUpperCase.ToolTipText = "Toggle between upper and lower case.";
            this.tbbUpperCase.CheckStateChanged += new System.EventHandler(this.OnUpperCaseCheckStateChanged);
            // 
            // binView
            // 
            this.binView.BackColor = System.Drawing.SystemColors.Window;
            this.binView.ContextMenuEnabled = false;
            this.binView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.binView.Font = new System.Drawing.Font("Consolas", 9F);
            this.binView.ForeColor = System.Drawing.SystemColors.WindowText;
            this.binView.Location = new System.Drawing.Point(0, 25);
            this.binView.Name = "binView";
            this.binView.Size = new System.Drawing.Size(701, 472);
            this.binView.TabIndex = 1;
            // 
            // BinResultPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.binView);
            this.Controls.Add(this.tbsButtons);
            this.Name = "BinResultPanel";
            this.Size = new System.Drawing.Size(701, 497);
            this.tbsButtons.ResumeLayout(false);
            this.tbsButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tbsButtons;
        private HexViewer binView;
        private System.Windows.Forms.ToolStripComboBox tbcBytesPerLine;
        private System.Windows.Forms.ToolStripComboBox tbcBlockWidth;
        private System.Windows.Forms.ToolStripButton tbbUpperCase;
    }
}
