using System;

namespace Api.Enum
{
    public enum ProcessStatusEnum
    {
        ConfirmingPayment = 0,
        Approved = 1,
        Cancelled = 2,
        InTransit = 3,
        Delivered = 4
    }
}
