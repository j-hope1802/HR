
 using Microsoft.AspNetCore.Http;
namespace Domain.Entities;

public class Location
{
       public int LocationId { get; set; }
    public string StreetAddreses{ get; set; }
       public int PostalCode { get; set; }
    public string City { get; set; }
        public string StateProvince{get;set;}
    public int CountryId{get;set;}  
        public Country  country;
    public List<Department>departments;
}