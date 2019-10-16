using Domain.CustomeAttributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Enums
{
    public enum JobTypeEnum
    {
        [JobIdPrefix("DO")]
        DISCOUNT_OFFER = 1
    }
}
