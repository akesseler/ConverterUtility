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

using Plexdata.ConverterUtility.Settings;
using System;
using System.Windows.Forms;

namespace Plexdata.ConverterUtility.Controls
{
    public partial class BinResultPanel : UserControl
    {
        #region Construction

        public BinResultPanel()
            : base()
        {
            this.InitializeComponent();

            this.binView.Buffer = null;

            this.tbcBytesPerLine.Items.Clear();
            this.tbcBytesPerLine.Items.Add(8);
            this.tbcBytesPerLine.Items.Add(16);
            this.tbcBytesPerLine.Items.Add(32);
            this.tbcBytesPerLine.Items.Add(64);
            this.tbcBytesPerLine.Items.Add(128);
            this.tbcBytesPerLine.Items.Add(256);
            this.tbcBytesPerLine.SelectedItem = 16;

            this.tbcBlockWidth.Items.Clear();
            this.tbcBlockWidth.Items.Add(2);
            this.tbcBlockWidth.Items.Add(4);
            this.tbcBlockWidth.Items.Add(8);
            this.tbcBlockWidth.SelectedItem = 2;

            this.tbbUpperCase.Checked = this.binView.UpperCase;
        }

        #endregion

        #region Public Methods

        public void SetResult(Byte[] source)
        {
            this.binView.Buffer = source;
        }

        public void LoadSettings(ProgramSettings settings)
        {
            this.tbcBytesPerLine.SelectedItem = settings.BinResultPanel.BytesPerLine;
            this.tbcBlockWidth.SelectedItem = settings.BinResultPanel.BlockWidth;
            this.tbbUpperCase.Checked = settings.BinResultPanel.UpperCase;
        }

        public void SaveSettings(ProgramSettings settings)
        {
            settings.BinResultPanel.BytesPerLine = (Int32)this.tbcBytesPerLine.SelectedItem;
            settings.BinResultPanel.BlockWidth = (Int32)this.tbcBlockWidth.SelectedItem;
            settings.BinResultPanel.UpperCase = this.tbbUpperCase.Checked;
        }

        #endregion

        #region Event Handlers

        private void OnBytesPerLineSelectedIndexChanged(Object sender, EventArgs args)
        {
            if (this.tbcBytesPerLine.SelectedItem is Int32 selected)
            {
                this.binView.BytesPerLine = selected;
            }
        }

        private void OnBlockWidthSelectedIndexChanged(Object sender, EventArgs args)
        {
            if (this.tbcBlockWidth.SelectedItem is Int32 selected)
            {
                this.binView.BlockWidth = selected;
            }
        }

        private void OnUpperCaseCheckStateChanged(Object sender, EventArgs args)
        {
            this.binView.UpperCase = this.tbbUpperCase.Checked;
        }

        #endregion
    }
}
