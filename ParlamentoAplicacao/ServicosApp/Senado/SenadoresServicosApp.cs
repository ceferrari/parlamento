using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Servicos.Senado;
using System.Linq;

namespace ParlamentoAplicacao.ServicosApp.Senado
{
    public class SenadoresServicosApp : BaseServicosApp<Senador>, ISenadoresServicosApp
    {
        private readonly ISenadoresServicos _servicos;

        public SenadoresServicosApp(ISenadoresServicos servicos)
            : base (servicos)
        {
            _servicos = servicos;
        }

        public IQueryable<string> ListarPartidos()
        {
            return _servicos.ListarPartidos();
        }

        public IQueryable<string> ListarEstados()
        {
            return _servicos.ListarEstados();
        }

        public IQueryable<string> ListarSexos()
        {
            return _servicos.ListarSexos();
        }
    }
}