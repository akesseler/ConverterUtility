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

namespace Plexdata.ConverterUtility.Helpers
{
    public static class StringExtractor
    {
        public static String Extract(String source)
        {
            return StringExtractor.Extract(source, '"');
        }

        public static String Extract(String source, Char divide)
        {
            if (String.IsNullOrWhiteSpace(source))
            {
                return String.Empty;
            }

            Int32 opened = 0;
            Int32 closed = 0;
            Int32 length = 0;

            opened = source.IndexOf(divide);

            if (opened < 0)
            {
                // Nothing found.
                return source;
            }

            closed = source.LastIndexOf(divide);

            if (opened == closed)
            {
                // Must be the same character.
                length = source.Length - opened;
            }
            else
            {
                length = closed - opened;
            }

            return source.Substring(opened + 1, length - 1);
        }

        public static Boolean TryFindSelection(String source, Int32 offset, out Int32 start, out Int32 count)
        {
            return StringExtractor.TryFindSelection(source, offset, '"', out start, out count);
        }

        public static Boolean TryFindSelection(String source, Int32 offset, Char divide, out Int32 start, out Int32 count)
        {
            start = -1;
            count = -1;

            if (String.IsNullOrEmpty(source))
            {
                return false;
            }

            if (offset < 0 || offset + 1 > source.Length)
            {
                return false;
            }

            Int32 index = offset;

            while (index >= 0)
            {
                index--;

                if (index >= 0 && source[index] == divide)
                {
                    start = index + 1;
                    break;
                }
            }

            if (index < 0)
            {
                return false;
            }

            index = offset;

            while (index < source.Length)
            {
                if (source[index] == divide)
                {
                    count = index - start;
                    break;
                }

                index++;
            }

            return start >= 0 && count > 0;
        }
    }
}
