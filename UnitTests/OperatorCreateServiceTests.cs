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
    public class OperatorCreateServiceTests
    {
        [Test]
        public async Task CreateAsync_PhoneNumberValidationSucceed_CreatesOperator()
        {
            // Arrange
            var Operator = new OperatorUpdateModel();
            var expected = new Operator();
            
            var PhoneNumberGetService = new Mock<IPhoneNumberGetService>();
            PhoneNumberGetService.Setup(x => x.ValidateAsync(Operator));

            var OperatorDataAccess = new Mock<IOperatorDataAccess>();
            OperatorDataAccess.Setup(x => x.InsertAsync(Operator)).ReturnsAsync(expected);

            var OperatorGetService = new OperatorCreateService(OperatorDataAccess.Object, PhoneNumberGetService.Object);
            
            // Act
            var result = await OperatorGetService.CreateAsync(Operator);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task CreateAsync_PhoneNumberValidationFailed_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var Operator = new OperatorUpdateModel();
            var expected = fixture.Create<string>();
            
            var PhoneNumberGetService = new Mock<IPhoneNumberGetService>();
            PhoneNumberGetService
                .Setup(x => x.ValidateAsync(Operator))
                .Throws(new InvalidOperationException(expected));

            var OperatorDataAccess = new Mock<IOperatorDataAccess>();

            var OperatorGetService = new OperatorCreateService(OperatorDataAccess.Object, PhoneNumberGetService.Object);
            
            // Act
            var action = new Func<Task>(() => OperatorGetService.CreateAsync(Operator));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            OperatorDataAccess.Verify(x => x.InsertAsync(Operator), Times.Never);
        }
    }
}