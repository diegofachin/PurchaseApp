﻿using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.AddPurchase;

public class TransactionDto
{
    public Guid Id { get; set; }

    public string NumberCard { get; set; }

    public string NameOnCreditCard { get; set; }

    public string Validate { get; set; }

    public string Cvc { get; set; }

    public decimal Amount { get; set; }

    public PaymentStatus PaymentStatus { get; set; }
}
