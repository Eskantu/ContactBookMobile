using ContactBook.Core.Auth.Modelos;
using ContactBook.Core.COMMON.Interfaces;
using ContactBook.Core.COMMON.Models;
using ContactBookMobile.Services.Intarfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookMobile.Services.Managers
{
    public class UsuarioManager : GenericManager<Usuario>, IUsuarioManager
    {
        private readonly IToken _token;
        public UsuarioManager(IRequest<Usuario> request, IToken token) : base(request)
        {
            _token = token;
        }

        public Usuario Login(LoginRequest loginRequest)
        {
            string content = _request.Login(loginRequest).Result;
            if (string.IsNullOrEmpty(content))
            {
                return null;
            }
            else
            {
                AuthenticationModel authentication = JsonConvert.DeserializeObject<AuthenticationModel>(content);
                _token.SaveToken(content);
                return new Usuario()
                {
                    ApellidoMaterno = authentication.ApellidoMaterno,
                    ApellidoPaterno = authentication.ApellidoPaterno,
                    Contrasenia = "",
                    CreadoPor = 0,
                    Email = authentication.Email,
                    Nombre = authentication.Nombre,
                    UserName = authentication.UserName,
                    IdUsuario = authentication.IdUsuario

                };
            }
        }
    }
}
