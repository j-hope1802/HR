 using Microsoft.AspNetCore.Http;
 namespace Domain.Entities;
 public class JobGrades

{
    public int JobGradesId{get;set;}
    public string GradeLevel{get;set;}
    public int LowestSai{get;set;}
    public int HighestSai{get;set;}
}