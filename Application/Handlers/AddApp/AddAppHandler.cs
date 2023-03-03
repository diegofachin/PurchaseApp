using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.AddApp;

public class AddAppHandler : IRequestHandler<AddAppRequestDto, string>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddAppHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<string> Handle(AddAppRequestDto request, CancellationToken cancellationToken)
    {
        AppEntity app = new()
        {
            Name = request.Name,
            Price = request.Price
        };

        await _unitOfWork.AppRepository.Add(app);
        _unitOfWork.Commit();

        return await Task.FromResult("Aplicativo cadastrado com sucesso!");
    }
}
