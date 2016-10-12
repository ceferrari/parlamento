using System.Collections.Generic;
using AutoMapper;
using ParlamentoDominio.Entidades.Parlamentares;
using ParlamentoTarefas.ViewModels.Parlamentares;

namespace ParlamentoTarefas
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<BasePerfilMapeamento>();
            });
        }

        public class BasePerfilMapeamento : Profile
        {
            public override string ProfileName => "BaseMapeamento";

            public BasePerfilMapeamento()
            {
                CreateMap<ExercicioViewModel, Exercicio>();

                CreateMap<IdentificacaoViewModel, Identificacao>()
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.NomeParlamentar))
                    .ForMember(dest => dest.NomeCompleto, opt => opt.MapFrom(src => src.NomeCompletoParlamentar))
                    .ForMember(dest => dest.Sexo, opt => opt.MapFrom(src => src.SexoParlamentar))
                    .ForMember(dest => dest.UrlFoto, opt => opt.MapFrom(src => src.UrlFotoParlamentar))
                    .ForMember(dest => dest.UrlPagina, opt => opt.MapFrom(src => src.UrlPaginaParlamentar))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailParlamentar))
                    .ForMember(dest => dest.SiglaPartido, opt => opt.MapFrom(src => src.SiglaPartidoParlamentar))
                    .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => src.UfParlamentar));

                
                CreateMap<LegislaturaViewModel, Legislatura>();

                //CreateMap<MandatoViewModel, Mandato>();

                CreateMap<ParlamentarViewModel, Parlamentar>()
                    .ForMember(dest => dest.Identificacao, opt => opt.MapFrom(src => Mapper.Map<Identificacao>(src.IdentificacaoParlamentar)))
                    .ForMember(dest => dest.Mandato, opt => opt.MapFrom(src => new Mandato
                    {
                        Exercicios = Mapper.Map<ICollection<Exercicio>>(src.Mandato.Exercicios.Exercicio),
                        Suplentes = Mapper.Map<ICollection<Suplente>>(src.Mandato.Suplentes.Suplente)
                    }))
                    .ForMember(dest => dest.UrlGlossario, opt => opt.MapFrom(src => src.UrlGlossario));

                CreateMap<SuplenteViewModel, Suplente>();
            }
        }
    }
}