using System;
using System.Threading.Tasks;
using AutoFixture;
using BLL.Contracts;
using BLL.Implementation;
using DataAccess.Contracts;
using Domain;
using Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BLL.TestsUnit
{
    public class PersonCreateServiceTests
    {
        [Test]
        public async Task CreateAsync_PhoneNumberValidationSucceed_CreatesPerson()
        {
            // Arrange
            var Person = new PersonUpdateModel();
            var expected = new Person();
            
            var PhoneNumberGetService = new Mock<IPhoneNumberGetService>();
            PhoneNumberGetService.Setup(x => x.ValidateAsync(Person));

            var PersonDataAccess = new Mock<IPersonDataAccess>();
            PersonDataAccess.Setup(x => x.InsertAsync(Person)).ReturnsAsync(expected);

            var PersonGetService = new PersonCreateService(PersonDataAccess.Object, PhoneNumberGetService.Object);
            
            // Act
            var result = await PersonGetService.CreateAsync(Person);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_PhoneNumberValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var Person = new PersonUpdateModel();
            var expected = fixture.Create<string>();
            
            var PhoneNumberGetService = new Mock<IPhoneNumberGetService>();
            PhoneNumberGetService
                .Setup(x => x.ValidateAsync(Person))
                .Throws(new InvalidOperationException(expected));

            var PersonDataAccess = new Mock<IPersonDataAccess>();

            var PersonGetService = new PersonCreateService(PersonDataAccess.Object, PhoneNumberGetService.Object);
            
            // Act
            var action = new Func<Task>(() => PersonGetService.CreateAsync(Person));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            PersonDataAccess.Verify(x => x.InsertAsync(Person), Times.Never);
        }
    }
}