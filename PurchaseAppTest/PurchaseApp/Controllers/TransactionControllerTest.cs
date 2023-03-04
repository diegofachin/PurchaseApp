using Application.Handlers.AddApp;
using Application.Handlers.AddPurchase;
using AutoFixture;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PurchaseApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseAppTest.PurchaseApp.Controllers;

public class TransactionControllerTest : IDisposable
{
    protected readonly Fixture Fixture;
    protected readonly Mock<IMediator> MediatorMock;
    protected readonly PurchaseController PurchaseController;

    public TransactionControllerTest()
    {
        MediatorMock = new();
        Fixture = new Fixture();

        PurchaseController = new PurchaseController(MediatorMock.Object);
    }

    public void Dispose()
    {
        MediatorMock.Reset();

        GC.SuppressFinalize(this);
    }

    [Fact]
    public async Task AddPurchaseApp_ReturnCreated_WhenSuccess()
    {
        var request = Fixture.Create<AddPurchaseRequestDto>();
        var response = Fixture.Create<AddPurchaseResponseDto>();

        MediatorMock.Setup(
            mock => mock.Send(It.IsAny<AddPurchaseRequestDto>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(response);

        var result = await PurchaseController.AddPurchaseApp(request) as ObjectResult;

        result.StatusCode.Should().Be((int)HttpStatusCode.OK);
    }

    [Fact]
    public async Task AddPurchaseApp_ReturnError_WhenResponseIsNull()
    {
        var request = Fixture.Create<AddPurchaseRequestDto>();
        AddPurchaseResponseDto? response = null;

        MediatorMock.Setup(
            mock => mock.Send(It.IsAny<AddPurchaseRequestDto>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(response);

        var result = await PurchaseController.AddPurchaseApp(request) as BadRequestResult;

        result.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
    }
}
