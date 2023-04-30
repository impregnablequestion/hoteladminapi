using System.Diagnostics;
using HotelAdmin.API.DbContexts;
using HotelAdmin.API.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        using var context = new HotelContext(builder.Options);
        
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

    [TestMethod]
    public void CanInsertRoomIntoDatabase()
    {
        var builder = new DbContextOptionsBuilder<HotelContext>();
        builder.UseInMemoryDatabase("CanInsertHotel");
        using var context = new HotelContext(builder.Options);
        
        var hotel = new Hotel(
            "Yotel",
            "123 Fake Street",
            "Scotland",
            "+018533423",
            "www.yotel.com",
            "yotel@gmail.com");

        context.Hotels.Add(hotel);
        
        hotel.Rooms.Add(new Room(4, 80.00m));

        context.SaveChanges();

        Assert.AreEqual(1, context.Rooms.ToList().Count());
    }
    
    /*
    [TestMethod]
    public void CantInsertIfEmailIsInvalid()
    {
        var builder = new DbContextOptionsBuilder<HotelContext>();
        builder.UseInMemoryDatabase("CantInsertIfEmailIsInvalid");
        using var context = new HotelContext(builder.Options);
        {
            var hotel = new Hotel(
                "Yotel",
                "123 Fake Street",
                "Scotland",
                "+018533423",
                "www.yotel.com",
                "fjiod");
    
            context.Hotels.Add(hotel);
            context.SaveChanges();
            
            
            
            Assert.AreEqual(0, context.Hotels.Count());
        }
    }
    
    [TestMethod]
    public void CantInsertIfPhoneNoIsInvalid()
    {
        var builder = new DbContextOptionsBuilder<HotelContext>();
        builder.UseInMemoryDatabase("CantInsertIfPhoneNoIsInvalid");
        using var context = new HotelContext(builder.Options);
        {
            var hotel = new Hotel(
                "Yotel",
                "123 Fake Street",
                "Scotland",
                "this is not a phonenumber",
                "www.yotel.com",
                "yotel@gmail.com");
    
            context.Hotels.Add(hotel);
            context.SaveChanges();
            
            Assert.AreEqual(0, context.Hotels.Count());
        }
    }
    
    [TestMethod]
    public void CantInsertIfWebsiteIsNotAUrl()
    {
        var builder = new DbContextOptionsBuilder<HotelContext>();
        builder.UseInMemoryDatabase("CantInsertIfWebsiteIsNotaUrl");
        using var context = new HotelContext(builder.Options);
        {
            var hotel = new Hotel(
                "Yotel",
                "123 Fake Street",
                "Scotland",
                "+07871938721",
                "this is not a website",
                "yotel@gmail.com");
    
            context.Hotels.Add(hotel);
            context.SaveChanges();
            
            Assert.AreEqual(0, context.Hotels.Count());
        }
    }
    public void CantInsertIfNameIsDuplicate()
    {
        var builder = new DbContextOptionsBuilder<HotelContext>();
        builder.UseInMemoryDatabase("");
        using var context = new HotelContext(builder.Options);
        {
            var hotel = new Hotel(
                "Yotel",
                "123 Fake Street",
                "Scotland",
                "+07871938721",
                "www.yotel.com",
                "yotel@gmail.com");
            var hotel2 = new Hotel(
                "Yotel",
                "123 Fake Street",
                "Scotland",
                "+07871938721",
                "www.yotel.com",
                "yotel@gmail.com");
    
            context.Hotels.Add(hotel);
            context.Hotels.Add(hotel2);
            context.SaveChanges();
            
            Assert.AreEqual(1, context.Hotels.Count());
        }
    }
    */
    
}