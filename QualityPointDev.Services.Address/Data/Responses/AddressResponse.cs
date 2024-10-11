namespace QualityPointDev.Services.Address.Data.Responses;

public class AddressResponse<TData>
{
    public TData? Data { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}