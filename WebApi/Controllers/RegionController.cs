using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RegionController
{
    private RegionService _regService;
    public RegionController(RegionService regService)
    {
        _regService = regService;
    }
    [HttpGet("GetRegion")]
    public async Task<Response<List<GetRegion>>> GetRegion()=> await _regService.GetRegion();

      [HttpPost("Insert")]
        public async Task<Response<GetRegion>> InsertRegion([FromForm]GetRegion region)
        {
            return await _regService.InsertRegion(region);
        }

          [HttpPut("Update")]
        public async Task <Response<GetRegion>> UpdateRegion([FromForm]GetRegion region)
        {
            return await _regService.UpdateRegion(region);
        }
           [HttpDelete("Region")]
         public async Task<Response<string>> DeleteRegion(int id)
        {
            return await _regService. DeleteRegion(id);
        }

}
    