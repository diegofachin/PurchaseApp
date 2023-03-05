using Application.Handlers.AddApp;
using AutoFixture;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseAppTest.Application.Handlers.AddApp;

public class AddAppHandlerTest : IDisposable
{
    protected readonly Fixture Fixture;
    protected readonly Mock<IUnitOfWork> UnitOfWorkMock;
    protected readonly Mock<IAppRepository> AppRepositoryMock;
    protected readonly AddAppHandler AddAppHandler;

    public AddAppHandlerTest()
    {
        UnitOfWorkMock = new();
        AppRepositoryMock = new();
        Fixture = new Fixture();

        UnitOfWorkMock.Setup(mock => mock.AppRepository).Returns(AppRepositoryMock.Object);

        AddAppHandler = new AddAppHandler(UnitOfWorkMock.Object);
    }

    public void Dispose()
    {
        UnitOfWorkMock.Reset();

        GC.SuppressFinalize(this);
    }

    [Fact]
    public async Task AddCreditCardHandler_ReturnCreated_WhenSuccess()
    {
        var request = Fixture.Create<AddAppRequestDto>();

        var result = await AddAppHandler.Handle(request, CancellationToken.None);

        AppRepositoryMock.Verify(m => m.Add(It.IsAny<AppEntity>()), Times.Once);
        UnitOfWorkMock.Verify(m => m.Commit(), Times.Once);

        result.Id.Should().NotBeEmpty();
    }

    [Fact]
    public async Task AddCreditCardHandler_ReturnError_WhenIsInvalid()
    {
        var request = Fixture.Create<AddAppRequestDto>();

        UnitOfWorkMock.Setup(m => m.Commit()).Throws(new Exception());

        Func<Task> action = async () => await AddAppHandler.Handle(request, CancellationToken.None);

        await action.Should().ThrowAsync<Exception>();

        AppRepositoryMock.Verify(m => m.Add(It.IsAny<AppEntity>()), Times.Once);
        UnitOfWorkMock.Verify(m => m.Commit(), Times.Once);
    }
}
