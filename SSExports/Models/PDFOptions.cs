using HiQPdf;
using System;
using System.Collections.Generic;
using System.Text;
using static SSExports.Enums.Enumerations;

namespace SSExports.Models
{
    public class PDFOptions
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int Zoom = 100;
        public PdfPageOrientation Orientation = PdfPageOrientation.Portrait;

        public PdfPageSize PageSize = PdfPageSize.A4;
        public PDFMargin Margin { get; set; }

    }
}
