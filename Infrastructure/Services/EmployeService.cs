namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Hosting;
public class EmployeeService
{
    private DataContext _context;

   private readonly IWebHostEnvironment _hostEnvironment;

    public EmployeeService(DataContext context,IWebHostEnvironment env)
    {
        _context = context;
        _hostEnvironment = env;
    }

    public async Task<Response<List<GetEmployee>>> GetEmployees()
    {
        try
        {
            var list = await _context.Employees.Select(c => new GetEmployee()
        {
           
            FirstName = c.FirstName,
             LastName = c.LastName,
             EmployeeId = c.EmployeeId,
            Email = c.Email,
            PhoneNumber = c.PhoneNumber,
            ManagerId = c.ManagerId,
            Comission = c.Comission  ,
            Sallary = c.Sallary,
            JobId = c.job.JobId,
            HireDate = c.HireDate,
            DepartmentId = c.department.DepartmentId,
        }).ToListAsync();

        return new Response<List<GetEmployee>>(list);
        }
        catch (Exception ex )
        {
            return new Response<List<GetEmployee>>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
    public async Task<Response<AddEmployee>> InsertEmployee(AddEmployee employee)
    {
        try
        {
            var newEmployee = new Employee()
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber,
            ManagerId = employee.ManagerId,
            Comission = employee.Comission  ,
            Sallary = employee.Sallary,
              HireDate = employee.HireDate,
            JobId = employee.JobId,
        };
         _context.Employees.Add(newEmployee);

         await _context.SaveChangesAsync();

         return new Response<AddEmployee>(employee);
        }
        catch (Exception ex )
        {
            
            return new Response<AddEmployee>(HttpStatusCode.InternalServerError,ex.Message);
        }
           
        
    }
        public async Task<Response<AddEmployee>> UpdateEmployee(AddEmployee employee)
        {   
            try
            {
                 var find = await _context.Employees.FindAsync(employee.EmployeeId);
             if(find == null) return null;
            find.EmployeeId = employee.EmployeeId;
            find.FirstName = employee.FirstName;
            find.LastName = employee.LastName;
            find.Email = employee.Email;
            find.PhoneNumber = employee.PhoneNumber;
            find.ManagerId = employee.ManagerId;
            find.Comission = employee.Comission ;
            find.Sallary = employee.Sallary;
            find.JobId = employee.JobId;
            find.HireDate = employee.HireDate;
            await _context.SaveChangesAsync();
            return new Response<AddEmployee>(employee);
            }
            catch (Exception ex)
            {
                
                return new Response<AddEmployee>(HttpStatusCode.InternalServerError,ex.Message);
            }
            
        }
      public async Task<Response<string>> DeleteEmployee(int id)
        {    
            try
            {
            var find = await _context.Employees.FindAsync(id);
        _context.Employees.Remove(find);
        await _context.SaveChangesAsync();
            return new Response<string>("Employee deleted successfully");
           
            }
            catch (System.Exception)
            {
               return new Response<string>(HttpStatusCode.NotFound, "Employee not found");
            }  
 
        }
}
