using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resume2.Models;

namespace Resume2.Data
{
  public class Resume2Context: DbContext
  {
    public Resume2Context(DbContextOptions<Resume2Context> options) : base(options)
    {
    }
    public DbSet<Resume> Resumes { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Reference> References { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Duty> Dutys { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Resume>().ToTable("Resume");
      modelBuilder.Entity<Experience>().ToTable("Experience");
      modelBuilder.Entity<Reference>().ToTable("Reference");
      modelBuilder.Entity<Education>().ToTable("Education");
      modelBuilder.Entity<Duty>().ToTable("Duty");


    }
  }
}
