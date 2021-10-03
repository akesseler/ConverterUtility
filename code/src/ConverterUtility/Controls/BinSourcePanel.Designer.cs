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
    partial class BinSourcePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BinSourcePanel));
            this.tbsButtons = new System.Windows.Forms.ToolStrip();
            this.tbbView = new System.Windows.Forms.ToolStripButton();
            this.tbsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbWrap = new System.Windows.Forms.ToolStripButton();
            this.tbbSelect = new System.Windows.Forms.ToolStripButton();
            this.tbsSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbCut = new System.Windows.Forms.ToolStripButton();
            this.tbbCopy = new System.Windows.Forms.ToolStripSplitButton();
            this.tbmCopyZip = new System.Windows.Forms.ToolStripMenuItem();
            this.tbmCopyPdf = new System.Windows.Forms.ToolStripMenuItem();
            this.tbbPaste = new System.Windows.Forms.ToolStripButton();
            this.tbsSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbUndo = new System.Windows.Forms.ToolStripButton();
            this.tbbRedo = new System.Windows.Forms.ToolStripButton();
            this.tbsSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbbClear = new System.Windows.Forms.ToolStripButton();
            this.tbsSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tbcTypes = new System.Windows.Forms.ToolStripComboBox();
            this.tscEncodings = new System.Windows.Forms.ToolStripComboBox();
            this.panSource = new System.Windows.Forms.Panel();
            this.txtSource = new System.Windows.Forms.RichTextBox();
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.lblSource = new ConverterUtility.Controls.InfoLabel();
            this.tbsButtons.SuspendLayout();
            this.panSource.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbsButtons
            // 
            this.tbsButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbbView,
            this.tbsSeparator1,
            this.tbbWrap,
            this.tbbSelect,
            this.tbsSeparator2,
            this.tbbCut,
            this.tbbCopy,
            this.tbbPaste,
            this.tbsSeparator3,
            this.tbbUndo,
            this.tbbRedo,
            this.tbsSeparator4,
            this.tbbClear,
            this.tbsSeparator5,
            this.tbcTypes,
            this.tscEncodings});
            this.tbsButtons.Location = new System.Drawing.Point(0, 0);
            this.tbsButtons.Name = "tbsButtons";
            this.tbsButtons.Size = new System.Drawing.Size(558, 25);
            this.tbsButtons.TabIndex = 0;
            // 
            // tbbView
            // 
            this.tbbView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbView.Image = global::Plexdata.ConverterUtility.Properties.Resources.ViewSmall;
            this.tbbView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbView.Name = "tbbView";
            this.tbbView.Size = new System.Drawing.Size(23, 22);
            this.tbbView.Text = "View";
            this.tbbView.ToolTipText = "View data as binary.";
            this.tbbView.Click += new System.EventHandler(this.OnButtonViewClick);
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
            // tbbSelect
            // 
            this.tbbSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbbSelect.Image = global::Plexdata.ConverterUtility.Properties.Resources.SelectSmall;
            this.tbbSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbSelect.Name = "tbbSelect";
            this.tbbSelect.Size = new System.Drawing.Size(23, 22);
            this.tbbSelect.Text = "Select";
            this.tbbSelect.ToolTipText = "Select content.";
            this.tbbSelect.Click += new System.EventHandler(this.OnButtonSelectClick);
            // 
            // tbsSeparator2
            // 
            this.tbsSeparator2.Name = "tbsSeparator2";
            this.tbsSeparator2.Size = new System.Drawing.Size(6, 25);
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
            this.tbmCopyPdf});
            this.tbbCopy.Image = global::Plexdata.ConverterUtility.Properties.Resources.CopySmall;
            this.tbbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbbCopy.Name = "tbbCopy";
            this.tbbCopy.Size = new System.Drawing.Size(32, 22);
            this.tbbCopy.Text = "Copy";
            this.tbbCopy.ToolTipText = "Copy content.";
            this.tbbCopy.ButtonClick += new System.EventHandler(this.OnButtonCopyClick);
            // 
            // tbmCopyZip
            // 
            this.tbmCopyZip.Name = "tbmCopyZip";
            this.tbmCopyZip.Size = new System.Drawing.Size(180, 22);
            this.tbmCopyZip.Text = "Copy to ZIP Source";
            this.tbmCopyZip.Click += new System.EventHandler(this.OnMenuCopyZipClick);
            // 
            // tbmCopyPdf
            // 
            this.tbmCopyPdf.Name = "tbmCopyPdf";
            this.tbmCopyPdf.Size = new System.Drawing.Size(180, 22);
            this.tbmCopyPdf.Text = "Copy to PDF Source";
            this.tbmCopyPdf.Click += new System.EventHandler(this.OnMenuCopyPdfClick);
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
            // tbsSeparator3
            // 
            this.tbsSeparator3.Name = "tbsSeparator3";
            this.tbsSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // tbsSeparator5
            // 
            this.tbsSeparator5.Name = "tbsSeparator5";
            this.tbsSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tbcTypes
            // 
            this.tbcTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbcTypes.Items.AddRange(new object[] {
            "Raw",
            "Base 64"});
            this.tbcTypes.Name = "tbcTypes";
            this.tbcTypes.Size = new System.Drawing.Size(75, 25);
            this.tbcTypes.ToolTipText = "Choose a format.";
            // 
            // tscEncodings
            // 
            this.tscEncodings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscEncodings.Name = "tscEncodings";
            this.tscEncodings.Size = new System.Drawing.Size(110, 25);
            this.tscEncodings.ToolTipText = "Choose an encoding.";
            // 
            // panSource
            // 
            this.panSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSource.Controls.Add(this.txtSource);
            this.panSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panSource.Location = new System.Drawing.Point(0, 23);
            this.panSource.Margin = new System.Windows.Forms.Padding(0);
            this.panSource.Name = "panSource";
            this.panSource.Size = new System.Drawing.Size(558, 413);
            this.panSource.TabIndex = 1;
            // 
            // txtSource
            // 
            this.txtSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSource.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSource.Location = new System.Drawing.Point(0, 0);
            this.txtSource.Margin = new System.Windows.Forms.Padding(0);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(556, 411);
            this.txtSource.TabIndex = 0;
            this.txtSource.Text = "";
            this.txtSource.WordWrap = false;
            // 
            // tlpContent
            // 
            this.tlpContent.ColumnCount = 1;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Controls.Add(this.lblSource, 0, 0);
            this.tlpContent.Controls.Add(this.panSource, 0, 1);
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.Location = new System.Drawing.Point(0, 25);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 2;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Size = new System.Drawing.Size(558, 436);
            this.tlpContent.TabIndex = 2;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSource.Image = global::Plexdata.ConverterUtility.Properties.Resources.LightSmall;
            this.lblSource.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSource.InfoText = resources.GetString("lblSource.InfoText");
            this.lblSource.Location = new System.Drawing.Point(0, 0);
            this.lblSource.Margin = new System.Windows.Forms.Padding(0);
            this.lblSource.Name = "lblSource";
            this.lblSource.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblSource.Size = new System.Drawing.Size(558, 23);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Paste Raw or Base64 content into edit box below.";
            this.lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BinSourcePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpContent);
            this.Controls.Add(this.tbsButtons);
            this.Name = "BinSourcePanel";
            this.Size = new System.Drawing.Size(558, 461);
            this.tbsButtons.ResumeLayout(false);
            this.tbsButtons.PerformLayout();
            this.panSource.ResumeLayout(false);
            this.tlpContent.ResumeLayout(false);
            this.tlpContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tbsButtons;
        private System.Windows.Forms.Panel panSource;
        private System.Windows.Forms.RichTextBox txtSource;
        private System.Windows.Forms.ToolStripButton tbbView;
        private System.Windows.Forms.ToolStripSeparator tbsSeparator1;
        private System.Windows.Forms.ToolStripButton tbbWrap;
        private System.Windows.Forms.ToolStripSeparator tbsSeparator2;
        private System.Windows.Forms.ToolStripComboBox tbcTypes;
        private System.Windows.Forms.ToolStripComboBox tscEncodings;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private ConverterUtility.Controls.InfoLabel lblSource;
        private System.Windows.Forms.ToolStripButton tbbClear;
        private System.Windows.Forms.ToolStripButton tbbSelect;
        private System.Windows.Forms.ToolStripSeparator tbsSeparator5;
        private System.Windows.Forms.ToolStripButton tbbCut;
        private System.Windows.Forms.ToolStripSplitButton tbbCopy;
        private System.Windows.Forms.ToolStripMenuItem tbmCopyZip;
        private System.Windows.Forms.ToolStripMenuItem tbmCopyPdf;
        private System.Windows.Forms.ToolStripButton tbbPaste;
        private System.Windows.Forms.ToolStripSeparator tbsSeparator3;
        private System.Windows.Forms.ToolStripButton tbbUndo;
        private System.Windows.Forms.ToolStripButton tbbRedo;
        private System.Windows.Forms.ToolStripSeparator tbsSeparator4;
    }
}
