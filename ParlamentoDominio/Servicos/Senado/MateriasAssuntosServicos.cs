using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Repositorios.Senado;
using ParlamentoDominio.Interfaces.Servicos.Senado;

namespace ParlamentoDominio.Servicos.Senado
{
    public class MateriasAssuntosServicos : BaseServicos<MateriaAssunto>, IMateriasAssuntosServicos
    {
        private readonly IMateriasAssuntosRepositorio _repositorio;

        public MateriasAssuntosServicos(IMateriasAssuntosRepositorio repositorio)
            : base (repositorio)
        {
            _repositorio = repositorio;
        }
    }
}