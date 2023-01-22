using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController
{
    private DepartmentService _conService;
    public DepartmentController(DepartmentService conService)
    {
        _conService = conService;
    }
    [HttpGet("GetDepartment")]
    public async Task<Response<List<GetDepartment>>> GetDepartment()=> await _conService.GetDepartment();

      [HttpPost("Insert")]
        public async Task<Response<AddDepartment>> InsertDepartment([FromForm]AddDepartment department)
        {
            return await _conService.InsertDepartment(department);
        }

          [HttpPut("Update")]
        public async Task <Response<AddDepartment>> UpdateDepartment([FromForm]AddDepartment department)
        {
            return await _conService.UpdateDepartment(department);
        }
           [HttpDelete("Delete")]
         public async Task<Response<string>> DeleteDepartment(int id)
        {
            return await _conService. DeleteDepartment(id);
        }

}
    