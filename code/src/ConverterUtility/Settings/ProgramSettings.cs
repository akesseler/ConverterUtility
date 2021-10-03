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

using Plexdata.CfgParser.Attributes;
using Plexdata.ConverterUtility.Defines;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Plexdata.ConverterUtility.Settings
{
    public class ProgramSettings
    {
        private WindowSettings windowSettings = null;
        private ZipSourcePanelSettings zipSourcePanel = null;
        private ZipResultPanelSettings zipResultPanel = null;
        private PdfSourcePanelSettings pdfSourcePanel = null;
        private PdfResultPanelSettings pdfResultPanel = null;
        private BinSourcePanelSettings binSourcePanel = null;
        private BinResultPanelSettings binResultPanel = null;

        public ProgramSettings()
            : base()
        {
            this.WindowSettings = null;
            this.ZipSourcePanel = null;
            this.ZipResultPanel = null;
            this.PdfSourcePanel = null;
            this.PdfResultPanel = null;
            this.BinSourcePanel = null;
            this.BinResultPanel = null;
        }

        [ConfigSection("main-window")]
        public WindowSettings WindowSettings
        {
            get
            {
                return this.windowSettings;
            }
            set
            {
                if (value == null)
                {
                    value = new WindowSettings();
                }

                this.windowSettings = value;
            }
        }

        [ConfigSection("zip-source-panel")]
        public ZipSourcePanelSettings ZipSourcePanel
        {
            get
            {
                return this.zipSourcePanel;
            }
            set
            {
                if (value == null)
                {
                    value = new ZipSourcePanelSettings();
                }

                this.zipSourcePanel = value;
            }
        }

        [ConfigSection("zip-result-panel")]
        public ZipResultPanelSettings ZipResultPanel
        {
            get
            {
                return this.zipResultPanel;
            }
            set
            {
                if (value == null)
                {
                    value = new ZipResultPanelSettings();
                }

                this.zipResultPanel = value;
            }
        }

        [ConfigSection("pdf-source-panel")]
        public PdfSourcePanelSettings PdfSourcePanel
        {
            get
            {
                return this.pdfSourcePanel;
            }
            set
            {
                if (value == null)
                {
                    value = new PdfSourcePanelSettings();
                }

                this.pdfSourcePanel = value;
            }
        }

        [ConfigSection("pdf-result-panel")]
        public PdfResultPanelSettings PdfResultPanel
        {
            get
            {
                return this.pdfResultPanel;
            }
            set
            {
                if (value == null)
                {
                    value = new PdfResultPanelSettings();
                }

                this.pdfResultPanel = value;
            }
        }

        [ConfigSection("bin-source-panel")]
        public BinSourcePanelSettings BinSourcePanel
        {
            get
            {
                return this.binSourcePanel;
            }
            set
            {
                if (value == null)
                {
                    value = new BinSourcePanelSettings();
                }

                this.binSourcePanel = value;
            }
        }

        [ConfigSection("bin-result-panel")]
        public BinResultPanelSettings BinResultPanel
        {
            get
            {
                return this.binResultPanel;
            }
            set
            {
                if (value == null)
                {
                    value = new BinResultPanelSettings();
                }

                this.binResultPanel = value;
            }
        }
    }

    public class WindowSettings
    {
        public WindowSettings()
            : base()
        {
            this.DesktopBounds = WindowSettings.DefaultDesktopBounds;
            this.DisplayState = FormWindowState.Normal;
            this.SelectedPage = 0;
        }

        [CustomParser(typeof(DesktopBoundsParser))]
        [ConfigValue("desktop-bounds", Default = "10,10,1000,800")]
        public Rectangle DesktopBounds { get; set; }

        [CustomParser(typeof(DisplayStateleParser))]
        [ConfigValue("display-state", Default = "Normal")]
        public FormWindowState DisplayState { get; set; }

        [ConfigValue("selected-page")]
        public Int32 SelectedPage { get; set; }

        private static Rectangle DefaultDesktopBounds
        {
            get
            {
                Rectangle workingArea = SystemInformation.WorkingArea;

                Int32 w = 1000;
                Int32 h = 800;
                Int32 x = (workingArea.Width - w) / 2;
                Int32 y = (workingArea.Height - h) / 2;

                return new Rectangle(x, y, w, h);
            }
        }
    }

    public class ZipSourcePanelSettings
    {
        public ZipSourcePanelSettings()
            : base()
        {
            this.WordWrap = true;
        }

        [CustomParser(typeof(BooleanParser))]
        [ConfigValue("word-wrap", Default = true)]
        public Boolean WordWrap { get; set; }
    }

    public class ZipResultPanelSettings
    {
        public ZipResultPanelSettings()
            : base()
        {
            this.WordWrap = true;
        }

        [CustomParser(typeof(BooleanParser))]
        [ConfigValue("word-wrap", Default = true)]
        public Boolean WordWrap { get; set; }
    }

    public class PdfSourcePanelSettings
    {
        public PdfSourcePanelSettings()
            : base()
        {
            this.WordWrap = true;
        }

        [CustomParser(typeof(BooleanParser))]
        [ConfigValue("word-wrap", Default = true)]
        public Boolean WordWrap { get; set; }
    }

    public class PdfResultPanelSettings
    {
        public PdfResultPanelSettings()
            : base()
        {
            this.OutputFolder = null;
        }

        [ConfigValue("output-folder")]
        public String OutputFolder { get; set; }
    }

    public class BinSourcePanelSettings
    {
        public BinSourcePanelSettings()
            : base()
        {
            this.WordWrap = true;
            this.BinaryType = BinaryType.BASE64;
            this.SelectedEncoding = Encoding.UTF8;
        }

        [CustomParser(typeof(BooleanParser))]
        [ConfigValue("word-wrap", Default = true)]
        public Boolean WordWrap { get; set; }

        [CustomParser(typeof(BinaryTypeParser))]
        [ConfigValue("binary-type", Default = "BASE64")]
        public BinaryType BinaryType { get; set; }

        [CustomParser(typeof(EncodingParser))]
        [ConfigValue("selected-encoding", Default = "us-ascii;[utf-7,utf-8,utf-32,us-ascii,Windows-1252,utf-16,utf-16BE]")]
        public Encoding SelectedEncoding { get; set; }
    }

    public class BinResultPanelSettings
    {
        public BinResultPanelSettings()
            : base()
        {
            this.BlockWidth = 2;
            this.BytesPerLine = 16;
            this.UpperCase = true;
        }

        [CustomParser(typeof(SeriesParser))]
        [ConfigValue("bytes-per-line", Default = "[8,16,32,64,128,256]")]
        public Int32 BytesPerLine { get; set; }

        [CustomParser(typeof(SeriesParser))]
        [ConfigValue("block-width", Default = "[2,4,8]")]
        public Int32 BlockWidth { get; set; }

        [CustomParser(typeof(BooleanParser))]
        [ConfigValue("upper-case", Default = true)]
        public Boolean UpperCase { get; set; }
    }
}
