using ContactBook.Core.Auth.Modelos;
using ContactBookMobile.Services.Intarfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
namespace ContactBookMobile.Services
{
    public class Token : IToken
    {
        public string GetToken()
        {
            return Preferences.Get("token", "");
        }

        public bool SaveToken(string authenticationModel)
        {
            Preferences.Set("token", authenticationModel);
            return true;
        }
    }
}
