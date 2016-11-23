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
            // Assuntos de Matérias
            var materiasAssuntos = _senado.ListarMateriasAssuntos();
            while (materiasAssuntos.CodigoStatus != HttpStatusCode.OK)
            {
                materiasAssuntos = _senado.ListarMateriasAssuntos();
            }
            var materiasAssuntosEntidades = Mapper.Map<List<MateriaAssunto>>(materiasAssuntos.Conteudo.ListaAssuntos.Assuntos.Assunto);
            materiasAssuntosEntidades.Add(new MateriaAssunto
            {
                Codigo = 0,
                AssuntoGeral = "- Sem Assunto",
                AssuntoEspecifico = "- Sem Assunto"
            });
            _materiasAssuntosSvc.MesclarEmMassa(materiasAssuntosEntidades);

            // Subtipos de Matérias
            var materiasSubtipos = _senado.ListarMateriasSubtipos();
            while (materiasSubtipos.CodigoStatus != HttpStatusCode.OK)
            {
                materiasSubtipos = _senado.ListarMateriasSubtipos();
            }
            var materiasSubtiposEntidades = Mapper.Map<List<MateriaSubtipo>>(materiasSubtipos.Conteudo.ListaSubtiposMateria.SubtiposMateria.SubtipoMateria);
            materiasSubtiposEntidades.Add(new MateriaSubtipo
            {
                Codigo = "0",
                Descricao = "- Sem Subtipo"
            });
            _materiasSubtiposSvc.MesclarEmMassa(materiasSubtiposEntidades);

            // Matérias
            var materias = _senado.ListarMaterias().Conteudo;
            var codigosMaterias = materias.ListaMateriasLegislaturaAtual.Materias.Materia.Select(x => x.IdentificacaoMateria.CodigoMateria);

            var materiasEntidades = new List<Materia>();
            foreach (var codigoMateria in codigosMaterias)
            {
                var materia = _senado.ObterMateriaPorCodigo(codigoMateria);
                while (materia.CodigoStatus != HttpStatusCode.OK)
                {
                    materia = _senado.ObterMateriaPorCodigo(codigoMateria);
                }
                var materiaEntidade = Mapper.Map<Materia>(materia.Conteudo);
                materiasEntidades.Add(materiaEntidade);
            }
            
            var codigosMateriasAssuntos = materiasAssuntosEntidades.Select(x => x.Codigo);
            var codigosMateriasSubtipos = materiasSubtiposEntidades.Select(x => x.Codigo);

            materiasEntidades.ForEach(x => x.CodigoSubtipo = string.IsNullOrWhiteSpace(x.CodigoSubtipo) ? "0" : x.CodigoSubtipo = x.CodigoSubtipo);
            materiasEntidades.RemoveAll(x => x == null || !codigosMateriasAssuntos.Contains(x.CodigoAssunto) || !codigosMateriasSubtipos.Contains(x.CodigoSubtipo));
            _materiasSvc.MesclarEmMassa(materiasEntidades);

            //var listaCodigosMateriasAssuntos = listaMateriasAssuntosEntidades.Select(x => x.Codigo);
            //var listaCodigosMateriasSubtipos = listaMateriasSubtiposEntidades.Select(x => x.Codigo);

            //listaMateriasEntidades.RemoveAll(x => x == null);
            //listaMateriasEntidades.RemoveAll(x => x.CodigoAssunto == 0 || x.CodigoSubtipo == null);
            //listaMateriasEntidades.RemoveAll(x => !listaCodigosMateriasAssuntos.Contains(x.CodigoAssunto) || !listaCodigosMateriasSubtipos.Contains(x.CodigoSubtipo));
        }
    }
}