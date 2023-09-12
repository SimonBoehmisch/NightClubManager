using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NightClubManager.Common.Models;

namespace NightClubManager.Infrastructure;

public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<EmployeeAssignment> EmployeeAssignments { get; set; }
    public DbSet<RoleRequirement> RoleRequirements { get; set; }
    public DbSet<Schedule> Schedules { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=NightClubManager.db");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasKey(e => e.Id);
        modelBuilder.Entity<Event>().HasKey(e => e.Id);
        modelBuilder.Entity<Role>().HasKey(e => e.Id);
        modelBuilder.Entity<EmployeeAssignment>().HasKey(e => e.Id);
        modelBuilder.Entity<Employee>().HasKey(e => e.Id);

        modelBuilder.Entity<Employee>().HasMany(e => e.Roles).WithMany(e => e.Employees);

        modelBuilder.Entity<EmployeeAssignment>().HasOne(e => e.Employee).WithMany(e => e.EmployeeAssignments);
        modelBuilder.Entity<EmployeeAssignment>().HasOne(e => e.Event).WithMany(e => e.EmployeeAssignments);

        modelBuilder.Entity<RoleRequirement>().HasOne(e => e.Role).WithMany(e => e.RoleRequirements);
        modelBuilder.Entity<RoleRequirement>().HasOne(e => e.Event).WithMany(e => e.RoleRequirements);


        base.OnModelCreating(modelBuilder);
    }
}
