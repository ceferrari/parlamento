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
    class AtualizarMateriasTarefa : NinjectJobActivator, IAtualizarMateriasTarefa
    {
        private readonly ISenadoServicosExternos _senado;
        private readonly IMateriasServicosApp _materiasSvc;
        private readonly IMateriasAssuntosServicosApp _materiasAssuntosSvc;
        private readonly IMateriasSubtiposServicosApp _materiasSubtiposSvc;

        public AtualizarMateriasTarefa(ISenadoServicosExternos senado, IMateriasServicosApp materiasSvc, IMateriasAssuntosServicosApp materiasAssuntosSvc, IMateriasSubtiposServicosApp materiasSubtiposSvc)
            : base(new StandardKernel())
        {
            _senado = senado;
            _materiasSvc = materiasSvc;
            _materiasAssuntosSvc = materiasAssuntosSvc;
            _materiasSubtiposSvc = materiasSubtiposSvc;
        }

        public void Executar()
        {
            var listaMateriasAssuntosViewModel = _senado.ListarMateriasAssuntos().Conteudo.ListaAssuntos.Assuntos.Assunto;
            var listaMateriasSubtiposViewModel = _senado.ListarMateriasSubtipos().Conteudo.ListaSubtiposMateria.SubtiposMateria.SubtipoMateria;

            var listaMateriasAssuntosEntidades = Mapper.Map<List<MateriaAssunto>>(listaMateriasAssuntosViewModel);
            var listaMateriasSubtiposEntidades = Mapper.Map<List<MateriaSubtipo>>(listaMateriasSubtiposViewModel);

            _materiasAssuntosSvc.MesclarEmMassa(listaMateriasAssuntosEntidades);
            _materiasSubtiposSvc.MesclarEmMassa(listaMateriasSubtiposEntidades);

            var listaMateriasViewModels = _senado.ListarMaterias().Conteudo;
            var listaCodigosMaterias = listaMateriasViewModels.ListaMateriasLegislaturaAtual.Materias.Materia
                .Select(x => x.IdentificacaoMateria.CodigoMateria);

            var listaMateriasEntidades = new List<Materia>();

            foreach (var codigoMateria in listaCodigosMaterias)
            {
                var materiaViewModel = _senado.ObterMateriaPorCodigo(codigoMateria).Conteudo;
                var materiaEntidade = Mapper.Map<Materia>(materiaViewModel);

                listaMateriasEntidades.Add(materiaEntidade);
            }

            _materiasSvc.MesclarEmMassa(listaMateriasEntidades);
        }
    }
}