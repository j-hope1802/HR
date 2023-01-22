namespace Domain.Dtos;
using Microsoft.AspNetCore.Http;
public  class AddEmployee
{
     public int EmployeeId { get; set; }
     public int DepartmentId{get;set;}
     public int JobId{get;set;}
    public string   FirstName{ get; set; }
    public string LastName{get;set;}
    public string   Email{get;set;}
    public int PhoneNumber{get;set;}
    public int ManagerId {get;set;}
    public int Comission {get;set;}
    public int Sallary {get;set;}
    public DateTime HireDate{get;set;}
}  