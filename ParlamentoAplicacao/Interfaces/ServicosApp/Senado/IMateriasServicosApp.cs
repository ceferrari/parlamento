﻿using System.Linq;
using ParlamentoDominio.Entidades.Senado;

namespace ParlamentoAplicacao.Interfaces.ServicosApp.Senado
{
    public interface IMateriasServicosApp : IBaseServicosApp<Materia>
    {
        IQueryable<int> ListarAnos();
    }
}