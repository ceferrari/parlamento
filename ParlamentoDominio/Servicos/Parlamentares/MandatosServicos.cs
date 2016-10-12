using ParlamentoDominio.Entidades.Parlamentares;
using ParlamentoDominio.Interfaces.Repositorios.Parlamentares;
using ParlamentoDominio.Interfaces.Servicos.Parlamentares;

namespace ParlamentoDominio.Servicos.Parlamentares
{
    public class MandatosServicos : BaseServicos<Mandato>, IMandatosServicos
    {
        private readonly IMandatosRepositorio _repositorio;

        public MandatosServicos(IMandatosRepositorio repositorio)
            : base (repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
