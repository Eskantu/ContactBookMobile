using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ContactBookMobile.Services.Modelos
{
   public class RequestException:Exception
    {
        public HttpStatusCode ErrorCode { get; set; }
        public string Mensaje { get; set; }
    }
}
