using ContactBook.Core.Auth.Modelos;
using ContactBookMobile.Services.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookMobile.Services.Intarfaces
{
    public interface IRequest<T> where T:class

    {
        List<T> Get();
        Task<T> GetById(int id);
        Task<bool> Post(string entidad);
        Task<bool> Put(string entidad);
        Task<bool> Delete(int id);
        string Error { get;}
        Task<string> Login(LoginRequest request);

    }
}
