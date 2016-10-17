using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Repositorios.Senado;
using ParlamentoDominio.Interfaces.Servicos.Senado;

namespace ParlamentoDominio.Servicos.Senado
{
    public class MateriasServicos : BaseServicos<Materia>, IMateriasServicos
    {
        private readonly IMateriasRepositorio _repositorio;

        public MateriasServicos(IMateriasRepositorio repositorio)
            : base (repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
