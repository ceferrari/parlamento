using Newtonsoft.Json;
using ParlamentoTransversal;
using System.Collections.Generic;

namespace ParlamentoTarefas.ViewModels.Senado
{
    public class MateriaViewModel
    {
        public MateriaViewModelDetalheMateria DetalheMateria { get; set; }
    }

    public class MateriaViewModelDetalheMateria
    {
        public MateriaViewModelMetadados Metadados { get; set; }
        public MateriaViewModelMateria Materia { get; set; }
    }

    public class MateriaViewModelMetadados
    {
        public string Versao { get; set; }
        public string VersaoServico { get; set; }
        public string DescricaoDataSet { get; set; }
    }

    public class MateriaViewModelMateria
    {
        public MateriaViewModelIdentificacaoMateria IdentificacaoMateria { get; set; }
        public MateriaViewModelDadosBasicosMateria DadosBasicosMateria { get; set; }
        public MateriaViewModelAutoria Autoria { get; set; }
        public MateriaViewModelAssuntos Assunto { get; set; }
        public MateriaViewModelOrigemMateria OrigemMateria { get; set; }
        public MateriaViewModelCasaIniciadoraNoLegislativo CasaIniciadoraNoLegislativo { get; set; }
        public MateriaViewModelMateriasAnexadas MateriasAnexadas { get; set; }
        public MateriaViewModelMateriasRelacionadas MateriasRelacionadas { get; set; }
        public MateriaViewModelSituacaoAtual SituacaoAtual { get; set; }
        public MateriaViewModelOutrasInformacoes OutrasInformacoes { get; set; }
        public string UrlGlossario { get; set; }
    }

    public class MateriaViewModelIdentificacaoMateria
    {
        public string CodigoMateria { get; set; }
        public string SiglaCasaIdentificacaoMateria { get; set; }
        public string NomeCasaIdentificacaoMateria { get; set; }
        public string SiglaSubtipoMateria { get; set; }
        public string DescricaoSubtipoMateria { get; set; }
        public string NumeroMateria { get; set; }
        public string AnoMateria { get; set; }
        public string IndicadorTramitando { get; set; }
    }

    public class MateriaViewModelDadosBasicosMateria
    {
        public string EmentaMateria { get; set; }
        public string ExplicacaoEmentaMateria { get; set; }
        public string ObservacaoMateria { get; set; }
        public string IndexacaoMateria { get; set; }
        public string IndicadorComplementar { get; set; }
        public string DataApresentacao { get; set; }
        public string DataLeitura { get; set; }
        public string SiglaCasaLeitura { get; set; }
        public string NomeCasaLeitura { get; set; }
    }

    public class MateriaViewModelAutoria
    {
        public MateriaViewModelAutor Autor { get; set; }
    }

    public class MateriaViewModelAutor
    {
        public string CodigoAutor { get; set; }
        public string NomeAutor { get; set; }
        public string SiglaTipoAutor { get; set; }
        public string UfAutor { get; set; }
        public string IndicadorAutorPrincipal { get; set; }
        public string IndicadorOutrosAutores { get; set; }
        public MateriaViewModelIdentificacaoParlamentar IdentificacaoParlamentar { get; set; }
    }

    public class MateriaViewModelIdentificacaoParlamentar
    {
        public string CodigoParlamentar { get; set; }
        public string NomeParlamentar { get; set; }
        public string NomeCompletoParlamentar { get; set; }
        public string SexoParlamentar { get; set; }
        public string FormaTratamento { get; set; }
        public string UrlFotoParlamentar { get; set; }
        public string UrlPaginaParlamentar { get; set; }
        public string EmailParlamentar { get; set; }
        public string SiglaPartidoParlamentar { get; set; }
        public string UfParlamentar { get; set; }
    }

    public class MateriaViewModelAssuntos
    {
        public MateriaViewModelAssuntoEspecifico AssuntoEspecifico { get; set; }
        public MateriaViewModelAssuntoGeral AssuntoGeral { get; set; }
    }

    public class MateriaViewModelAssuntoEspecifico
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }

    public class MateriaViewModelAssuntoGeral
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }

    public class MateriaViewModelOrigemMateria
    {
        public string NomePoderOrigem { get; set; }
        public string SiglaCasaOrigem { get; set; }
        public string NomeCasaOrigem { get; set; }
    }

    public class MateriaViewModelCasaIniciadoraNoLegislativo
    {
        public string SiglaCasaIniciadora { get; set; }
        public string NomeCasaIniciadora { get; set; }
    }

    public class MateriaViewModelMateriasAnexadas
    {
        [JsonConverter(typeof(SingleOrArrayConverter<MateriaViewModelMateriaAnexada>))]
        public IList<MateriaViewModelMateriaAnexada> MateriaAnexada { get; set; }
    }

    public class MateriaViewModelMateriaAnexada
    {
        public MateriaViewModelIdentificacaoMateria IdentificacaoMateria { get; set; }
        public string DataAnexacao { get; set; }
    }

    public class MateriaViewModelMateriasRelacionadas
    {
        [JsonConverter(typeof(SingleOrArrayConverter<MateriaViewModelMateriaRelacionada>))]
        public IList<MateriaViewModelMateriaRelacionada> MateriaRelacionada { get; set; }
    }

    public class MateriaViewModelMateriaRelacionada
    {
        public MateriaViewModelIdentificacaoMateria IdentificacaoMateria { get; set; }
    }

    public class MateriaViewModelSituacaoAtual
    {
        public MateriaViewModelAutuacoes Autuacoes { get; set; }
    }

    public class MateriaViewModelAutuacoes
    {
        [JsonConverter(typeof(SingleOrArrayConverter<MateriaViewModelAutuacao>))]
        public IList<MateriaViewModelAutuacao> Autuacao { get; set; }
    }

    public class MateriaViewModelAutuacao
    {
        public string NumeroAutuacao { get; set; }
        public MateriaViewModelSituacao Situacao { get; set; }
        public MateriaViewModelLocal Local { get; set; }
    }

    public class MateriaViewModelSituacao
    {
        public string DataSituacao { get; set; }
        public string CodigoSituacao { get; set; }
        public string SiglaSituacao { get; set; }
        public string DescricaoSituacao { get; set; }
    }

    public class MateriaViewModelLocal
    {
        public string CodigoLocal { get; set; }
        public string TipoLocal { get; set; }
        public string SiglaCasaLocal { get; set; }
        public string NomeCasaLocal { get; set; }
        public string SiglaLocal { get; set; }
        public string NomeLocal { get; set; }
    }

    public class MateriaViewModelOutrasInformacoes
    {
        [JsonConverter(typeof(SingleOrArrayConverter<MateriaViewModelServico>))]
        public IList<MateriaViewModelServico> Servico { get; set; }
    }

    public class MateriaViewModelServico
    {
        public string NomeServico { get; set; }
        public string DescricaoServico { get; set; }
        public string UrlServico { get; set; }
    }
}