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
    partial class PdfPanel
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
            this.spsContent = new ConverterUtility.Controls.SplitContainerEx();
            this.panSource = new ConverterUtility.Controls.PdfSourcePanel();
            this.panResult = new ConverterUtility.Controls.PdfResultPanel();
            ((System.ComponentModel.ISupportInitialize)(this.spsContent)).BeginInit();
            this.spsContent.Panel1.SuspendLayout();
            this.spsContent.Panel2.SuspendLayout();
            this.spsContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // spsContent
            // 
            this.spsContent.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.spsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spsContent.Location = new System.Drawing.Point(0, 0);
            this.spsContent.Name = "spsContent";
            this.spsContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spsContent.Panel1
            // 
            this.spsContent.Panel1.Controls.Add(this.panSource);
            // 
            // spsContent.Panel2
            // 
            this.spsContent.Panel2.Controls.Add(this.panResult);
            this.spsContent.Size = new System.Drawing.Size(521, 421);
            this.spsContent.SplitterDistance = 173;
            this.spsContent.SplitterWidth = 11;
            this.spsContent.TabIndex = 0;
            this.spsContent.TabStop = false;
            // 
            // panSource
            // 
            this.panSource.Cursor = System.Windows.Forms.Cursors.Default;
            this.panSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panSource.Location = new System.Drawing.Point(0, 0);
            this.panSource.Margin = new System.Windows.Forms.Padding(0);
            this.panSource.Name = "panSource";
            this.panSource.Size = new System.Drawing.Size(521, 173);
            this.panSource.TabIndex = 0;
            // 
            // panResult
            // 
            this.panResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.panResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panResult.Location = new System.Drawing.Point(0, 0);
            this.panResult.Name = "panResult";
            this.panResult.Size = new System.Drawing.Size(521, 241);
            this.panResult.TabIndex = 0;
            // 
            // PdfPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spsContent);
            this.Name = "PdfPanel";
            this.Size = new System.Drawing.Size(521, 421);
            this.spsContent.Panel1.ResumeLayout(false);
            this.spsContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spsContent)).EndInit();
            this.spsContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainerEx spsContent;
        private PdfSourcePanel panSource;
        private PdfResultPanel panResult;
    }
}
