using NUnit.Framework;
using Microsoft.AspNetCore.Identity;
using Moq;
using SportApp_Domain.Entities;
using SportApp_Infrastructure;
using SportApp_Infrastructure.Model.UserModel;
using SportApp_Infrastructure.Repositories;
using SportApp_Infrastructure.Repositories.Interfaces;
using NUnit.Framework.Legacy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace UnitTest
{
    using Moq;
    using NUnit.Framework;
    using SportApp_Infrastructure.Repositories;
    using SportApp_Domain.Entities;
    using SportApp_Infrastructure.Model.UserModel;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using SportApp_Infrastructure;
    using SportApp_Infrastructure.Dto.UserDto;
    using System.Linq.Expressions;
    using Microsoft.Identity.Client;
    using Microsoft.AspNetCore.WebUtilities;
    using System.Text;
    using Microsoft.AspNetCore.Mvc.Routing;
    using System.Diagnostics;
    using SportApp_Infrastructure.Helper;
    using SportApp_Infrastructure.Model.SportFieldModel;
    using SportApp_Infrastructure.Model.BookingModel;
    using Castle.Core.Resource;

    namespace SportApp.Tests
    {
        [TestFixture]
        public class BookingRepositoryTests
        {
            private Mock<IUnitOfWork> _mockUnitOfWork;
            private BookingRepository _bookingRepository;
            private SportAppDbContext _context;

            [SetUp]
            public void Setup()
            {
                var options = new DbContextOptionsBuilder<SportAppDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase")
                    .Options;
                _context = new SportAppDbContext(options);
                _mockUnitOfWork = new Mock<IUnitOfWork>();
                _bookingRepository = new BookingRepository(_context, _mockUnitOfWork.Object);
            }
            [Test]
            public async Task Create_Success()
            {
                var model = new CreateBookingModel
                {
                    Name = "test booking",
                    CustomerId = Guid.NewGuid(),
                    SportFieldId = Guid.NewGuid(),
                    TotalPrice = 100000,
                    BookingDate = DateTime.Now,
                };
                var result = await _bookingRepository.Create(model);
                ClassicAssert.AreEqual(model.Name,result.Name);
                ClassicAssert.AreEqual(model.CustomerId, result.CustomerId);
                ClassicAssert.AreEqual(model.SportFieldId, result.SportFieldId);
                ClassicAssert.AreEqual(model.TotalPrice, result.TotalPrice);
                ClassicAssert.AreEqual(model.BookingDate, result.BookingDate);
            }

        }
    }


}