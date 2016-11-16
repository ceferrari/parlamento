using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Servicos.Senado;
using System.Collections.Generic;

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

        public IEnumerable<string> ListarPartidos()
        {
            return _servicos.ListarPartidos();
        }

        public IEnumerable<string> ListarEstados()
        {
            return _servicos.ListarEstados();
        }

        public IEnumerable<string> ListarSexos()
        {
            return _servicos.ListarSexos();
        }
    }
}