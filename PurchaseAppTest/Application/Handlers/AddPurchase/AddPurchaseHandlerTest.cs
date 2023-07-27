using Application.Handlers.AddApp;
using Application.Handlers.AddPurchase;
using AutoFixture;
using Domain.Entities;
using Domain.Interfaces;
using EasyNetQ;
using EasyNetQ.Topology;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseAppTest.Application.Handlers.AddPurchase;

public class AddPurchaseHandlerTest : IDisposable
{
    protected readonly Fixture Fixture;
    protected readonly Mock<IBus> BusMock;
    protected readonly Mock<IUnitOfWork> UnitOfWorkMock;
    protected readonly Mock<ITransactionRepository> TransactionRepositoryMock;
    protected readonly Mock<IPurchaseRepository> PurchaseRepositoryMock;
    protected readonly AddPurchaseHandler AddPurchaseHandler;

    public AddPurchaseHandlerTest()
    {
        BusMock = new();
        UnitOfWorkMock = new();
        TransactionRepositoryMock = new();
        PurchaseRepositoryMock = new();
        Fixture = new Fixture();

        UnitOfWorkMock.Setup(mock => mock.TransactionRepository).Returns(TransactionRepositoryMock.Object);
        UnitOfWorkMock.Setup(mock => mock.PurchaseRepository).Returns(PurchaseRepositoryMock.Object);

        AddPurchaseHandler = new AddPurchaseHandler(UnitOfWorkMock.Object, BusMock.Object);
    }

    public void Dispose()
    {
        UnitOfWorkMock.Reset();

        GC.SuppressFinalize(this);
    }

    [Fact]
    public async Task AddPurchaseHandler_ReturnCreated_WhenSuccess()
    {
        var request = Fixture.Create<AddPurchaseRequestDto>();
        var exchange = Fixture.Create<Exchange>();
                
        BusMock.Setup(
           mock => mock.Advanced.ExchangeDeclareAsync(It.IsAny<string>(), 
            It.IsAny<Action<IExchangeDeclareConfiguration>>(),
            It.IsAny<CancellationToken>())
        ).ReturnsAsync(exchange);       
        
        var result = await AddPurchaseHandler.Handle(request, CancellationToken.None);

        TransactionRepositoryMock.Verify(m => m.Add(It.IsAny<TransactionEntity>()), Times.Once);
        PurchaseRepositoryMock.Verify(m => m.Add(It.IsAny<PurchaseEntity>()), Times.Once);
        UnitOfWorkMock.Verify(m => m.Commit(), Times.Exactly(2));

        result.Id.Should().NotBeEmpty();
    }

    [Fact]
    public async Task AddPurchaseHandler_ReturnError_WhenInvalidErrado()
    {
        var request = Fixture.Create<AddPurchaseRequestDto>();

        UnitOfWorkMock.Setup(m => m.Commit()).Throws(new Exception());

        Func<Task> action = async () => await AddPurchaseHandler.Handle(request, CancellationToken.None);

        await action.Should().ThrowAsync<Exception>();

        TransactionRepositoryMock.Verify(m => m.Add(It.IsAny<TransactionEntity>()), Times.Once);
        UnitOfWorkMock.Verify(m => m.Commit(), Times.Once);
    }
}
