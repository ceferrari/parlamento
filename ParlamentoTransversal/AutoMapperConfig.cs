using AutoMapper;

namespace ParlamentoTransversal
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
                //CreateMap<ExemploViewModel, EntidadeViewModel>()
                //    .ForMember(dest => dest.Codigo1, opt => opt.MapFrom(src => src.Codigo1))
                //    .ForMember(dest => dest.Codigo2, opt => opt.MapFrom(src => src.Codigo2))
                //    .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao));
            }
        }
    }
}