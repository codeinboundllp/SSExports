using HiQPdf;
using SSExports.Interfaces;
using SSExports.Models;
using System;
using System.Threading.Tasks;

namespace SSExports.Implementation
{
    public class HiQPDF : IPDFExport
    {
        private HtmlToPdf htmlToPdfConverter = new HtmlToPdf();
        private IHiPDFConfig _config;
        public HiQPDF(IHiPDFConfig config)
        {
            _config = config;
        }

        public Task<GenericExportResponse<byte[]>> HtmlToPDFAsync(string htmlContent, PDFOptions options = null)
        {
            try
            {
                //setting the pdf options
                SetPDFOptions(options);
                var bytes = htmlToPdfConverter.ConvertHtmlToMemory(htmlContent, null);
                return Task.FromResult(
                    new GenericExportResponse<byte[]>
                    {
                        Data = bytes,
                        Status = System.Net.HttpStatusCode.OK
                    });
            }
            catch (Exception ex)
            {
                //TODO : Add Logging
                return Task.FromResult(new GenericExportResponse<byte[]>
                {
                    Data = null,
                    Message = ex.Message,
                    Status = System.Net.HttpStatusCode.InternalServerError
                });
            }
        }

        public Task<GenericExportResponse<byte[]>> HtmlToPDFAsync(Uri uri, PDFOptions options = null)
        {
            throw new NotImplementedException();
        }

        public Task<GenericExportResponse<string>> HtmlToPDFBase64Async(string htmlContent, PDFOptions options = null)
        {
            try
            {
                SetPDFOptions(options);
                var base64 = Convert.ToBase64String(htmlToPdfConverter.ConvertHtmlToMemory(htmlContent, null));
                return Task.FromResult(new GenericExportResponse<string>
                {
                    Data = base64,
                    Status = System.Net.HttpStatusCode.OK
                });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new GenericExportResponse<string>
                {
                    Data = null,
                    Message = ex.Message,
                    Status = System.Net.HttpStatusCode.InternalServerError
                });
            }
        }

        #region Internal Functions
        private void SetPDFOptions(PDFOptions options)
        {
            try
            {
                htmlToPdfConverter = new HtmlToPdf();
                htmlToPdfConverter.SerialNumber = _config.SerialNumber;

                if (options != null)
                {
                    htmlToPdfConverter.BrowserHeight = options.Height;
                    htmlToPdfConverter.BrowserWidth = options.Width;
                    htmlToPdfConverter.BrowserZoom = options.Zoom;
                    htmlToPdfConverter.Document.PageSize = options.PageSize;
                    htmlToPdfConverter.Document.PageOrientation = options.Orientation;
                    htmlToPdfConverter.Document.PdfStandard = PdfStandard.Pdf;
                    htmlToPdfConverter.Document.Margins = new PdfMargins(options.Margin.MarginLeft, options.Margin.MarginRight, options.Margin.MarginTop, options.Margin.MarginBottom);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
