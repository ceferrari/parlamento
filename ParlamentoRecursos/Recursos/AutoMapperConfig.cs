using System.Linq;
using AutoMapper;
using ParlamentoDominio.Entidades.Senado;
using ParlamentoRecursos.ViewModels.Senado;

namespace ParlamentoRecursos.Recursos
{
    public class BasePerfilMapeamento : Profile
    {
        public override string ProfileName => "Base";

        public BasePerfilMapeamento()
        {
            CreateMap<ListaLegislaturasViewModelLegislatura, Legislatura>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.NumeroLegislatura))
                .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.DataInicio))
                .ForMember(dest => dest.DataFim, opt => opt.MapFrom(src => src.DataFim))
                .ForMember(dest => dest.DataEleicao, opt => opt.MapFrom(src => src.DataEleicao));

            CreateMap<ListaMateriasAssuntosViewModelAssunto, MateriaAssunto>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.AssuntoGeral, opt => opt.MapFrom(src => src.AssuntoGeral))
                .ForMember(dest => dest.AssuntoEspecifico, opt => opt.MapFrom(src => src.AssuntoEspecifico));

            CreateMap<ListaMateriasSubtiposViewModelSubtipoMateria, MateriaSubtipo>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.SiglaMateria))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.DescricaoSubtipoMateria))
                .ForMember(dest => dest.IndicadorProposicao, opt => opt.MapFrom(src => src.IndicadorProposicao));

            CreateMap<MateriaViewModel, Materia>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.DetalheMateria.Materia.IdentificacaoMateria.CodigoMateria))
                .ForMember(dest => dest.Ano, opt => opt.MapFrom(src => src.DetalheMateria.Materia.IdentificacaoMateria.AnoMateria))
                .ForMember(dest => dest.Ementa, opt => opt.MapFrom(src => src.DetalheMateria.Materia.DadosBasicosMateria.EmentaMateria))
                .ForMember(dest => dest.ExplicacaoEmenta, opt => opt.MapFrom(src => src.DetalheMateria.Materia.DadosBasicosMateria.ExplicacaoEmentaMateria))
                .ForMember(dest => dest.CodigoAutor, opt => opt.MapFrom(src => src.DetalheMateria.Materia.Autoria.Autor.FirstOrDefault().CodigoAutor))
                .ForMember(dest => dest.CodigoAssunto, opt => opt.MapFrom(src => src.DetalheMateria.Materia.Assunto.AssuntoEspecifico.Codigo))
                .ForMember(dest => dest.CodigoSubtipo, opt => opt.MapFrom(src => src.DetalheMateria.Materia.IdentificacaoMateria.SiglaSubtipoMateria));

            CreateMap<SenadorViewModel, Senador>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.DetalheParlamentar.Parlamentar.IdentificacaoParlamentar.CodigoParlamentar))
                .ForMember(dest => dest.FormaTratamento, opt => opt.MapFrom(src => src.DetalheParlamentar.Parlamentar.IdentificacaoParlamentar.FormaTratamento))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.DetalheParlamentar.Parlamentar.IdentificacaoParlamentar.NomeParlamentar))
                .ForMember(dest => dest.NomeCompleto, opt => opt.MapFrom(src => src.DetalheParlamentar.Parlamentar.IdentificacaoParlamentar.NomeCompletoParlamentar))
                .ForMember(dest => dest.SiglaPartido, opt => opt.MapFrom(src => src.DetalheParlamentar.Parlamentar.FiliacaoAtual.Partido.SiglaPartido))
                .ForMember(dest => dest.UfMandato, opt => opt.MapFrom(src => src.DetalheParlamentar.Parlamentar.MandatoAtual.UfParlamentar))
                .ForMember(dest => dest.CodigoPrimeiraLegislatura, opt => opt.MapFrom(src => src.DetalheParlamentar.Parlamentar.MandatoAtual.PrimeiraLegislaturaDoMandato.NumeroLegislatura))
                .ForMember(dest => dest.CodigoSegundaLegislatura, opt => opt.MapFrom(src => src.DetalheParlamentar.Parlamentar.MandatoAtual.SegundaLegislaturaDoMandato.NumeroLegislatura))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DetalheParlamentar.Parlamentar.DadosBasicosParlamentar.DataNascimento))
                .ForMember(dest => dest.UfNascimento, opt => opt.MapFrom(src => src.DetalheParlamentar.Parlamentar.DadosBasicosParlamentar.UfNaturalidade))
                .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.DetalheParlamentar.Parlamentar.IdentificacaoParlamentar.SexoParlamentar))
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.DetalheParlamentar.Parlamentar.DadosBasicosParlamentar.EnderecoParlamentar))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.DetalheParlamentar.Parlamentar.DadosBasicosParlamentar.TelefoneParlamentar))
                .ForMember(dest => dest.Fax, opt => opt.MapFrom(src => src.DetalheParlamentar.Parlamentar.DadosBasicosParlamentar.FaxParlamentar))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.DetalheParlamentar.Parlamentar.IdentificacaoParlamentar.EmailParlamentar))
                .ForMember(dest => dest.UrlFoto, opt => opt.MapFrom(src => src.DetalheParlamentar.Parlamentar.IdentificacaoParlamentar.UrlFotoParlamentar))
                .ForMember(dest => dest.UrlPagina, opt => opt.MapFrom(src => src.DetalheParlamentar.Parlamentar.IdentificacaoParlamentar.UrlPaginaParlamentar));

            CreateMap<VotacaoViewModelVotacao, Votacao>()
                .ForMember(dest => dest.CodigoSessao, opt => opt.MapFrom(src => src.SessaoPlenaria.CodigoSessao))
                .ForMember(dest => dest.CodigoMateria, opt => opt.MapFrom(src => src.IdentificacaoMateria.CodigoMateria))
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.SessaoPlenaria.DataSessao))
                .ForMember(dest => dest.HoraInicio, opt => opt.MapFrom(src => src.SessaoPlenaria.HoraInicioSessao))
                .ForMember(dest => dest.IndicadorVotacaoSecreta, opt => opt.MapFrom(src => src.IndicadorVotacaoSecreta))
                .ForMember(dest => dest.DescricaoVotacao, opt => opt.MapFrom(src => src.DescricaoVotacao))
                .ForMember(dest => dest.DescricaoResultado, opt => opt.MapFrom(src => src.DescricaoResultado))
                .ForMember(dest => dest.TotalVotosSim, opt => opt.MapFrom(src => src.TotalVotosSim))
                .ForMember(dest => dest.TotalVotosNao, opt => opt.MapFrom(src => src.TotalVotosNao))
                .ForMember(dest => dest.TotalVotosAbstencao, opt => opt.MapFrom(src => src.TotalVotosAbstencao));

            CreateMap<VotacaoViewModelVotacao, Voto>()
                .ForMember(dest => dest.CodigoMateria, opt => opt.MapFrom(src => src.IdentificacaoMateria.CodigoMateria))
                .ForMember(dest => dest.CodigoSessao, opt => opt.MapFrom(src => src.SessaoPlenaria.CodigoSessao))
                .ForMember(dest => dest.DescricaoVoto, opt => opt.MapFrom(src => src.DescricaoVoto));
        }
    }
}