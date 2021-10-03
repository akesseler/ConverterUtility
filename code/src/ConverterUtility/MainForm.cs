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

using Plexdata.ConverterUtility.Dialogs;
using Plexdata.ConverterUtility.Settings;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Plexdata.ConverterUtility
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm()
            : base()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Protected Methods

        protected override void OnLoad(EventArgs args)
        {
            base.OnLoad(args);
            this.LoadSettings(Program.Settings);
        }

        protected override void OnClosing(CancelEventArgs args)
        {
            base.OnClosing(args);
            this.SaveSettings(Program.Settings);
        }

        #endregion

        #region Private Methods

        private void LoadSettings(ProgramSettings settings)
        {
            try
            {
                this.WindowState = settings.WindowSettings.DisplayState;
                this.DesktopBounds = this.GetFixedDesktopBounds(settings.WindowSettings.DesktopBounds, this.MinimumSize);
                this.tabControl.SelectedIndex = this.GetSelectedPage(settings.WindowSettings.SelectedPage, 0, this.tabControl.TabCount - 1);

                this.panZipView.LoadSettings(settings);
                this.panPdfView.LoadSettings(settings);
                this.panBinView.LoadSettings(settings);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }

        private void SaveSettings(ProgramSettings settings)
        {
            try
            {
                settings.WindowSettings.DisplayState = this.WindowState;
                settings.WindowSettings.DesktopBounds = this.DesktopBounds;
                settings.WindowSettings.SelectedPage = this.tabControl.SelectedIndex;

                this.panZipView.SaveSettings(settings);
                this.panPdfView.SaveSettings(settings);
                this.panBinView.SaveSettings(settings);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }

        private Rectangle GetFixedDesktopBounds(Rectangle desktopBounds, Size minimumSize)
        {
            foreach (Screen currentScreen in Screen.AllScreens)
            {
                if (currentScreen.Bounds.Contains(desktopBounds))
                {
                    return desktopBounds;
                }
            }

            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

            // Width adjustment.

            Int32 w = desktopBounds.Width;

            if (w < minimumSize.Width) { w = minimumSize.Width; }

            if (w > workingArea.Width) { w = workingArea.Width; }

            // Height adjustment.

            Int32 h = desktopBounds.Height;

            if (h < minimumSize.Height) { h = minimumSize.Height; }

            if (h > workingArea.Height) { h = workingArea.Height; }

            // Left adjustment.

            Int32 x = desktopBounds.Left;

            if (x < workingArea.Left) { x = workingArea.Left; }

            if (x + w > workingArea.Left + workingArea.Right) { x = workingArea.Right - w; }

            // Top adjustment.

            Int32 y = desktopBounds.Top;

            if (y < workingArea.Top) { y = workingArea.Top; }

            if (y + h > workingArea.Top + workingArea.Bottom) { y = workingArea.Bottom - h; }

            return new Rectangle(x, y, w, h);
        }

        private Int32 GetSelectedPage(Int32 value, Int32 lower, Int32 upper)
        {
            if (value < lower) { return lower; }

            if (value > upper) { return upper; }

            return value;
        }

        #endregion

        #region Event Handlers

        private void OnButtonExitClick(Object sender, EventArgs args)
        {
            this.Close();
        }

        private void OnButtonInfoClick(Object sender, EventArgs args)
        {
            AboutDialog dialog = new AboutDialog();
            dialog.ShowDialog();
        }

        #endregion
    }
}
