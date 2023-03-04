using Application.Handlers.AddApp;
using Application.Handlers.ListApps;
using AutoFixture;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PurchaseApp.Controllers;
using System.Net;

namespace PurchaseAppTest.PurchaseApp.Controllers;

public class AppControllerTest : IDisposable
{
    protected readonly Fixture Fixture;
    protected readonly Mock<IMediator> MediatorMock;
    protected readonly AppController AppController;

    public AppControllerTest()
    {
        MediatorMock = new();
        Fixture = new Fixture();

        AppController = new AppController(MediatorMock.Object);
    }

    public void Dispose()
    {
        MediatorMock.Reset();

        GC.SuppressFinalize(this);
    }

    [Fact]
    public async Task AddApp_ReturnCreated_WhenSuccess()
    {
        var request = Fixture.Create<AddAppRequestDto>();
        var response = Fixture.Create<AddAppResponseDto>();

        MediatorMock.Setup(
            mock => mock.Send(It.IsAny<AddAppRequestDto>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(response);

        var result = await AppController.AddAppAsync(request) as ObjectResult;

        result.StatusCode.Should().Be((int)HttpStatusCode.OK);
    }

    [Fact]
    public async Task AddApp_ReturnError_WhenResponseIsNull()
    {
        var request = Fixture.Create<AddAppRequestDto>();
        AddAppResponseDto? response = null;

        MediatorMock.Setup(
            mock => mock.Send(It.IsAny<AddAppRequestDto>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(response);

        var result = await AppController.AddAppAsync(request) as BadRequestResult;

        result.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task ListApp_ReturnApps_WhenExist()
    {
        var request = Fixture.Create<ListAppsRequestDto>();
        var response = Fixture.Create<ListAppsResponseDto>();

        MediatorMock.Setup(
            mock => mock.Send(It.IsAny<ListAppsRequestDto>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(response);

        var result = await AppController.ListAppAsync() as ObjectResult;

        result.StatusCode.Should().Be((int)HttpStatusCode.OK);
    }

    [Fact]
    public async Task AddApp_ReturnNoContent_WhenResponseIsNull()
    {
        var request = Fixture.Create<ListAppsRequestDto>();
        ListAppsResponseDto? response = null;

        MediatorMock.Setup(
            mock => mock.Send(It.IsAny<ListAppsRequestDto>(), It.IsAny<CancellationToken>())
        ).ReturnsAsync(response);

        var result = await AppController.ListAppAsync() as NoContentResult;

        result.StatusCode.Should().Be((int)HttpStatusCode.NoContent);
    }
}
