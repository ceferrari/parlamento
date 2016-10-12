using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Ninject;
using ParlamentoTarefas.Interfaces.ServicosExternos;
using ParlamentoTarefas.Interfaces.Tarefas;
using ParlamentoTarefas.Interfaces.Tarefas.Parlamentares;

namespace ParlamentoTarefas.Tarefas.Parlamentares
{
    public class AtualizarSenadoresTarefa : NinjectJobActivator, IAtualizarSenadoresTarefa
    {
        private readonly ISenadoServicosExternos _senado;

        public AtualizarSenadoresTarefa(ISenadoServicosExternos senado)
            : base(new StandardKernel())
        {
            _senado = senado;
        }

        public void Executar()
        {
            var senadores = _senado.ListarSenadores();

            var teste = senadores;
        }
    }
}