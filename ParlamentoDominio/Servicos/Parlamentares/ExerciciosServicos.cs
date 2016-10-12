using ParlamentoDominio.Entidades.Parlamentares;
using ParlamentoDominio.Interfaces.Repositorios.Parlamentares;
using ParlamentoDominio.Interfaces.Servicos.Parlamentares;

namespace ParlamentoDominio.Servicos.Parlamentares
{
    public class ExerciciosServicos : BaseServicos<Exercicio>, IExerciciosServicos
    {
        private readonly IExerciciosRepositorio _repositorio;

        public ExerciciosServicos(IExerciciosRepositorio repositorio)
            : base (repositorio)
        {
            _repositorio = repositorio;
        }
    }
}
