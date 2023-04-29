using HotelAdmin.API.DbContexts;
using HotelAdmin.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace HotelAdmin.UnitTests.IntegrationTests;

[TestClass]
public class InMemoryTests
{
    [TestMethod]
    public void CanInsertHotelIntoDatabase()
    {
        var builder = new DbContextOptionsBuilder<HotelContext>();
        builder.UseInMemoryDatabase("CanInsertHotel");

        using (var context = new HotelContext(builder.Options))
        {
            var hotel = new Hotel(
                "Yotel",
                "123 Fake Street",
                "Scotland",
                "+018533423",
                "www.yotel.com",
                "yotel@gmail.com");

            context.Hotels.Add(hotel);
            Assert.AreEqual(EntityState.Added, context.Entry(hotel).State);
        }
    }
}