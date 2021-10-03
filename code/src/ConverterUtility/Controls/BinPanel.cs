﻿/*
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
using Plexdata.ConverterUtility.Settings;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Plexdata.ConverterUtility.Controls
{
    public partial class BinPanel : UserControl
    {
        #region Construction

        public BinPanel()
            : base()
        {
            this.InitializeComponent();

            this.panSource.ViewBinary += this.OnHandleViewBinary;
        }

        #endregion

        #region Public Methods

        public void LoadSettings(ProgramSettings settings)
        {
            this.panSource.LoadSettings(settings);
            this.panResult.LoadSettings(settings);
        }

        public void SaveSettings(ProgramSettings settings)
        {
            this.panSource.SaveSettings(settings);
            this.panResult.SaveSettings(settings);
        }

        #endregion

        #region Event Handlers

        private void OnHandleViewBinary(Object sender, ViewBinaryEventArgs args)
        {
            try
            {
                this.panResult.SetResult(args.Source);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                Program.ShowMessage(this, exception.Message, MessageType.Error);
            }
        }

        #endregion
    }
}
