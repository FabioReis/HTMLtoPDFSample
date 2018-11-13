using DinkToPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestPdf.Utils
{
    public static class PdfUtils
    {
        public static HtmlToPdfDocument GetPage()
        {
            var doc = new HtmlToPdfDocument
            {
                GlobalSettings =
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings(0,0,0,0)
                }
            };
            return doc;
        }
    }
}
