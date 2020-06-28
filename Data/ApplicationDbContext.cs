using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using moodi.Models;

namespace moodi.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<DailyReport> DailyReports { get; set; }
        public DbSet<Mood> Moods { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Meditation> Meditations { get; set; }
        public override DbSet<AppUser> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>().Ignore(e => e.FullName);
        }
    }
}