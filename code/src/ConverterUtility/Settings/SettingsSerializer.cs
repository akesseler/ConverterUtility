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

using Plexdata.CfgParser.Entities;
using Plexdata.CfgParser.Processors;
using Plexdata.CfgParser.Settings;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;

namespace Plexdata.ConverterUtility.Settings
{
    public static class SettingsSerializer
    {
        #region Private Fields

        private static String defaultFilename = String.Empty;

        #endregion

        #region Public Properties

        public static String DefaultFilename
        {
            get
            {
                if (String.IsNullOrWhiteSpace(SettingsSerializer.defaultFilename))
                {
                    SettingsSerializer.defaultFilename = SettingsSerializer.GetDefaultFilename();
                }

                return SettingsSerializer.defaultFilename;
            }
        }

        #endregion

        #region Public Methods

        public static Boolean Load(out ProgramSettings settings)
        {
            return SettingsSerializer.Load(SettingsSerializer.DefaultFilename, out settings);
        }

        public static Boolean Load(String filename, out ProgramSettings settings)
        {
            settings = null;

            try
            {
                ConfigContent content = ConfigReader.Read(filename);

                settings = ConfigParser<ProgramSettings>.Parse(content);

                return true;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return false;
            }
        }

        public static Boolean Save(ProgramSettings settings)
        {
            return SettingsSerializer.Save(SettingsSerializer.DefaultFilename, settings);
        }

        public static Boolean Save(String filename, ProgramSettings settings)
        {
            try
            {
                ConfigContent content = ConfigParser<ProgramSettings>.Parse(settings);

                content.Header = ConfigSettings.CreateStandardHeader("Do not change this file!", true);

                ConfigWriter.Write(content, filename, true);

                return true;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                return false;
            }
        }

        #endregion

        #region Private Methods

        private static String GetDefaultFilename()
        {
            String site = Path.GetFullPath(Application.ExecutablePath);
            String file = Path.ChangeExtension(Path.GetFileName(site), ".conf");
            String path = Path.GetDirectoryName(site);

            if (SettingsSerializer.IsAccessPermitted(path, FileSystemRights.Write))
            {
                return Path.Combine(path, file);
            }

            if (String.IsNullOrWhiteSpace(Application.CompanyName))
            {
                // May never happen, but safety first...
                throw new ArgumentException("Company name is invalid.");
            }

            if (String.IsNullOrWhiteSpace(Application.ProductName))
            {
                // May never happen, but safety first...
                throw new ArgumentException("Product name is invalid.");
            }

            path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            path = Path.Combine(path, Application.CompanyName, Application.ProductName);

            Directory.CreateDirectory(path);

            return Path.Combine(path, file);
        }

        private static Boolean IsAccessPermitted(String folder, FileSystemRights rights)
        {
            if (String.IsNullOrEmpty(folder))
            {
                return false;
            }

            try
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();

                AuthorizationRuleCollection rules = Directory
                    .GetAccessControl(folder)
                    .GetAccessRules(true, true, typeof(SecurityIdentifier));

                foreach (FileSystemAccessRule rule in rules)
                {
                    if (identity.Groups.Contains(rule.IdentityReference))
                    {
                        if (rule.AccessControlType == AccessControlType.Allow && rule.FileSystemRights.HasFlag(rights))
                        {
                            return true;
                        }
                    }
                }
            }
            catch
            {
            }

            return false;
        }

        #endregion
    }
}
