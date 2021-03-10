using System;

namespace Api.Enum
{
    public enum ProcessStatusEnum
    {
        ConfirmingPayment = 0,
        PaymentApproved = 1,
        InTransit = 2,
        Delivered = 3,
        Cancelled = 5,

    }
}
