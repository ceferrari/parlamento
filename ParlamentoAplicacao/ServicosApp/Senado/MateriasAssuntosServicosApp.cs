using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoDominio.Interfaces.Servicos.Senado;

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
    }
}