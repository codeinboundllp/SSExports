using SSExports.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSExports.Interfaces
{
    public interface IPDFExport
    {
        Task<GenericExportResponse<byte[]>> HtmlToPDFAsync(string htmlContent, PDFOptions options = null);
        Task<GenericExportResponse<string>> HtmlToPDFBase64Async(string htmlContent, PDFOptions options = null);
        Task<GenericExportResponse<byte[]>> HtmlToPDFAsync(Uri uri, PDFOptions options = null);
    }
}
