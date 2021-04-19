using System;
using System.Threading.Tasks;
using AutoFixture;
using BLL.Implementation;
using DataAccess.Contracts;
using Domain;
using Domain.Contracts;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BLL.TestsUnit
{
    [TestFixture]
    public class PhoneNumberGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_PhoneNumberExists_DoesNothing()
        {
            // Arrange
            var PhoneNumberContainer = new Mock<IPhoneNumberContainer>();

            var PhoneNumber = new PhoneNumber();
            var PhoneNumberDataAccess = new Mock<IPhoneNumberDataAccess>();
            PhoneNumberDataAccess.Setup(x => x.GetByAsync(PhoneNumberContainer.Object)).ReturnsAsync(PhoneNumber);

            var PhoneNumberGetService = new PhoneNumberGetService(PhoneNumberDataAccess.Object);

            // Act
            var action = new Func<Task>(() => PhoneNumberGetService.ValidateAsync(PhoneNumberContainer.Object));

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_PhoneNumberNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var PhoneNumberContainer = new Mock<IPhoneNumberContainer>();
            PhoneNumberContainer.Setup(x => x.PhoneNumberId).Returns(id);

            var PhoneNumber = new PhoneNumber();
            var PhoneNumberDataAccess = new Mock<IPhoneNumberDataAccess>();
            PhoneNumberDataAccess.Setup(x => x.GetByAsync(PhoneNumberContainer.Object)).ReturnsAsync((PhoneNumber) null);

            var PhoneNumberGetService = new PhoneNumberGetService(PhoneNumberDataAccess.Object);

            // Act
            var action = new Func<Task>(() => PhoneNumberGetService.ValidateAsync(PhoneNumberContainer.Object));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"PhoneNumber not found by id {id}");
        }
    }
}