using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class JobHistoryController
{
    private JobHistoryService _JobHistoryService;
    public JobHistoryController(JobHistoryService JobHistoryService)
    {
        _JobHistoryService = JobHistoryService;
    }
    [HttpGet("GetJobHistory")]
    public async Task<Response<List<GetJobHistory>>> GetJobHistory()
    {
        return await _JobHistoryService.GetJobHistory();
    }

    [HttpPost("Insert")]
    public async Task<Response<AddJobHistory>> InsertJobHistory([FromForm]AddJobHistory job)
    {
        return await _JobHistoryService.InsertJobHistory(job);
    }

    [HttpPut("Update")]
    public async Task<Response<AddJobHistory>> UpdateJobHistory([FromForm]AddJobHistory job)
    {
        return await _JobHistoryService.UpdateJobHistory(job);
    }
    [HttpDelete("Delete")]
    public async Task<Response<string>> DeleteJobHistory(int id)
    {
        return await _JobHistoryService.DeleteJobHistory(id);
    }

}
