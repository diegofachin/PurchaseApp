using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.AddApp;

public class AddAppRequestDto : IRequest<AddAppResponseDto>
{
    public string Name { get; set; }

    public decimal Price { get; set; }
}
