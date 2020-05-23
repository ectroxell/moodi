using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using moodi.Models;

namespace moodi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       public DbSet<DailyReport> DailyReports { get; set; }
       public DbSet<Mood> Moods { get; set; }

       //public DbSet<Journal> Journals { get; set; }
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
