namespace SisPDC.Models.Entities;

public class ResponseModel<T>
{
    public T Data { get; set; }
    public bool Status { get; set; } = true;
    public string Message { get; set; } = string.Empty;
}
