using ProjetoLar.src.Entities;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ProjetoLar.src.DTOs.PessoaDTO;
using ProjetoLar.src.DTOs.TelefoneDTO;


namespace ProjetoLar.src.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Pessoa, PessoaDTO>();
            CreateMap<CreatePessoaDTO, Pessoa>();
            CreateMap<UpdatePessoaDTO, Pessoa>();


            CreateMap<Telefone, TelefoneDTO>()
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo.ToString()));
            CreateMap<CreateTelefoneDTO, Telefone>()
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => Enum.Parse<TipoTelefone>(src.Tipo)));
            CreateMap<UpdateTelefoneDTO, Telefone>()
            .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => Enum.Parse<TipoTelefone>(src.Tipo)));
        }
    }
}
