namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
public class Locationservice
{
    private DataContext _context;

    public Locationservice(DataContext context)
    {
        _context = context;
    }
    
    public async Task<Response<List<GetLocation>>> GetLocations()
    {
        try
        {
               var list = await _context.Locations.Select(l => new GetLocation()
        {
            LocationId = l.LocationId,
            PostalCode = l.PostalCode,
            StateProvince = l.StateProvince,
            CountryId=l.country.CountryId,
            City = l.City,
          
        }).ToListAsync();

        return new Response<List<GetLocation>>(list);
        }
        catch (Exception ex)
        {
            
            return new Response<List<GetLocation>>(HttpStatusCode.InternalServerError,ex.Message);
        }
     
            
    }
    
    public async Task<Response<AddLocation>> InsertLocation(AddLocation location)
    {
        try
        {
             var newLocation = new Location()
        {
            PostalCode = location.PostalCode,
            StateProvince = location.StateProvince,
            StreetAddreses = location.StreetAddreses,
            City = location.City,
            CountryId = location.CountryId
        };
         _context.Locations.Add(newLocation);

         await _context.SaveChangesAsync();

         return new Response<AddLocation>(location);
        }
        catch (Exception ex)
        {
            return new Response<AddLocation>(HttpStatusCode.InternalServerError,ex.Message);
        }
       
    }
        public async Task<Response<AddLocation>> UpdateLocation(AddLocation location)
        {
            try
            {
                var find = await _context.Locations.FindAsync(location.LocationId);
           find.PostalCode = location.PostalCode;
            find.StateProvince = location.StateProvince;
           find. StreetAddreses = location.StreetAddreses;
            find.City = location.City;
            find.CountryId = location.CountryId;

            await _context.SaveChangesAsync();

            return new Response<AddLocation>(location);
                
            }
            catch (Exception ex)
            {
                return new Response<AddLocation>(HttpStatusCode.InternalServerError,ex.Message);
            }
            
        }
      public async Task<Response<string>> DeleteLocation(int id)
        {      
            try
            {
                var find = await _context.Locations.FindAsync(id);
        _context.Locations.Remove(find);
        await _context.SaveChangesAsync();
           return new Response<string>("Location deleted successfully");
            }
            catch (System.Exception)
            {
                  return new Response<string>(HttpStatusCode.BadRequest, "Location not found");
            }
      
           
        }
}