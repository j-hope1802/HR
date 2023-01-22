using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class JobController
{
    private JobService _jobService;
    public JobController(JobService jobService)
    {
        _jobService = jobService;
    }
    [HttpGet("GetJob")]
    public async Task<Response<List<GetJob>>> GetJob()=> await _jobService.GetJob();

      [HttpPost("Insert")]
        public async Task<Response<GetJob>> InsertJob([FromForm]GetJob job)
        {
            return await _jobService.InsertJob(job);
        }

          [HttpPut("Update")]
        public async Task <Response<GetJob>> UpdateJob([FromForm]GetJob job)
        {
            return await _jobService.UpdateJob(job);
        }
           [HttpDelete("Delete")]
         public async Task<Response<string>> DeleteJob(int id)
        {
            return await _jobService.DeleteJob(id);
        }

}
    