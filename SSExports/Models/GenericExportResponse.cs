using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SSExports.Models
{
    public class GenericExportResponse<T>
    {
        public HttpStatusCode Status;
        public T Data;
        public string Message;
    }
}
