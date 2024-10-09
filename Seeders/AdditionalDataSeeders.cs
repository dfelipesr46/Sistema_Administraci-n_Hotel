using Bogus;
using PruebaNET_DiegoFelipeSalamanca.Models;
using System.Collections.Generic;

public class AdditionalDataSeeders
{
    public static List<Guest> GetGuests(int count)
    {
        var faker = new Faker<Guest>()
            .RuleFor(g => g.FirstName, f => f.Name.FirstName())
            .RuleFor(g => g.LastName, f => f.Name.LastName())
            .RuleFor(g => g.Email, f => f.Internet.Email())
            .RuleFor(g => g.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(g => g.IdentificationNumber, f => f.Random.Int(10000000, 99999999).ToString());

        return faker.Generate(count);
    }

    public static List<Booking> GetBookings(List<Guest> guests, List<Room> rooms, int count)
    {
        var faker = new Faker<Booking>()
            .RuleFor(b => b.StartDate, f => f.Date.Future())
            .RuleFor(b => b.EndDate, f => f.Date.Future())
            .RuleFor(b => b.GuestId, f => f.PickRandom(guests).Id)
            .RuleFor(b => b.RoomId, f => f.PickRandom(rooms).Id);

        return faker.Generate(count);
    }
}
