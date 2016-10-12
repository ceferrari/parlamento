using ParlamentoAplicacao.Interfaces.ServicosApp.Parlamentares;
using ParlamentoDominio.Entidades.Parlamentares;
using ParlamentoDominio.Interfaces.Servicos.Parlamentares;

namespace ParlamentoAplicacao.ServicosApp.Parlamentares
{
    public class ExerciciosServicosApp : BaseServicosApp<Exercicio>, IExerciciosServicosApp
    {
        private readonly IExerciciosServicos _servicos;

        public ExerciciosServicosApp(IExerciciosServicos servicos)
            : base (servicos)
        {
            _servicos = servicos;
        }
    }
}
