using System.Diagnostics;
using HotelAdmin.API.DbContexts;
using HotelAdmin.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace HotelAdmin.UnitTests.IntegrationTests;

[TestClass]
public class HotelDatabaseTest
{
    [TestMethod]
    public void CanInsertHotelIntoDatabase()
    {
        var builder = new DbContextOptionsBuilder<HotelContext>();
        builder.UseSqlServer(
            "Data Source=localhost; Initial Catalog=hoteldbtest; User Id=sa; Password=<YourStrong@Passw0rd>; TrustServerCertificate=True");

        using (var context = new HotelContext(builder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var hotel = new Hotel("Yotel", "Argyle Street", "Scotland", "+07483792831", "www.yotel.com",
                "yotel@gmail.com");
            context.Hotels.Add(hotel);
            context.SaveChanges();

            Assert.AreNotEqual(0, hotel.Id);
        }

    }
}