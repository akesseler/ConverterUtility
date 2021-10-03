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

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Plexdata.ConverterUtility.Controls
{
    // It's not perfect but much better than all other solutions,
    // such as a user control with a self-made popup window.
    public class InfoLabel : Label
    {
        #region Private fields

        private ToolTip tooltip;

        #endregion

        #region Construction

        public InfoLabel()
            : base()
        {
            this.tooltip = new ToolTip();
            this.tooltip.ShowAlways = true;
            this.tooltip.AutomaticDelay = 0;
            this.tooltip.AutoPopDelay = 20000;
            this.tooltip.InitialDelay = 0;
            this.tooltip.ReshowDelay = 0;
            this.tooltip.UseAnimation = false;
            this.tooltip.UseFading = false;
            this.tooltip.IsBalloon = false;

            base.AutoSize = true;
            base.TextAlign = ContentAlignment.MiddleLeft;
            base.ImageAlign = ContentAlignment.MiddleRight;
            base.Padding = new Padding(0, 5, 0, 5);
        }

        #endregion

        #region Public properties

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public String InfoText
        {
            get
            {
                return this.tooltip.GetToolTip(this);
            }
            set
            {
                this.tooltip.SetToolTip(this, value);
            }
        }

        #endregion

        #region Protected methods

        protected override void Dispose(Boolean disposing)
        {
            if (disposing)
            {
                if (this.tooltip != null)
                {
                    this.tooltip.Dispose();
                    this.tooltip = null;
                }
            }

            base.Dispose(disposing);
        }

        protected override void OnMouseMove(MouseEventArgs args)
        {
            base.OnMouseMove(args);

            if (String.IsNullOrWhiteSpace(this.InfoText))
            {
                return;
            }

            Rectangle display = base.ClientRectangle;
            Padding padding = base.Padding;

            display.X += padding.Left;
            display.Y += padding.Top;
            display.Width -= padding.Horizontal;
            display.Height -= padding.Vertical;

            Rectangle boundary = base.CalcImageRenderBounds(base.Image, display, base.ImageAlign);
            Boolean inside = boundary.Contains(args.Location);

            if (inside)
            {
                this.tooltip.Active = true;
            }
            else
            {
                this.tooltip.Active = false;
            }
        }

        #endregion
    }
}
