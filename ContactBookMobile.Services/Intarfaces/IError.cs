using ContactBookMobile.Services.Modelos;

using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookMobile.Services.Intarfaces
{
    public interface IError
    {
        event EventHandler<RequestException> SendError;
        void OnError(RequestException exception);
    }
}
