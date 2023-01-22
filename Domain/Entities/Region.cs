namespace Domain.Entities;
 using Microsoft.AspNetCore.Http;
public class  Region {
    public int RegionId{get;set;}
    public string RegionName{get;set;}
    public List<Country> countries;
}