namespace QualityPointDev.Services.Address.Data.Dto;

public class AddressDto
{
    public string Result { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string CountryIsoCode { get; set; } = string.Empty;
    public string FederalDistrict { get; set; } = string.Empty;
    public string RegionIsoCode { get; set; } = string.Empty;
    public List<Metro>? Metro { get; set; } = [];
}