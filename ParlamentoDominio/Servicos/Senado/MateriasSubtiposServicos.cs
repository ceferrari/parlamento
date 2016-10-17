using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Repositorios.Senado;
using ParlamentoDominio.Interfaces.Servicos.Senado;

namespace ParlamentoDominio.Servicos.Senado
{
    public class MateriasSubtiposServicos : BaseServicos<MateriaSubtipo>, IMateriasSubtiposServicos
    {
        private readonly IMateriasSubtiposRepositorio _repositorio;

        public MateriasSubtiposServicos(IMateriasSubtiposRepositorio repositorio)
            : base (repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
