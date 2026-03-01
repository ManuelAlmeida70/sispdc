using AutoMapper;
using SisPDC.DTOs;
using SisPDC.Models.Repositories;

namespace SisPDC.Services.Exames.GetAll;

public class GetAllExame : IGetAllExame
{
    private readonly IExameRepository _exameRepository;
    private readonly IMapper _mapper;

    public GetAllExame(IExameRepository exameRepository, IMapper mapper)
    {
        _exameRepository = exameRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ExameListagemDTO>> Execute()
    {
        try
        {
            var exames = await _exameRepository.GetAll();
            return _mapper.Map<IEnumerable<ExameListagemDTO>>(exames);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while fetching exames: {ex.Message}");
            throw;
        }
    }
}