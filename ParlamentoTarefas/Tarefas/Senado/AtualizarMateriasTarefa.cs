using System;
using AutoMapper;
using Hangfire;
using Ninject;
using ParlamentoAplicacao.Interfaces.ServicosApp.Senado;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoRecursos.Interfaces.ServicosExternos;
using ParlamentoTarefas.Interfaces.Tarefas.Senado;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ParlamentoTarefas.Tarefas.Senado
{
    public class AtualizarMateriasTarefa : NinjectJobActivator, IAtualizarMateriasTarefa
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

            var listaCodigosMateriasAssuntos = listaMateriasAssuntosEntidades.Select(x => x.Codigo);
            var listaCodigosMateriasSubtipos = listaMateriasSubtiposEntidades.Select(x => x.Codigo);

            listaMateriasEntidades.RemoveAll(x => x == null);
            listaMateriasEntidades.RemoveAll(x => x.CodigoAssunto == 0 || x.CodigoSubtipo == null);
            listaMateriasEntidades.RemoveAll(x => !listaCodigosMateriasAssuntos.Contains(x.CodigoAssunto) || !listaCodigosMateriasSubtipos.Contains(x.CodigoSubtipo));

            _materiasSvc.MesclarEmMassa(listaMateriasEntidades);
        }
    }
}