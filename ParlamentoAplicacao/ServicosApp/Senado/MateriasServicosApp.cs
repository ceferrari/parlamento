using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Servicos.Senado;
using System.Linq;

namespace ParlamentoAplicacao.ServicosApp.Senado
{
    public class MateriasServicosApp : BaseServicosApp<Materia>, IMateriasServicosApp
    {
        private readonly IMateriasServicos _servicos;

        public MateriasServicosApp(IMateriasServicos servicos)
            : base (servicos)
        {
            _servicos = servicos;
        }

        public IQueryable<int> ListarAnos()
        {
            return _servicos.ListarAnos();
        }
    }
}