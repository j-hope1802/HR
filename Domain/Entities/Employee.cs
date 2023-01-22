
using Microsoft.AspNetCore.Http;

namespace Domain.Entities;


public class Employee
{
    public int EmployeeId { get; set; }
    public string   FirstName{ get; set; }
    public string LastName{get;set;}
    public string   Email{get;set;}
    public int PhoneNumber{get;set;}
    public int DepartmentId{get;set;}
    public int ManagerId {get;set;}
    public int Comission {get;set;}
    public int Sallary {get;set;}
    public int JobId{get;set;}
     public DateTime HireDate;
public  Job job;
public Department department;
public  Job Job;
public List<JobHistory>JobHistories;
}