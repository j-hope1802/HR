using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController
{
    private  Locationservice _locService;
    public LocationController( Locationservice locService)
    {
        _locService = locService;
    }
    [HttpGet("GetLocation")]
    public async Task<Response<List<GetLocation>>> GetLocation()=> await _locService.GetLocations();

      [HttpPost("Insert")]
        public async Task<Response<AddLocation>> InsertLocation([FromForm]AddLocation Location)
        {
            return await _locService.InsertLocation(Location);
        }

          [HttpPut("Update")]
        public async Task <Response<AddLocation>> UpdateLocation([FromForm]AddLocation Location)
        {
            return await _locService.UpdateLocation(Location);
        }
           [HttpDelete("Delete")]
         public async Task<Response<string>> DeleteLocation(int id)
        {
            return await _locService. DeleteLocation(id);
        }

}
    