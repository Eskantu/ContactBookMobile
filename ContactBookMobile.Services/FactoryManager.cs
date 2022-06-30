using ContactBook.Core.Auth.Modelos;
using ContactBook.Core.COMMON.Interfaces;
using ContactBook.Core.COMMON.Models;

using ContactBookMobile.Services.Intarfaces;
using ContactBookMobile.Services.Managers;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookMobile.Services
{
    public class FactoryManager
    {
        private IToken _token;
        private readonly IError error;

        public FactoryManager(IToken token, IError error)
        {
            _token = token;
            this.error = error;
        }
        public IUsuarioManager GetUsuarioManager() => new UsuarioManager(RequestFactory<Usuario>.GetRequest(_token, "Usuario", error),_token);
    }

    public static class RequestFactory<T> where T : class
    {
        public static IRequest<T> GetRequest(IToken token, string endPoint, IError error)
        {
            AuthenticationModel authentication = string.IsNullOrEmpty(token.GetToken()) ? new AuthenticationModel() : JsonConvert.DeserializeObject<AuthenticationModel>(token.GetToken());
            return new Request<T>(authentication.Token, endPoint, error);
        }
    }
}
