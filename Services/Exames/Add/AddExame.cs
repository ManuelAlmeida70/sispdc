using AutoMapper;
using SisPDC.DTOs;
using SisPDC.Models.Entities;
using SisPDC.Models.Repositories;

namespace SisPDC.Services.Exames.Add;

public class AddExame : IAddExame
{
    private readonly IExameRepository _exameRepository;
    private readonly IMapper _mapper;

    public AddExame(IExameRepository exameRepository, IMapper mapper)
    {
        _exameRepository = exameRepository;
        _mapper = mapper;
    }

    public async Task<ResponseModel<CriarExameDTO>> Execute(CriarExameDTO exameDTO)
    {
        ResponseModel<CriarExameDTO> response = new ResponseModel<CriarExameDTO>();

        try
        {
            var exame = _mapper.Map<ExamesModel>(exameDTO);
            await _exameRepository.Add(exame);

            response.Data = exameDTO;
            response.Message = "Exame cadastrado com sucesso";

            return response;
        }
        catch (Exception ex)
        {
            response.Data = null;
            response.Message = ex.Message;
            response.Status = false;
            return response;
        }
    }
}
