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
        public FactoryManager(IToken token)
        {
            _token = token;
        }
        public IUsuarioManager GetUsuarioManager() => new UsuarioManager(RequestFactory<Usuario>.GetRequest(_token, "Usuario"), _token);
    }

    public static class RequestFactory<T> where T : class
    {
        public static IRequest<T> GetRequest(IToken token, string endPoint)
        {
            AuthenticationModel authentication = string.IsNullOrEmpty(token.GetToken()) ? new AuthenticationModel() : JsonConvert.DeserializeObject<AuthenticationModel>(token.GetToken());
            return new Request<T>(authentication.Token, endPoint);
        }
    }
}
