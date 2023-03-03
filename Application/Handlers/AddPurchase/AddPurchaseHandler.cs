using Application.Handlers.AddApp;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using EasyNetQ;
using MediatR;
using System.Threading;

namespace Application.Handlers.AddPurchase;

public class AddPurchaseHandler : IRequestHandler<AddPurchaseRequestDto, string>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBus _bus;

    public AddPurchaseHandler(IUnitOfWork unitOfWork, IBus bus)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _bus = bus;
    }

    public async Task<string> Handle(AddPurchaseRequestDto request, CancellationToken cancellationToken)
    {
        var transaction = new TransactionEntity()
        {
            NumberCard = request.NumberCard,
            NameOnCreditCard = request.NameOnCreditCard,
            Cvc = request.Cvc,
            Validate = request.Validate,
            Amount = request.Amount,
            PaymentStatus = PaymentStatus.AwaitingProcessing                        
        };
        
        await _unitOfWork.TransactionRepository.Add(transaction);
        _unitOfWork.Commit();

        var purchase = new PurchaseEntity()
        {
            AppId = request.AppId,
            PersonId = request.PersonId,
            TransactionId = transaction.Id
        };

        await _unitOfWork.PurchaseRepository.Add(purchase);
        _unitOfWork.Commit();

        await PublishTransaction(transaction, cancellationToken);

        return await Task.FromResult("Pedido lançado com sucesso!");
    }

    private async Task PublishTransaction(TransactionEntity transaction, CancellationToken cancellationToken)
    {
        var transactionDto = new TransactionDto()
        {
            Id = transaction.Id,
            NumberCard = transaction.NumberCard,
            NameOnCreditCard = transaction.NameOnCreditCard,
            Cvc = transaction.Cvc,
            Validate = transaction.Validate,
            Amount = transaction.Amount,
            PaymentStatus = PaymentStatus.AwaitingProcessing
        };

        var exchange = _bus.Advanced.ExchangeDeclare("transaction", options =>
        {
            options.WithType("direct");
        }, cancellationToken: cancellationToken);

        await _bus.Advanced.PublishAsync(exchange, "", false, new Message<TransactionDto>(transactionDto), cancellationToken);
    }
}

