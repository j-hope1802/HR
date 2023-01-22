using System.Net;
using Dapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Npgsql;
namespace Infrastructure.Services;
public class CountryService
{
    private readonly DataContext _context;

    public CountryService(DataContext context)
    {
        _context = context;

    }

    public async Task<Response<List<GetCountry>>> GetCountry()
    {
        var list1 =new List<GetCountry>();
        try
        {
            var list = await _context.Countries.Select(c => new GetCountry()
            {
                CountryId = c.CountryId,
                CountryName = c.CountryName,
                RegionId = c.Region.RegionId
            }).ToListAsync();
  
            return new Response<List<GetCountry>>(list);
        }
        catch (Exception ex)
        {

            return new Response<List<GetCountry>>(HttpStatusCode.InternalServerError, ex.Message);
        }
   
    }

    public async Task<Response<AddCountry>> InsertCountry(AddCountry country)
    {
        try
        {
            var newCountry = new Country()
        {
            CountryName = country.CountryName,
            RegionId = country.RegionId

        };
        _context.Countries.Add(newCountry);
        await _context.SaveChangesAsync();
        return new Response<AddCountry>(country);

        }
        catch (Exception ex)
        {
            
            return new Response<AddCountry>(HttpStatusCode.InternalServerError, ex.Message);
        }

    }
    public async Task<Response<AddCountry>> UpdateCountry(AddCountry country)
    {
        try
        {
             var find = await _context.Countries.FindAsync(country.CountryId);

        if (find == null) return null;

        find.CountryName = country.CountryName;
        find.RegionId = country.RegionId;
        await _context.SaveChangesAsync();
        return new Response<AddCountry>(country);
        }
        catch (Exception ex )
        {
        return new Response<AddCountry>(HttpStatusCode.NotImplemented, ex.Message);
        }
   
    }
    public async Task<Response<string>> DeleteCountry(int id)
    { try
    {
        
        var find = await _context.Countries.FindAsync(id);
        _context.Countries.Remove(find);
        await _context.SaveChangesAsync();
      return new Response<string>("Country deleted successfully");
       
    }
    catch (Exception ex)
    {
        
       return new Response<string>(HttpStatusCode.BadRequest, "Country not found");
    }
    }
}
