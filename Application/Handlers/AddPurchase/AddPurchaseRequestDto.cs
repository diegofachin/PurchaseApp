using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.AddPurchase;

public class AddPurchaseRequestDto : IRequest<AddPurchaseResponseDto>
{
    public Guid PersonId { get; set; }

    public Guid AppId { get; set; }

    public string NumberCard { get; set; }

    public string NameOnCreditCard { get; set; }

    public string Validate { get; set; }

    public string Cvc { get; set; }

    public decimal Amount { get; set; }
}
