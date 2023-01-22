using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CountryController
{
    private CountryService _conService;
    public CountryController(CountryService conService)
    {
        _conService = conService;
    }
    [HttpGet("GetCountry")]
    public async Task<Response<List<GetCountry>>> GetCountry()=> await _conService.GetCountry();

      [HttpPost("Insert")]
        public async Task<Response<AddCountry>> InsertCountry([FromForm]AddCountry country)
        {
            return await _conService.InsertCountry(country);
        }

          [HttpPut("Update")]
        public async Task <Response<AddCountry>> UpdateCountry(AddCountry country)
        {
            return await _conService.UpdateCountry(country);
        }
           [HttpDelete("Delete")]
         public async Task<Response<string>> DeleteCountry(int id)
        {
            return await _conService. DeleteCountry(id);
        }
}
    