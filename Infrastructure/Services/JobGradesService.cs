using System.Net;

using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;


namespace Infrastructure.Services;

public class JobGradesService
{
    private readonly DataContext _context;


    public JobGradesService(DataContext context)
    {
        _context = context;
        
    }

     public async Task<Response<List<GetJobGrades>>> GetJobGrades()
        {  
            try
            {
                 var list = await _context.JobGrades.Select(j => new GetJobGrades()
        {  JobGradesId=j.JobGradesId,
            GradeLevel=j.GradeLevel,
            LowestSai=j.LowestSai,
            HighestSai=j.HighestSai
          
        
        }).ToListAsync();

        return new Response<List<GetJobGrades>>(list);
            }
            catch (Exception ex) 
            {
                
                return new Response<List<GetJobGrades>>(HttpStatusCode.InternalServerError,ex.Message);
            }     
      
        }

        public async Task <Response<GetJobGrades>> InsertJobGrades(GetJobGrades job)
        {
            try
            {
                var newJob= new JobGrades()
        {     
            GradeLevel=job.GradeLevel,
            LowestSai=job.LowestSai,
            HighestSai=job.HighestSai

        };
        _context.JobGrades.Add(newJob);
        await _context.SaveChangesAsync();
        return new Response<GetJobGrades>(job);
            }
            catch (Exception ex)
            {
                
               return new Response<GetJobGrades>(HttpStatusCode.InternalServerError,ex.Message);
            }
 
        
}
   public async  Task<Response<GetJobGrades>> UpdateJobGrades(GetJobGrades job)
        {try
        {
               var find = await _context.JobGrades.FindAsync(job.JobGradesId);

        if(find == null) return null;
         find.GradeLevel=job.GradeLevel;
            find.LowestSai=job.LowestSai;
            find.HighestSai=job.HighestSai;
        await _context.SaveChangesAsync();
        return new Response<GetJobGrades>(job);
        }
        catch (Exception ex)
        {
            
           return new Response<GetJobGrades>(HttpStatusCode.InternalServerError,ex.Message);
        }

     
            }
        
         public async Task<Response<string>> DeleteJobGrades(int id)
        {      
            try
            {
                 var find = await _context.JobGrades.FindAsync(id);
        _context.JobGrades.Remove(find);
        await _context.SaveChangesAsync();
         return new Response<string>("JobGrades deleted successfully");

            }
            catch (Exception ex)
            {
                
             return new Response<string>(HttpStatusCode.InternalServerError,ex.Message);
            }
       
        }
}
