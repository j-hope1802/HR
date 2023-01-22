namespace Domain.Entities;
using Microsoft.AspNetCore.Http;
public class  Job{
    public int JobId{get;set;}
    public int MaxSalary{get;set;}
    public int MinSalary{get;set;}
    public string JobTitle{get;set;}
    public List<Employee>employees;
    public List<JobHistory>JobHistories;
}