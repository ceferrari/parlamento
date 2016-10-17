using System;
using Hangfire;
using Ninject;
using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoTarefas.Interfaces.ServicosExternos;
using ParlamentoTarefas.Interfaces.Tarefas.Senado;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace ParlamentoTarefas.Tarefas.Senado
{
    class AtualizarLegislaturasTarefa : NinjectJobActivator, IAtualizarLegislaturasTarefa
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
            var listaLegislaturasViewModels = _senado.ListarLegislaturas().Conteudo.ListaLegislatura.Legislatura.Legislatura;
            var listaLegislaturasEntidades = Mapper.Map<List<Legislatura>>(listaLegislaturasViewModels);
            var legislaturaAtual = listaLegislaturasEntidades.OrderByDescending(x => x.Codigo).First();
            listaLegislaturasEntidades.Add(new Legislatura()
            {
                Codigo = legislaturaAtual.Codigo + 1,
                DataInicio = legislaturaAtual.DataInicio.AddYears(4),
                DataFim = legislaturaAtual.DataFim.AddYears(4)
            });

            _legislaturas.MesclarEmMassa(listaLegislaturasEntidades);
        }
    }
}