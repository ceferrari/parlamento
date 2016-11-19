using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Servicos.Senado;
using System.Linq;

namespace ParlamentoAplicacao.ServicosApp.Senado
{
    public class MateriasAssuntosServicosApp : BaseServicosApp<MateriaAssunto>, IMateriasAssuntosServicosApp
    {
        private readonly IMateriasAssuntosServicos _servicos;

        public MateriasAssuntosServicosApp(IMateriasAssuntosServicos servicos)
            : base (servicos)
        {
            _servicos = servicos;
        }

        public IQueryable<string> ListarGerais()
        {
            return _servicos.ListarGerais();
        }

        public IQueryable<string> ListarEspecificos()
        {
            return _servicos.ListarEspecificos();
        }
    }
}