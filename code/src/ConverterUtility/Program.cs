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
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Plexdata.ConverterUtility
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += OnApplicationExit;
            Application.ThreadException += OnGlobalException;

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, false);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        #region Application Settings

        private static ProgramSettings settings;

        public static ProgramSettings Settings
        {
            get
            {
                if (Program.settings == null)
                {
                    if (!SettingsSerializer.Load(out Program.settings))
                    {
                        Program.settings = new ProgramSettings();
                    }
                }

                return Program.settings;
            }
        }

        #endregion

        #region Application Event Handlers

        private static void OnApplicationExit(Object sender, EventArgs args)
        {
            SettingsSerializer.Save(Program.Settings);
        }

        private static void OnGlobalException(Object sender, ThreadExceptionEventArgs args)
        {
            Program.ShowMessage(args.Exception.Message, MessageType.Error);
        }

        #endregion

        #region Message Showing

        public static DialogResult ShowMessage(String message, MessageType type)
        {
            return Program.ShowMessage(null, message, type);
        }

        public static DialogResult ShowMessage(IWin32Window owner, String message, MessageType type)
        {
            String caption = String.Empty;
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.None;

            switch (type)
            {
                case MessageType.Information:
                    caption = "Information";
                    icon = MessageBoxIcon.Information;
                    break;
                case MessageType.Error:
                    caption = "Error";
                    icon = MessageBoxIcon.Error;
                    break;
                case MessageType.Warning:
                    caption = "Warning";
                    icon = MessageBoxIcon.Warning;
                    break;
                case MessageType.Question1:
                    caption = "Question";
                    icon = MessageBoxIcon.Question;
                    buttons = MessageBoxButtons.YesNo;
                    break;
                case MessageType.Question2:
                    caption = "Question";
                    icon = MessageBoxIcon.Question;
                    buttons = MessageBoxButtons.YesNoCancel;
                    break;
                default:
                    Debug.Assert(false, $"Support message type of \"{type}\".");
                    break;
            }

            return Program.ShowMessage(owner, caption, message, icon, buttons);
        }

        public static DialogResult ShowMessage(IWin32Window owner, String caption, String message, MessageBoxIcon type, MessageBoxButtons buttons)
        {
            try
            {
                if (owner == null)
                {
                    owner = Application.OpenForms.Cast<Form>().FirstOrDefault();
                }
            }
            catch { }

            return MessageBox.Show(owner, message, caption, buttons, type);
        }

        #endregion
    }
}
