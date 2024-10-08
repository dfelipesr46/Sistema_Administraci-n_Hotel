using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET_DiegoFelipeSalamanca.Models;

namespace PruebaNET_DiegoFelipeSalamanca.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RoomStatus> RoomStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación entre RoomType y Room
            modelBuilder.Entity<Room>()
                .HasOne<RoomType>()  // Cada Room tiene un RoomType
                .WithMany(rt => rt.Rooms)  // Un RoomType puede tener muchos Rooms
                .HasForeignKey(r => r.RoomTypeId);  // Especifica que RoomTypeId es la clave foránea

            // Relación entre Room y Booking
            modelBuilder.Entity<Booking>()
                .HasOne<Room>()  // Cada Booking tiene un Room
                .WithMany(r => r.Bookings)  // Un Room puede tener muchas Bookings
                .HasForeignKey(b => b.RoomId);  // Especifica que RoomId es la clave foránea

            // Relación entre Guest y Booking
            modelBuilder.Entity<Booking>()
                .HasOne<Guest>()  // Cada Booking tiene un Guest
                .WithMany(g => g.Bookings)  // Un Guest puede tener muchas Bookings
                .HasForeignKey(b => b.GuestId);  // Especifica que GuestId es la clave foránea

            // Relación entre Employee y Booking
            modelBuilder.Entity<Booking>()
                .HasOne<Employee>()  // Cada Booking tiene un Employee
                .WithMany(e => e.Bookings)  // Un Employee puede tener muchas Bookings
                .HasForeignKey(b => b.EmployeeId);  // Especifica que EmployeeId es la clave foránea
        }
    }
}