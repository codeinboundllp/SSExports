using SSExports.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SSExports.Interfaces
{
    public interface IExcelExport
    {
        Task<GenericExportResponse<byte[]>> ExportDataToExcel(DataTable table);
        Task<GenericExportResponse<string>> ExportDataToExcelBase64(DataTable table);

    }
}
