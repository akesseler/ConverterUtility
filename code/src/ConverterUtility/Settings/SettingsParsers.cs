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

using Plexdata.CfgParser.Interfaces;
using Plexdata.ConverterUtility.Defines;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Plexdata.ConverterUtility.Settings
{
    public class DesktopBoundsParser : ICustomParser<Rectangle>
    {
        public Rectangle Parse(String label, String value, Object fallback, CultureInfo culture)
        {
            if (!this.TryParse(value, out Rectangle result))
            {
                if (!this.TryParse(fallback?.ToString(), out result))
                {
                    return new Rectangle(10, 10, 1000, 800);
                }
            }

            return result;
        }

        public String Parse(String label, Rectangle value, Object fallback, CultureInfo culture)
        {
            return String.Format("{0},{1},{2},{3}", value.X, value.Y, value.Width, value.Height);
        }

        private Boolean TryParse(String value, out Rectangle result)
        {
            result = new Rectangle();

            if (String.IsNullOrWhiteSpace(value)) { return false; }

            String[] pieces = value.Split(',');

            if (pieces.Length < 4) { return false; }

            if (!Int32.TryParse(pieces[0]?.Trim(), out Int32 x)) { return false; }

            if (!Int32.TryParse(pieces[1]?.Trim(), out Int32 y)) { return false; }

            if (!Int32.TryParse(pieces[2]?.Trim(), out Int32 w)) { return false; }

            if (!Int32.TryParse(pieces[3]?.Trim(), out Int32 h)) { return false; }

            result = new Rectangle(x, y, w, h);

            return true;
        }
    }

    public class DisplayStateleParser : ICustomParser<FormWindowState>
    {
        public FormWindowState Parse(String label, String value, Object fallback, CultureInfo culture)
        {
            if (!Enum.TryParse(value, true, out FormWindowState result))
            {
                if (!Enum.TryParse(fallback?.ToString(), true, out result))
                {
                    return FormWindowState.Normal;
                }
            }

            return result;
        }

        public String Parse(String label, FormWindowState value, Object fallback, CultureInfo culture)
        {
            return value.ToString();
        }
    }

    public class BinaryTypeParser : ICustomParser<BinaryType>
    {
        public BinaryType Parse(String label, String value, Object fallback, CultureInfo culture)
        {
            if (!Enum.TryParse(value, true, out BinaryType result))
            {
                if (!Enum.TryParse(fallback?.ToString(), true, out result))
                {
                    return BinaryType.BASE64;
                }
            }

            return result;
        }

        public String Parse(String label, BinaryType value, Object fallback, CultureInfo culture)
        {
            return value.ToString();
        }
    }

    public class BooleanParser : ICustomParser<Boolean>
    {
        public Boolean Parse(String label, String value, Object fallback, CultureInfo culture)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return this.GetFromValue(fallback);
            }

            return this.GetFromValue(value);
        }

        public String Parse(String label, Boolean value, Object fallback, CultureInfo culture)
        {
            return value.ToString().ToLower();
        }

        private Boolean GetFromValue(Object value)
        {
            if (value is Boolean)
            {
                return (Boolean)value;
            }

            if (value is Int32)
            {
                return (Int32)value != 0;
            }

            if (value is String)
            {
                return this.GetFromValue(value.ToString());
            }

            return false;
        }

        private Boolean GetFromValue(String value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            if (Int32.TryParse(value, out Int32 helper))
            {
                return helper != 0;
            }

            if (this.IsEqual(value, "true") || this.IsEqual(value, "yes"))
            {
                return true;
            }

            return false;
        }

        private Boolean IsEqual(String value, String other)
        {
            return String.Equals(value, other, StringComparison.InvariantCultureIgnoreCase);
        }
    }

    public class SeriesParser : ICustomParser<Int32>
    {
        public Int32 Parse(String label, String value, Object fallback, CultureInfo culture)
        {
            Int32.TryParse(value, out Int32 result);

            if (fallback is String format && !String.IsNullOrWhiteSpace(format))
            {
                Int32[] values = format
                    .TrimStart('[').TrimEnd(']').Split(',')
                    .Where(x => Int32.TryParse(x, out _))
                    .Select(x => Int32.Parse(x))
                    .ToArray();

                for (Int32 index = 0; index < values.Length; index++)
                {
                    if (result <= values[index])
                    {
                        result = values[index];
                        break;
                    }
                }
            }

            return result;
        }

        public String Parse(String label, Int32 value, Object fallback, CultureInfo culture)
        {
            return value.ToString();
        }
    }

    public class EncodingParser : ICustomParser<Encoding>
    {
        public Encoding Parse(String label, String value, Object fallback, CultureInfo culture)
        {
            if (fallback is String helper && !String.IsNullOrWhiteSpace(helper))
            {
                String[] pieces = helper.Split(';');

                if (pieces.Length > 1)
                {
                    String defaultEncoding = pieces[0].Trim();

                    String[] supportedEncodings = pieces[1]
                        .TrimStart('[').TrimEnd(']').Split(',')
                        .Select(x => x.Trim())
                        .Where(x => !String.IsNullOrEmpty(x))
                        .ToArray();

                    Encoding[] availableEncodings = Encoding.GetEncodings().Select(x => x.GetEncoding()).ToArray();

                    foreach (Encoding availableEncoding in availableEncodings)
                    {
                        if (String.Equals(value, availableEncoding.WebName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return availableEncoding;
                        }
                    }

                    foreach (Encoding availableEncoding in availableEncodings)
                    {
                        if (String.Equals(defaultEncoding, availableEncoding.WebName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return availableEncoding;
                        }
                    }
                }
            }

            return Encoding.UTF8;
        }

        public String Parse(String label, Encoding value, Object fallback, CultureInfo culture)
        {
            return value?.WebName ?? Encoding.UTF8.WebName;
        }
    }
}
