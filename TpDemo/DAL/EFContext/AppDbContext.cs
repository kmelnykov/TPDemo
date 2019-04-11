using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TpDemo.DAL.Entities;

namespace TpDemo.DAL.EFContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourBooking> TourBookings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //TOUR TABLE

            builder.Entity<Tour>().ToTable("Tours");
            builder.Entity<Tour>().HasKey(t => t.Id);
            builder.Entity<Tour>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tour>().Property(t => t.HotelNames).IsRequired().HasMaxLength(60);
            builder.Entity<Tour>().Property(t => t.CityNames).IsRequired().HasMaxLength(60);
            builder.Entity<Tour>().Property(t => t.CountryNames).IsRequired().HasMaxLength(60);
            builder.Entity<Tour>().Property(t => t.BeginDate).IsRequired();
            builder.Entity<Tour>().Property(t => t.FinishDate).IsRequired();
            builder.Entity<Tour>().Property(t => t.HotTour).IsRequired();
            builder.Entity<Tour>().Property(t => t.Description).HasMaxLength(300);
            builder.Entity<Tour>().Property(t => t.Transports).IsRequired().HasMaxLength(60);
            builder.Entity<Tour>().HasMany(t => t.TourBookings).WithOne(b => b.Tour).HasForeignKey(b => b.TourId);

            builder.Entity<Tour>().HasData
                (
                    new Tour
                    {
                        Id = 100,
                        HotelNames = "Lagun",
                        CityNames = "Lviv",
                        CountryNames = "Ukraine"
                    ,
                        BeginDate = new DateTime(2019, 4, 9),
                        FinishDate = new DateTime(2019, 4, 17),
                        HotTour = true
                    ,
                        Transports = "bus"

                    }
                );

            builder.Entity<Tour>().HasData
                (
                    new Tour
                    {
                        Id = 101,
                        HotelNames = "Dolphin",
                        CityNames = "Moskow",
                        CountryNames = "Russia"
                        ,
                        BeginDate = new DateTime(2019, 6, 2),
                        FinishDate = new DateTime(2019, 6, 4),
                        HotTour = false
                        ,
                        Transports = "plane"

                    }

                );

            //TOURBOOKING TABLE

            builder.Entity<TourBooking>().ToTable("TourBookings");
            builder.Entity<TourBooking>().HasKey(b => b.Id);
            builder.Entity<TourBooking>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TourBooking>().Property(b => b.Sum).IsRequired();
            builder.Entity<TourBooking>().Property(b => b.Age).IsRequired();
            builder.Entity<TourBooking>().Property(b => b.MaxNumberOfPersonInRoom).IsRequired();
            builder.Entity<TourBooking>().Property(b => b.Notes).HasMaxLength(99);

            builder.Entity<TourBooking>().HasData
                (
                    new TourBooking
                    {
                        Id = 100,
                        Sum = 321,
                        Age = 18,
                        MaxNumberOfPersonInRoom = 4,
                        Notes = "some note",
                        TourId = 100,
                        UserId = 100
                    }
                );
            //ROLE TABLE

            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<Role>().HasKey(r => r.Id);
            builder.Entity<Role>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Role>().Property(r => r.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Role>().HasMany(r => r.Users).WithOne(u => u.Role).HasForeignKey(u => u.RoleId);

            builder.Entity<Role>().HasData
                (
                    new Role { Id = 1, Name = "admin" },
                    new Role { Id = 2, Name = "user" }
                );


            //USER TABLE

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(60);
            builder.Entity<User>().Property(u => u.Password).IsRequired().HasMaxLength(60);
            builder.Entity<User>().HasMany(u => u.TourBookings).WithOne(t => t.User).HasForeignKey(t => t.UserId);

            builder.Entity<User>().HasData
                (
                    new User { Id = 100, Email = "admin@gmail.com", Password = "qwerty", RoleId = 1 }
                );
        }
    }
}
