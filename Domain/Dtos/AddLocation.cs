
namespace Domain.Dtos;

public class AddLocation
{
    public int LocationId { get; set; }
    public string StreetAddreses{ get; set; }
    public int PostalCode { get; set; }
    public string City { get; set; }
    public string StateProvince{get;set;}
    public int CountryId{get;set;}

}