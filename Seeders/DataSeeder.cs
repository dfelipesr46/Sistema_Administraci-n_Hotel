using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaNET_DiegoFelipeSalamanca.Data;
using PruebaNET_DiegoFelipeSalamanca.Models;

namespace PruebaNET_DiegoFelipeSalamanca.Seeders
{
    public class DataSeeder
    {
        public static async Task SeedDataAsync(ApplicationDbContext context)
        {
            // Comprobar si ya existen RoomTypes
            if (await context.RoomTypes.AnyAsync())
            {
                return; // Si ya hay datos, no hacemos nada.
            }

            var roomTypes = new[]
            {
            new RoomType
            {
                Name = "Habitación Simple",
                Description = "Una acogedora habitación básica con una cama individual, ideal para viajeros solos.",
                PricePerNight = 50, // Precio por noche
                MaxOccupancyPersons = 1 // Capacidad máxima
            },
            new RoomType
            {
                Name = "Habitación Doble",
                Description = "Ofrece flexibilidad con dos camas individuales o una cama doble, perfecta para parejas o amigos.",
                PricePerNight = 80, // Precio por noche
                MaxOccupancyPersons = 2 // Capacidad máxima
            },
            new RoomType
            {
                Name = "Suite",
                Description = "Espaciosa y lujosa, con una cama king size y una sala de estar separada, ideal para quienes buscan confort y exclusividad.",
                PricePerNight = 150, // Precio por noche
                MaxOccupancyPersons = 2 // Capacidad máxima
            },
            new RoomType
            {
                Name = "Habitación Familiar",
                Description = "Diseñada para familias, con espacio adicional y varias camas para una estancia cómoda.",
                PricePerNight = 200, // Precio por noche
                MaxOccupancyPersons = 4 // Capacidad máxima
            }
        };

            await context.RoomTypes.AddRangeAsync(roomTypes);
            await context.SaveChangesAsync();

            // Llamar al método para crear las habitaciones
            SeedRooms(context);
        }

        private static void SeedRooms(ApplicationDbContext context)
        {
            // Asegúrate de que los RoomTypes estén cargados antes de crear las habitaciones.
            var roomTypes = context.RoomTypes.ToList();

            for (int i = 1; i <= 50; i++) // 50 habitaciones
            {
                var roomType = roomTypes[i % roomTypes.Count]; // Alternar entre los tipos de habitación
                var room = new Room
                {
                    RoomNumber = $"R{i}",
                    RoomTypeId = roomType.Id,
                    Availability = true,
                };
                context.Rooms.Add(room);
            }
            context.SaveChanges();
        }


        public static async Task SeedData(ApplicationDbContext context)
        {
            // Datos de habitaciones ya existentes

            // Agregar huéspedes
            var guests = AdditionalDataSeeders.GetGuests(10); // Cambia 10 por el número de huéspedes que deseas
            await context.Guests.AddRangeAsync(guests);

            // Agregar reservas
            var rooms = await context.Rooms.ToListAsync(); // Obtener habitaciones existentes
            var bookings = AdditionalDataSeeders.GetBookings(guests, rooms, 20); // Cambia 20 por el número de reservas que deseas
            await context.Bookings.AddRangeAsync(bookings);

            await context.SaveChangesAsync();
        }
    }

}
