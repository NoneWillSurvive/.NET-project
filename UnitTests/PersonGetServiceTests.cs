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

{ [TestFixture]
    public class PersonGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_PersonExists_DoesNothing()
        {
            // Arrange
            var PersonContainer = new Mock<IPersonContainer>();

            var Person = new Person();
            var PersonDataAccess = new Mock<IPersonDataAccess>();
            PersonDataAccess.Setup(x => x.GetByAsync(PersonContainer.Object)).ReturnsAsync(Person);

            var PersonGetService = new PersonGetService(PersonDataAccess.Object);

            // Act
            var action = new Func<Task>(() => PersonGetService.ValidateAsync(PersonContainer.Object));

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_PersonNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var PersonContainer = new Mock<IPersonContainer>();
            PersonContainer.Setup(x => x.PersonId).Returns(id);

            var Person = new Person();
            var PersonDataAccess = new Mock<IPersonDataAccess>();
            PersonDataAccess.Setup(x => x.GetByAsync(PersonContainer.Object)).ReturnsAsync((Person) null);

            var PersonGetService = new PersonGetService(PersonDataAccess.Object);

            // Act
            var action = new Func<Task>(() => PersonGetService.ValidateAsync(PersonContainer.Object));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Person not found by id {id}");
        }
    }
}