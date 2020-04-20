using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FireAlarm.Web.Data.Entities
{
    public class FireAlarmDbContext : DbContext
    {
        public FireAlarmDbContext(DbContextOptions<FireAlarmDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne<UserRole>(u => u.userRole)
                .WithMany(ur => ur.Users)
                .HasForeignKey(u => u.userRoleId);

            modelBuilder.Entity<SensorState>()
                .HasOne<SensorDetails>(ss => ss.sensorDetails)
                .WithMany(sd => sd.sensorStates)
                .HasForeignKey(ss => ss.sensorId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<SensorDetails> SensorDetails { get; set; }
        public DbSet<SensorState> SensorState { get; set; }
    }
}
