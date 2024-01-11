using LegacyApp.Services.Contracts;
using Moq;
using System.Media;

namespace LegacyApp.Tests
{
    public class UserServiceTests
    {
        Mock<IDateTimeService> datetimeService = new Mock<IDateTimeService>();
        Mock<IClientRepository> clientRepository = new Mock<IClientRepository>();
        Mock<IUserCreditServiceClient> userCreditServiceClient = new Mock<IUserCreditServiceClient>();
        Mock<IUserDataAccess> userDataAccess = new Mock<IUserDataAccess>();
        UserService sut;
        


        [Test]
        public void AddUser_ShouldReturnFalse_WhenMissingFirstName()
        {
            // Arrange
            string firname = "";
            string surname = "Surname";
            string email = "Email@email.com";
            DateTime dateOfBirth = new DateTime(1983, 10, 22);
            
            int clientId = 0;
            datetimeService
                .Setup(x => x.GetCurrentDateTime())
                .Returns(new DateTime(2024, 01, 09));
            sut = new UserService(datetimeService.Object,
                clientRepository.Object, 
                userCreditServiceClient.Object,
                userDataAccess.Object);

            var expected = false;

            // Act
            var actual = sut.AddUser(firname, surname, email, dateOfBirth, clientId);

            // Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void AddUser_ShouldReturnFalse_WhenMissingSurname()
        {
            // Arrange
            string firname = "FirstName";
            string surname = "";
            string email = "Email@email.com";
            DateTime dateOfBirth = new DateTime(1983, 10, 22);
            int clientId = 0;
            datetimeService
                .Setup(x => x.GetCurrentDateTime())
                .Returns(new DateTime(2024, 01, 09));
            sut = new UserService(datetimeService.Object,
                clientRepository.Object,
                userCreditServiceClient.Object,
                userDataAccess.Object);

            var expected = false;

            // Act
            var actual = sut.AddUser(firname, surname, email, dateOfBirth, clientId);

            // Assert
            Assert.That(expected, Is.EqualTo(actual));
        }

        [TestCase("igor.luna&email.com")]
        [TestCase("igor-luna0email.com")]
        public void AddUser_ShouldReturnFalse_WhenSentAnInvalidEmail(string invalidEmail)
        {
            // Arrange
            string firname = "FirstName";
            string surname = "Surname";
            string email = invalidEmail;
            DateTime dateOfBirth = new DateTime(1983, 10, 22);
            int clientId = 0;
            datetimeService
                .Setup(x => x.GetCurrentDateTime())
                .Returns(new DateTime(2024, 01, 09));
            sut = new UserService(datetimeService.Object,
                clientRepository.Object,
                userCreditServiceClient.Object,
                userDataAccess.Object);

            var expected = false;

            // Act
            var actual = sut.AddUser(firname, surname, email, dateOfBirth, clientId);

            // Assert
            Assert.That(expected, Is.EqualTo(actual));
        }


        [TestCase(2004, 01, 10)]
        [TestCase(2005, 01, 01)]
        public void AddUser_ShouldReturnFalse_WhenYougerThen21AndHasCredit(int year, int month, int day)
        {
            // Arrange
            string firname = "FirstName";
            string surname = "Surname";
            string email = "igor.luna@email.com";
            DateTime dateOfBirth = new DateTime(year, month, day);
            int clientId = 0;
            datetimeService
                .Setup(x => x.GetCurrentDateTime())
                .Returns(new DateTime(2024, 01, 09));
            sut = new UserService(
                datetimeService.Object,
                clientRepository.Object,
                userCreditServiceClient.Object,
                userDataAccess.Object);

            var expected = false;

            // Act
            var actual = sut.AddUser(firname, surname, email, dateOfBirth, clientId);

            // Assert
            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}