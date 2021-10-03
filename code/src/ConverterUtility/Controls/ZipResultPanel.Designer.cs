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
    partial class ZipResultPanel
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
            this.tbcTypes = new System.Windows.Forms.ToolStripComboBox();
            this.tbbPretty = new System.Windows.Forms.ToolStripButton();
            this.tbsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbWrap = new System.Windows.Forms.ToolStripButton();
            this.tbbClear = new System.Windows.Forms.ToolStripButton();
            this.tbsSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbxFind = new System.Windows.Forms.ToolStripTextBox();
            this.tbbFind = new System.Windows.Forms.ToolStripButton();
            this.tbsSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.panResult = new System.Windows.Forms.Panel();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.tbbSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbCut = new System.Windows.Forms.ToolStripButton();
            this.tbbCopy = new System.Windows.Forms.ToolStripSplitButton();
            this.tbmCopyPdf = new System.Windows.Forms.ToolStripMenuItem();
            this.tbmCopyBin = new System.Windows.Forms.ToolStripMenuItem();
            this.tbbPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbUndo = new System.Windows.Forms.ToolStripButton();
            this.tbbRedo = new System.Windows.Forms.ToolStripButton();
            this.tbsSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbmCopyZip = new System.Windows.Forms.ToolStripMenuItem();
            this.tbsButtons.SuspendLayout();
            this.panResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbsButtons
            // 
            this.tbsButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbcTypes,
            this.tbbPretty,
            this.tbsSeparator1,
            this.tbbWrap,
            this.tbbSelect,
            this.toolStripSeparator1,
            this.tbbCut,
            this.tbbCopy,
            this.tbbPaste,
            this.toolStripSeparator2,
            this.tbbUndo,
            this.tbbRedo,
            this.tbsSeparator4,
            this.tbbClear,
            this.tbsSeparator2,
            this.tbxFind,
            this.tbbFind,
            this.tbsSeparator3});
            this.tbsButtons.Location = new System.Drawing.Point(0, 0);
            this.tbsButtons.Name = "tbsButtons";
            this.tbsButtons.Size = new System.Drawing.Size(616, 25);
            this.tbsButtons.TabIndex = 0;
            // 
            // tbcTypes
            // 
            this.tbcTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbcTypes.Items.AddRange(new object[] {
            "Raw",
            "Xml",
            "Json"});
            this.tbcTypes.Name = "tbcTypes";
            this.tbcTypes.Size = new System.Drawing.Size(75, 25);
            this.tbcTypes.ToolTipText = "Choose a format.";
            this.tbcTypes.SelectedIndexChanged += new System.EventHandler(this.OnComboBoxTypesSelectedIndexChanged);
            // 
            // tbbPretty
            // 
            this.tbbPretty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbPretty.Image = global::Plexdata.ConverterUtility.Properties.Resources.PrettySmall;
            this.tbbPretty.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbPretty.Name = "tbbPretty";
            this.tbbPretty.Size = new System.Drawing.Size(23, 22);
            this.tbbPretty.Text = "Pretty";
            this.tbbPretty.ToolTipText = "Pretty print content.";
            this.tbbPretty.Click += new System.EventHandler(this.OnButtonPrettyClick);
            // 
            // tbsSeparator1
            // 
            this.tbsSeparator1.Name = "tbsSeparator1";
            this.tbsSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbWrap
            // 
            this.tbbWrap.CheckOnClick = true;
            this.tbbWrap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbWrap.Image = global::Plexdata.ConverterUtility.Properties.Resources.WrapSmall;
            this.tbbWrap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbWrap.Name = "tbbWrap";
            this.tbbWrap.Size = new System.Drawing.Size(23, 22);
            this.tbbWrap.Text = "Wrap";
            this.tbbWrap.ToolTipText = "Enable or disable word wrapping.";
            this.tbbWrap.CheckedChanged += new System.EventHandler(this.OnButtonWrapCheckedChanged);
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
            // tbsSeparator2
            // 
            this.tbsSeparator2.Name = "tbsSeparator2";
            this.tbsSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tbxFind
            // 
            this.tbxFind.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbxFind.Name = "tbxFind";
            this.tbxFind.Size = new System.Drawing.Size(100, 25);
            this.tbxFind.ToolTipText = "Type a text to search for.";
            // 
            // tbbFind
            // 
            this.tbbFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbFind.Image = global::Plexdata.ConverterUtility.Properties.Resources.FindSmall;
            this.tbbFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbFind.Name = "tbbFind";
            this.tbbFind.Size = new System.Drawing.Size(23, 22);
            this.tbbFind.Text = "Find";
            this.tbbFind.ToolTipText = "Find text starting from current position.";
            this.tbbFind.Click += new System.EventHandler(this.OnButtonFindClick);
            // 
            // tbsSeparator3
            // 
            this.tbsSeparator3.Name = "tbsSeparator3";
            this.tbsSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // panResult
            // 
            this.panResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panResult.Controls.Add(this.txtResult);
            this.panResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panResult.Location = new System.Drawing.Point(0, 25);
            this.panResult.Name = "panResult";
            this.panResult.Size = new System.Drawing.Size(616, 360);
            this.panResult.TabIndex = 2;
            // 
            // txtResult
            // 
            this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtResult.HideSelection = false;
            this.txtResult.Location = new System.Drawing.Point(0, 0);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(614, 358);
            this.txtResult.TabIndex = 0;
            this.txtResult.Text = "Dummy Dummy Dummy Dummy \nDummy Dummy Dummy Dummy \nDummy Dummy Dummy Dummy \n";
            this.txtResult.WordWrap = false;
            // 
            // tbbSelect
            // 
            this.tbbSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbSelect.Image = global::Plexdata.ConverterUtility.Properties.Resources.SelectSmall;
            this.tbbSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSelect.Name = "tbbSelect";
            this.tbbSelect.Size = new System.Drawing.Size(23, 22);
            this.tbbSelect.Text = "Select";
            this.tbbSelect.ToolTipText = "Select all content between current leading and trailing double quote.";
            this.tbbSelect.Click += new System.EventHandler(this.OnButtonSelectClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbCut
            // 
            this.tbbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbCut.Image = global::Plexdata.ConverterUtility.Properties.Resources.CutSmall;
            this.tbbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbCut.Name = "tbbCut";
            this.tbbCut.Size = new System.Drawing.Size(23, 22);
            this.tbbCut.Text = "Cut";
            this.tbbCut.ToolTipText = "Cut content.";
            this.tbbCut.Click += new System.EventHandler(this.OnButtonCutClick);
            // 
            // tbbCopy
            // 
            this.tbbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbCopy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbmCopyZip,
            this.tbmCopyPdf,
            this.tbmCopyBin});
            this.tbbCopy.Image = global::Plexdata.ConverterUtility.Properties.Resources.CopySmall;
            this.tbbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbCopy.Name = "tbbCopy";
            this.tbbCopy.Size = new System.Drawing.Size(32, 22);
            this.tbbCopy.Text = "Copy";
            this.tbbCopy.ToolTipText = "Copy content.";
            this.tbbCopy.ButtonClick += new System.EventHandler(this.OnButtonCopyClick);
            // 
            // tbmCopyPdf
            // 
            this.tbmCopyPdf.Name = "tbmCopyPdf";
            this.tbmCopyPdf.Size = new System.Drawing.Size(180, 22);
            this.tbmCopyPdf.Text = "Copy to PDF Source";
            this.tbmCopyPdf.Click += new System.EventHandler(this.OnMenuCopyPdfClick);
            // 
            // tbmCopyBin
            // 
            this.tbmCopyBin.Name = "tbmCopyBin";
            this.tbmCopyBin.Size = new System.Drawing.Size(180, 22);
            this.tbmCopyBin.Text = "Copy to BIN Source";
            this.tbmCopyBin.Click += new System.EventHandler(this.OnMenuCopyBinClick);
            // 
            // tbbPaste
            // 
            this.tbbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbPaste.Image = global::Plexdata.ConverterUtility.Properties.Resources.PasteSmall;
            this.tbbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbPaste.Name = "tbbPaste";
            this.tbbPaste.Size = new System.Drawing.Size(23, 22);
            this.tbbPaste.Text = "Paste";
            this.tbbPaste.ToolTipText = "Paste content.";
            this.tbbPaste.Click += new System.EventHandler(this.OnButtonPasteClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tbbUndo
            // 
            this.tbbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbUndo.Image = global::Plexdata.ConverterUtility.Properties.Resources.UndoSmall;
            this.tbbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbUndo.Name = "tbbUndo";
            this.tbbUndo.Size = new System.Drawing.Size(23, 22);
            this.tbbUndo.Text = "Undo";
            this.tbbUndo.ToolTipText = "Undo last change.";
            this.tbbUndo.Click += new System.EventHandler(this.OnButtonUndoClick);
            // 
            // tbbRedo
            // 
            this.tbbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbRedo.Image = global::Plexdata.ConverterUtility.Properties.Resources.RedoSmall;
            this.tbbRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbRedo.Name = "tbbRedo";
            this.tbbRedo.Size = new System.Drawing.Size(23, 22);
            this.tbbRedo.Text = "Redo";
            this.tbbRedo.ToolTipText = "Redo last change.";
            this.tbbRedo.Click += new System.EventHandler(this.OnButtonRedoClick);
            // 
            // tbsSeparator4
            // 
            this.tbsSeparator4.Name = "tbsSeparator4";
            this.tbsSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tbmCopyZip
            // 
            this.tbmCopyZip.Name = "tbmCopyZip";
            this.tbmCopyZip.Size = new System.Drawing.Size(180, 22);
            this.tbmCopyZip.Text = "Copy to ZIP Source";
            this.tbmCopyZip.Click += new System.EventHandler(this.OnMenuCopyZipClick);
            // 
            // ZipResultPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panResult);
            this.Controls.Add(this.tbsButtons);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ZipResultPanel";
            this.Size = new System.Drawing.Size(616, 385);
            this.tbsButtons.ResumeLayout(false);
            this.tbsButtons.PerformLayout();
            this.panResult.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tbsButtons;
        private System.Windows.Forms.Panel panResult;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.ToolStripButton tbbWrap;
        private System.Windows.Forms.ToolStripComboBox tbcTypes;
        private System.Windows.Forms.ToolStripButton tbbPretty;
        private System.Windows.Forms.ToolStripTextBox tbxFind;
        private System.Windows.Forms.ToolStripButton tbbFind;
        private System.Windows.Forms.ToolStripSeparator tbsSeparator1;
        private System.Windows.Forms.ToolStripSeparator tbsSeparator2;
        private System.Windows.Forms.ToolStripSeparator tbsSeparator3;
        private System.Windows.Forms.ToolStripButton tbbClear;
        private System.Windows.Forms.ToolStripButton tbbSelect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbbCut;
        private System.Windows.Forms.ToolStripSplitButton tbbCopy;
        private System.Windows.Forms.ToolStripMenuItem tbmCopyZip;
        private System.Windows.Forms.ToolStripMenuItem tbmCopyPdf;
        private System.Windows.Forms.ToolStripMenuItem tbmCopyBin;
        private System.Windows.Forms.ToolStripButton tbbPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbbUndo;
        private System.Windows.Forms.ToolStripButton tbbRedo;
        private System.Windows.Forms.ToolStripSeparator tbsSeparator4;
    }
}
