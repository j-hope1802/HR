using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Infrastructure.Context;
public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext>options):base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    
 
            
        modelBuilder.Entity<Employee>()
            .HasOne<Department>(s => s.department)
            .WithMany(g => g.employees)
            .HasForeignKey(s => s.DepartmentId);

            
            modelBuilder.Entity<Department>()
            .HasOne<Location>(s => s.location)
            .WithMany(g => g.departments)
            .HasForeignKey(s => s.LocationId); 
            
                modelBuilder.Entity<Location>()
            .HasOne<Country>(s => s.country)
            .WithMany(g => g.Locations)
            .HasForeignKey(s => s.CountryId);

                modelBuilder.Entity<Country>()
            .HasOne<Region>(s => s.Region)
            .WithMany(g => g.countries)
            .HasForeignKey(s => s.RegionId);

                modelBuilder.Entity<JobHistory>()
            .HasOne<Job>(s => s.job)
            .WithMany(g => g.JobHistories)
            .HasForeignKey(s => s.JobId);

            

                modelBuilder.Entity<JobHistory>()
            .HasOne<Employee>(s => s.employee)
            .WithMany(g => g.JobHistories)
            .HasForeignKey(s => s.EmployeeId);


             modelBuilder.Entity<Employee>()
            .HasOne<Job>(s => s.job)
            .WithMany(g => g.employees)
            .HasForeignKey(s => s.JobId);


            
                modelBuilder.Entity<JobHistory>()
            .HasOne<Department>(s => s.department)
            .WithMany(g => g.jobHistories)
            .HasForeignKey(s => s.DepartmentId);


    }
    public DbSet<Employee> Employees{get;set;}
        public DbSet<Department> Departments{get;set;}
            public DbSet<Country> Countries{get;set;}
                  public DbSet<Job> Jobs{get;set;}
               public DbSet<JobHistory> JobHistories {get;set;}
          public DbSet<Region> Regions{get;set;}
       public DbSet<Location> Locations{get;set;}
     public DbSet<JobGrades> JobGrades{get;set;}

}
