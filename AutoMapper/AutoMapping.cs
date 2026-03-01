using AutoMapper;
using SisPDC.DTOs;
using SisPDC.Models.Entities;

namespace SisPDC.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestEntity();
        ResponseEntity();
    }
    private void RequestEntity()
    {
        CreateMap<ConsultaDTO, ConsultaModel>();
        CreateMap<CriarExameDTO, ExamesModel>();
    }

    private void ResponseEntity()
    {
        CreateMap<ConsultaModel, ConsultaDTO>();
        CreateMap<ExamesModel, CriarExameDTO>();

        CreateMap<ExamesModel, ExameListagemDTO>()
        .ForMember(dest => dest.NomeMedico,
            opt => opt.MapFrom(src => src.PessoaClinica != null
                ? src.PessoaClinica.Nome
                : null))
        .ForMember(dest => dest.EspecialidadeMedico,
            opt => opt.MapFrom(src => src.PessoaClinica != null && src.PessoaClinica.Especialidade != null
                ? src.PessoaClinica.Especialidade.Descricao
                : null))
        .ForMember(dest => dest.TemResultados,
            opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Resultados)))
        .ForMember(dest => dest.TemArquivo,
            opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.CaminhoArquivo)));
    }
}
