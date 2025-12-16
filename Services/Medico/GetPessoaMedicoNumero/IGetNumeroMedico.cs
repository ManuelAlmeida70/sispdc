namespace SisPDC.Services.Medico.GetPessoaMedicoNumero;

public interface IGetNumeroMedico
{
    Task<string> GetNumeroPessoaMedico(string email);
}
