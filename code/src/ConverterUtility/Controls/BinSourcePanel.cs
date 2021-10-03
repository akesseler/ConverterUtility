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

using Plexdata.ConverterUtility.Defines;
using Plexdata.ConverterUtility.Events;
using Plexdata.ConverterUtility.Helpers;
using Plexdata.ConverterUtility.Settings;
using Plexdata.ConverterUtility.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Plexdata.ConverterUtility.Controls
{
    public partial class BinSourcePanel : UserControl
    {
        public event ViewBinaryHandler ViewBinary;

        #region Construction

        public BinSourcePanel()
            : base()
        {
            this.InitializeComponent();

            this.tbbWrap.Checked = true;
            this.txtSource.MaxLength = Int32.MaxValue;
            this.txtSource.Text = null;

            this.tbcTypes.Items.Clear();

            foreach (BinaryType current in Enum.GetValues(typeof(BinaryType)))
            {
                this.tbcTypes.Items.Add(current);
            }

            this.tbcTypes.SelectedItem = BinaryType.BASE64;

            List<Encoding> encodings = new List<Encoding>()
            {
                Encoding.UTF7,
                Encoding.UTF8,
                Encoding.UTF32,
                Encoding.ASCII,
                Encoding.Default,
                Encoding.Unicode,
                Encoding.BigEndianUnicode,
            };

            this.tscEncodings.ComboBox.DataSource = encodings;
            this.tscEncodings.ComboBox.DisplayMember = nameof(Encoding.WebName);
            this.tscEncodings.ComboBox.SelectedItem = Encoding.UTF8;

            DataCopyManager.DataCopied += this.OnDataCopyManagerDataCopied;
        }

        #endregion

        #region Public Methods

        public void LoadSettings(ProgramSettings settings)
        {
            this.tbcTypes.SelectedItem = settings.BinSourcePanel.BinaryType;
            this.tbbWrap.Checked = settings.BinSourcePanel.WordWrap;
            this.tscEncodings.SelectedItem = settings.BinSourcePanel.SelectedEncoding;
        }

        public void SaveSettings(ProgramSettings settings)
        {
            settings.BinSourcePanel.BinaryType = (BinaryType)this.tbcTypes.SelectedItem;
            settings.BinSourcePanel.WordWrap = this.tbbWrap.Checked;
            settings.BinSourcePanel.SelectedEncoding = (Encoding)this.tscEncodings.SelectedItem;
        }

        #endregion

        #region Private Methods

        private Byte[] GetFromRawData(String source)
        {
            return (this.tscEncodings.SelectedItem as Encoding).GetBytes(source);
        }

        private Byte[] GetFromBase64(String source)
        {
            return Convert.FromBase64String(StringExtractor.Extract(source));
        }

        #endregion

        #region Event Handlers

        private void OnDataCopyManagerDataCopied(Object sender, DataCopyEventArgs args)
        {
            if (args.Target != TargetType.BinSource)
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
                Byte[] source = null;

                if (this.tbcTypes.SelectedItem is BinaryType selected)
                {
                    switch (selected)
                    {
                        case BinaryType.RAW:
                            source = this.GetFromRawData(this.txtSource.Text);
                            break;
                        case BinaryType.BASE64:
                            source = this.GetFromBase64(this.txtSource.Text);
                            break;
                        default:
                            return;
                    }
                }

                this.ViewBinary?.Invoke(this, new ViewBinaryEventArgs(source));
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

        private void OnMenuCopyPdfClick(Object sender, EventArgs args)
        {
            DataCopyManager.CopyDataToPdfSource(this.txtSource);
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
