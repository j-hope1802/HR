namespace Domain.Dtos;

public class GetJobHistory
{
public int EmployeId{get;set;}
public    DateTime StartDate{get;set;}
public DateTime EndDate{get;set;}
public int JobId{get;set;}
public int DepartmentId {get;set;}
}