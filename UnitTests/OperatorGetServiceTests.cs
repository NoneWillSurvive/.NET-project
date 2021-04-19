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
    public class OperatorGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_OperatorExists_DoesNothing()
        {
            // Arrange
            var OperatorContainer = new Mock<IOperatorContainer>();

            var Operator = new Operator();
            var OperatorDataAccess = new Mock<IOperatorDataAccess>();
            OperatorDataAccess.Setup(x => x.GetByAsync(OperatorContainer.Object)).ReturnsAsync(Operator);

            var OperatorGetService = new OperatorGetService(OperatorDataAccess.Object);

            // Act
            var action = new Func<Task>(() => OperatorGetService.ValidateAsync(OperatorContainer.Object));

            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task ValidateAsync_OperatorNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();

            var OperatorContainer = new Mock<IOperatorContainer>();
            OperatorContainer.Setup(x => x.OperatorId).Returns(id);

            var Operator = new Operator();
            var OperatorDataAccess = new Mock<IOperatorDataAccess>();
            OperatorDataAccess.Setup(x => x.GetByAsync(OperatorContainer.Object))
                .ReturnsAsync((Operator) null);

            var OperatorGetService = new OperatorGetService(OperatorDataAccess.Object);

            // Act
            var action = new Func<Task>(() => OperatorGetService.ValidateAsync(OperatorContainer.Object));

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Operator not found by id {id}");
        }
    }
}