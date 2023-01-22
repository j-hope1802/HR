namespace Domain.Entities;
 using Microsoft.AspNetCore.Http;
 using System.ComponentModel.DataAnnotations.Schema;
 using System.ComponentModel.DataAnnotations;
public class JobHistory{
    [Key]
public int EmployeeId{get;set;}
public    DateTime StartDate{get;set;}
public DateTime EndDate{get;set;}
public int JobId{get;set;}
public int DepartmentId {get;set;}
public  Employee employee;
public Job job;
public Department department;
}