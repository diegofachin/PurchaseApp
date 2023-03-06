using Application.Handlers.ListApps;
using AutoFixture;
using Bogus;
using Domain.Entities;
using Domain.Interfaces;
using FluentAssertions;
using Moq;

namespace PurchaseAppTest.Application.Handlers.ListApps;

public class ListAppsHandlerTest : IDisposable
{
    protected readonly Fixture Fixture;
    protected readonly Faker Faker;
    protected readonly Mock<IUnitOfWork> UnitOfWorkMock;
    protected readonly Mock<IAppRepository> AppRepositoryMock;
    protected readonly ListAppsHandler ListAppsHandler;

    public ListAppsHandlerTest()
    {
        UnitOfWorkMock = new();
        AppRepositoryMock = new();
        Fixture = new Fixture();
        Faker = new Faker();

        UnitOfWorkMock.Setup(mock => mock.AppRepository).Returns(AppRepositoryMock.Object);

        ListAppsHandler = new ListAppsHandler(UnitOfWorkMock.Object);
    }

    public void Dispose()
    {
        UnitOfWorkMock.Reset();

        GC.SuppressFinalize(this);
    }

    [Fact]
    public async Task ListAppsHandler_ReturnList_WhenExist()
    {
        var request = Fixture.Create<ListAppsRequestDto>();
        var listApps = new List<AppEntity>()
        {
            new AppEntity()
            {
                Name = Faker.Random.AlphaNumeric(200),
                Price = Faker.Random.Decimal(0,1000),
            },
            new AppEntity()
            {
                Name = Faker.Random.AlphaNumeric(200),
                Price = Faker.Random.Decimal(0,1000),
            }
        };

        AppRepositoryMock.Setup(
           mock => mock.GetAll()
        ).ReturnsAsync(listApps);

        var result = await ListAppsHandler.Handle(request, CancellationToken.None);

        AppRepositoryMock.Verify(m => m.GetAll(), Times.Once);

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task ListAppsHandler_ReturnNoContent_WhenIsNull()
    {
        var request = Fixture.Create<ListAppsRequestDto>();
        List<AppEntity> listApps = null;

        AppRepositoryMock.Setup(
           mock => mock.GetAll()
        ).ReturnsAsync(listApps);

        var result = await ListAppsHandler.Handle(request, CancellationToken.None);

        AppRepositoryMock.Verify(m => m.GetAll(), Times.Once);

        result.Should().BeNull();

    }
}
