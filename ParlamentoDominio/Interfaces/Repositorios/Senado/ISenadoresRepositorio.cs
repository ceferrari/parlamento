using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ParlamentoDominio.Entidades.Senado;

namespace ParlamentoDominio.Interfaces.Repositorios.Senado
{
    public interface ISenadoresRepositorio : IBaseRepositorio<Senador>
    {
        IEnumerable<string> ListarPartidos();
        IEnumerable<string> ListarEstados();
        IEnumerable<string> ListarSexos();
    }
}