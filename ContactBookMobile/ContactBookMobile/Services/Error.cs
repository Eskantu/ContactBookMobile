using ContactBookMobile.Services.Intarfaces;
using ContactBookMobile.Services.Modelos;

using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookMobile.Services
{
    public class Error : IError
    {
        public event EventHandler<RequestException> OnError;
        event EventHandler<RequestException> IError.SendError
        {
            add
            {
                if (OnError is null)
                {
                    OnError += value;
                }
            }

            remove
            {
                OnError -= value;
            }
        }

        void IError.OnError(RequestException exception)
        {
            OnError?.Invoke(this, exception);
        }
    }

}
