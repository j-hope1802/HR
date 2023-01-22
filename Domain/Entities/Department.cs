namespace Domain.Entities;

public class Department
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public int ManagerId { get; set; }
   public int LocationId{get;set;}
   public Location location;
   public List<Employee> employees;
   public List<JobHistory>jobHistories;
}