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

    namespace SportApp.Tests
    {
        [TestFixture]
        public class SportFieldRepositoryTests
        {
            private Mock<IUnitOfWork> _mockUnitOfWork;
            private SportFieldRepository _sportFieldRepository;
            private SportAppDbContext _context;

            [SetUp]
            public void Setup()
            {
                var options = new DbContextOptionsBuilder<SportAppDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase")
                    .Options;
                _context = new SportAppDbContext(options);
                _mockUnitOfWork = new Mock<IUnitOfWork>();
                _sportFieldRepository = new SportFieldRepository(_context, _mockUnitOfWork.Object);
                var mockSportField = new SportField
                {
                    Name = "test name",
                    Sport = "test sport",
                    Address = "test address",
                    Description = "test description",
                    FieldTypeId = Guid.NewGuid(),
                    OwnerId = Guid.NewGuid(),
                    EndPoint = CreateEndpoint.AddEndpoint("test name"),
                    Latitude = null,
                    Longitude = null,
                };
                _context.SportField.Add(mockSportField);
                _context.SaveChanges();
            }
            [Test]
            public async Task Create_DuplicateName()
            {
                var mockSportField = _context.SportField.First();
                var model = new CreateSportFieldModel
                {
                    Name = mockSportField.Name,
                    Sport = mockSportField.Sport,
                    Address = mockSportField.Address,
                    Description = mockSportField.Description,
                    FieldTypeId = mockSportField.FieldTypeId,
                    OwnerId = mockSportField.OwnerId,
                };
                var ex = Assert.ThrowsAsync<AppException>(async () => await _sportFieldRepository.Create(model));
                Assert.That(ex.Message, Is.EqualTo(ErrorMessage.SportFieldExist));
            }
            [Test]
            public async Task Create_Success()
            {
                var model = new CreateSportFieldModel
                {
                    Name = "test name",
                    Sport = "test sport",
                    Address = "test address",
                    Description = "test description",
                    FieldTypeId = Guid.NewGuid(),
                    OwnerId = Guid.NewGuid(),
                };
                var result = await _sportFieldRepository.Create(model);
                ClassicAssert.AreEqual(model.Name, result.Name);
                ClassicAssert.AreEqual(model.Sport, result.Sport);
                ClassicAssert.AreEqual(model.Address, result.Address);
                ClassicAssert.AreEqual(model.Description, result.Description);
                ClassicAssert.AreEqual(model.FieldTypeId, result.FieldTypeId);
                ClassicAssert.AreEqual(model.OwnerId, result.OwnerId);
            }
            [Test]
            public async Task Delete_SportFieldNotFound()
            {
                var sportFieldId = Guid.NewGuid();
                var ex = Assert.ThrowsAsync<AppException>(async () => await _sportFieldRepository.Delete(sportFieldId));
                Assert.That(ex.Message, Is.EqualTo(ErrorMessage.SportFieldNotExist));
            }
            [Test]
            public async Task Delete_Success()
            {
                var sportField = _context.SportField.First();
                var sportFieldId = sportField.Id;
                var result = await _sportFieldRepository.Delete(sportFieldId);
                ClassicAssert.AreEqual(true, result);
            }
            [Test]
            public async Task Update_DuplicateName()
            {
                var sportField = _context.SportField.First();
                var model = new UpdateSportFieldModel
                {
                    SportFieldId = Guid.NewGuid(),
                    Name = "test name",
                    Sport = "test sport",
                    Address = "test address",
                    Description = "test description"
                };
                var ex = Assert.ThrowsAsync<AppException>(async () => await _sportFieldRepository.Update(model));
                Assert.That(ex.Message, Is.EqualTo(ErrorMessage.SportFieldNameExist));
            }
            [Test]
            public async Task Update_SportFieldNotFound()
            {
                var sportField = _context.SportField.First();
                var model = new UpdateSportFieldModel
                {
                    SportFieldId = sportField.Id,
                    Name = "test",
                    Sport = "test sport",
                    Address = "test address",
                    Description = "test description"
                };
                var result = await _sportFieldRepository.Update(model);
                ClassicAssert.AreEqual(true, result);
            }

        }
    }


}