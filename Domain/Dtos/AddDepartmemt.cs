namespace Domain.Dtos;
using Microsoft.AspNetCore.Http;
public class AddDepartment
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
   public int LocationId{get;set;}
   
}