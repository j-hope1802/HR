using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class JobsGradesController
{
    private JobGradesService _jobGradesService;
    public JobsGradesController(JobGradesService jobGradesService)
    {
        _jobGradesService = jobGradesService;
    }
    [HttpGet("GetJob")]
    public async Task<Response<List<GetJobGrades>>> GetJobGrades()=> await _jobGradesService.GetJobGrades();

      [HttpPost("Insert")]
        public async Task<Response<GetJobGrades>> InsertJobGrades([FromForm]GetJobGrades job)
        {
            return await _jobGradesService.InsertJobGrades(job);
        }

          [HttpPut("Update")]
        public async Task <Response<GetJobGrades>> UpdateJobGrades([FromForm]GetJobGrades job)
        {
            return await _jobGradesService.UpdateJobGrades(job);
        }
           [HttpDelete("Delete")]
         public async Task<Response<string>> DeleteJobGrades(int id)
        {
            return await _jobGradesService.DeleteJobGrades(id);
        }

}
    