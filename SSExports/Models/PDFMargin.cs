using System;
using System.Collections.Generic;
using System.Text;

namespace SSExports.Models
{
    public class PDFMargin
    {
        public float MarginTop { get; set; }
        public float MarginBottom { get; set; }
        public float MarginLeft { get; set; }
        public float MarginRight { get; set; }
        public PDFMargin(float margin)
        {
            MarginTop = margin;
            MarginBottom = margin;
            MarginLeft = margin;
            MarginRight = margin;
        }
    }
}
