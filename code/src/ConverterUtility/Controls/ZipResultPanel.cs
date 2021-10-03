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
using Plexdata.ConverterUtility.Helpers;
using Plexdata.ConverterUtility.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.DataFormats;
using Plexdata.ConverterUtility.Settings;

namespace Plexdata.ConverterUtility.Controls
{
    public partial class ZipResultPanel : UserControl
    {
        #region Construction

        public ZipResultPanel()
            : base()
        {
            this.InitializeComponent();

            this.tbbWrap.Checked = true;
            this.txtResult.MaxLength = Int32.MaxValue;
            this.txtResult.Text = null;

            this.tbcTypes.Items.Clear();

            foreach (PrettyType current in Enum.GetValues(typeof(PrettyType)))
            {
                this.tbcTypes.Items.Add(current);
            }

            this.tbcTypes.SelectedItem = PrettyType.RAW;
        }

        #endregion

        #region Public Methods

        public void SetResult(String result)
        {
            this.txtResult.Text = result ?? String.Empty;
        }

        public void LoadSettings(ProgramSettings settings)
        {
            this.tbbWrap.Checked = settings.ZipResultPanel.WordWrap;
        }

        public void SaveSettings(ProgramSettings settings)
        {
            settings.ZipResultPanel.WordWrap = this.tbbWrap.Checked;
        }

        #endregion

        #region Private Methods

        private void DoPrettyPrintJson()
        {
            try
            {
                this.txtResult.Text = JValue.Parse(this.txtResult.Text).ToString(Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                Program.ShowMessage(this, "Trying to format text has encountered an error.", MessageType.Error);
            }
        }

        private void DoPrettyPrintXml()
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    using (XmlTextWriter writer = new XmlTextWriter(stream, Encoding.Unicode))
                    {
                        writer.Formatting = Formatting.Indented;

                        XmlDocument document = new XmlDocument();

                        document.LoadXml(this.txtResult.Text);

                        document.WriteContentTo(writer);

                        writer.Flush();
                        stream.Flush();
                        stream.Position = 0;

                        using (StreamReader reader = new StreamReader(stream))
                        {
                            this.txtResult.Text = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                Program.ShowMessage(this, "Trying to format text has encountered an error.", MessageType.Error);
            }
        }

        private Boolean CanSearch()
        {
            if (this.txtResult.TextLength == 0)
            {
                Program.ShowMessage(this, "Nothing to find.", MessageType.Information);
                return false;
            }

            if (this.tbxFind.TextLength == 0)
            {
                Program.ShowMessage(this, "Provide a text to search for.", MessageType.Information);
                return false;
            }

            return true;
        }

        private void FindText(Int32 offset, String value)
        {
            try
            {
                offset = this.txtResult.Find(value, offset, RichTextBoxFinds.None);

                if (offset < 0)
                {
                    Program.ShowMessage(this, $"Text \"{value}\" could not be found.", MessageType.Information);
                    return;
                }

                this.txtResult.Select(offset, value.Length);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                Program.ShowMessage(this, $"Woops, an error occurred while searching for text \"{value}\".", MessageType.Error);
            }
        }

        #endregion

        #region Event Handlers

        private void OnComboBoxTypesSelectedIndexChanged(Object sender, EventArgs args)
        {
            if (this.tbcTypes.SelectedItem is PrettyType selected)
            {
                this.tbbPretty.Enabled = selected != PrettyType.RAW;
            }
        }

        private void OnButtonPrettyClick(Object sender, EventArgs args)
        {
            if (this.tbcTypes.SelectedItem is PrettyType selected)
            {
                switch (selected)
                {
                    case PrettyType.JSON:
                        this.DoPrettyPrintJson();
                        break;
                    case PrettyType.XML:
                        this.DoPrettyPrintXml();
                        break;
                    default:
                        return;
                }
            }
        }

        private void OnButtonWrapCheckedChanged(Object sender, EventArgs args)
        {
            this.txtResult.WordWrap = this.tbbWrap.Checked;
        }

        private void OnButtonSelectClick(Object sender, EventArgs args)
        {
            String source = this.txtResult.Text;
            Int32 offset = this.txtResult.SelectionStart;

            if (StringExtractor.TryFindSelection(source, offset, out Int32 start, out Int32 count))
            {
                this.txtResult.Select(start, count);
            }
        }

        private void OnButtonCutClick(Object sender, EventArgs args)
        {
            using (new WindowUpdateLocker(this.txtResult))
            {
                if (this.txtResult.SelectionLength < 1)
                {
                    this.txtResult.SelectAll();
                }

                this.txtResult.Cut();
            }
        }

        private void OnButtonCopyClick(Object sender, EventArgs args)
        {
            using (new WindowUpdateLocker(this.txtResult))
            {
                Boolean deselect = this.txtResult.SelectionLength < 1;

                if (deselect)
                {
                    this.txtResult.SelectAll();
                }

                this.txtResult.Copy();

                if (deselect)
                {
                    this.txtResult.DeselectAll();
                }
            }
        }

        private void OnMenuCopyZipClick(Object sender, EventArgs args)
        {
            DataCopyManager.CopyDataToZipSource(this.txtResult);
        }

        private void OnMenuCopyPdfClick(Object sender, EventArgs args)
        {
            DataCopyManager.CopyDataToPdfSource(this.txtResult);
        }

        private void OnMenuCopyBinClick(Object sender, EventArgs args)
        {
            DataCopyManager.CopyDataToBinSource(this.txtResult);
        }

        private void OnButtonPasteClick(Object sender, EventArgs args)
        {
            using (new WindowUpdateLocker(this.txtResult))
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
                    if (this.txtResult.CanPaste(format))
                    {
                        this.txtResult.Paste(format);
                        return;
                    }
                }
            }
        }

        private void OnButtonUndoClick(Object sender, EventArgs args)
        {
            using (new WindowUpdateLocker(this.txtResult))
            {
                if (this.txtResult.CanUndo)
                {
                    this.txtResult.Undo();
                }
            }
        }

        private void OnButtonRedoClick(Object sender, EventArgs args)
        {
            using (new WindowUpdateLocker(this.txtResult))
            {
                if (this.txtResult.CanRedo)
                {
                    this.txtResult.Redo();
                }
            }
        }

        private void OnButtonClearClick(Object sender, EventArgs args)
        {
            this.txtResult.Clear();
        }

        private void OnButtonFindClick(Object sender, EventArgs args)
        {
            if (this.CanSearch())
            {
                Int32 offset = this.txtResult.SelectionStart + this.txtResult.SelectionLength + 1;

                if (offset > this.txtResult.TextLength)
                {
                    offset = this.txtResult.SelectionStart + 1;
                }

                this.FindText(offset + 0, this.tbxFind.Text);
            }
        }

        #endregion
    }
}
