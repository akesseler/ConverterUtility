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

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Plexdata.ConverterUtility.Utilities
{
    public class WindowUpdateLocker : IDisposable
    {
        #region Private Fields

        private readonly IntPtr handle = IntPtr.Zero;

        #endregion

        #region Construction

        public WindowUpdateLocker(Control control)
            : this(control?.Handle ?? IntPtr.Zero)
        {
        }

        public WindowUpdateLocker(IntPtr handle)
            : base()
        {
            this.handle = handle;

            // Lock window update only if possible.
            if (this.handle != IntPtr.Zero)
            {
                WindowUpdateLocker.LockWindowUpdate(this.handle);
            }
        }

        #endregion

        #region Public Methods

        public void Dispose()
        {
            // Unlock window update only if possible.
            if (this.handle != IntPtr.Zero)
            {
                WindowUpdateLocker.LockWindowUpdate(IntPtr.Zero);
            }
        }

        #endregion

        #region Win32 Access

        [DllImport("user32.dll")]
        private static extern Boolean LockWindowUpdate(IntPtr hWnd);

        #endregion
    }
}
