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

    namespace SportApp.Tests
    {
        [TestFixture]
        public class UserRepositoryTests
        {
            private Mock<UserManager<User>> _mockUserManager;
            private Mock<IUnitOfWork> _mockUnitOfWork;
            private Mock<IUrlHelper> _mockUrlHelper;
            private UserRepository _userRepository;
            private SportAppDbContext _context;

            [SetUp]
            public void Setup()
            {
                var options = new DbContextOptionsBuilder<SportAppDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase")
                    .Options;
                _context = new SportAppDbContext(options);
                _mockUserManager = new Mock<UserManager<User>>(
                    Mock.Of<IUserStore<User>>(),
                    null, null, null, null, null, null, null, null);
                _mockUnitOfWork = new Mock<IUnitOfWork>();
                _mockUrlHelper = new Mock<IUrlHelper>();
                _userRepository = new UserRepository(_context, _mockUserManager.Object, _mockUnitOfWork.Object, _mockUrlHelper.Object);
                var mockUser = new User
                {
                    Id = new Guid(),
                    UserName = "user@example.com",
                    Email = "user@example.com",
                    Avatar = "old-avatar.png"
                };
                _context.Users.Add(mockUser);
                _context.SaveChanges();
            }

            [Test]
            public async Task SignIn_ShouldReturnUser_WhenCredentialsAreValid()
            {
                var signInModel = new SignInModel
                {
                    Email = "user@example.com",
                    Password = "Password123!"
                };

                var mockUser = new User { UserName = "user@example.com", Email = "user@example.com" };

                _mockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                                .ReturnsAsync(mockUser);

                _mockUserManager.Setup(x => x.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>()))
                                .ReturnsAsync(true);

                // Act
                var result = await _userRepository.SignIn(signInModel);

                // Assert
                ClassicAssert.NotNull(result);
                ClassicAssert.AreEqual("user@example.com", result.Email);
            }

            [Test]
            public async Task SignIn_ShouldThrowAppException_WhenUserNotFound()
            {
                var signInModel = new SignInModel
                {
                    Email = "nonexistent@example.com",
                    Password = "Password123!"
                };

                _mockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                                .ReturnsAsync((User)null);
                var ex = Assert.ThrowsAsync<AppException>(async () => await _userRepository.SignIn(signInModel));
                Assert.That(ex.Message, Is.EqualTo(ErrorMessage.EmailNotExist));
            }

            [Test]
            public async Task SignIn_ShouldThrowAppException_WhenPasswordIsIncorrect()
            {
                var signInModel = new SignInModel
                {
                    Email = "user@example.com",
                    Password = "IncorrectPassword"
                };

                var mockUser = new User { UserName = "user@example.com", Email = "user@example.com" };

                _mockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                                .ReturnsAsync(mockUser);

                _mockUserManager.Setup(x => x.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>()))
                                .ReturnsAsync(false);
                var ex = Assert.ThrowsAsync<AppException>(async () => await _userRepository.SignIn(signInModel));
                Assert.That(ex.Message, Is.EqualTo(ErrorMessage.WrongPassword));
            }
            [Test]
            public async Task SignUp_EmailExist()
            {
                var signUpModel = new SignUpRequest
                {
                    Email = "test@gmail.com",
                    Password = "Test@1092002",
                    ConfirmPassword = "Test@1092002",
                    FirstName = "Unit",
                    LastName = "Test"
                };
                var mockUser = new User { UserName = "user@example.com", Email = "user@example.com" };
                _mockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                                .ReturnsAsync(mockUser);
                var ex = Assert.ThrowsAsync<AppException>(async () => await _userRepository.SignUp(signUpModel));
                Assert.That(ex.Message, Is.EqualTo(ErrorMessage.EmailExist));
            }
            [Test]
            public async Task SignUp_Success()
            {
                var signUpModel = new SignUpRequest
                {
                    Email = "test@gmail.com",
                    Password = "Test@1092002",
                    ConfirmPassword = "Test@1092002",
                    FirstName = "Unit",
                    LastName = "Test"
                };
                _mockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((User)null);
                var mockUser = new User
                {
                    UserName = "test@gmail.com",
                    Email = "test@gmail.com",
                    FirstName = "Unit",
                    LastName = "Test"
                };
                var mockIdentityResult = IdentityResult.Success;
                _mockUserManager.Setup(x => x.CreateAsync(It.IsAny<User>(), signUpModel.Password))
                    .ReturnsAsync(mockIdentityResult);
                var result = await _userRepository.SignUp(signUpModel);
                ClassicAssert.NotNull(result);
            }
            [Test]
            public async Task UpdateAvater_Success()
            {
                var updateAvatarModel = new UpdateAvatarModel
                {
                    UserId = _context.Users.First().Id,
                    Avatar = "image.png"
                };
                var options = new DbContextOptionsBuilder<SportAppDbContext>()
                    .UseInMemoryDatabase(databaseName: "TestDatabase")
                    .Options;
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == updateAvatarModel.UserId);
                if (user == null)
                {
                    throw new AppException("User is not exist");
                }
                var result = await _userRepository.UpdateAvatar(updateAvatarModel);
                ClassicAssert.AreEqual(true, result);

            }
            [Test]
            public async Task ConfirmEmail_Fail()
            {
                var token = "token";
                var email = "test@gmail.com";
                _mockUserManager.Setup(x => x.FindByNameAsync(It.IsAny<string>()))
                    .ReturnsAsync((User)null);
                var result = await _userRepository.ConfirmEmail(token, email);
                ClassicAssert.AreEqual(false, result);
            }
            [Test]
            public async Task ConfirmEmail_Success()
            {
                var token = "token";
                var email = "test@gmail.com";
                var mockUser = new User
                {
                    Email = email,
                };
                _mockUserManager.Setup(x => x.FindByNameAsync(It.IsAny<string>()))
                    .ReturnsAsync(mockUser);
                var mockIdentityResult = IdentityResult.Success;
                _mockUserManager.Setup(x => x.ConfirmEmailAsync(mockUser, token)).ReturnsAsync(mockIdentityResult);
                var result = await _userRepository.ConfirmEmail(token, email);
                ClassicAssert.AreEqual(true, result);
            }
            [Test]
            public async Task ConfirmEmail_ConfirmFail()
            {
                var token = "token";
                var email = "test@gmail.com";
                var mockUser = new User
                {
                    Email = email,
                };
                _mockUserManager.Setup(x => x.FindByNameAsync(It.IsAny<string>()))
                    .ReturnsAsync(mockUser);
                _mockUserManager.Setup(x => x.ConfirmEmailAsync(mockUser, token)).ReturnsAsync(IdentityResult.Failed());
                var result = await _userRepository.ConfirmEmail(token, email);
                ClassicAssert.AreEqual(false, result);
            }
            [Test]
            public async Task ForgetPassword_EmailNotExist_ReturnFail()
            {
                var email = "test@gmail.com";
                _mockUserManager.Setup(x => x.FindByEmailAsync(email)).ReturnsAsync((User)null);
                var ex = Assert.ThrowsAsync<AppException>(async () => await _userRepository.ForgetPassword(email));
                Assert.That(ex.Message, Is.EqualTo(ErrorMessage.EmailNotExist));
            }
            [Test]
            public async Task ForgetPassword_Success()
            {
                var email = "test@example.com";
                var user = new User { Email = email };
                var token = "reset_token";
                var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                var expectedLink = "http://example.com/ResetPassword?decodedToken=" + encodedToken;

                _mockUserManager.Setup(x => x.FindByEmailAsync(email))
                                .ReturnsAsync(user);

                _mockUserManager.Setup(x => x.GeneratePasswordResetTokenAsync(user))
                                .ReturnsAsync(token);

                _mockUrlHelper.Setup(x => x.Action(It.IsAny<UrlActionContext>()))
                  .Returns(expectedLink);
                var result = await _userRepository.ForgetPassword(email);
                ClassicAssert.IsNotNull(result);
                ClassicAssert.AreEqual(email, result.Email);
                ClassicAssert.AreEqual(expectedLink, result.Link);
            }
            [Test]
            public async Task GetConfirmEmail_EmailNotFound()
            {
                var email = "test@gmail.com";
                _mockUserManager.Setup(x => x.FindByEmailAsync(email)).ReturnsAsync((User)null);
                var ex = Assert.ThrowsAsync<AppException>(async () => await _userRepository.GetConfirmEmail(email));
                Assert.That(ex.Message, Is.EqualTo(ErrorMessage.EmailNotExist));
            }
            [Test]
            public async Task GetConfirmEmail_EmailNotConfirmed()
            {
                var email = "test@example.com";
                var user = new User { UserName = email, EmailConfirmed = true };
                _mockUserManager.Setup(x => x.FindByNameAsync(email)).ReturnsAsync(user);
                var ex = Assert.ThrowsAsync<AppException>(() => _userRepository.GetConfirmEmail(email));
                Assert.That(ex.Message, Is.EqualTo(ErrorMessage.AccountConfirmed));
            }
            [Test]
            public async Task GetConfirmEmail_Success()
            {
                var email = "test@example.com";
                var user = new User { UserName = email, EmailConfirmed = false };
                var token = "test_token";
                var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
                var expectedLink = $"http://example.com/ConfirmEmail?endcodedToken={encodedToken}&email={email}";

                _mockUserManager.Setup(x => x.FindByNameAsync(email)).ReturnsAsync(user);
                _mockUserManager.Setup(x => x.GenerateEmailConfirmationTokenAsync(user)).ReturnsAsync(token);
                _mockUrlHelper.Setup(x => x.Action(It.IsAny<UrlActionContext>())).Returns(expectedLink);
                var result = await _userRepository.GetConfirmEmail(email);
                ClassicAssert.IsNotNull(result);
                ClassicAssert.AreEqual(email, result.Email);
                ClassicAssert.AreEqual(expectedLink, result.Link);
            }
        }
    }


}




