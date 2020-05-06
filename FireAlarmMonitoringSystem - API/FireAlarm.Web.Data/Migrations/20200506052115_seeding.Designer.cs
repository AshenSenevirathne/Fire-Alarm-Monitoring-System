﻿// <auto-generated />
using FireAlarm.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FireAlarm.Web.Data.Migrations
{
    [DbContext(typeof(FireAlarmDbContext))]
    [Migration("20200506052115_seeding")]
    partial class seeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FireAlarm.Web.Data.Entities.SensorDetails", b =>
                {
                    b.Property<int>("sensorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("coLevel")
                        .HasColumnType("int");

                    b.Property<string>("floorNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("roomNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sensorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sensorRemark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sensorStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("smokeLevel")
                        .HasColumnType("int");

                    b.HasKey("sensorId");

                    b.ToTable("SensorDetails");

                    b.HasData(
                        new
                        {
                            sensorId = 1,
                            coLevel = 0,
                            floorNo = "2",
                            roomNo = "1",
                            sensorName = "Sensor One",
                            sensorStatus = "A",
                            smokeLevel = 0
                        },
                        new
                        {
                            sensorId = 2,
                            coLevel = 0,
                            floorNo = "1",
                            roomNo = "8",
                            sensorName = "Sensor Two",
                            sensorStatus = "A",
                            smokeLevel = 0
                        },
                        new
                        {
                            sensorId = 3,
                            coLevel = 0,
                            floorNo = "3",
                            roomNo = "3",
                            sensorName = "Sensor Three",
                            sensorStatus = "A",
                            smokeLevel = 0
                        },
                        new
                        {
                            sensorId = 4,
                            coLevel = 0,
                            floorNo = "6",
                            roomNo = "1",
                            sensorName = "Sensor Four",
                            sensorStatus = "A",
                            smokeLevel = 0
                        },
                        new
                        {
                            sensorId = 5,
                            coLevel = 0,
                            floorNo = "5",
                            roomNo = "2",
                            sensorName = "Sensor Five",
                            sensorStatus = "A",
                            smokeLevel = 0
                        });
                });

            modelBuilder.Entity("FireAlarm.Web.Data.Entities.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("userEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userMobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userRoleId")
                        .HasColumnType("int");

                    b.HasKey("userId");

                    b.HasIndex("userRoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            userId = 1,
                            userEmail = "kusalpriyanka782@gmail.com",
                            userMobileNo = "0777123456",
                            userName = "Kusal Priyanka",
                            userPassword = "abc123",
                            userRoleId = 2
                        },
                        new
                        {
                            userId = 2,
                            userEmail = "dimuthuc2@gmail.com",
                            userMobileNo = "0757123456",
                            userName = "Dimuthu Abesighe",
                            userPassword = "abc123",
                            userRoleId = 1
                        });
                });

            modelBuilder.Entity("FireAlarm.Web.Data.Entities.UserRole", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("roleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            roleId = 1,
                            roleDescription = "SDUSER"
                        },
                        new
                        {
                            roleId = 2,
                            roleDescription = "ADMIN"
                        });
                });

            modelBuilder.Entity("FireAlarm.Web.Data.Entities.User", b =>
                {
                    b.HasOne("FireAlarm.Web.Data.Entities.UserRole", "userRole")
                        .WithMany("Users")
                        .HasForeignKey("userRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
