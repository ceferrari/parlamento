using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Servicos.Senado;

namespace ParlamentoAplicacao.ServicosApp.Senado
{
    public class MateriasSubtiposServicosApp : BaseServicosApp<MateriaSubtipo>, IMateriasSubtiposServicosApp
    {
        private readonly IMateriasSubtiposServicos _servicos;

        public MateriasSubtiposServicosApp(IMateriasSubtiposServicos servicos)
            : base (servicos)
        {
            _servicos = servicos;
        }
    }
}