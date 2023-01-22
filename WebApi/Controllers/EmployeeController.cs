using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController
{
    private EmployeeService _employeeService;
    public EmployeeController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    

    [HttpGet("GetEmployee")]
    public async Task<Response<List<GetEmployee>>> GetEmployees()
    {
        return  await _employeeService.GetEmployees();
    }
       [HttpPost("InsertEmployee")]
    public async Task<Response<AddEmployee>> InsertEmployee([FromForm]AddEmployee empl)
    {
        return await _employeeService.InsertEmployee(empl);
    }

    [HttpPut("UpdateEmployee")]
    public async Task<Response<AddEmployee>> Update([FromForm] AddEmployee empl)
    {
        return await _employeeService.UpdateEmployee(empl);
    }
    [HttpDelete("DeleteEmployee")]
    public async Task<Response<string>> DeleteEmployee(int id)
    {
        return await _employeeService.DeleteEmployee(id);
    }
}