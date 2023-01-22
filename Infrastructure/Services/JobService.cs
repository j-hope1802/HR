using System.Net;

using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;


namespace Infrastructure.Services;

public class JobService
{
    private readonly DataContext _context;
    public JobService(DataContext context)
    {
        _context = context;
        
    }

     public async Task<Response<List<GetJob>>> GetJob()
        {       
            try
            {
            var list = await _context.Jobs.Select(j => new GetJob()
        {    JobId=j.JobId,
            JobTitle=j.JobTitle,
            MaxSalary=j.MaxSalary,
            MinSalary=j.MinSalary

        }).ToListAsync();

        return new Response<List<GetJob>>(list);
            }
            catch (Exception ex)
            {
                return new Response<List<GetJob>>(HttpStatusCode.InternalServerError,ex.Message);
            }
  
        }

        public async Task <Response<GetJob>> InsertJob(GetJob job)
        {
            try
            {
                 var newJob= new Job()
        {
      JobTitle=job.JobTitle,
            MaxSalary=job.MaxSalary,
            MinSalary=job.MinSalary

        };
        _context.Jobs.Add(newJob);
        await _context.SaveChangesAsync();
        return new Response<GetJob>(job);

            }
            catch (Exception ex)
            {
                
            return new Response<GetJob>(HttpStatusCode.InternalServerError,ex.Message);
            }
}
   public async  Task<Response<GetJob>> UpdateJob(GetJob job)
        {
            try
            {
                var find = await _context.Jobs.FindAsync(job.JobId);
           find.JobTitle = job.JobTitle;
          find.MaxSalary = job.MaxSalary;
             find.MinSalary = job.MinSalary;
        await _context.SaveChangesAsync();
        return new Response<GetJob>(job);
            }
            catch (Exception ex)
            {
                return new Response<GetJob>(HttpStatusCode.InternalServerError,ex.Message);
            }

            }
        
         public async Task<Response<string>> DeleteJob(int id)
        {      
            try
            { var find = await _context.Jobs.FindAsync(id);
        _context.Jobs.Remove(find);
        await _context.SaveChangesAsync();
          return new Response<string>("Job deleted successfully");
            }
            catch (Exception ex)
            {
               return new Response<string>(HttpStatusCode.BadRequest, "Job not found");
            }
       
        
        }
}
