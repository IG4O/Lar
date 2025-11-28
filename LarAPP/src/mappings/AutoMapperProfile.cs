using AutoMapper;
using LarAPP.src.Entities;
using LarAPP.src.DTOs.PessoaDTO;
using LarAPP.src.DTOs.TelefoneDTO;
using LarAPP.src.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
