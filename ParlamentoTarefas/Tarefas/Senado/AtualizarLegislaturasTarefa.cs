using AutoMapper;
using Hangfire;
using Ninject;
using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoRecursos.Interfaces.ServicosExternos;
using ParlamentoTarefas.Interfaces.Tarefas.Senado;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ParlamentoTarefas.Tarefas.Senado
{
    public class AtualizarLegislaturasTarefa : NinjectJobActivator, IAtualizarLegislaturasTarefa
    {
        private readonly ISenadoServicosExternos _senado;
        private readonly ILegislaturasServicosApp _legislaturas;

        public AtualizarLegislaturasTarefa(ISenadoServicosExternos senado, ILegislaturasServicosApp legislaturas)
            : base(new StandardKernel())
        {
            _senado = senado;
            _legislaturas = legislaturas;
        }

        public void Executar()
        {
            var legislaturas = _senado.ListarLegislaturas();
            while (legislaturas.CodigoStatus != HttpStatusCode.OK)
            {
                legislaturas = _senado.ListarLegislaturas();
            }
            var legislaturasEntidades = Mapper.Map<List<Legislatura>>(legislaturas.Conteudo.ListaLegislatura.Legislatura.Legislatura);
            var legislaturaAtual = legislaturasEntidades.OrderByDescending(x => x.Codigo).First();
            legislaturasEntidades.Add(new Legislatura
            {
                Codigo = legislaturaAtual.Codigo + 1,
                DataInicio = legislaturaAtual.DataInicio.AddYears(4),
                DataFim = legislaturaAtual.DataFim.AddYears(4)
            });
            _legislaturas.MesclarEmMassa(legislaturasEntidades);
        }
    }
}