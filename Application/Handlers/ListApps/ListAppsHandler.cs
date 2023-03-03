using Application.Handlers.ListApp;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.ListApps;

public class ListAppsHandler : IRequestHandler<ListAppsRequestDto, ListAppsResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public ListAppsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ListAppsResponseDto> Handle(ListAppsRequestDto request, CancellationToken cancellationToken)
    {
        var appsRepository = await _unitOfWork.AppRepository.GetAll();
        if (appsRepository is null)
            return null;

        List<App> apps = new();

        foreach (AppEntity app in appsRepository)
        {
            var addApp = new App()
            {
                Name = app.Name,
                Price = app.Price
            };

            apps.Add(addApp);            
        }

        var listAppResponseDto = new ListAppsResponseDto()
        {
            Apps = apps
        };

        return listAppResponseDto;
    }
}
