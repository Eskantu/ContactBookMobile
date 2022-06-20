using ContactBook.Core.COMMON.Interfaces;
using ContactBook.Core.COMMON.Models;
using ContactBookMobile.Services.Intarfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookMobile.Services.Managers
{
    public class GenericManager<T> : IGenericManager<T> where T:class
    {
        protected readonly IRequest<T> _request;
        public GenericManager(IRequest<T> request)
        {
            _request = request;
        }
        public string Errror => _request.Error;

        public bool Actualizar(T entidad)
        {
            throw new NotImplementedException();
        }

        public bool Crear(T entidad)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public T ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }

        public  List<T> ObtenerTodos()
        {
           return  _request.Get();
        }

        public List<Y> Query<Y>(SpParametros parametros)
        {
            throw new NotImplementedException();
        }
    }
}
