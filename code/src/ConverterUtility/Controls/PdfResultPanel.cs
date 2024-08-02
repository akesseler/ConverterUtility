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
using Plexdata.ConverterUtility.Settings;
using Plexdata.Formatters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Plexdata.ConverterUtility.Controls
{
    public partial class PdfResultPanel : UserControl
    {
        private static readonly Byte[] pdfSignature = new Byte[] { 0x25, 0x50, 0x44, 0x46, 0x2D };

        private String filePathName = null;

        #region Construction

        public PdfResultPanel()
            : base()
        {
            this.InitializeComponent();

            // Stop flickering while column resizing.
            MethodInfo method = this.lstResults.GetType().GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance);
            method.Invoke(this.lstResults, new Object[] { ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true });
        }

        #endregion

        #region Public Methods

        public void SetResult(Byte[] source)
        {
            if (source == null || source.Length < 1)
            {
                return;
            }

            FileType type = FileType.PDF;

            if (!this.IsPdfContent(source))
            {
                DialogResult choice = Program.ShowMessage(this,
                    "The provided bytes do not represent a PDF content. Do you want to process them anyway?",
                    MessageType.Question1);

                if (choice == DialogResult.No)
                {
                    return;
                }

                type = FileType.BIN;
            }

            String fullname = this.GetFullFileName(type);

            using (FileStream stream = File.Create(fullname))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write(source);
                    writer.Flush();
                    writer.Close();
                }
            }

            this.AddResultListItem(fullname);
        }

        public void LoadSettings(ProgramSettings settings)
        {
            this.filePathName = settings.PdfResultPanel.OutputFolder;
        }

        public void SaveSettings(ProgramSettings settings)
        {
            settings.PdfResultPanel.OutputFolder = this.filePathName;
        }

        #endregion

        #region Private Methods

        private Boolean IsPdfContent(Byte[] content)
        {
            Int32 length = PdfResultPanel.pdfSignature.Length;

            if (content.Length < length)
            {
                return false;
            }

            for (Int32 index = 0; index < length; index++)
            {
                if (PdfResultPanel.pdfSignature[index] != content[index])
                {
                    return false;
                }
            }

            return true;
        }

        private String GetFullFileName(FileType type)
        {
            return this.GetFullFileName($"{Guid.NewGuid():N}.{type.ToString().ToLower()}");
        }

        private String GetFullFileName(String filename)
        {
            return Path.Combine(this.GetFilePathName(), filename);
        }

        private String GetFilePathName()
        {
            if (String.IsNullOrWhiteSpace(this.filePathName))
            {
                this.filePathName = this.GetFilePathName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            }

            return this.filePathName;
        }

        private String GetFilePathName(String folder)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog()
            {
                SelectedPath = folder,
                ShowNewFolderButton = true,
                Description = this.tbbFolder.ToolTipText,
                RootFolder = Environment.SpecialFolder.MyComputer
            };

            switch (dialog.ShowDialog(this))
            {
                case DialogResult.OK:
                    return dialog.SelectedPath;
                default:
                    throw new InvalidOperationException();
            }
        }

        private void AddResultListItem(String fullname)
        {
            try
            {
                this.lstResults.BeginUpdate();

                FileInfo file = new FileInfo(fullname);

                ListViewItem item = new ListViewItem(this.GetFileNameColumnValue(file));

                item.Tag = file;
                item.Font = new Font("Consolas", 9F);

                item.SubItems.Add(this.GetFilePathColumnValue(file));
                item.SubItems.Add(this.GetFileSizeColumnValue(file));

                this.lstResults.Items.Add(item);

                foreach (ColumnHeader header in this.lstResults.Columns)
                {
                    header.Width = -1;
                }
            }
            finally
            {
                this.lstResults.EndUpdate();
            }
        }

        private String GetFileNameColumnValue(FileInfo file)
        {
            String result = "unknown";

            try { result = file.Name; } catch { }

            return result;
        }

        private String GetFilePathColumnValue(FileInfo file)
        {
            String result = "unknown";

            try { result = file.DirectoryName; } catch { }

            return result;
        }

        private String GetFileSizeColumnValue(FileInfo file)
        {
            Decimal result = 0M;

            try { result = file.Length; } catch { }

            return String.Format(new CapacityFormatter(), "{0:one}", result);
        }

        private void OpenFiles(IEnumerable<ListViewItem> items)
        {
            try
            {
                foreach (ListViewItem item in items)
                {
                    if (item.Tag is FileInfo file)
                    {
                        Process.Start(file.FullName);
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                Program.ShowMessage(this, "Woops, an error occurred while opening file.", MessageType.Error);
            }
        }

        private void DeleteFiles(IEnumerable<ListViewItem> items)
        {
            foreach (ListViewItem item in items)
            {
                if (item.Tag is FileInfo file)
                {
                    try
                    {
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine(exception);
                    }
                }
            }

            this.RemoveItems(items);
        }

        private void RemoveItems(IEnumerable<ListViewItem> items)
        {
            foreach (ListViewItem item in items)
            {
                this.lstResults.Items.Remove(item);
            }
        }

        #endregion

        #region Event Handlers

        private void OnResultsListDoubleClick(Object sender, EventArgs args)
        {
            this.OpenFiles(this.lstResults.SelectedItems.Cast<ListViewItem>());
        }

        private void OnButtonFolderClick(Object sender, EventArgs args)
        {
            try { this.filePathName = this.GetFilePathName(this.filePathName ?? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)); } catch { }
        }

        private void OnButtonViewClick(Object sender, EventArgs args)
        {
            this.OpenFiles(this.lstResults.SelectedItems.Cast<ListViewItem>());
        }

        private void OnButtonClearClick(Object sender, EventArgs args)
        {
            if (this.lstResults.SelectedItems.Count < 1)
            {
                return;
            }

            DialogResult choice = Program.ShowMessage(this, "Would you also like to physically delete selected files?", MessageType.Question2);

            switch (choice)
            {
                case DialogResult.Cancel:
                    return;
                case DialogResult.Yes:
                    this.DeleteFiles(this.lstResults.SelectedItems.Cast<ListViewItem>());
                    break;
                case DialogResult.No:
                    this.RemoveItems(this.lstResults.SelectedItems.Cast<ListViewItem>());
                    break;
            }
        }

        #endregion
    }
}
