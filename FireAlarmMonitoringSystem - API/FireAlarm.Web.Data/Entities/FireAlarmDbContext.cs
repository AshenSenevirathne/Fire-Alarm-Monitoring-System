using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * @Author      :   Kusal Priyanka
 * @Class Name  :   FireAlarmDbContext
 * @Description :   FireAlarmDbContext inherite from the DbContext in Entity framework
*/

namespace FireAlarm.Web.Data.Entities
{
    public class FireAlarmDbContext : DbContext
    {
        public FireAlarmDbContext(DbContextOptions<FireAlarmDbContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set the relationship of User table and User role table.
            modelBuilder.Entity<User>()
                .HasOne<UserRole>(u => u.userRole)
                .WithMany(ur => ur.Users)
                .HasForeignKey(u => u.userRoleId);
            
            // Add dummy user roles to the db
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { roleId = 1, roleDescription = "SDUSER" },
                new UserRole { roleId = 2, roleDescription = "ADMIN" });

            // Add dummy users to the db
            modelBuilder.Entity<User>().HasData(
                new User { userId = 1, userName = "Kusal Priyanka", userPassword = "abc123", userEmail = "kusalpriyanka782@gmail.com", userMobileNo = "+940755628231", userRoleId = 2 },
                new User { userId = 2, userName = "Dimuthu Abesighe", userPassword = "abc123", userEmail = "dimuthuc2@gmail.com", userMobileNo = "+940766944088", userRoleId = 1 });

            // Add dummy sensors roles to the db
            modelBuilder.Entity<SensorDetails>().HasData(
                new SensorDetails { sensorId = 1, sensorName = "Sensor One", floorNo = "2", roomNo = "1", sensorStatus = "A"},
                new SensorDetails { sensorId = 2, sensorName = "Sensor Two", floorNo = "1", roomNo = "8", sensorStatus = "A" },
                new SensorDetails { sensorId = 3, sensorName = "Sensor Three", floorNo = "3", roomNo = "3", sensorStatus = "A" },
                new SensorDetails { sensorId = 4, sensorName = "Sensor Four", floorNo = "6", roomNo = "1", sensorStatus = "A" },
                new SensorDetails { sensorId = 5, sensorName = "Sensor Five", floorNo = "5", roomNo = "2", sensorStatus = "A" });

        }

        // Set DbSet by passing the model class
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<SensorDetails> SensorDetails { get; set; }
    }
}
