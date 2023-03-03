using Application.Handlers.ListApp;
using Domain.Entities;

namespace Application.Handlers.ListApps;

public class ListAppsResponseDto
{
    public IEnumerable<App> Apps { get; set; }
}
