using ContactBook.Core.Auth.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookMobile.Services.Intarfaces
{
    public interface IToken
    {
        string GetToken();
        bool SaveToken(string authenticationModel);
    }
}
