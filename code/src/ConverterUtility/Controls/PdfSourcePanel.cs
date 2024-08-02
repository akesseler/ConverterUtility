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

using Plexdata.ConverterUtility.Defines;
using Plexdata.ConverterUtility.Events;
using Plexdata.ConverterUtility.Helpers;
using Plexdata.ConverterUtility.Settings;
using Plexdata.ConverterUtility.Utilities;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Plexdata.ConverterUtility.Controls
{
    public partial class PdfSourcePanel : UserControl
    {
        public event SaveBinaryHandler SaveBinary;

        #region Construction

        public PdfSourcePanel()
            : base()
        {
            this.InitializeComponent();

            this.tbbWrap.Checked = true;
            this.txtSource.MaxLength = Int32.MaxValue;
            this.txtSource.Text = null;

            DataCopyManager.DataCopied += this.OnDataCopyManagerDataCopied;
        }

        #endregion

        #region Public Methods

        public void LoadSettings(ProgramSettings settings)
        {
            this.tbbWrap.Checked = settings.PdfSourcePanel.WordWrap;
        }

        public void SaveSettings(ProgramSettings settings)
        {
            settings.PdfSourcePanel.WordWrap = this.tbbWrap.Checked;
        }

        #endregion

        #region Private Methods

        private Byte[] GetFromBase64(String source)
        {
            return Convert.FromBase64String(StringExtractor.Extract(source));
        }

        #endregion

        #region Event Handlers

        private void OnDataCopyManagerDataCopied(Object sender, DataCopyEventArgs args)
        {
            if (args.Target != TargetType.PdfSource)
            {
                return;
            }

            this.txtSource.Text = args.Value;
        }

        private void OnButtonViewClick(Object sender, EventArgs args)
        {
            if (this.txtSource.Text.Length < 1)
            {
                Program.ShowMessage(this, "Provide content to be viewed.", MessageType.Information);
                return;
            }

            try
            {
                Byte[] source = this.GetFromBase64(this.txtSource.Text);

                this.SaveBinary?.Invoke(this, new SaveBinaryEventArgs(source));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                Program.ShowMessage(this, "Woops, an error occurred while converting source data.", MessageType.Error);
            }
        }

        private void OnButtonWrapCheckedChanged(Object sender, EventArgs args)
        {
            this.txtSource.WordWrap = this.tbbWrap.Checked;
        }

        private void OnButtonSelectClick(Object sender, EventArgs args)
        {
            this.txtSource.SelectAll();
        }

        private void OnButtonCutClick(Object sender, EventArgs args)
        {
            using (new WindowUpdateLocker(this.txtSource))
            {
                if (this.txtSource.SelectionLength < 1)
                {
                    this.txtSource.SelectAll();
                }

                this.txtSource.Cut();
            }
        }

        private void OnButtonCopyClick(Object sender, EventArgs args)
        {
            using (new WindowUpdateLocker(this.txtSource))
            {
                Boolean deselect = this.txtSource.SelectionLength < 1;

                if (deselect)
                {
                    this.txtSource.SelectAll();
                }

                this.txtSource.Copy();

                if (deselect)
                {
                    this.txtSource.DeselectAll();
                }
            }
        }

        private void OnMenuCopyZipClick(Object sender, EventArgs args)
        {
            DataCopyManager.CopyDataToZipSource(this.txtSource);
        }

        private void OnMenuCopyBinClick(Object sender, EventArgs args)
        {
            DataCopyManager.CopyDataToBinSource(this.txtSource);
        }

        private void OnButtonPasteClick(Object sender, EventArgs args)
        {
            using (new WindowUpdateLocker(this.txtSource))
            {
                Format[] formats = new Format[]
                {
                    DataFormats.GetFormat(DataFormats.Rtf),
                    DataFormats.GetFormat(DataFormats.Text),
                    DataFormats.GetFormat(DataFormats.UnicodeText),
                    DataFormats.GetFormat(DataFormats.OemText)
                };

                foreach (Format format in formats)
                {
                    if (this.txtSource.CanPaste(format))
                    {
                        this.txtSource.Paste(format);
                        return;
                    }
                }
            }
        }

        private void OnButtonUndoClick(Object sender, EventArgs args)
        {
            using (new WindowUpdateLocker(this.txtSource))
            {
                if (this.txtSource.CanUndo)
                {
                    this.txtSource.Undo();
                }
            }
        }

        private void OnButtonRedoClick(Object sender, EventArgs args)
        {
            using (new WindowUpdateLocker(this.txtSource))
            {
                if (this.txtSource.CanRedo)
                {
                    this.txtSource.Redo();
                }
            }
        }

        private void OnButtonClearClick(Object sender, EventArgs args)
        {
            this.txtSource.Clear();
        }

        #endregion
    }
}
